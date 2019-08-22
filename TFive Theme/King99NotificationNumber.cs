using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using King99_Theme;

namespace King99
{
    public sealed class King99NotificationNumber : Control
    {
        #region Variables

        private int _value;
        private int _maximum = 99;

        #endregion Variables

        #region Properties

        public int Value
        {
            get
            {
                if (_value == 0)
                {
                    return 0;
                }
                return _value;
            }
            set
            {
                if (value > _maximum)
                {
                    value = _maximum;
                }
                _value = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get => _maximum;
            set
            {
                if (value < _value)
                {
                    _value = value;
                }
                _maximum = value;
                Invalidate();
            }
        }

        #endregion Properties

        public King99NotificationNumber()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            Text = null;
            DoubleBuffered = true;
            //  Font = CustomFont.GetCustomFont(15);
            Font = new Font("Kanit", 15, FontStyle.Regular);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 27;
            Width = 27;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            var myString = _value.ToString();
            //_G.Clear(Color.FromArgb(240, 240, 240));
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var lgb = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(24, 26)), Color.FromArgb(255, 60, 75), Color.FromArgb(255, 60, 75), 90f);

            // Fills the body with LGB gradient
            g.FillEllipse(lgb, new Rectangle(new Point(0, 0), new Size(24, 24)));
            // Draw border
            g.DrawEllipse(new Pen(Color.FromArgb(202, 62, 71)), new Rectangle(new Point(0, 0), new Size(24, 24)));
            g.DrawString(myString,
               Font,
                new SolidBrush(Color.FromArgb(255, 255, 255)),
                new Rectangle(0, 0, Width - 2, Height),
                new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            e.Dispose();
        }
    }
}