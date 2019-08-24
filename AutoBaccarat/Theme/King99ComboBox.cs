using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AutoBaccarat
{
    public sealed class King99ComboBox : ComboBox
    {

        #region Variables

        private int _startIndex;
        private Color _hoverSelectionColor = Color.FromArgb(202, 62, 71);
        private Color _bgColor = Color.FromArgb(82, 82, 82);
        #endregion
        #region Custom Properties
        public int StartIndex
        {
            get => _startIndex;
            set
            {
                _startIndex = value;
                try
                {
                    SelectedIndex = value;
                }
                catch
                {
                }
                Invalidate();
            }
        }
        public Color HoverSelectionColor
        {
            get => _hoverSelectionColor;
            set
            {
                _hoverSelectionColor = value;
                Invalidate();
            }
        }
        public Color BgColor
        {
            get => _bgColor;
            set
            {
                _bgColor = value;
                Invalidate();
            }
        }
        int _value = 5;
        public int Curv
        {
            get
            {
                var value = _value;
                return value != 0 ? _value : 0;
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
        #endregion
        #region EventArgs
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.Graphics.FillRectangle(
                (e.State & DrawItemState.Selected) == DrawItemState.Selected
                    ? new SolidBrush(_hoverSelectionColor)
                    : new SolidBrush(_bgColor), e.Bounds);

            if (e.Index != -1)
            {
                e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, Brushes.White, e.Bounds);
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            SuspendLayout();
            Update();
            ResumeLayout();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        #endregion

        public King99ComboBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            Cursor = Cursors.Hand; 
            //BackColor = Color.FromArgb(240, 240, 240);
            ForeColor = Color.White;
            Size = new Size(135, 31);
            ItemHeight = 20;
            DropDownHeight = 100;
            // Font = CustomFont.GetCustomFont(11);
            Font = new Font("Kanit", 11, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create a curvy border
            var gp = RoundRectangle.RoundRect(0, 0, Width - 1, Height - 1, _value);
            // Fills the body of the rectangle with a gradient
            var lgb = new LinearGradientBrush(
                ClientRectangle,
                BackColor,
                BackColor,
                90f);

            e.Graphics.SetClip(gp);
            e.Graphics.FillRectangle(lgb, ClientRectangle);
            e.Graphics.ResetClip();

            // Draw rectangle border
            e.Graphics.DrawPath(new Pen(Color.FromArgb(255, 60, 75)), gp);

            // Draw string
            //e.Graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(202, 62, 71)), new Rectangle(3, 0, Width - 20, Height), new StringFormat
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(10, 0, Width - 20, Height), new StringFormat

            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            });

            // Draw the dropdown arrow
            e.Graphics.DrawLine(new Pen(Color.FromArgb(202, 62, 71), 2), new Point(Width - 18, 10), new Point(Width - 14, 14));
            e.Graphics.DrawLine(new Pen(Color.FromArgb(202, 62, 71), 2), new Point(Width - 14, 14), new Point(Width - 10, 10));
            e.Graphics.DrawLine(new Pen(Color.FromArgb(202, 62, 71)), new Point(Width - 14, 15), new Point(Width - 14, 14));

            gp.Dispose();
            lgb.Dispose();
        }
    }
}