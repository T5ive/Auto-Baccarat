using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBaccarat
{
    public partial class FrmMainSettings : UserControl
    {
        public FrmMainSettings()
        {
            InitializeComponent();
        }

        private void BtnBetSystem_Click(object sender, EventArgs e)
        {
            var betSys = new FrmBetSystem();
            betSys.ShowDialog();
        }

        private void BtnFormula_Click(object sender, EventArgs e)
        {
            var formula = new FrmFormula();
            formula.ShowDialog();
        }

        private void BtnLayout_Click(object sender, EventArgs e)
        {
            var layout = new FrmLayout();
            layout.ShowDialog();
        }

        private void BtnLayout_Click_1(object sender, EventArgs e)
        {

        }
    }
}
