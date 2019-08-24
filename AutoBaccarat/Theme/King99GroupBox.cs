using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AutoBaccarat
{
    public sealed class King99GroupBox : ContainerControl
    {
        private Color _bgColor = Color.White;
        public Color BgColor
        {
            get => _bgColor;
            set
            {
                _bgColor = value;
                Invalidate();
            }
        }

        private int _value = 1;
        private int _value2 = 1;

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        public int Curv1
        {
            get
            {
                if (_value == 0)
                {
                    _value = 1;
                }
                var value = _value;
                var Value = value != 0 ? _value : 0;
                return Value;
            }
            set
            {
                if (value == 0)
                {
                    value = 1;
                }
                _value = value;
                Invalidate();
            }
        }
        public int Curv2
        {
            get
            {
                if (_value2 == 0)
                {
                    _value2 = 1;
                }
                var value = _value2;
                var Value = value != 0 ? _value2 : 0;
                return Value;
            }
            set
            {
                if (value == 0)
                {
                    value = 1;
                }
                _value2 = value;
                Invalidate();
            }
        }
        public King99GroupBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Size = new Size(212, 104);
            MinimumSize = new Size(136, 50);
            Padding = new Padding(5, 28, 5, 5);
            //  Font = CustomFont.GetCustomFont(11);
            Font = new Font("Kanit", 11, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
          
            base.OnPaint(e);
            var B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);
            var titleBox = new Rectangle(51, 3, Width - 103, 19);
            var box = new Rectangle(0, 0, Width - 1, Height - 10);

            G.Clear(Color.Transparent);
            G.SmoothingMode = SmoothingMode.HighQuality;

            // Draw the body of the GroupBox
            G.FillPath(new SolidBrush(_bgColor), RoundRectangle.RoundRect(new Rectangle(1, 12, Width - 3, box.Height - 1), _value));
            // Draw the border of the GroupBox
            G.DrawPath(new Pen(Color.FromArgb(202, 62, 71)), RoundRectangle.RoundRect(new Rectangle(1, 12, Width - 3, Height - 13), _value));

            // Draw the background of the title box
            G.FillPath(new SolidBrush(_bgColor), RoundRectangle.RoundRect(titleBox, 1));
            // Draw the border of the title box
            G.DrawPath(new Pen(Color.FromArgb(202, 62, 71)), RoundRectangle.RoundRect(titleBox, _value2));
            // Draw the specified string from 'Text' property inside the title box
            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(255,255,255)), titleBox, new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
}