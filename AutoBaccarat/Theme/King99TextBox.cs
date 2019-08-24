using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AutoBaccarat
{
    [DefaultEvent("TextChanged")]
    public sealed class King99TextBox : Control
    {
        [field: CompilerGenerated]
        [field: AccessedThroughProperty("TxtBox")]
        public TextBox TxtBox
        {
            [CompilerGenerated]
            get;
            [CompilerGenerated]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set;
        }

        #region Properties

        [Category("Options")]
        public HorizontalAlignment TextAlign
        {
            get => _textAlign;
            set
            {
                _textAlign = value;
                if (TxtBox != null)
                {
                    TxtBox.TextAlign = value;
                }
            }
        }

        [Category("Options")]
        public int MaxLength
        {
            get => _maxLength;
            set
            {
                _maxLength = value;
                if (TxtBox != null)
                {
                    TxtBox.MaxLength = value;
                }
            }
        }

        [Category("Options")]
        public bool ReadOnly
        {
            get => _readOnly;
            set
            {
                _readOnly = value;
                if (TxtBox != null)
                {
                    TxtBox.ReadOnly = value;
                }
            }
        }

        [Category("Options")]
        public bool UseSystemPasswordChar
        {
            get => _useSystemPasswordChar;
            set
            {
                _useSystemPasswordChar = value;
                if (TxtBox != null)
                {
                    TxtBox.UseSystemPasswordChar = value;
                }
            }
        }

        [Category("Options")]
        public bool Multiline
        {
            get => _multiline;
            set
            {
                _multiline = value;
                checked
                {
                    if (TxtBox == null) return;
                    TxtBox.Multiline = value;
                    if (value)
                    {
                        TxtBox.Height = Height - 11;
                    }
                    else
                    {
                        Height = TxtBox.Height + 11;
                    }
                }
            }
        }

        [Category("Options")]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                if (TxtBox != null)
                {
                    TxtBox.Text = value;
                }
            }
        }

        [Category("Options")]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                checked
                {
                    if (TxtBox == null) return;
                    TxtBox.Font = value;
                    TxtBox.Location = new Point(3, 5);
                    TxtBox.Width = Width - 6;
                    if (!_multiline)
                    {
                        Height = TxtBox.Height + 11;
                    }
                }
            }
        }

        #endregion Properties

        #region Event

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            _baseColor = BackColor;
            Invalidate();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            TxtBox.KeyPress += TextBox_KeyPress;
            if (!Controls.Contains(TxtBox))
            {
                Controls.Add(TxtBox);
            }
        }

        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = TxtBox.Text;
        }

        protected override void OnResize(EventArgs e)
        {
            TxtBox.Location = new Point(5, 5);
            checked
            {
                TxtBox.Width = Width - 10;
                var multiline = _multiline;
                if (multiline)
                {
                    TxtBox.Height = Height - 11;
                }
                else
                {
                    Height = TxtBox.Height + 11;
                }

                base.OnResize(e);
            }
        }

        #endregion Event

        #region Key Press

        public override Color ForeColor
        {
            get => _textColor;
            set => _textColor = value;
        }

        public enum _Num
        {
            TextNum,
            NumberOnly,
            NumberDot,
            NumberComma
        }

        private _Num StyleType;

        public _Num Style
        {
            get => StyleType;
            set
            {
                StyleType = value;
                Invalidate();
            }
        }

        public void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (StyleType)
            {
                case _Num.TextNum:

                    e.Handled = false;

                    break;

                case _Num.NumberOnly:
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //&&       (e.KeyChar != '.'))
                    {
                        e.Handled = true;
                    }

                    break;

                case _Num.NumberDot:
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    {
                        e.Handled = true;
                    }
                    break;

                case _Num.NumberComma:
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                    {
                        e.Handled = true;
                    }

                    break;
            }
        }

        #endregion Key Press

        public King99TextBox()
        {
            _textAlign = HorizontalAlignment.Left;
            _maxLength = 32767;
            _textColor = Color.White;

            SetStyle(
                ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor |
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(202, 62, 71);
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TxtBox = new TextBox
            {
                Text = Text,
                BackColor = _baseColor,
                ForeColor = _textColor,
                MaxLength = _maxLength,
                Multiline = _multiline,
                ReadOnly = _readOnly,
                UseSystemPasswordChar = _useSystemPasswordChar,
                BorderStyle = BorderStyle.None
            };
            MinimumSize = new Size(0, 31);
            // Font = CustomFont.GetCustomFont(11);
            Font = new Font("Kanit", 11, FontStyle.Regular);
            TxtBox.Location = new Point(5, 5);
            checked
            {
                TxtBox.Width = Width - 10;
                TxtBox.Cursor = Cursors.IBeam;
                var multiline = _multiline;
                if (multiline)
                {
                    TxtBox.Height = Height - 11;
                }
                else
                {
                    Height = TxtBox.Height + 11;
                }

                TxtBox.TextChanged += OnBaseTextChanged;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var b = new Bitmap(Width, Height);
            var G = Graphics.FromImage(b);

            checked
            {
                _w = Width - 1;
                _h = Height - 1;
                var g = G;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(BackColor);
                TxtBox.BackColor = _baseColor;
                TxtBox.ForeColor = _textColor;
                g.FillRectangle(new SolidBrush(Color.FromArgb(255, 60, 75)), 0, 0, Width, Height);
                g.FillRectangle(new SolidBrush(_baseColor), 1, 1, _w - 1, _h - 1);
                base.OnPaint(e);
                G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(b, 0, 0);
                b.Dispose();
            }
        }

        private int _w;

        private int _h;

        private HorizontalAlignment _textAlign;

        private int _maxLength;

        private bool _readOnly;

        private bool _useSystemPasswordChar;

        private bool _multiline;

        private Color _baseColor;

        private Color _textColor;
    }
}