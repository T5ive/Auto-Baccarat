using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AutoBaccarat
{
    [DefaultEvent("CheckedChanged")]
    public sealed class King99RadioButton : Control
    {


        #region Variables

        private bool _checked;
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        #endregion
        #region Properties

        public bool Checked
        {
            get => _checked;
            set
            {
                _checked = value;
                InvalidateControls();
                CheckedChanged?.Invoke(this);
                Invalidate();
            }
        }

        #endregion
        #region EventArgs

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!_checked)
                Checked = true;
            base.OnMouseDown(e);
            Focus();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            Invalidate();
        }

        #endregion

        public King99RadioButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | 
                     //ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
           // BackColor = Color.Transparent;
            ForeColor = Color.White;
            // Font = CustomFont.GetCustomFont(11);
            Font = new Font("Kanit", 11, FontStyle.Regular);
            // Width = 193;
            Cursor = Cursors.Hand;
            AutoSize = true;
        }

        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_checked)
                return;

            foreach (Control _Control in Parent.Controls)
            {
                if (!ReferenceEquals(_Control, this) && _Control is King99RadioButton)
                {
                    ((King99RadioButton)_Control).Checked = false;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var myDrawer = e.Graphics;

            //MyDrawer.Clear(Color.FromArgb(240, 240, 240));
            myDrawer.Clear(BackColor);
            myDrawer.SmoothingMode = SmoothingMode.AntiAlias;

            // Fill the body of the ellipse with a gradient
            var lgb = new LinearGradientBrush(new Rectangle(new Point(0, 0),
                new Size(Size.Height-1, Size.Height - 1)),
                BackColor,
                BackColor, 90);
            //Color.FromArgb(240, 240, 240),
            //Color.FromArgb(240, 240, 240), 90);

            myDrawer.FillEllipse(lgb, new Rectangle(new Point(0, 0), new Size(Size.Height - 1, Size.Height - 1)));

            var gp = new GraphicsPath();
            gp.AddEllipse(new Rectangle(0, 0, Size.Height - 1, Size.Height - 1));
            myDrawer.SetClip(gp);
            myDrawer.ResetClip();

            // Draw ellipse border
            myDrawer.DrawEllipse(new Pen(Color.FromArgb(255, 60, 75)), new Rectangle(new Point(0, 0), new Size(Size.Height - 1, Size.Height - 1)));

            // Draw an ellipse inside the body
            if (_checked)
            {
                var ellipseColor = new SolidBrush(Color.FromArgb(202, 62, 71));
                myDrawer.FillEllipse(ellipseColor, new Rectangle(new Point(2, 2), new Size(Size.Height-5, Size.Height-5)));
            }
            myDrawer.DrawString(Text, Font, new SolidBrush(ForeColor), Size.Height +1, Size.Height/2, new StringFormat { LineAlignment = StringAlignment.Center });
            e.Dispose();
        }
    }
}