using System.Windows.Forms;

namespace AutoBaccarat
{
    public partial class FrmMagnify : Form
    {
        public FrmMagnify()
        {
            InitializeComponent();
            magnifyingGlass1.UpdateTimer.Start();
        }

    }
}
