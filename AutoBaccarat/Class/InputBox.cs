using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBaccarat.Class
{
    public sealed class InputBox : Form
    {
        private const int CsDropshadow = 0x00020000;
        private Label lblMessage;
        private TextBox txtInput;
        private string _txtInput;
        private bool txtPaintInvalidated;
        private string btnOK = @"OK";
        private string btnCancel = @"Cancel";
        private InputBox()
        {

            var pl = new Panel { Dock = DockStyle.Fill };

            var flp = new FlowLayoutPanel { Dock = DockStyle.Fill };
            flp.MouseDown += _MouseDown;
            flp.MouseMove += _MouseMove;
            flp.MouseUp += _MouseUp;



            lblMessage = new Label { Font = new Font("Kanit", 10), ForeColor = Color.White, AutoSize = true };
            lblMessage.MouseDown += _MouseDown;
            lblMessage.MouseMove += _MouseMove;
            lblMessage.MouseUp += _MouseUp;


            var txtPl = new Panel
            {
                BorderStyle = BorderStyle.None,
                Width = 360,
                Height = 28,
                Padding = new Padding(5),
                BackColor = Color.FromArgb(82, 82, 82),
                Margin = new Padding(0, 15, 0, 0)
            };
            txtPl.Paint += txtPl_Paint;

            txtInput = new TextBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                Font = new Font("Kanit", 9),
                ForeColor = Color.White

            };
            txtInput.KeyDown += txtInput_KeyDown;
            txtInput.KeyPress += txtInput_KeyPress;
            txtInput.BackColor = Color.FromArgb(82, 82, 82);
            txtInput.Multiline = true;
            txtPl.Controls.Add(txtInput);

            var flpButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 35
            };

            flpButtons.MouseDown += _MouseDown;
            flpButtons.MouseMove += _MouseMove;
            flpButtons.MouseUp += _MouseUp;

            var btnCancel = new Button
            {
                Text = this.btnCancel,
                ForeColor = Color.White,
                Font = new Font("Kanit", 8),
                Padding = new Padding(3),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(202, 62, 71),
                FlatAppearance =
                {
                    BorderSize = 0,
                    MouseDownBackColor = Color.FromArgb(202, 62, 71),
                    MouseOverBackColor = Color.FromArgb(255, 60, 75)
                },
                Height = 30
            };
            btnCancel.Click += btnCancel_Click;

            var btnOK = new Button
            {
                Text = this.btnOK,
                ForeColor = Color.White,
                Font = new Font("Kanit", 8),
                Padding = new Padding(3),
                BackColor = Color.FromArgb(202, 62, 71),
                FlatAppearance =
                {
                    BorderSize = 0,
                    MouseDownBackColor = Color.FromArgb(202, 62, 71),
                    MouseOverBackColor = Color.FromArgb(255, 60, 75)
                },
                FlatStyle = FlatStyle.Flat,
                Height = 30
            };
            btnOK.Click += btnOK_Click;

            flpButtons.Controls.Add(btnCancel);
            flpButtons.Controls.Add(btnOK);

            flp.Controls.Add(lblMessage);
            flp.SetFlowBreak(lblMessage, true);
            flp.Controls.Add(txtPl);
            flp.SetFlowBreak(txtPl, true);
            flp.Controls.Add(flpButtons);
            pl.Controls.Add(flp);

            Controls.Add(pl);
            Controls.Add(flpButtons);
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.FromArgb(82, 82, 82);
            StartPosition = FormStartPosition.CenterScreen;
            Padding = new Padding(20);
            Width = 400;
            Height = 200;

            InitializeComponent();
            MouseDown += _MouseDown;
            MouseMove += _MouseMove;
            MouseUp += _MouseUp;


        }

        void _MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            downPoint = new Point(e.X, e.Y);
        }

        void _MouseMove(object sender, MouseEventArgs e)
        {
            if (downPoint == Point.Empty)
            {
                return;
            }
            var location = new Point(
                Left + e.X - downPoint.X,
                Top + e.Y - downPoint.Y);
            Location = location;
        }

        void _MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            downPoint = Point.Empty;
        }

        public Point downPoint = Point.Empty;

        void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_numOnly)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //&&       (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
        }

        void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            var txt = (TextBox)sender;

            if (e.KeyCode == Keys.Enter)
            {
                _txtInput = txt.Text;
                Dispose();
            }
            else
            {
                if (txt.Text.Length > 60)
                {
                    txt.Parent.Height = 80;

                    if (!txtPaintInvalidated)
                    {
                        txt.Parent.Invalidate();
                        txtPaintInvalidated = true;
                    }
                }

                if (txt.Text.Length < 60)
                {
                    txt.Parent.Height = 28;

                    if (txtPaintInvalidated)
                    {
                        txt.Parent.Invalidate();
                        txtPaintInvalidated = false;
                    }
                }
            }
        }

        void txtPl_Paint(object sender, PaintEventArgs e)
        {
            var pl = (Panel)sender;
            base.OnPaint(e);

            var g = e.Graphics;
            var rect = new Rectangle(new Point(0, 0), new Size(pl.Width - 1, pl.Height - 1));
            var pen = new Pen(Color.FromArgb(255, 60, 75)) { Width = 3 };
            g.FillRectangle(new SolidBrush(Color.FromArgb(82, 82, 82)), rect);
            g.DrawRectangle(pen, rect);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            _txtInput = _oldValue;
            Dispose();
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            _txtInput = txtInput.Text;
            Dispose();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ClassStyle |= CsDropshadow;
                return cp;
            }
        }

        ///// <summary>
        ///// Example: string input = TFiveInputBox.Show("Please enter your name");
        ///// </summary>
        ///// <param name="message"> Title</param>
        ///// <returns></returns>
        //public static string Show(string message)
        //{
        //    using (var box = new King99InputBox { lblMessage = { Text = message } })
        //    {
        //        box.ShowDialog();

        //        return box._txtInput;
        //    }
        //}

        private static string _oldValue;
        private static bool _numOnly;
        public static string Show(string message, string oldValue, bool show)
        {
            _numOnly = show;
            _oldValue = oldValue;
            using (var box = new InputBox { lblMessage = { Text = message }, txtInput = { Text = oldValue } })
            {
                box.ShowDialog();

                return box._txtInput;
            }
        }
        //public static string Show(string message, int maxLength)
        //{
        //    using (var box = new King99InputBox { lblMessage = { Text = message }, txtInput = { MaxLength = maxLength } })
        //    {
        //        box.ShowDialog();

        //        return box._txtInput;
        //    }
        //}
        //public string Show(string message, string OK)
        //{
        //    btnOK = OK;
        //    using (var box = new King99InputBox { lblMessage = { Text = message } })
        //    {
        //        box.ShowDialog();

        //        return box._txtInput;
        //    }
        //}
        //public string Show(string message, string OK, string Cancel)
        //{
        //    btnOK = OK;
        //    btnCancel = Cancel;
        //    using (var box = new King99InputBox { lblMessage = { Text = message } })
        //    {
        //        box.ShowDialog();

        //        return box._txtInput;
        //    }
        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            var rect = new Rectangle(new Point(0, 0), new Size(Width - 1, Height - 1));
            var pen = new Pen(Color.FromArgb(255, 60, 75));

            g.DrawRectangle(pen, rect);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            //   ClientSize = new Size(284, 261);
            ControlBox = false;
            Name = "InputBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            TopMost = true;
            ResumeLayout(false);

        }

    }
}
