using System.Drawing;
using System.Windows.Forms;
using King99_Theme;

namespace King99
{
    public sealed class King99Checkbox : ThemeControl
    {
        public bool CheckedState
        {
            get => _checkedState;
            set
            {
                _checkedState = value;
                Invalidate();
            }
        }

        public King99Checkbox()
        {
            Click += delegate
            {
                ChangeCheck();
            };
            AutoSize = true;
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
            //Font = CustomFont.GetCustomFont(11);
            Font = new Font("Kanit",11, FontStyle.Regular);
            CheckedState = false;
            Cursor = Cursors.Hand;
        }

        public override void PaintHook()
        {

            var border = new Pen(Color.FromArgb(255, 60, 75));
            G.Clear(BackColor);
            if (CheckedState)
            {
                DrawGradient(Color.FromArgb(255, 60, 75), Color.FromArgb(255, 60, 75), 3, 3, Size.Height - 7, Size.Height - 7, 90f);
                DrawGradient(Color.FromArgb(202, 62, 71), Color.FromArgb(202, 62, 71), 4, 4, Size.Height - 9, Size.Height - 9, 90f);
            }
            else
            {
                DrawGradient(
                    BackColor,
                    BackColor,
                    0, 0, 
                    Size.Height-1,
                    Size.Height - 1,
                    90f);
            }
            G.DrawRectangle(border, 0, 0, Size.Height - 2, Size.Height - 2);
            G.DrawRectangle(border, 1, 1, Size.Height - 4, Size.Height - 4);
            DrawText(HorizontalAlignment.Left, Color.White, Size.Height +1, 0);
        }

        public void ChangeCheck()
        {
            var checkedState = CheckedState;
            CheckedState = !checkedState;
        }

        private bool _checkedState;
    }
}