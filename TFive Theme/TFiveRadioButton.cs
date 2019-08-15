using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TFive
{
    [DefaultEvent("CheckedChanged")]
    public sealed class TFiveRadioButton : Control
    {

        #region Enums

        public enum MouseState : byte
        {
            None = 0,
            Over = 1,
            Down = 2,
            Block = 3
        }

        #endregion
        #region Variables

        private bool _Checked;
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        #endregion
        #region Properties

        public bool Checked
        {
            get => _Checked;
            set
            {
                _Checked = value;
                InvalidateControls();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
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
            if (!_Checked)
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

        public TFiveRadioButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | 
                     //ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
           // BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(0, 100, 255);
            Font = new Font("Segoe UI", 11);
            // Width = 193;
            Cursor = Cursors.Hand;
            AutoSize = true;
        }

        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control _Control in Parent.Controls)
            {
                if (!ReferenceEquals(_Control, this) && _Control is TFiveRadioButton)
                {
                    ((TFiveRadioButton)_Control).Checked = false;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var MyDrawer = e.Graphics;

            //MyDrawer.Clear(Color.FromArgb(240, 240, 240));
            MyDrawer.Clear(Color.White);
            MyDrawer.SmoothingMode = SmoothingMode.AntiAlias;

            // Fill the body of the ellipse with a gradient
            var LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0),
                new Size(Size.Height-1, Size.Height - 1)),
                Color.White,
                Color.White, 90);
            //Color.FromArgb(240, 240, 240),
            //Color.FromArgb(240, 240, 240), 90);

            MyDrawer.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(Size.Height - 1, Size.Height - 1)));

            var GP = new GraphicsPath();
            GP.AddEllipse(new Rectangle(0, 0, Size.Height - 1, Size.Height - 1));
            MyDrawer.SetClip(GP);
            MyDrawer.ResetClip();

            // Draw ellipse border
            MyDrawer.DrawEllipse(new Pen(Color.FromArgb(0, 100, 255)), new Rectangle(new Point(0, 0), new Size(Size.Height - 1, Size.Height - 1)));

            // Draw an ellipse inside the body
            if (_Checked)
            {
                var EllipseColor = new SolidBrush(Color.FromArgb(0, 100, 255));
                MyDrawer.FillEllipse(EllipseColor, new Rectangle(new Point(2, 2), new Size(Size.Height-5, Size.Height-5)));
            }
            MyDrawer.DrawString(Text, Font, new SolidBrush(Color.FromArgb(0, 100, 255)), Size.Height +1, Size.Height/2, new StringFormat { LineAlignment = StringAlignment.Center });
            e.Dispose();
        }
    }
}