using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using AutoBaccarat.Properties;
using AutoBaccarat.Setting;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    public partial class FrmBetSystem : Form
    {
        public FrmBetSystem()
        {
            InitializeComponent();
        }


        #region Load/Save

        private void FrmBetSystem_Load(object sender, EventArgs e)
        {
            LoadLocation();
            BetSystemLoad();
            BetLoad();
            ChipSelected();
        }
        private void LoadLocation()
        {
            if (Settings.Default.LocationBetSystem == new Point(0, 0))
            {
                CenterToScreen();
            }
            else
            {
                Location = Settings.Default.LocationBetSystem;
            }
        }
        private void BetSystemLoad()
        {
            BetSystemValues.BettingSelected = (BetSystemValues.BettingMode)Settings.Default.BettingSelected;
            switch (BetSystemValues.BettingSelected)
            {
                case BetSystemValues.BettingMode.PP:
                    radPP.Checked = true;
                    break;

                case BetSystemValues.BettingMode.NP:
                    radNP.Checked = true;
                    break;

                case BetSystemValues.BettingMode.PPNP:
                    radPPNP.Checked = true;
                    break;

                case BetSystemValues.BettingMode.Fibonacci:
                    radFib.Checked = true;
                    break;

                case BetSystemValues.BettingMode.AI:
                    radAI.Checked = true;
                    break;

                case BetSystemValues.BettingMode.OneShot:
                    radONE.Checked = true;
                    break;

                case BetSystemValues.BettingMode.X2:
                    radX2.Checked = true;
                    break;
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            BetSave();
            SaveSettings();
            Close();
        }
        private void SaveSettings()
        {
            Settings.Default.BetStopRound = txtStopRound.Text;
            Settings.Default.BetStopWin = txtStopWin.Text;
            Settings.Default.BetStopLose = txtStopLose.Text;
            Settings.Default.BetStopLess = txtStopLess.Text;
            Settings.Default.BetStopMore = txtStopMore.Text;
            Settings.Default.ChipSelected = (byte)cbChip.SelectedIndex;
            Settings.Default.BettingSelected = (byte)BetSystemValues.BettingSelected;
            Settings.Default.LocationBetSystem = Location;
            Settings.Default.Save();
        }

        #endregion

        #region Edit Bet System

        private void BtnEditPP_Click(object sender, EventArgs e)
        {
            BettingEditMode(BetSystemValues.BettingMode.PP);
        }

        private void BtnEditNP_Click(object sender, EventArgs e)
        {
            BettingEditMode(BetSystemValues.BettingMode.NP);
        }

        private void BtnEditFib_Click(object sender, EventArgs e)
        {
            BettingEditMode(BetSystemValues.BettingMode.Fibonacci);
        }

        private void BettingEditMode(BetSystemValues.BettingMode mode)
        {
            var frmBetSystemEdit = new FrmBetSystemEdit();
            BotValues.LclzManager.LocalizeForm(frmBetSystemEdit);
            BetSystemValues.EditMode = mode;
            switch (mode)
            {
                case BetSystemValues.BettingMode.PP:
                    frmBetSystemEdit.EditTitle.Text = stringLoader.PP;
                    frmBetSystemEdit.lbExplain.Text = $@"{stringLoader.DetailPp1}" + Environment.NewLine + $@"{stringLoader.DetailPp2}";
                    break;

                case BetSystemValues.BettingMode.NP:
                    frmBetSystemEdit.EditTitle.Text = stringLoader.NP;
                    frmBetSystemEdit.lbExplain.Text = $@"{stringLoader.DetailNp1}" + Environment.NewLine + $@"{stringLoader.DetailNp2}";
                    break;

                case BetSystemValues.BettingMode.Fibonacci:
                    frmBetSystemEdit.EditTitle.Text = stringLoader.Fib;
                    frmBetSystemEdit.lbExplain.Text = $@"{stringLoader.DetailFib1}" + Environment.NewLine + $@"{stringLoader.DetailFib2}";
                    break;
            }
            frmBetSystemEdit.ShowDialog();
            frmBetSystemEdit.Dispose();
        }

        #endregion

        #region Select Mode


        private void CheckBoxAll(object sender)
        {
            BettingChangeMode();
        }
        private void BettingChangeMode()
        {
            if (radPP.Checked)
            {
                BetSystemValues.BettingSelected = BetSystemValues.BettingMode.PP;
            }
            if (radNP.Checked)
            {
                BetSystemValues.BettingSelected = BetSystemValues.BettingMode.NP;
            }
            if (radPPNP.Checked)
            {
                BetSystemValues.BettingSelected = BetSystemValues.BettingMode.PPNP;
            }
            if (radFib.Checked)
            {
                BetSystemValues.BettingSelected = BetSystemValues.BettingMode.Fibonacci;
            }
            if (radAI.Checked)
            {
                BetSystemValues.BettingSelected = BetSystemValues.BettingMode.AI;
            }
            if (radONE.Checked)
            {
                BetSystemValues.BettingSelected = BetSystemValues.BettingMode.OneShot;
            }
            if (radX2.Checked)
            {
                BetSystemValues.BettingSelected = BetSystemValues.BettingMode.X2;
            }
        }

        #endregion

        #region Bet Settings
        private void BetLoad()
        {
            txtStopRound.Text = Settings.Default.BetStopRound;
            txtStopWin.Text = Settings.Default.BetStopWin;
            txtStopLose.Text = Settings.Default.BetStopLose;
            txtStopLess.Text = Settings.Default.BetStopLess;
            txtStopMore.Text = Settings.Default.BetStopMore;
        }
        private void BetSave()
        {
            BetSystemValues.BetStopRound = txtStopRound.Text;
            BetSystemValues.BetStopWin = txtStopWin.Text;
            BetSystemValues.BetStopLose = txtStopLose.Text;
            BetSystemValues.BetStopLess = txtStopLess.Text;
            BetSystemValues.BetStopMore = txtStopMore.Text;
            BetSystemValues.ChipSelected = (byte) cbChip.SelectedIndex;
            BetSystemValues.ChipValue = int.Parse(cbChip.SelectedItem.ToString());
        }
        private void ChipSelected()
        {
            cbChip.Items.Clear();
            cbChip.Items.Add(LayoutValues.Chip1);
            cbChip.Items.Add(LayoutValues.Chip2);
            cbChip.Items.Add(LayoutValues.Chip3);
            cbChip.Items.Add(LayoutValues.Chip4);
            cbChip.Items.Add(LayoutValues.Chip5);
            cbChip.SelectedIndex = BetSystemValues.ChipSelected;
        }


        #endregion
    }
}
