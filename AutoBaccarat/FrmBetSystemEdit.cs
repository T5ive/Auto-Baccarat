using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using AutoBaccarat.Properties;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    public partial class FrmBetSystemEdit : Form
    {
        public FrmBetSystemEdit()
        {
            InitializeComponent();
        }

        #region Load/Save
        
        private void FrmBetSystemEdit_Load(object sender, EventArgs e)
        {
            LoadLocation();
            BetSystemValues.BetSystemEditLoadValue();
            TextToDataGridView();
        }
        private void LoadLocation()
        {
            if (Settings.Default.LocationBetSystemEdit == new Point(0, 0))
            {
                CenterToScreen();
            }
            else
            {
                Location = Settings.Default.LocationBetSystemEdit;
            }
        }
        private void FrmBetSystemEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.LocationBetSystemEdit = Location;
            Settings.Default.Save();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (dgvBetting.RowCount == 0)
            {
                MessageBox.Show(stringLoader.SetBetUnit, stringLoader.Error+ @"02x1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Settings.Default.ValuePP = BetSystemValues.ValuePP;
            Settings.Default.ValueNP = BetSystemValues.ValueNP;
            Settings.Default.ValueFib = BetSystemValues.ValueFib;
            Settings.Default.BettingSelected = (byte)BetSystemValues.BettingSelected;
            Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            BetSystemValues.BetSystemEditLoadValue();
            Close();
        }

        #endregion

        #region Value Control
        private void TextToDataGridView()
        {
            var text = "";
            switch (BetSystemValues.EditMode)
            {
                case BetSystemValues.BettingMode.PP:
                    text = BetSystemValues.ValuePP;
                    break;

                case BetSystemValues.BettingMode.NP:
                    text = BetSystemValues.ValueNP;
                    break;

                case BetSystemValues.BettingMode.Fibonacci:
                    text = BetSystemValues.ValueFib;
                    break;
            }
            dgvBetting.Rows.Clear();
            var array = text.Split('-');
            checked
            {
                var num = array.Length - 1;
                for (var i = 0; i <= num; i++)
                {
                    dgvBetting.Rows.Add(dgvBetting.RowCount + 1, array[i]);
                    DataGridToTxt();
                }
            }
        }
        private void DataGridToTxt()
        {
            var text = "";
            checked
            {
                var num = dgvBetting.RowCount - 1;
                for (var i = 0; i <= num; i++)
                {
                    dgvBetting[0, i].Value = i + 1;
                    if (i > 0)
                    {
                        text += "-";
                    }
                    text += dgvBetting[1, i].Value;
                }

                switch (BetSystemValues.EditMode)
                {
                    case BetSystemValues.BettingMode.PP:
                        BetSystemValues.ValuePP = text;
                        break;

                    case BetSystemValues.BettingMode.NP:
                        BetSystemValues.ValueNP = text;
                        break;

                    case BetSystemValues.BettingMode.Fibonacci:
                        BetSystemValues.ValueFib = text;
                        break;
                }
            }
        }

        #endregion

        #region Button Control

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            dgvBetting.Rows.Add(checked(dgvBetting.RowCount + 1), int.Parse(Betting_txtNumber.Text));
            DataGridToTxt();
        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (dgvBetting.RowCount > 0)
            {
                if (dgvBetting.CurrentRow != null) dgvBetting.Rows.RemoveAt(dgvBetting.CurrentRow.Index);
            }

            DataGridToTxt();
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (dgvBetting.RowCount > 0)
            {
                dgvBetting.Rows.Clear();
                DataGridToTxt();
            }
        }
        private void BtnDefault_Click(object sender, EventArgs e)
        {
            switch (BetSystemValues.EditMode)
            {
                case BetSystemValues.BettingMode.PP:
                    BetSystemValues.ValuePP = "1-2-2-3-3-3-4-4-4-4-5-5-5-5-5";

                    break;

                case BetSystemValues.BettingMode.NP:
                    BetSystemValues.ValueNP = "1-1-3-7-15-31-63-127-255-511-1023-2047";

                    break;

                case BetSystemValues.BettingMode.Fibonacci:
                    BetSystemValues.ValueFib = "1-1-2-3-5-8-13-21-34-55-89-144-233-377-610-987-1597-2584";
                    break;
            }

            TextToDataGridView();
        }
        private void DgvBetting_SelectionChanged(object sender, EventArgs e)
        {
           // dgvBetting.ClearSelection();
        }



        #endregion

       
    }
}
