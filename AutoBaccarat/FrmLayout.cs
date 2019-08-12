using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AutoBaccarat.Properties;
using AutoBaccarat.Setting;

namespace AutoBaccarat
{
    public partial class FrmLayout : Form
    {
        public FrmLayout()
        {
            InitializeComponent();
        }

        #region Load/Save
        private void FrmLayout_Load(object sender, EventArgs e)
        {
            LoadDgvSetting();
            LoadFiles2List();
        }
        private void LoadDgvSetting()
        {
            dgvSetting.Rows.Clear();

            EasyAdd(dgvSetting, "Start", "Set XY", "0,0");
            EasyAdd(dgvSetting, "P", "Set XY", "0,0");
            EasyAdd(dgvSetting, "B", "Set XY", "0,0");
            EasyAdd(dgvSetting, "T", "Set XY", "0,0");

            EasyAdd(dgvSetting, "Confirm P", "Set XY", "0,0");
            EasyAdd(dgvSetting, "Confirm B", "Set XY", "0,0");

            EasyAdd(dgvSetting, "Chip 1", "Set XY", "0,0", 5);
            EasyAdd(dgvSetting, "Chip 2", "Set XY", "0,0", 10);
            EasyAdd(dgvSetting, "Chip 3", "Set XY", "0,0", 20);
            EasyAdd(dgvSetting, "Chip 4", "Set XY", "0,0", 50);
            EasyAdd(dgvSetting, "Chip 5", "Set XY", "0,0", 100);
            dgvSetting.ClearSelection();
        }
        private void EasyAdd(DataGridView dgv, string name, string button, string position, object chipValue = null, string color = " ", string processName = " ", string colorRgb = " ")
        {
            if (chipValue == null)
            {
                chipValue = " ";
            }
            dgv.Rows.Add(name, button, position, chipValue, color, processName, colorRgb);
        }

        #endregion
        

        #region File List Control

        private bool _layoutListFirstTime;
        private void LoadFiles2List()
        {
            try
            {
                checked
                {
                    LayoutValues.ListLoad = LayoutValues.ListMng.GetLayoutList();
                    listLayout.DataSource = LayoutValues.ListLoad;
                    listLayout.SelectedIndex = Settings.Default.LoadLayoutListCount;
                }

            }
            catch
            {
            }
        }
        private void ListLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_layoutListFirstTime)
                {
                    _layoutListFirstTime = false;
                    goto skip;
                }

                //if (CheckEdit())
                //{
                //    var msgResult = MessageBox.Show($@"[{FormulaValues.ListName}] {stringLoader.Modified}",
                //        stringLoader.Confirmation, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                //    if (msgResult == DialogResult.Yes)
                //    {
                //        SaveValue();
                //        return;
                //    }
                //    if (msgResult == DialogResult.Cancel)
                //    {
                //        listLayout.SelectedIndex = FormulaValues.LoadListCount;
                //        return;
                //    }
                //}

                skip:
                if (listLayout.SelectedItem == null)
                {
                    return;
                }

                LayoutValues.ListMng.LoadValuesFromFile(((LayoutInfo)listLayout.SelectedItem).File);

