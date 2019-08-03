using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveGroupBox : ContainerControl
    {
        private Color _BGColor = Color.FromArgb(240, 240, 240);
        public Color BGColor
        {
            get => _BGColor;
            set
            {
                _BGColor = value;
                Invalidate();
            }
        }
        int _Value = 1;
        int _Value2 = 1;

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        public int Curv1
        {
            get
            {
                if (_Value == 0)
                {
                    _Value = 1;
                }
                var value = _Value;
                var Value = value != 0 ? _Value : 0;
                return Value;
            }
            set
            {
                _Value = value;
                Invalidate();
            }
        }
        public int Curv2
        {
            get
            {
                if (_Value2 == 0)
                {
                    _Value2 = 1;
                }
                var value = _Value2;
                var Value = value != 0 ? _Value2 : 0;
                return Value;
            }
            set
            {
                _Value2 = value;
                Invalidate();
            }
        }
        public TFiveGroupBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Size = new Size(212, 104);
            MinimumSize = new Size(136, 50);
            Padding = new Padding(5, 28, 5, 5);
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
            G.FillPath(new SolidBrush(_BGColor), RoundRectangle.RoundRect(new Rectangle(1, 12, Width - 3, box.Height - 1), _Value));
            // Draw the border of the GroupBox
            G.DrawPath(new Pen(Color.DodgerBlue), RoundRectangle.RoundRect(new Rectangle(1, 12, Width - 3, Height - 13), _Value));

            // Draw the background of the title box
            G.FillPath(new SolidBrush(_BGColor), RoundRectangle.RoundRect(titleBox, 1));
            // Draw the border of the title box
            G.DrawPath(new Pen(Color.DodgerBlue), RoundRectangle.RoundRect(titleBox, _Value2));
            // Draw the specified string from 'Text' property inside the title box
            G.DrawString(Text, new Font("Segoe UI", 11, FontStyle.Regular), new SolidBrush(Color.FromArgb(0, 100, 255)), titleBox, new StringFormat
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