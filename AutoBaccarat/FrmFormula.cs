using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using AutoBaccarat.Properties;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    public partial class FrmFormula : Form
    {
        public FrmFormula()
        {
            InitializeComponent();
        }

        #region Load/Save

        private void FrmFormula_Load(object sender, EventArgs e)
        {
            LoadLocation();
            LoadFormula();
            ForceLoad();
        }
        private void LoadLocation()
        {
            if (Settings.Default.LocationFormula == new Point(0, 0))
            {
                CenterToScreen();
            }
            else
            {
                Location = Settings.Default.LocationFormula;
            }
        }
        private void LoadFormula()
        {
            FormulaValues.FormulaSelected = (FormulaValues.FormulaMode)Settings.Default.FormulaSelected;
            cbGoodLineFix.SelectedIndex = Settings.Default.FormulaGoodLineFix;
            cbLock.SelectedIndex = Settings.Default.FormulaLock;
            cbFollow.SelectedIndex = Settings.Default.FormulaFollow;

            switch (FormulaValues.FormulaSelected)
            {
                case FormulaValues.FormulaMode.Custom:
                    radCustom.Checked = true;
                    break;

                case FormulaValues.FormulaMode.GoodLine:
                    radGoodLine.Checked = true;
                    break;

                case FormulaValues.FormulaMode.GoodLineFix:
                    radGoodLineFix.Checked = true;
                    break;

                case FormulaValues.FormulaMode.GoodLineRandom:
                    radGoodLineRandom.Checked = true;
                    break;

                case FormulaValues.FormulaMode.Lock:
                    radLock.Checked = true;
                    break;

                case FormulaValues.FormulaMode.Follow:
                    radFollow.Checked = true;
                    break;

                case FormulaValues.FormulaMode.AI:
                    radAI.Checked = true;
                    break;

                case FormulaValues.FormulaMode.Random:
                    radRandom.Checked = true;
                    break;

                case FormulaValues.FormulaMode.Fixed:
                    radFixed.Checked = true;
                    break;
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.LocationFormula = Location;
            Settings.Default.FormulaSelected = (byte)FormulaValues.FormulaSelected;

            Settings.Default.FormulaGoodLineFix = (byte)cbGoodLineFix.SelectedIndex;
            Settings.Default.FormulaLock = (byte) cbLock.SelectedIndex;
            Settings.Default.FormulaFollow = (byte) cbFollow.SelectedIndex;

            Settings.Default.ForceSelected = (int)FormulaValues.ForceSelected;
            Settings.Default.ForceValue = byte.Parse(txtForce.Text);

            FormulaValues.GoodLineFix = (byte) cbGoodLineFix.SelectedIndex;
            FormulaValues.Lock = (byte) cbLock.SelectedIndex;
            FormulaValues.Follow = (byte) cbFollow.SelectedIndex;
            FormulaValues.ForceValue = byte.Parse(txtForce.Text);
            Settings.Default.Save();
            Close();
        }

        #endregion

        #region Select Mode 

        private void BtnCustom_Click(object sender, EventArgs e)
        {
            var custom = new FrmFormulaCustom();
            BotValues.LclzManager.LocalizeForm(custom);
            Hide();
            custom.ShowDialog();
            custom.Dispose();
            Show();
        }

        private void BtnFixed_Click(object sender, EventArgs e)
        {
            Hide();
            var fix = new FrmFormulaFixed();
            BotValues.LclzManager.LocalizeForm(fix);
            fix.lbExplain.Text = StringLoader.DetailFixed;
            fix.ShowDialog();
            fix.Dispose();
            Show();
        }
        private void RadioCheckAll(object sender)
        {
            FormulaChangeMode();
        }
        private void FormulaChangeMode()
        {
            if (radCustom.Checked)
            {
                FormulaValues.FormulaSelected = FormulaValues.FormulaMode.Custom;
            }
            if (radGoodLine.Checked)
            {
                FormulaValues.FormulaSelected = FormulaValues.FormulaMode.GoodLine;
            }
            if (radGoodLineFix.Checked)
            {
                FormulaValues.FormulaSelected = FormulaValues.FormulaMode.GoodLineFix;
            }
            if (radGoodLineRandom.Checked)
            {
                FormulaValues.FormulaSelected = FormulaValues.FormulaMode.GoodLineRandom;
            }
            if (radLock.Checked)
            {
                FormulaValues.FormulaSelected = FormulaValues.FormulaMode.Lock;
            }
            if (radFollow.Checked)
            {
                FormulaValues.FormulaSelected = FormulaValues.FormulaMode.Follow;
            }
            if (radAI.Checked)
            {
                FormulaValues.FormulaSelected = FormulaValues.FormulaMode.AI;
            }
            if (radRandom.Checked)
            {
                FormulaValues.FormulaSelected = FormulaValues.FormulaMode.Random;
            }
            if (radFixed.Checked)
            {
                FormulaValues.FormulaSelected = FormulaValues.FormulaMode.Fixed;
            }
        }


        #endregion

        #region Force

        private void ForceLoad()
        {
            FormulaValues.ForceSelected = (FormulaValues.ForceType)Settings.Default.ForceSelected;
            txtForce.Text = Settings.Default.ForceValue.ToString();
            switch (FormulaValues.ForceSelected)
            {
                case FormulaValues.ForceType.Follow:
                    radForceFollow.Checked = true;
                    break;

                case FormulaValues.ForceType.Adverse:
                    radForceAdverse.Checked = true;
                    break;
            }
        }
        private void ForceCheck(object sender)
        {
            ForceCheckChanged();
        }
        private void ForceCheckChanged()
        {
            if (radForceFollow.Checked)
            {
                FormulaValues.ForceSelected = FormulaValues.ForceType.Follow;
            }
            if (radForceAdverse.Checked)
            {
                FormulaValues.ForceSelected = FormulaValues.ForceType.Adverse;
            }
        }


        #endregion

        
    }
}
