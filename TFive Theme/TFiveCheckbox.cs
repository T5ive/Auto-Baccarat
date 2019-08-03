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
        }

        public override void PaintHook()
        {

            var border = new Pen(Color.DodgerBlue);
            G.Clear(Color.FromArgb(240, 240, 240));
            if (CheckedState)
            {
                DrawGradient(Color.FromArgb(0, 100, 255), Color.FromArgb(0, 100, 255), 3, 3, Size.Height - 7, Size.Height - 7, 90f);
                DrawGradient(Color.DodgerBlue, Color.DodgerBlue, 4, 4, Size.Height - 9, Size.Height - 9, 90f);
            }
            else
            {
                DrawGradient(Color.FromArgb(240, 240, 240), Color.FromArgb(240, 240, 240), 0, 0, Size.Height-1, Size.Height - 1, 90f);
            }
            G.DrawRectangle(border, 0, 0, Size.Height - 2, Size.Height - 2);
            G.DrawRectangle(border, 1, 1, Size.Height - 4, Size.Height - 4);
            DrawText(HorizontalAlignment.Left, Color.FromArgb(0, 100, 255), Size.Height +1, 0);
        }

        public void changeCheck()
        {
            var checkedState = CheckedState;
            CheckedState = !checkedState;
        }

        private bool _CheckedState;
    }
}