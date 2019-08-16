using System;
using System.Drawing;
using System.Windows.Forms;

namespace TFive
{
    public sealed class TFiveCheckbox : ThemeControl
    {
        public bool CheckedState
        {
            get => _CheckedState;
            set
            {
                _CheckedState = value;
                Invalidate();
            }
        }

        public TFiveCheckbox()
        {
            Click += delegate
            {
                changeCheck();
            };
            AutoSize = true;
           // Size = new Size(90, 16);
           // MinimumSize = new Size(16, 16);
           // MaximumSize = new Size(600, 16);
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
            Font = new Font("Segoe UI", 11);
            CheckedState = false;
            Cursor = Cursors.Hand;
        }

        public override void PaintHook()
        {

            var border = new Pen(Color.FromArgb(255, 60, 75));
            //G.Clear(Color.FromArgb(240, 240, 240));
            G.Clear(BackColor);
            if (CheckedState)
            {
                DrawGradient(Color.FromArgb(255, 60, 75), Color.FromArgb(255, 60, 75), 3, 3, Size.Height - 7, Size.Height - 7, 90f);
                DrawGradient(Color.FromArgb(202, 62, 71), Color.FromArgb(202, 62, 71), 4, 4, Size.Height - 9, Size.Height - 9, 90f);
            }
            else
            {
                DrawGradient(
                    //Color.FromArgb(240, 240, 240),
                    //Color.FromArgb(240, 240, 240),
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

        public void changeCheck()
        {
            var checkedState = CheckedState;
            CheckedState = !checkedState;
        }

        private bool _CheckedState;
    }
}