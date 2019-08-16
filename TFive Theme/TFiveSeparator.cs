using System.Drawing;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveSeparator : Control
    {

        public TFiveSeparator()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            Size = new Size(120, 10);
            BackColor = Color.FromArgb(240, 240, 240);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(255, 60, 75)), 0, 5, Width, 5);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(202, 62, 71)), 0, 6, Width, 6);
        }
    }
}