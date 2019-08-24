using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AutoBaccarat.Properties;


namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    public partial class FrmColorInfo : Form
    {
        public int Mode = 0;
        public FrmColorInfo()
        {
            InitializeComponent();
            var cv = new CursorConverter();
            _curTarget = (Cursor)cv.ConvertFrom(Resources.curTarget);
        }

        #region FormLoad/Save

        private void GetColor_Load(object sender, EventArgs e)
        {
            if (Settings.Default.LocationColorInfo == new Point(0, 0))
            {
                CenterToScreen();
            }
            else
            {
                Location = Settings.Default.LocationColorInfo;
            }
            _bitmapFind = Resources.bmpFind;
            _bitmapFind2 = Resources.bmpFinda;
            _newCursor = _curTarget;

            _tKing99GroupBox1.Text = Mode == 0 ? stringLoader.NormalMode : stringLoader.BackgroundMode;
        }
        private void FrmColorInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.LocationColorInfo = Location;
            Settings.Default.Save();
        }

        #endregion

        #region Cusor

        #region Cusor

        private readonly Cursor _curTarget;
        private Bitmap _bitmapFind;
        private Bitmap _bitmapFind2;
        private Cursor _newCursor;
        #endregion

        #region Var

        private const uint GaRoot = 2;
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }
        #endregion

        #region Dll Import

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(int xPoint, int yPoint);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern IntPtr GetAncestor(IntPtr hWnd, uint gaFlags);

        [DllImport("user32.dll")]
        private static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        #endregion

        #endregion
   
        #region Control Mouse
        [DllImport("user32.dll")] public static extern short GetAsyncKeyState(Keys vKey);

        private void tm_mouse_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(Keys.Up) != 0)
            {
                MouseMove(-1, 0);
            }
            if (GetAsyncKeyState(Keys.Down) != 0)
            {
                MouseMove(1, 0);
            }
            if (GetAsyncKeyState(Keys.Left) != 0)
            {
                MouseMove(0, -1);
            }
            if (GetAsyncKeyState(Keys.Right) != 0)
            {
                MouseMove(0, 1);
            }
        }

        private new void MouseMove(int y, int x)
        {
            Cursor.Position = new Point(Cursor.Position.X + x, Cursor.Position.Y + y);
        }

        #endregion

        #region Windows Info
        
        readonly FrmMagnify _frmMagnify = new FrmMagnify();
        readonly GetAppName _getApp = new GetAppName();

        #region Get Posision Color
        private void picTarget_MouseDown(object sender, MouseEventArgs e)
        {
            picTarget.Image = _bitmapFind2;
            picTarget.Cursor = _newCursor;
            _frmMagnify.Show();
            timer1.Start();
            tm_mouse.Start();
        }

        private void picTarget_MouseUp(object sender, MouseEventArgs e)
        {
            picTarget.Cursor = Cursors.Default;
            picTarget.Image = _bitmapFind;
            _frmMagnify.Hide();
            timer1.Stop();
            tm_mouse.Stop();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetPositionColor();
        }

        private Color _colorRGB;
        private void GetPositionColor()
        {
            try
            {
                if (Mode == 0)
                {
                    var bitmap = new Bitmap(1, 1);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(Cursor.Position, new Point(0, 0), new Size(1, 1));
                    }
                    var pixel = bitmap.GetPixel(0, 0);
                    _colorRGB = pixel;
                    var hexPixel = GetColor.HexConverter(pixel);
                    txt_color.Text = hexPixel; //bitmap.GetPixel(0, 0).ToString();

                    txt_posiX.Text = Cursor.Position.X.ToString();
                    txt_posiY.Text = Cursor.Position.Y.ToString();
                    panel_color.BackColor = pixel;
                }
                else if (Mode == 1)
                {
                    var pt = Cursor.Position;
                    var wnd = WindowFromPoint(pt.X, pt.Y);
                    var mainWnd = GetAncestor(wnd, GaRoot);
                    POINT PT;

                    PT.X = pt.X;
                    PT.Y = pt.Y;
                    ScreenToClient(mainWnd, ref PT);
                    txt_title.Text = Win32.GetWindowText(mainWnd);
                    GetAppName.App = txt_title.Text;
                    txt_class.Text = Win32.GetClassName(mainWnd);
                    GetAppName.Class = txt_class.Text;


                    _getApp.AppName();
                    var intPtr = GetAppName.appName;
                    txt_posiX.Text = PT.X.ToString();
                    txt_posiY.Text = PT.Y.ToString();
                    txt_color.Text = GetColor.GetColorString(int.Parse(txt_posiX.Text), int.Parse(txt_posiY.Text));
                    lb_status.Text = @"Status: " + GetColor.GetColorFast(intPtr, PT.X, PT.Y, GetColor.StringColor(txt_color.Text), 4);

                    panel_color.BackColor = _frmMagnify.magnifyingGlass1.PixelColor;
                }
               
                LocationMagnify();
            }
            catch
            {
                // ignored
            }
        }
       
        #endregion      
        
        private void LocationMagnify()
        {

            var pt = Cursor.Position;
            pt.X = Cursor.Position.X;
            pt.Y = Cursor.Position.Y;
            var width = Screen.PrimaryScreen.Bounds.Width;
            var height = Screen.PrimaryScreen.Bounds.Height;
            var locationX = 30;
            var locationY = 30;
            if (pt.X > width - 167)
            {
                locationX -= 30 + 167;
            }
            if (pt.Y > height - 167)
            {
                locationY -= 30 + 167;
            }

            _frmMagnify.Location = new Point(pt.X + locationX, pt.Y + locationY);
        }

        #endregion

        #region Button
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Mode == 0)
            {
                if (string.IsNullOrWhiteSpace(txt_posiY.Text) || string.IsNullOrWhiteSpace(txt_color.Text))
                {
                    MessageBox.Show(@"Please Input Position X, Y and Color", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Values.RgbColor = _colorRGB;
            }

            if (Mode == 1)
            {
                if (string.IsNullOrWhiteSpace(txt_title.Text) || string.IsNullOrWhiteSpace(txt_posiX.Text) ||
                    string.IsNullOrWhiteSpace(txt_posiY.Text) || string.IsNullOrWhiteSpace(txt_color.Text))
                {
                    MessageBox.Show(@"Please Input Position X, Y and Color", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            Values.CheckX = int.Parse(txt_posiX.Text);
            Values.CheckY = int.Parse(txt_posiY.Text);
            Values.Color = txt_color.Text;
            Values.TitleName = txt_title.Text + " % " + txt_class.Text;
            Values.CloseFrom = true;
            Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Values.CloseFrom = false;
            Close();
        }

        #endregion


    }
}
