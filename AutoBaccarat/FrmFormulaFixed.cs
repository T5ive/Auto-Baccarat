using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using AutoBaccarat.Properties;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    public partial class FrmFormulaFixed : Form
    {
        public FrmFormulaFixed()
        {
            InitializeComponent();
        }

        #region Load/Save

        private void FrmFormulaFixed_Load(object sender, EventArgs e)
        {
            LoadLocation();
            FormulaValues.LoadFixed();
            TextToDataGridView();
        }

        private void LoadLocation()
        {
            if (Settings.Default.LocationFormulaFixed == new Point(0, 0))
            {
                CenterToScreen();
            }
            else
            {
                Location = Settings.Default.LocationFormulaFixed;
            }
        }
        private void FrmFormulaFixed_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.LocationFormulaFixed = Location;
            Settings.Default.Save();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (dgvBetting.RowCount == 0)
            {
                MessageBox.Show(StringLoader.FixedError, StringLoader.Error + @"04x1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridToText();
            Settings.Default.Fixed = FormulaValues.Fixed;
            Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            FormulaValues.LoadFixed();
            Close();
        }

        #endregion

        #region Value Control
        private void TextToDataGridView()
        {
            var text = FormulaValues.Fixed;
            dgvBetting.Rows.Clear();
            var array = text.Split('-');
            checked
            {
                var num = array.Length - 1;
                for (var i = 0; i <= num; i++)
                {
                    switch (array[i])
                    {
                        case "1":
                            array[i] = "P";
                            break;
                        case "2":
                            array[i] = "B";
                            break;
                        case "3":
                            array[i] = "N";
                            break;
                    }

                    if (!string.IsNullOrWhiteSpace(array[i]))
                    {
                        dgvBetting.Rows.Add(array[i]);
                    }
                   
                    DataGridToText();
                }
            }
        }

        private void DataGridToText()
        {
            var text = "";
            checked
            {
                var num = dgvBetting.RowCount - 1;
                for (var i = 0; i <= num; i++)
                {
                    string value="";
                    switch (dgvBetting[0, i].Value)
                    {
                        case "P":
                            value = "1";
                            break;
                        case "B":
                            value = "2";
                            break;
                        case "N":
                            value = "3";
                            break;
                    }
                    if (i > 0)
                    {
                        text += "-";
                    }
                    text += value;
                }
                FormulaValues.Fixed = text;
            }
        }

        #endregion

        #region Button Control

        private void BtnAddP_Click(object sender, EventArgs e)
        {
            dgvBetting.Rows.Add("P");
            DataGridToText();
        }

        private void BtnAddB_Click(object sender, EventArgs e)
        {
            dgvBetting.Rows.Add("B");
            DataGridToText();
        }

        private void BtnAddSkip_Click(object sender, EventArgs e)
        {
            dgvBetting.Rows.Add("N");
            DataGridToText();
        }
        private void BtnDefault_Click(object sender, EventArgs e)
        {
            FormulaValues.Fixed = "1-2";
            TextToDataGridView();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (dgvBetting.RowCount > 0)
            {
                if (dgvBetting.CurrentRow != null) dgvBetting.Rows.RemoveAt(dgvBetting.CurrentRow.Index);
            }

            DataGridToText();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (dgvBetting.RowCount > 0)
            {
                dgvBetting.Rows.Clear();
                DataGridToText();
            }
        }
        #endregion

      
    }
}
