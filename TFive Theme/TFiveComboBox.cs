using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveComboBox : ComboBox
    {

        #region Variables

        private int _StartIndex;
        private Color _HoverSelectionColor = Color.FromArgb(202, 62, 71);
        private Color _BGColor = Color.FromArgb(82, 82, 82);
        #endregion
        #region Custom Properties
        public int StartIndex
        {
            get => _StartIndex;
            set
            {
                _StartIndex = value;
                try
                {
                    base.SelectedIndex = value;
                }
                catch
                {
                }
                Invalidate();
            }
        }
        public Color HoverSelectionColor
        {
            get => _HoverSelectionColor;
            set
            {
                _HoverSelectionColor = value;
                Invalidate();
            }
        }
        public Color BGColor
        {
            get => _BGColor;
            set
            {
                _BGColor = value;
                Invalidate();
            }
        }
        int _Value = 5;
        public int Curv
        {
            get
            {
                var value = _Value;
                int Value;
                if (value != 0)
                {
                    Value = _Value;
                }
                else
                {
                    Value = 0;
                }
                return Value;
            }
            set
            {
                var num = value;
                _Value = value;
                Invalidate();
            }
        }
        #endregion
        #region EventArgs
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(_HoverSelectionColor), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(_BGColor), e.Bounds);
            }

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

        public TFiveComboBox()
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
            Font = new Font("Segoe UI", 11, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create a curvy border
            var GP = RoundRectangle.RoundRect(0, 0, Width - 1, Height - 1, _Value);
            // Fills the body of the rectangle with a gradient
            var LGB = new LinearGradientBrush(
                ClientRectangle,
                BackColor,
                BackColor,
                //Color.FromArgb(240, 240, 240),
                //Color.FromArgb(240, 240, 240),
                90f);

            e.Graphics.SetClip(GP);
            e.Graphics.FillRectangle(LGB, ClientRectangle);
            e.Graphics.ResetClip();

            // Draw rectangle border
            e.Graphics.DrawPath(new Pen(Color.FromArgb(255, 60, 75)), GP);
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

            GP.Dispose();
            LGB.Dispose();
        }
    }
}