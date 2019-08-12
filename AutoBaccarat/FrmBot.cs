using System;
using System.Drawing;
using System.Windows.Forms;
using AutoBaccarat.Properties;
using AutoBaccarat.Setting;
using Bunifu.Framework.UI;

namespace AutoBaccarat
{
    public partial class FrmBot : Form
    {
        public FrmBot()
        {
            InitializeComponent();
        }


        #region Load/Close

        private void FrmBot_Load(object sender, EventArgs e)
        {
            LoadLocation();
            FormulaValues.LoadFormula();
            BetSystemValues.LoadBetSystem();
            LayoutValues.LoadLayout();

            MenuControl(btnMain);
        }
        private void LoadLocation()
        {
            if (Settings.Default.Location == new Point(0, 0))
            {
                CenterToScreen();
            }
            else
            {
                Location = Settings.Default.Location;
            }
            Size = new Size((Point) Settings.Default.SizeMain);
        }

       
        private void FrmBot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Location = Location;
            Settings.Default.SizeMain = Size;
            Settings.Default.Save();
        }

        #endregion

        #region MenuControl

        private void BtnMain_Click(object sender, EventArgs e)
        {
            MenuControl(btnMain);
        }
        private void BtnLogs_Click(object sender, EventArgs e)
        {
            MenuControl(btnLogs);
        }
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            MenuControl(btnSettings);
        }

        private void MenuControl(BunifuFlatButton button)
        {
            if (button == btnLogs)
            {

                return;
            }

            btnMain.Normalcolor = Color.CornflowerBlue;
            btnLogs.Normalcolor = Color.CornflowerBlue;
            btnSettings.Normalcolor = Color.CornflowerBlue;
            button.Normalcolor = button.Activecolor;


            if (button == btnMain)
            {
                panelSettings.Hide();
                TransMain.ShowSync(panelMain);
            }

            if (button == btnSettings)
            {
                panelMain.Hide();
                TransSettings.ShowSync(panelSettings);
            }
        }

        #endregion

        private void ButtonAddValue2BigRoad(object sender, EventArgs e)
        {

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnBetSystem_Click(object sender, EventArgs e)
        {
            Hide();
            var betSys = new FrmBetSystem();
            betSys.ShowDialog();
            betSys.Dispose();
            Show();
        }

        private void BtnFormula_Click(object sender, EventArgs e)
        {
            Hide();
            var formula = new FrmFormula();
            formula.ShowDialog();
            formula.Dispose();
            Show();
        }

        private void BtnLayout_Click(object sender, EventArgs e)
        {
            Hide();
            var layout = new FrmLayout();
            layout.ShowDialog();
            layout.Dispose();
            Show();
        }

        private void BtnLine_Click(object sender, EventArgs e)
        {

        }

        
    }
}
