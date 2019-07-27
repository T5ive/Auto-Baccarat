using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AutoBaccarat
{
    public partial class FrmDisplay : Form
    {
        public string Formula, Betting, Chip, StopRound, StopWin, StopLose, StopLess, StopMore, LayoutList, Mode;
        public bool Submit;
        public FrmDisplay()
        {
            InitializeComponent();
        }

        private void BtOK_Click(object sender, EventArgs e)
        {
            Submit = true;
            Close();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            Submit = false;
            Close();
        }
        private void FrmDisplay_Load(object sender, EventArgs e)
        {
            lbValue.Text = $@"Layout: {LayoutList}" + Environment.NewLine +
                           $@"Mode: {Mode}" + Environment.NewLine +
                           $@"Formula: {Formula}" + Environment.NewLine +
                           $@"Betting System: {Betting}" + Environment.NewLine +
                           $@"Bet Price {Chip}" + Environment.NewLine +
                           $@"Stop at Round {StopRound}" + Environment.NewLine +
                           $@"Stop If Wining at {StopWin} Rounds" + Environment.NewLine +
                           $@"Stop If Lossing at {StopLose} Rounds" + Environment.NewLine +
                           $@"Stop If Less Money {StopLess}" + Environment.NewLine +
                           $@"Stop If More Money {StopMore}";
        }
    }
}
