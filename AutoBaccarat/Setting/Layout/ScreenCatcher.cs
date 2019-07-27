using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    [Obfuscation(Feature = "PEVerify", Exclude = false)]
    [Obfuscation(Feature = "debug [secure] with password 12345A", Exclude = false)]
    [Obfuscation(Feature = "encrypt resources", Exclude = false)]
    public partial class ScreenCatcher : Form
    {
        public ScreenCatcher()
        {
            InitializeComponent();
        }

        private void ScreenCatcher_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        public void GetBitMap()
        {
            checked
            {
                if (State) return;
                try
                {
                    State = true;
                    var rectangle = RectangleToScreen(ClientRectangle);
                    var clientRectangle = ClientRectangle;
                    RecLeft = rectangle.Left + 3;
                    RecTop = rectangle.Top + 3;
                    RecWidth = clientRectangle.Width - 6;
                    RecHeight = clientRectangle.Height - 6;
                    PicShow = BuildBitmap(RecLeft, RecTop, RecWidth, RecHeight);
                }
                catch
                {
                }
                finally
                {
                    State = false;
                }
            }
        }

        public void GetPosition(int posX, int posY, int catcherX, int catcherY)
        {
            var rectangle = RectangleToScreen(ClientRectangle);
            var clientRectangle = ClientRectangle;
            checked
            {
                Left = posX - 3 - rectangle.Left + Left;
                Top = posY - 3 - rectangle.Top + Top;
                Height = Height - clientRectangle.Height + catcherY + 6;
                Width = Width - clientRectangle.Width + catcherX + 6;
            }
        }

        public static Bitmap BuildBitmap(int recLeft, int recTop, int recWidth, int recHeight)
        {
            var bitmap = new Bitmap(recWidth, recHeight, PixelFormat.Format32bppArgb);
            try
            {
                var graphics = Graphics.FromImage(bitmap);
                graphics.CopyFromScreen(recLeft, recTop, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            }
            catch
            {
            }

            return bitmap;
        }

        public bool State;

        public Bitmap PicShow;

        public int RecLeft;

        public int RecTop;

        public int RecWidth;

        public int RecHeight;
    }
}