                LayoutValues.LoadListValue();
                UpdateValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stringLoader.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateValues()
        {
            LayoutValues.LoadListCount = (byte)listLayout.SelectedIndex;
            LayoutValues.ListName = listLayout.SelectedItem.ToString();

            txtName.Text = listLayout.SelectedItem.ToString();

            UpdateDgvValue();
            UpdateMode();
        }
        private void UpdateDgvValue()
        {
            #region Update Position

            EasyUpdate(0, 2, LayoutValues.PositionStart);
            EasyUpdate(1, 2, LayoutValues.PositionPlayer);
            EasyUpdate(2, 2, LayoutValues.PositionBanker);
            EasyUpdate(3, 2, LayoutValues.PositionTie);

            EasyUpdate(4, 2, LayoutValues.PositionConP);
            EasyUpdate(5, 2, LayoutValues.PositionConB);

            EasyUpdate(6, 2, LayoutValues.PositionChip1);
            EasyUpdate(7, 2, LayoutValues.PositionChip2);
            EasyUpdate(8, 2, LayoutValues.PositionChip3);
            EasyUpdate(9, 2, LayoutValues.PositionChip4);
            EasyUpdate(10, 2, LayoutValues.PositionChip5);

            #endregion

            #region Update Chip Amount

            EasyUpdate(6, 3, LayoutValues.Chip1);
            EasyUpdate(7, 3, LayoutValues.Chip2);
            EasyUpdate(8, 3, LayoutValues.Chip3);
            EasyUpdate(9, 3, LayoutValues.Chip4);
            EasyUpdate(10, 3, LayoutValues.Chip5);

            #endregion

            #region Update Color Hex

            EasyUpdate(0, 4, LayoutValues.ColorStart);
            EasyUpdate(1, 4, LayoutValues.ColorPlayer);
            EasyUpdate(2, 4, LayoutValues.ColorBanker);
            EasyUpdate(3, 4, LayoutValues.ColorTie);

            #endregion

            #region Update Process Name

            EasyUpdate(0, 5, LayoutValues.ProcessStart);
            EasyUpdate(1, 5, LayoutValues.ProcessPlayer);
            EasyUpdate(2, 5, LayoutValues.ProcessBanker);
            EasyUpdate(3, 5, LayoutValues.ProcessTie);

            EasyUpdate(4, 5, LayoutValues.ProcessConP);
            EasyUpdate(5, 5, LayoutValues.ProcessConB);

            EasyUpdate(6, 5, LayoutValues.ProcessChip1);
            EasyUpdate(7, 5, LayoutValues.ProcessChip2);
            EasyUpdate(8, 5, LayoutValues.ProcessChip3);
            EasyUpdate(9, 5, LayoutValues.ProcessChip4);
            EasyUpdate(10, 5, LayoutValues.ProcessChip5);

            #endregion

            #region Update Color RGB

            EasyUpdate(0, 6, LayoutValues.RgbStart);
            EasyUpdate(1, 6, LayoutValues.RgbPlayer);
            EasyUpdate(2, 6, LayoutValues.RgbBanker);
            EasyUpdate(3, 6, LayoutValues.RgbTie);

            #endregion

            
        }

        /// <summary>
        /// Update dgvSetting Values
        /// </summary>
        /// <param name="row">แภว
        /// <para>0=Start</para>
        /// <para>1=Player</para>
        /// <para>2=Banker</para>
        /// <para>3=Tie</para>
        /// <para>4=Confirm Player</para>
        /// <para>5=Confirm Banker</para>
        /// <para>6=Chip 1</para>
        /// <para>7=Chip 2</para>
        /// <para>8=Chip 3</para>
        /// <para>9=Chip 4</para>
        /// <para>10=Chip 5</para>
        /// </param>
        /// <param name="column"></param>
        /// <para>2=Position</para>
        /// <para>3=Chip</para>
        /// <para>4=Color Hex</para>
        /// <para>5=Process Name</para>
        /// <para>6=Color RGB</para>
        /// <param name="value"></param>
        private void EasyUpdate(int row, int column,  string value)
        {
            dgvSetting[column, row].Value = value;
        }
        private void UpdateMode()
        {
            LayoutValues.ModeSelected = (LayoutValues.Mode)int.Parse(LayoutValues.ListValues[11]);
            switch (LayoutValues.ModeSelected)
            {
                case LayoutValues.Mode.Normal:
                    radNormal.Checked = true;
                    break;

                case LayoutValues.Mode.Background:
                    radBackGround.Checked = true;
                    break;
            }
        }
        
        private void BtnAddList_Click(object sender, EventArgs e)
        {
            LayoutListManager.AddNewLayout();
            LoadFiles2List();
        }

        private void BtnDelList_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Values Control

        private bool CheckEdit()
        {

            if (LayoutValues.ListName != txtName.Text)
            {
                return true;
            }

            return false;

        }

        #region Mode

        private void SelectMode(object sender)
        {
            ChangeMode();
        }
        private void ChangeMode()
        {
            if (radNormal.Checked)
            {
                LayoutValues.ModeSelected = LayoutValues.Mode.Normal;
            }

            if (radBackGround.Checked)
            {
                LayoutValues.ModeSelected = LayoutValues.Mode.Background;
            }
        }

        #endregion
        #endregion
    }
}
