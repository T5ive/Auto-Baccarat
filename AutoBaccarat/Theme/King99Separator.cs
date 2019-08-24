using System.Drawing;
using System.Windows.Forms;

namespace AutoBaccarat
{
    public sealed class King99Separator : Control
    {

        public King99Separator()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            Size = new Size(120, 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(255, 60, 75)), 0, 5, Width, 5);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(202, 62, 71)), 0, 6, Width, 6);
        }
    }
}