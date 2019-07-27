using System;
using System.Reflection;
using System.Windows.Forms;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    [Obfuscation(Feature = "PEVerify", Exclude = false)]
    [Obfuscation(Feature = "debug [secure] with password 12345A", Exclude = false)]
    [Obfuscation(Feature = "encrypt resources", Exclude = false)]
    public partial class LayerForm : Form
    {
        public LayerForm()
        {
            InitializeComponent();
        }

        private void LayerForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            checked
            {
                lblDesc.Left = (int)Math.Round(Width / 2.0 - lblDesc.Width / 2.0);
                lblDesc.Top = (int)Math.Round(Height / 2.0 - lblDesc.Height / 2.0);
            }
        }

        private void LayerForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Values.CheckX = Cursor.Position.X;
                Values.CheckY = Cursor.Position.Y;
                Values.Color = GetColor.GetColorString(Cursor.Position.X, Cursor.Position.Y);
                Values.CloseFrom = true;
                Close();
            }
            else
            {
                Values.CloseFrom = false;
                Close();
            }
        }
    }
}