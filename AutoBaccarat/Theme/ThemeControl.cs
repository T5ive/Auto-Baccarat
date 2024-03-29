﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AutoBaccarat
{
    public abstract class ThemeControl : Control
    {
        protected ThemeControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            B = new Bitmap(1, 1);
            G = Graphics.FromImage(B);
        }
        

        //public void AllowTransparent()
        //{
        //    SetStyle(ControlStyles.Opaque, false);
        //    SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        //}

        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            ChangeMouseState(State.MouseNone);
            base.OnMouseLeave(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            ChangeMouseState(State.MouseOver);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            ChangeMouseState(State.MouseOver);
            base.OnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            var flag = e.Button == MouseButtons.Left;
            if (flag)
            {
                ChangeMouseState(State.MouseDown);
            }
            base.OnMouseDown(e);
        }

        private void ChangeMouseState(State e)
        {
            MouseState = e;
            Invalidate();
        }

        public abstract void PaintHook();

        protected sealed override void OnPaint(PaintEventArgs e)
        {
            var flag = Width == 0 || Height == 0;
            if (!flag)
            {
                PaintHook();
                e.Graphics.DrawImage(B, 0, 0);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (Width != 0 && Height != 0)
            {
                B = new Bitmap(Width, Height);
                G = Graphics.FromImage(B);
                Invalidate();
            }
            base.OnSizeChanged(e);
        }

        public bool NoRounding
        {
            get => _noRounding;
            set
            {
                _noRounding = value;
                Invalidate();
            }
        }

        public Image Image
        {
            get => _image;
            set
            {
                _image = value;
                Invalidate();
            }
        }

        //public int ImageWidth
        //{
        //    get
        //    {
        //        var flag = _Image == null;
        //        int ImageWidth;
        //        if (flag)
        //        {
        //            ImageWidth = 0;
        //        }
        //        else
        //        {
        //            ImageWidth = _Image.Width;
        //        }
        //        return ImageWidth;
        //    }
        //}

        //public int ImageTop
        //{
        //    get
        //    {
        //        var flag = _Image == null;
        //        int ImageTop;
        //        if (flag)
        //        {
        //            ImageTop = 0;
        //        }
        //        else
        //        {
        //            ImageTop = checked(Height / 2 - _Image.Height / 2);
        //        }
        //        return ImageTop;
        //    }
        //}

        //protected void DrawCorners(Color c, Rectangle rect)
        //{
        //    var noRounding = _NoRounding;
        //    checked
        //    {
        //        if (!noRounding)
        //        {
        //            B.SetPixel(rect.X, rect.Y, c);
        //            B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c);
        //            B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c);
        //            B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c);
        //        }
        //    }
        //}

        //protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
        //{
        //    checked
        //    {
        //        G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
        //        G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
        //    }
        //}

        //protected void DrawText(HorizontalAlignment a, Color c, int x)
        //{
        //    DrawText(a, c, x, 0);
        //}

        protected void DrawText(HorizontalAlignment a, Color c, int x, int y)
        {
            var flag = string.IsNullOrEmpty(Text);
            checked
            {
                if (!flag)
                {
                    _size = G.MeasureString(Text, Font).ToSize();
                    _brush = new SolidBrush(c);
                    switch (a)
                    {
                        case HorizontalAlignment.Left:
                            G.DrawString(Text, Font, _brush, x, Height / 2 - _size.Height / 2 + y);
                            break;
                        case HorizontalAlignment.Right:
                            G.DrawString(Text, Font, _brush, Width - _size.Width - x, Height / 2 - _size.Height / 2 + y);
                            break;
                        case HorizontalAlignment.Center:
                            G.DrawString(Text, Font, _brush, Width / 2 - _size.Width / 2 + x, Height / 2 - _size.Height / 2 + y);
                            break;
                    }
                }
            }
        }

        //protected void DrawIcon(HorizontalAlignment a, int x)
        //{
        //    DrawIcon(a, x, 0);
        //}

        //protected void DrawIcon(HorizontalAlignment a, int x, int y)
        //{
        //    var flag = _Image == null;
        //    checked
        //    {
        //        if (!flag)
        //        {
        //            switch (a)
        //            {
        //                case HorizontalAlignment.Left:
        //                    G.DrawImage(_Image, x, Height / 2 - _Image.Height / 2 + y);
        //                    break;
        //                case HorizontalAlignment.Right:
        //                    G.DrawImage(_Image, Width - _Image.Width - x, Height / 2 - _Image.Height / 2 + y);
        //                    break;
        //                case HorizontalAlignment.Center:
        //                    G.DrawImage(_Image, Width / 2 - _Image.Width / 2, Height / 2 - _Image.Height / 2);
        //                    break;
        //            }
        //        }
        //    }
        //}

        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            _rectangle = new Rectangle(x, y, width, height);
            _gradient = new LinearGradientBrush(_rectangle, c1, c2, angle);
            G.FillRectangle(_gradient, _rectangle);
        }

        protected Graphics G;

        protected Bitmap B;

        protected State MouseState;

        private bool _noRounding;

        private Image _image;

        private Size _size;

        private Rectangle _rectangle;

        private LinearGradientBrush _gradient;

        private SolidBrush _brush;

        protected enum State : byte
        {
            MouseNone,
            MouseOver,
            MouseDown
        }
    }
}