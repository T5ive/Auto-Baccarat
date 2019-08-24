using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AutoBaccarat.Class;
using AutoBaccarat.Properties;
using AutoBaccarat.Setting;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    public partial class FrmLayout : Form
    {
        public FrmLayout()
        {
            InitializeComponent();
        }

        #region Load/Save
        private void FrmLayout_Load(object sender, EventArgs e)
        {
            LoadLocation();
            LoadDgvSetting();
            LoadFiles2List();
        }
        private void LoadLocation()
        {
            if (Settings.Default.LocationLayout == new Point(0, 0))
            {
                CenterToScreen();
            }
            else
            {
                Location = Settings.Default.LocationLayout;
            }
        }
        private void LoadDgvSetting()
        {
            dgvSetting.Rows.Clear();

            EasyAdd(dgvSetting, "Start", "Set XY", "(0,0)");
            EasyAdd(dgvSetting, "P", "Set XY", "(0,0)");
            EasyAdd(dgvSetting, "B", "Set XY", "(0,0)");
            EasyAdd(dgvSetting, "T", "Set XY", "(0,0)");

            EasyAdd(dgvSetting, "Confirm P", "Set XY", "(0,0)");
            EasyAdd(dgvSetting, "Confirm B", "Set XY", "(0,0)");

            EasyAdd(dgvSetting, "Chip 1", "Set XY", "(0,0)", 5);
            EasyAdd(dgvSetting, "Chip 2", "Set XY", "(0,0)", 10);
            EasyAdd(dgvSetting, "Chip 3", "Set XY", "(0,0)", 20);
            EasyAdd(dgvSetting, "Chip 4", "Set XY", "(0,0)", 50);
            EasyAdd(dgvSetting, "Chip 5", "Set XY", "(0,0)", 100);
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

        private void FrmLayout_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
        private void SaveSettings()
        {
            Settings.Default.LocationLayout = Location;
            Settings.Default.LoadLayoutListCount = LayoutValues.LoadListCount;
            Settings.Default.Save();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (CheckEdit())
            {
                var msgResult = MessageBox.Show($@"[{LayoutValues.ListName}] {stringLoader.Modified}",
                    stringLoader.Confirmation, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (msgResult == DialogResult.Yes)
                {
                    SaveValue();
                    Close();
                }
                if (msgResult == DialogResult.No)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveValue();
        }
        private void SaveValue()
        {
            if (listLayout.Items.Count == 0)
            {
                MessageBox.Show(stringLoader.SetBetUnit, stringLoader.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateValue();

            LayoutValues.ListName = txtName.Text;
            SaveValue(LayoutValues.PositionStart, null, LayoutValues.HexColorStart, LayoutValues.ProcessStart,LayoutValues.RgbStart);
            SaveValue(LayoutValues.PositionPlayer, null, LayoutValues.HexColorPlayer, LayoutValues.ProcessPlayer, LayoutValues.RgbPlayer);
            SaveValue(LayoutValues.PositionBanker, null, LayoutValues.HexColorBanker, LayoutValues.ProcessBanker, LayoutValues.RgbBanker);
            SaveValue(LayoutValues.PositionTie, null, LayoutValues.HexColorTie, LayoutValues.ProcessTie, LayoutValues.RgbTie);
            SaveValue(LayoutValues.PositionConP, null, null, LayoutValues.ProcessConP, null);
            SaveValue(LayoutValues.PositionConB, null, null, LayoutValues.ProcessConB, null); ;
            SaveValue(LayoutValues.PositionChip1, LayoutValues.Chip1, null, LayoutValues.ProcessChip1, null);
            SaveValue(LayoutValues.PositionChip2, LayoutValues.Chip2, null, LayoutValues.ProcessChip2, null);
            SaveValue(LayoutValues.PositionChip3, LayoutValues.Chip3, null, LayoutValues.ProcessChip3, null);
            SaveValue(LayoutValues.PositionChip4, LayoutValues.Chip4, null, LayoutValues.ProcessChip4, null);
            SaveValue(LayoutValues.PositionChip5, LayoutValues.Chip5, null, LayoutValues.ProcessChip5, null);
            LayoutValues.ListValuesSave.Add(((byte) LayoutValues.ModeSelected).ToString());
            LayoutListManager.SaveValue();

            SaveSettings();
            LoadFiles2List();
        }

        private void SaveValue(string position, string chip, string hexColor, string process, string rgbColor)
        {
            if (chip == null)
            {
                chip = " ";
            }
            if (hexColor == null)
            {
                hexColor = " ";
            }
            if (process == null)
            {
                process = " ";
            }
            if (rgbColor == null)
            {
                rgbColor = " ";
            }

            LayoutValues.ListValuesSave.Add($"{position}|{chip}|{hexColor}|{process}|{rgbColor}");
        }

        #endregion

        #region File List Control

        private bool _layoutListFirstTime=true;
        private bool _cancel;
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
                if (_cancel)
                {
                    _cancel = false;
                    return;
                }
                if (CheckEdit())
                {
                    var msgResult = MessageBox.Show($@"[{LayoutValues.ListName}] {stringLoader.Modified}",
                        stringLoader.Confirmation, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (msgResult == DialogResult.Yes)
                    {
                        SaveValue();
                        return;
                    }
                    if (msgResult == DialogResult.Cancel)
                    {
                        _cancel = true;
                        listLayout.SelectedIndex = LayoutValues.LoadListCount;
                        return;
                    }
                }

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
                MessageBox.Show(ex.Message, stringLoader.Error + @"01x1", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            EasyUpdate(0, 4, LayoutValues.HexColorStart);
            EasyUpdate(1, 4, LayoutValues.HexColorPlayer);
            EasyUpdate(2, 4, LayoutValues.HexColorBanker);
            EasyUpdate(3, 4, LayoutValues.HexColorTie);

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
            try
            {
                if (listLayout.SelectedItem != null)
                {
                    var itemList = listLayout.SelectedItem;

                    if (MessageBox.Show($@"{stringLoader.Delete} {itemList} ?", stringLoader.Confirmation,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                    {
                        var iniReader = new IniReader(((LayoutInfo) listLayout.SelectedItem).File);
                        var path = iniReader.Path;
                        var file = new FileInfo(path);
                        file.Delete();

                        var num = listLayout.SelectedIndex;
                        if (num == 0)
                        {
                            LayoutValues.LoadListCount = 0;
                        }

                        if (num < listLayout.Items.Count)
                        {
                            LayoutValues.LoadListCount = (byte) (num - 1);
                        }

                        SaveSettings();
                        LoadFiles2List();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stringLoader.Error + @"01x2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Values Control
        private bool CheckEdit()
        {
            if (LayoutValues.ListName != txtName.Text||
                LayoutValues.PositionStart != EasyGetDgvValue(0, 2) ||
                LayoutValues.PositionPlayer != EasyGetDgvValue(1, 2) ||
                LayoutValues.PositionBanker != EasyGetDgvValue(2, 2) ||
                LayoutValues.PositionTie != EasyGetDgvValue(3, 2) ||
                LayoutValues.PositionConP != EasyGetDgvValue(4, 2) ||
                LayoutValues.PositionConB != EasyGetDgvValue(5, 2) ||
                LayoutValues.PositionChip1 != EasyGetDgvValue(6, 2) ||
                LayoutValues.PositionChip2 != EasyGetDgvValue(7, 2) ||
                LayoutValues.PositionChip3 != EasyGetDgvValue(8, 2) ||
                LayoutValues.PositionChip4 != EasyGetDgvValue(9, 2) ||
                LayoutValues.PositionChip5 != EasyGetDgvValue(10, 2) ||
                LayoutValues.Chip1 != EasyGetDgvValue(6, 3) ||
                LayoutValues.Chip2 != EasyGetDgvValue(7, 3) ||
                LayoutValues.Chip3 != EasyGetDgvValue(8, 3) ||
                LayoutValues.Chip4 != EasyGetDgvValue(9, 3) ||
                LayoutValues.Chip5 != EasyGetDgvValue(10, 3) ||
                LayoutValues.HexColorStart != EasyGetDgvValue(0, 4) ||
                LayoutValues.HexColorPlayer != EasyGetDgvValue(1, 4) ||
                LayoutValues.HexColorBanker != EasyGetDgvValue(2, 4) ||
                LayoutValues.HexColorTie != EasyGetDgvValue(3, 4) ||
                LayoutValues.ProcessStart != EasyGetDgvValue(0, 5) ||
                LayoutValues.ProcessPlayer != EasyGetDgvValue(1, 5) ||
                LayoutValues.ProcessBanker != EasyGetDgvValue(2, 5) ||
                LayoutValues.ProcessTie != EasyGetDgvValue(3, 5) ||
                LayoutValues.ProcessConP != EasyGetDgvValue(4, 5) ||
                LayoutValues.ProcessConB != EasyGetDgvValue(5, 5) ||
                LayoutValues.ProcessChip1 != EasyGetDgvValue(6, 5) ||
                LayoutValues.ProcessChip2 != EasyGetDgvValue(7, 5) ||
                LayoutValues.ProcessChip3 != EasyGetDgvValue(8, 5) ||
                LayoutValues.ProcessChip4 != EasyGetDgvValue(9, 5) ||
                LayoutValues.ProcessChip5 != EasyGetDgvValue(10, 5) ||
                LayoutValues.RgbStart != EasyGetDgvValue(0, 6) ||
                LayoutValues.RgbPlayer != EasyGetDgvValue(1, 6) ||
                LayoutValues.RgbBanker != EasyGetDgvValue(2, 6) ||
                LayoutValues.RgbTie != EasyGetDgvValue(3, 6))
                
            {
                return true;
            }

            return radNormal.Checked && LayoutValues.ModeSelected != LayoutValues.Mode.Normal ||
                   radBackGround.Checked && LayoutValues.ModeSelected != LayoutValues.Mode.Background;
        }
        private string EasyGetDgvValue(int row, int column)
        {
            return dgvSetting[column, row].Value.ToString();
        }
        private void UpdateValue()
        {
            LayoutValues.PositionStart = EasyGetDgvValue(0, 2);
            LayoutValues.PositionPlayer = EasyGetDgvValue(1, 2);
            LayoutValues.PositionBanker = EasyGetDgvValue(2, 2);
            LayoutValues.PositionTie = EasyGetDgvValue(3, 2);
            LayoutValues.PositionConP = EasyGetDgvValue(4, 2);
            LayoutValues.PositionConB = EasyGetDgvValue(5, 2);
            LayoutValues.PositionChip1 = EasyGetDgvValue(6, 2);
            LayoutValues.PositionChip2 = EasyGetDgvValue(7, 2);
            LayoutValues.PositionChip3 = EasyGetDgvValue(8, 2);
            LayoutValues.PositionChip4 = EasyGetDgvValue(9, 2);
            LayoutValues.PositionChip5 = EasyGetDgvValue(10, 2);
            LayoutValues.Chip1 = EasyGetDgvValue(6, 3);
            LayoutValues.Chip2 = EasyGetDgvValue(7, 3);
            LayoutValues.Chip3 = EasyGetDgvValue(8, 3);
            LayoutValues.Chip4 = EasyGetDgvValue(9, 3);
            LayoutValues.Chip5 = EasyGetDgvValue(10, 3);
            LayoutValues.HexColorStart = EasyGetDgvValue(0, 4);
            LayoutValues.HexColorPlayer = EasyGetDgvValue(1, 4);
            LayoutValues.HexColorBanker = EasyGetDgvValue(2, 4);
            LayoutValues.HexColorTie = EasyGetDgvValue(3, 4);
            LayoutValues.ProcessStart = EasyGetDgvValue(0, 5);
            LayoutValues.ProcessPlayer = EasyGetDgvValue(1, 5);
            LayoutValues.ProcessBanker = EasyGetDgvValue(2, 5);
            LayoutValues.ProcessTie = EasyGetDgvValue(3, 5);
            LayoutValues.ProcessConP = EasyGetDgvValue(4, 5);
            LayoutValues.ProcessConB = EasyGetDgvValue(5, 5);
            LayoutValues.ProcessChip1 = EasyGetDgvValue(6, 5);
            LayoutValues.ProcessChip2 = EasyGetDgvValue(7, 5);
            LayoutValues.ProcessChip3 = EasyGetDgvValue(8, 5);
            LayoutValues.ProcessChip4 = EasyGetDgvValue(9, 5);
            LayoutValues.ProcessChip5 = EasyGetDgvValue(10, 5);
            LayoutValues.RgbStart = EasyGetDgvValue(0, 6);
            LayoutValues.RgbPlayer = EasyGetDgvValue(1, 6);
            LayoutValues.RgbBanker = EasyGetDgvValue(2, 6);
            LayoutValues.RgbTie = EasyGetDgvValue(3, 6);
            LayoutValues.ModeSelected = radNormal.Checked ? LayoutValues.Mode.Normal : LayoutValues.Mode.Background;

        }
        private void DgvSetting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    var column = e.ColumnIndex;
                    var row = e.RowIndex;

                    //if (LayoutValues.ModeSelected == LayoutValues.Mode.Normal)
                    if(radNormal.Checked)
                    {
                        Visible = false;
                        using (var getColor = new FrmColorInfo())
                        {
                            getColor.Mode = 0;
                            getColor.ShowDialog();
                            getColor.Dispose();
                        }
                        Visible = true;
                        if (Values.CloseFrom)
                        {
                            dgvSetting[column + 1, row].Value = $"({Values.CheckX},{Values.CheckY})";
                            if (row == 0 | row == 1 | row == 2 | row == 3)
                            {
                                dgvSetting[column + 3, row].Value = $"{Values.Color}";
                                dgvSetting[column + 5, row].Value = $"{Values.RgbColor.R},{Values.RgbColor.G},{Values.RgbColor.B}";
                            }

                            Values.CloseFrom = false;
                        }
                    }

                    //if (LayoutValues.ModeSelected == LayoutValues.Mode.Background)
                    if(radBackGround.Checked)
                    {
                        Visible = false;
                        using (var getColor = new FrmColorInfo())
                        {
                            getColor.Mode = 1;
                            getColor.ShowDialog();
                            getColor.Dispose();
                        }
                        Visible = true;
                        if (Values.CloseFrom)
                        {
                            dgvSetting[column + 1, row].Value = $"({Values.CheckX},{Values.CheckY})";
                            if (row == 0 | row == 1 | row == 2 | row == 3)
                            {
                                dgvSetting[column + 3, row].Value = $"{Values.Color}";
                            }

                            dgvSetting[column + 4, row].Value = $"{Values.TitleName}";
                            Values.CloseFrom = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stringLoader.Error + @"01x3", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (e.ColumnIndex == 3 && dgvSetting.CurrentRow.Index >= 6)
                {
                    var column = e.ColumnIndex;
                    var row = e.RowIndex;
                    var oldValue = dgvSetting[column, row].Value.ToString();
                    var input = InputBox.Show(stringLoader.InputChip, oldValue, true);

                    if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
                    {
                        dgvSetting.CurrentCell.Value = input;
                        //if (dgvSetting.CurrentRow.Index == 6)
                        //{
                        //    LayoutValues.Chip1 = input;
                        //    return;
                        //}
                        //if (dgvSetting.CurrentRow.Index == 7)
                        //{
                        //    LayoutValues.Chip2 = input;
                        //    return;
                        //}
                        //if (dgvSetting.CurrentRow.Index == 8)
                        //{
                        //    LayoutValues.Chip3 = input;
                        //    return;
                        //}
                        //if (dgvSetting.CurrentRow.Index == 9)
                        //{
                        //    LayoutValues.Chip4 = input;
                        //    return;
                        //}
                        //if (dgvSetting.CurrentRow.Index == 10)
                        //{
                        //    LayoutValues.Chip5 = input;
                        //}
                    }
                    else
                    {
                        MessageBox.Show(stringLoader.InputChipNull, stringLoader.Error + @"01x4", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stringLoader.Error + @"01x5", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #region Mode

        private void SelectMode(object sender)
        {
            // ChangeMode();
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
