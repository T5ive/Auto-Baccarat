using AutoBaccarat.Properties;
using AutoBaccarat.Setting.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TFive_Class;

namespace AutoBaccarat
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region Load/Close

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLocation();
            CheckFile();

            StatusLoad();

            MainSettingsLoad();
            Layout_CallPosition();
            FormulaLoadValue();
            Layout_LoadFiles2List();
            BettingLoadValue();
            CustomLoad();
            SettingChipSelected();
            Settings_cbChip.SelectedIndex = 0;
        }

        protected virtual void CheckFile()
        {
            if (!File.Exists("TFive Magnify.dll"))
            {
                MessageBox.Show(@"File ""TFive Magnify.dll"" is missing!!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (!File.Exists("TFive Theme.dll"))
            {
                MessageBox.Show(@"File ""TFive Theme.dll"" is missing!!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (!File.Exists("TFive UI.dll"))
            {
                MessageBox.Show(@"File ""TFive UI.dll"" is missing!!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
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
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseSetting();
        }

        private void CloseSetting()
        {
            Settings.Default.Location = Location;

            Settings.Default._formulaSelected = (int)_formulaSelected;
            Settings.Default._formulaGoodLineFix = Formula_cbGoodLineFix.SelectedIndex;
            Settings.Default._formulaLock = Formula_cbLock.SelectedIndex;
            Settings.Default._formulaFollow = Formula_cbFollow.SelectedIndex;

            Settings.Default._forceSelected = (int)_forceSelected;
            Settings.Default._forcetxt = MainSetting_txtForce.Text;

            Settings.Default._bettingSelected = (int)_bettingSelected;

            SettingBetSave();
            Settings.Default.Save();
        }

        #endregion Load/Close

        #region Tab Control

        private void TFiveTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabMainControl.SelectedTab == TabMainControl.TabPages["tabDash"])
            {
                Size = new Size(785, 575);
            }

            if (TabMainControl.SelectedTab == TabMainControl.TabPages["tabLogs"])
            {
                Size = new Size(785, 575);
            }

            if (TabMainControl.SelectedTab == TabMainControl.TabPages["tabSetting"])
            {
                FamilyTabSetting();
            }

            if (TabMainControl.SelectedTab == TabMainControl.TabPages["tabAbout"])
            {
                Size = new Size(785, 575);
            }
        }

        private void TabSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            FamilyTabSetting();
        }

        private void FamilyTabSetting()
        {
            if (tabSettings.SelectedTab == tabSettings.TabPages["tabMain"])
            {
                Size = new Size(785, 575);
            }

            if (tabSettings.SelectedTab == tabSettings.TabPages["tabLayout"])
            {
                Layout_ChangeMode();
            }

            if (tabSettings.SelectedTab == tabSettings.TabPages["tabFormula"])
            {
                Size = new Size(1015, 575);
            }

            if (tabSettings.SelectedTab == tabSettings.TabPages["tabBetting"])
            {
                Size = new Size(815, 575);
            }
        }

        #endregion Tab Control

        #region DashBoard

        private void StatusLoad()
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Font = new Font("Segoe UI", 9);

            dataGridView2.Rows.Add("Operating Time:", "0", "Total Bet Amount:", "0");
            dataGridView2.Rows.Add("Round:", "0", "Maximum Profit:", "0");
            dataGridView2.Rows.Add("Win:", "0", "Max Profit-Balance:", "0");
            dataGridView2.Rows.Add("Lose:", "0", "Balance:", "0");
            dataGridView2.Rows.Add("Maximum Continuous Win:", "0", "Profit:", "0");
            dataGridView2.Rows.Add("Maximum Continuous Lose:", "0", "Lose:", "0");

            dataGridView2.ClearSelection();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            ShowDisplaySetting();

        }

        private void ShowDisplaySetting()
        {
            
            var frmDisplay = new FrmDisplay
            {
                LayoutList = listLayout.SelectedItem.ToString(),
                Mode = _layoutMode.ToString(),
                Formula = _formulaSelected.ToString(),
                Betting = _bettingSelected.ToString(),
                Chip = Settings_cbChip.SelectedItem.ToString(),
                StopRound = Settings_txtStopRound.Text,
                StopWin = Settings_txtStopWin.Text,
                StopLose = Settings_txtStopLose.Text,
                StopLess = Settings_txtStopLess.Text,
                StopMore = Settings_txtStopMore.Text
            };

            switch (_formulaSelected)
            {
                case FormulaMode.GoodLineFix:
                    frmDisplay.Formula = _formulaSelected+ " Line " + Formula_cbGoodLineFix.SelectedItem;
                    break;
                case FormulaMode.Lock:
                    frmDisplay.Formula = _formulaSelected + " - " + Formula_cbLock.SelectedItem;
                    break;
                case FormulaMode.Follow:
                    frmDisplay.Formula = _formulaSelected + " - " + Formula_cbFollow.SelectedItem;
                    break;
            }

            frmDisplay.ShowDialog();
            if (!frmDisplay.Submit)
            {
                //stop bot
            }
            frmDisplay.Dispose();
        }

        #endregion

        #region Settings

        #region Main Settings

        private void MainSettingsLoad()
        {
            Size = new Size();
            SettingBetLoad();
            ForceLoad();
        }

        #region Bet


        private void SettingBetLoad()
        {
            Settings_txtStopRound.Text = Settings.Default._betStopRound;
            Settings_txtStopWin.Text = Settings.Default._betStopWin;
            Settings_txtStopLose.Text = Settings.Default._betStopLose;
            Settings_txtStopLess.Text = Settings.Default._betStopLess;
            Settings_txtStopMore.Text = Settings.Default._betStopMore;
        }

        private void SettingBetSave()
        {
            Settings.Default._betStopRound = Settings_txtStopRound.Text;
            Settings.Default._betStopWin = Settings_txtStopWin.Text;
            Settings.Default._betStopLose = Settings_txtStopLose.Text;
            Settings.Default._betStopLess = Settings_txtStopLess.Text;
            Settings.Default._betStopMore = Settings_txtStopMore.Text;
        }

        private void SettingChipSelected()
        {
            Settings_cbChip.Items.Clear();
            Settings_cbChip.Items.Add(_chip1);
            Settings_cbChip.Items.Add(_chip2);
            Settings_cbChip.Items.Add(_chip3);
            Settings_cbChip.Items.Add(_chip4);
            Settings_cbChip.Items.Add(_chip5);
            Settings_cbChip.SelectedIndex = 0;

        }
        #endregion

        #region Program

        private void Setting_cbTopMost_Click(object sender, EventArgs e)
        {
            Setting_TopMost();
        }

        private void Setting_TopMost()
        {
            TopMost = Settings_cbTopMost.CheckedState;
        }

        #endregion Program

        #region Force Bet

        private ForceType _forceSelected;

        private enum ForceType
        {
            Follow,
            Adverse
        }

        private void ForceLoad()
        {
            _forceSelected = (ForceType)Settings.Default._forceSelected;
            MainSetting_txtForce.Text = Settings.Default._forcetxt;
            switch (_forceSelected)
            {
                case ForceType.Follow:
                    MainSetting_radForceFollow.Checked = true;
                    break;

                case ForceType.Adverse:
                    MainSetting_radForceAdverse.Checked = true;
                    break;
            }
        }

        private void SettingsForceCheckChanged(object sender)
        {
            ForceCheckChanged();
        }

        private void ForceCheckChanged()
        {
            if (MainSetting_radForceFollow.Checked)
            {
                _forceSelected = ForceType.Follow;
            }
            if (MainSetting_radForceAdverse.Checked)
            {
                _forceSelected = ForceType.Adverse;
            }
        }

        #endregion Force Bet

        #endregion Main Settings

        #region Layout

        #region Variable

        private readonly frmResultImageTester _frmResultImage = new frmResultImageTester();
        private Bitmap _picBit2;
        public int PosX2, PosY2, CatcherX2, CatcherY2, BitWidth, BitHeight;
        private int _player, _banker, _tie, _empty, _all, _allNow, _allMax;
        private bool _allChanging1, _allChanging2, _allChanging3, _scoreFirstTime, _layoutCancel, _layoutYes;
        private bool _layoutListFirstTime = true;

        private string _lastWin, _pStart, _pPlayer, _pBanker, _pConP, _pConB,
            _pChip1, _pChip2, _pChip3, _pChip4, _pChip5,
            _pProcessStart, _pProcessPlayer, _pProcessBanker, _pProcessConP, _pProcessConB,
            _pProcessChip1, _pProcessChip2, _pProcessChip3, _pProcessChip4, _pProcessChip5,
            _xCount, _yCount, _posPic, _chip1, _chip2, _chip3, _chip4, _chip5, _save;

        private static PositionMode _layoutMode;

        #endregion Variable

        #region Load/SaveSetting

        private void Layout_CallPosition()
        {
            dgvSetting.Rows.Clear();
            dgvSetting.Font = new Font("Segoe UI", 9);

            dgvSetting.Rows.Add("Start", "Set XY", "0,0", "-", "-");
            dgvSetting.Rows.Add("P", "Set XY", "0,0", "-", "-");
            dgvSetting.Rows.Add("B", "Set XY", "0,0", "-", "-");
            dgvSetting.Rows.Add("Confirm P", "Set XY", "0,0", "-", "-");
            dgvSetting.Rows.Add("Confirm B", "Set XY", "0,0", "-", "-");

            dgvSetting.Rows.Add("Chip 1", "Set XY", "0,0", 5, "-");
            dgvSetting.Rows.Add("Chip 2", "Set XY", "0,0", 10, "-");
            dgvSetting.Rows.Add("Chip 3", "Set XY", "0,0", 20, "-");
            dgvSetting.Rows.Add("Chip 4", "Set XY", "0,0", 50, "-");
            dgvSetting.Rows.Add("Chip 5", "Set XY", "0,0", 100, "-");

            dgvSetting.ClearSelection();
        }

        private void Layout_LoadFiles2List()
        {
            listLayout.Items.Clear();
            try
            {
                foreach (var file in Directory.EnumerateFiles(@"./Layout/"))
                {
                    var extension = Path.GetExtension(file);
                    if (string.Compare(extension, ".dat", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        var split = file.Replace(".dat", "");
                        listLayout.Items.Add(Path.GetFileName(split));
                    }
                }

                if (listLayout.Items.Count == 0)
                {
                    Layout_AddListbox();
                }

                listLayout.SelectedIndex = 0;
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

                if (_layoutCancel)
                {
                    _layoutCancel = false;
                    return;
                }
                if (Layout_CheckEdit())
                {
                    var msgResult = MessageBox.Show($@"[{LayoutValues.NameList}] was modified, do you want to save it now?",
                        @"Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (msgResult == DialogResult.Yes)
                    {
                        _layoutYes = true;
                        Layout_SaveLayoutList();
                        return;
                    }
                    if (msgResult == DialogResult.Cancel)
                    {
                        _layoutCancel = true;
                        listLayout.SelectedIndex = LayoutValues.Count;
                        return;
                    }
                }
            skip:
                if (listLayout.SelectedItem != null)
                {
                    txtSettingsName.Text = listLayout.SelectedItem.ToString();
                    picResult.Image = null;
                    Layout_LoadList2Data();
                    Layout_GetValue4Check();
                }

                SettingChipSelected();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error 0x2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Layout_LoadList2Data()
        {
            try
            {
                var path = Path.Combine(@"./Layout/", listLayout.SelectedItem + ".dat");
                var list = Layout_LoadData2Strings(path);
                var num = list.Count - 1;

                for (var i = 0; i <= num; i++)
                {
                    var array = list[i].Split(';');
                    switch (i)
                    {
                        case 0:
                            _pStart = array[0];
                            _pProcessStart = array[2];
                            break;

                        case 1:
                            _pPlayer = array[0];
                            _pProcessPlayer = array[2];
                            break;

                        case 2:
                            _pBanker = array[0];
                            _pProcessBanker = array[2];
                            break;

                        case 3:
                            _pConP = array[0];
                            _pProcessConP = array[2];
                            break;

                        case 4:
                            _pConB = array[0];
                            _pProcessConB = array[2];
                            break;

                        case 5:
                            _pChip1 = array[0];
                            _chip1 = array[1];
                            _pProcessChip1 = array[2];
                            break;

                        case 6:
                            _pChip2 = array[0];
                            _chip2 = array[1];
                            _pProcessChip2 = array[2];
                            break;

                        case 7:
                            _pChip3 = array[0];
                            _chip3 = array[1];
                            _pProcessChip3 = array[2];
                            break;

                        case 8:
                            _pChip4 = array[0];
                            _chip4 = array[1];
                            _pProcessChip4 = array[2];
                            break;

                        case 9:
                            _pChip5 = array[0];
                            _chip5 = array[1];
                            _pProcessChip5 = array[2];
                            break;

                        case 10:
                            _xCount = array[0];
                            _yCount = array[1];
                            _posPic = array[2];
                            _layoutMode = (PositionMode)int.Parse(array[3]);
                            break;
                    }
                }

                dgvSetting[2, 0].Value = _pStart;
                dgvSetting[2, 1].Value = _pPlayer;
                dgvSetting[2, 2].Value = _pBanker;
                dgvSetting[2, 3].Value = _pConP;
                dgvSetting[2, 4].Value = _pConB;

                dgvSetting[2, 5].Value = _pChip1;
                dgvSetting[2, 6].Value = _pChip2;
                dgvSetting[2, 7].Value = _pChip3;
                dgvSetting[2, 8].Value = _pChip4;
                dgvSetting[2, 9].Value = _pChip5;

                dgvSetting[3, 5].Value = _chip1;
                dgvSetting[3, 6].Value = _chip2;
                dgvSetting[3, 7].Value = _chip3;
                dgvSetting[3, 8].Value = _chip4;
                dgvSetting[3, 9].Value = _chip5;

                dgvSetting[4, 0].Value = _pProcessStart;
                dgvSetting[4, 1].Value = _pProcessPlayer;
                dgvSetting[4, 2].Value = _pProcessBanker;
                dgvSetting[4, 3].Value = _pProcessConP;
                dgvSetting[4, 4].Value = _pProcessConB;

                dgvSetting[4, 5].Value = _pProcessChip1;
                dgvSetting[4, 6].Value = _pProcessChip2;
                dgvSetting[4, 7].Value = _pProcessChip3;
                dgvSetting[4, 8].Value = _pProcessChip4;
                dgvSetting[4, 9].Value = _pProcessChip5;

                txtResultXCount.Text = _xCount;
                txtResultYCount.Text = _yCount;
                lblResultXY.Text = _posPic;

                LayoutLoadMode();

                var value = _posPic.Split('(', ',', ')');

                PosX2 = int.Parse(value[1]);
                PosY2 = int.Parse(value[2]);

                CatcherX2 = int.Parse(value[4]);
                CatcherY2 = int.Parse(value[5]);
                Layout_ChangeMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error 0x3", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<string> Layout_LoadData2Strings(string str)
        {
            var stringBuilder = new StringBuilder();
            var list = new List<string>();
            List<string> result;
            if (File.Exists(str))
            {
                try
                {
                    var streamReader = new StreamReader(str);
                    var stringBuilder2 = stringBuilder;
                    while (streamReader.Peek() != -1)
                    {
                        var text = streamReader.ReadLine();
                        if (text != null && text.IndexOf("--", StringComparison.Ordinal) == -1)
                        {
                            stringBuilder2.Append(" " + text);
                        }
                        if (text != null && !string.Equals(text.Trim(), ""))
                        {
                            list.Add(text.Trim());
                        }
                    }
                    streamReader.Close();
                }
                catch
                {
                }

                result = list;
            }
            else
            {
                MessageBox.Show($@"[{str}] note found!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = null;
            }
            return result;
        }

        private void BtnSaveLayout_Click(object sender, EventArgs e)
        {
            Layout_SaveLayoutList();
        }

        private void Layout_SaveLayoutList()
        {
            var name = txtSettingsName.Text;
            _save = $"{txtResultXCount.Text};{txtResultYCount.Text};{lblResultXY.Text};{(int)_layoutMode}";
            if (Layout_ChangeNameList())
            {
                Layout_SaveList(dgvSetting, txtSettingsName.Text, _save);

                if (_layoutYes)
                {
                    name = listLayout.SelectedItem.ToString();
                    _layoutYes = false;
                }

                Layout_SelectListByName(name);

                LayoutValues.Saved = false;
            }
        }

        private bool Layout_ChangeNameList()
        {
            if (LayoutValues.ListSelected != txtSettingsName.Text)
            //if (listLayout.SelectedItem.ToString() != txtSettingsName.Text)
            {
                var path = Path.Combine(@"./Layout/", txtSettingsName.Text + ".dat");
                if (Layout_CheckFile(path)) // ถ้ามีไฟล์(ชื่อใหม่)
                {
                    var msgResult = MessageBox.Show($@"Has [{txtSettingsName.Text}] file, do you want to replace it now?",
                        @"Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (msgResult == DialogResult.No)
                    {
                        txtSettingsName.Text = listLayout.SelectedItem.ToString();
                        return false;
                    }
                }
                // path = Path.Combine(@"./Layout/", listLayout.SelectedItem + ".dat");
                path = Path.Combine(@"./Layout/", LayoutValues.ListSelected + ".dat");
                var file = new FileInfo(path);
                Layout_Rename(file, txtSettingsName.Text + ".dat");
            }
            LayoutValues.Saved = true;
            return true;
        }

        public static bool Layout_CheckFile(string fileInfo)
        {
            return File.Exists(fileInfo);
        }

        public static void Layout_Rename(FileInfo fileInfo, string newName)
        {
            try
            {
                if (fileInfo.Directory != null) fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + newName);
            }
            catch
            {
            }
        }

        public static void Layout_SaveList(DataGridView dgv, string name, string another)
        {
            checked
            {
                try
                {
                    var path = Path.Combine(@"./Layout/", name + ".dat");
                    var streamWriter = new StreamWriter(path);
                    var num = dgv.RowCount - 1;
                    for (var i = 0; i <= num; i++)
                    {
                        var value = string.Concat(
                            dgv[2, i].Value.ToString(), ";",
                            dgv[3, i].Value.ToString(), ";",
                            dgv[4, i].Value.ToString());
                        streamWriter.Write(value);
                        streamWriter.Write(Environment.NewLine);
                    }
                    streamWriter.Write(another);
                    streamWriter.Write(Environment.NewLine);
                    streamWriter.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Error 0x4", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Layout_SelectListByName(string name)
        {
            Layout_LoadFiles2List();
            listLayout.SelectedIndex = 0;
            try
            {
                for (var i = 0; i < listLayout.Items.Count; i++)
                {
                    if (string.Equals(name, listLayout.SelectedItem.ToString(), StringComparison.Ordinal))
                    {
                        listLayout.SelectedIndex = i;
                        break;
                    }
                    listLayout.SelectedIndex++;
                }
            }
            catch
            {
            }
        }

        #region CheckEdit

        private bool Layout_CheckEdit()
        {
            if (LayoutValues.NameList != txtSettingsName.Text ||
                //LayoutValues.TxtX != txtResultXCount.Text ||
                //LayoutValues.TxtY != txtResultYCount.Text ||
                //LayoutValues.LblXy != lblResultXY.Text ||
                //LayoutValues.Mode != cbBackground.CheckedState ||

                LayoutValues.TxtX != _xCount ||
                LayoutValues.TxtY != _yCount ||
                LayoutValues.LblXy != _posPic ||
                LayoutValues.Mode != (int)_layoutMode ||

                LayoutValues._pStart != _pStart ||
                LayoutValues._pPlayer != _pPlayer ||
                LayoutValues._pBanker != _pBanker ||
                LayoutValues._pConP != _pConP ||
                LayoutValues._pConB != _pConB ||
                LayoutValues._pChip1 != _pChip1 ||
                LayoutValues._pChip2 != _pChip2 ||
                LayoutValues._pChip3 != _pChip3 ||
                LayoutValues._pChip4 != _pChip4 ||
                LayoutValues._pChip5 != _pChip5 ||
                LayoutValues._chip1 != _chip1 ||
                LayoutValues._chip2 != _chip2 ||
                LayoutValues._chip3 != _chip3 ||
                LayoutValues._chip4 != _chip4 ||
                LayoutValues._chip5 != _chip5 ||
                LayoutValues._pProcessStart != _pProcessStart ||
                LayoutValues._pProcessPlayer != _pProcessPlayer ||
                LayoutValues._pProcessBanker != _pProcessBanker ||
                LayoutValues._pProcessConP != _pProcessConP ||
                LayoutValues._pProcessConB != _pProcessConB ||
                LayoutValues._pProcessChip1 != _pProcessChip1 ||
                LayoutValues._pProcessChip2 != _pProcessChip2 ||
                LayoutValues._pProcessChip3 != _pProcessChip3 ||
                LayoutValues._pProcessChip4 != _pProcessChip4 ||
                LayoutValues._pProcessChip5 != _pProcessChip5)
            {
                if (!LayoutValues.Saved)
                {
                    return true;
                }
            }

            return false;
        }

        private void Layout_GetValue4Check()
        {
            LayoutValues.NameList = txtSettingsName.Text;
            LayoutValues.TxtX = txtResultXCount.Text;
            LayoutValues.TxtY = txtResultYCount.Text;
            LayoutValues.LblXy = lblResultXY.Text;
            LayoutValues.Mode = (int)_layoutMode;

            LayoutValues._pStart = dgvSetting[2, 0].Value.ToString();
            LayoutValues._pPlayer = dgvSetting[2, 1].Value.ToString();
            LayoutValues._pBanker = dgvSetting[2, 2].Value.ToString();
            LayoutValues._pConP = dgvSetting[2, 3].Value.ToString();
            LayoutValues._pConB = dgvSetting[2, 4].Value.ToString();

            LayoutValues._pChip1 = dgvSetting[2, 5].Value.ToString();
            LayoutValues._pChip2 = dgvSetting[2, 6].Value.ToString();
            LayoutValues._pChip3 = dgvSetting[2, 7].Value.ToString();
            LayoutValues._pChip4 = dgvSetting[2, 8].Value.ToString();
            LayoutValues._pChip5 = dgvSetting[2, 9].Value.ToString();

            LayoutValues._chip1 = dgvSetting[3, 5].Value.ToString();
            LayoutValues._chip2 = dgvSetting[3, 6].Value.ToString();
            LayoutValues._chip3 = dgvSetting[3, 7].Value.ToString();
            LayoutValues._chip4 = dgvSetting[3, 8].Value.ToString();
            LayoutValues._chip5 = dgvSetting[3, 9].Value.ToString();

            LayoutValues._pProcessStart = dgvSetting[4, 0].Value.ToString();
            LayoutValues._pProcessPlayer = dgvSetting[4, 1].Value.ToString();
            LayoutValues._pProcessBanker = dgvSetting[4, 2].Value.ToString();
            LayoutValues._pProcessConP = dgvSetting[4, 3].Value.ToString();
            LayoutValues._pProcessConB = dgvSetting[4, 4].Value.ToString();

            LayoutValues._pProcessChip1 = dgvSetting[4, 5].Value.ToString();
            LayoutValues._pProcessChip2 = dgvSetting[4, 6].Value.ToString();
            LayoutValues._pProcessChip3 = dgvSetting[4, 7].Value.ToString();
            LayoutValues._pProcessChip4 = dgvSetting[4, 8].Value.ToString();
            LayoutValues._pProcessChip5 = dgvSetting[4, 9].Value.ToString();

            LayoutValues.Count = listLayout.SelectedIndex;
            LayoutValues.ListSelected = listLayout.SelectedItem.ToString();

            #region Old

            //LayoutValues.TxtX = _xCount;
            //LayoutValues.TxtY = _yCount;
            //LayoutValues.LblXy = _posPic;
            //LayoutValues.Mode = _layoutMode;

            //LayoutValues._pStart = _pStart;
            //LayoutValues._pPlayer = _pPlayer;
            //LayoutValues._pBanker = _pBanker;
            //LayoutValues._pConP = _pConP;
            //LayoutValues._pConB = _pConB;
            //LayoutValues._pChip1 = _pChip1;
            //LayoutValues._pChip2 = _pChip2;
            //LayoutValues._pChip3 = _pChip3;
            //LayoutValues._pChip4 = _pChip4;
            //LayoutValues._pChip5 = _pChip5;

            //LayoutValues._chip1 = _chip1;
            //LayoutValues._chip2 = _chip2;
            //LayoutValues._chip3 = _chip3;
            //LayoutValues._chip4 = _chip4;
            //LayoutValues._chip5 = _chip5;

            //LayoutValues._pProcessStart = _pProcessStart;
            //LayoutValues._pProcessPlayer = _pProcessPlayer;
            //LayoutValues._pProcessBanker = _pProcessBanker;
            //LayoutValues._pProcessConP = _pProcessConP;
            //LayoutValues._pProcessConB = _pProcessConB;
            //LayoutValues._pProcessChip1 = _pProcessChip1;
            //LayoutValues._pProcessChip2 = _pProcessChip2;
            //LayoutValues._pProcessChip3 = _pProcessChip3;
            //LayoutValues._pProcessChip4 = _pProcessChip4;
            //LayoutValues._pProcessChip5 = _pProcessChip5;

            #endregion Old
        }

        private void Layout_UpdateDataGridViewValue()
        {
            _pStart = dgvSetting[2, 0].Value.ToString();
            _pPlayer = dgvSetting[2, 1].Value.ToString();
            _pBanker = dgvSetting[2, 2].Value.ToString();
            _pConP = dgvSetting[2, 3].Value.ToString();
            _pConB = dgvSetting[2, 4].Value.ToString();

            _pChip1 = dgvSetting[2, 5].Value.ToString();
            _pChip2 = dgvSetting[2, 6].Value.ToString();
            _pChip3 = dgvSetting[2, 7].Value.ToString();
            _pChip4 = dgvSetting[2, 8].Value.ToString();
            _pChip5 = dgvSetting[2, 9].Value.ToString();

            _chip1 = dgvSetting[3, 5].Value.ToString();
            _chip2 = dgvSetting[3, 6].Value.ToString();
            _chip3 = dgvSetting[3, 7].Value.ToString();
            _chip4 = dgvSetting[3, 8].Value.ToString();
            _chip5 = dgvSetting[3, 9].Value.ToString();

            _pProcessStart = dgvSetting[4, 0].Value.ToString();
            _pProcessPlayer = dgvSetting[4, 1].Value.ToString();
            _pProcessBanker = dgvSetting[4, 2].Value.ToString();
            _pProcessConP = dgvSetting[4, 3].Value.ToString();
            _pProcessConB = dgvSetting[4, 4].Value.ToString();

            _pProcessChip1 = dgvSetting[4, 5].Value.ToString();
            _pProcessChip2 = dgvSetting[4, 6].Value.ToString();
            _pProcessChip3 = dgvSetting[4, 7].Value.ToString();
            _pProcessChip4 = dgvSetting[4, 8].Value.ToString();
            _pProcessChip5 = dgvSetting[4, 9].Value.ToString();

            _xCount = txtResultXCount.Text;
            _yCount = txtResultYCount.Text;
            _posPic = lblResultXY.Text;
            PositionChangeMode();
        }

        #endregion CheckEdit

        #endregion Load/SaveSetting

        #region Add/Delete

        private void BtnAddList_Click(object sender, EventArgs e)
        {
            Layout_AddListbox();
        }

        private void Layout_AddListbox()
        {
            try
            {
                Layout_CallPosition();
                _save = "15;6;(0, 0) (0, 0);0";
                var count = listLayout.Items.Count;
                var newItem = "New Layout " + (count + 1);
                var path = Path.Combine(@"./Layout/", newItem + ".dat");

                if (Layout_CheckFile(path))
                {
                    newItem = "New Layout " + (count + 1);
                }

                Layout_SaveList(dgvSetting, newItem, _save);
                Layout_LoadFiles2List();
                listLayout.SelectedIndex = checked(listLayout.Items.Count - 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error 0x5", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listLayout.SelectedItem != null)
                {
                    var itemList = listLayout.SelectedItem;

                    if (MessageBox.Show($@"Confirm to delete {itemList} ?", @"Confirmation",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                    {
                        //var path = Path.Combine(@"./Layout/", txtSettingsName.Text + ".dat");
                        var path = Path.Combine(@"./Layout/", LayoutValues.NameList + ".dat");
                        // File.Delete(path);
                        var file = new FileInfo(path);
                        Layout_Delete(file);

                        var num = listLayout.SelectedIndex;
                        Layout_LoadFiles2List();

                        if (num == 0)
                        {
                            listLayout.SelectedIndex = 0;
                        }
                        else if (num >= listLayout.Items.Count)
                        {
                            listLayout.SelectedIndex = num - 1;
                        }
                        else
                        {
                            listLayout.SelectedIndex = num;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error 0x6", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Layout_Delete(FileInfo fileInfo)
        {
            try
            {
                fileInfo.Delete();
            }
            catch
            {
            }
        }

        #endregion Add/Delete

        #region Position Settings

        private void DgvSetting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // var layer = new LayerForm();
                if (e.ColumnIndex == 1)
                {
                    var column = e.ColumnIndex;
                    var row = e.RowIndex;

                    if (_layoutMode == PositionMode.Background)
                    {
                        Visible = false;
                        using (var getColor = new FrmColorInfo())
                        {
                            getColor.ShowDialog();
                        }
                        Visible = true;
                        if (Values.CloseFrom)
                        {
                            dgvSetting[column + 1, row].Value = $"({Values.CheckX},{Values.CheckY})";
                            dgvSetting[column + 3, row].Value = $"{Values.Color}";
                            dgvSetting[column + 4, row].Value = $"{Values.TitleName}";
                            Values.CloseFrom = false;
                        }
                    }
                    else
                    {
                        Visible = false;
                        using (var layer = new LayerForm())
                        {
                            layer.ShowDialog();
                        }
                        Visible = true;

                        if (Values.CloseFrom)
                        {
                            dgvSetting[column + 1, row].Value = $"({Values.CheckX},{Values.CheckY})";
                            dgvSetting[column + 3, row].Value = $"{Values.Color}";
                            Values.CloseFrom = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error 0x7", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (e.ColumnIndex == 3 && dgvSetting.CurrentRow.Index >= 5)
                {
                    var column = e.ColumnIndex;
                    var row = e.RowIndex;
                    var oldValue = dgvSetting[column, row].Value.ToString();
                    var input = TFiveInputBox.Show("Please enter your name", oldValue, true);

                    if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
                    {
                        dgvSetting.CurrentCell.Value = input;
                        if (dgvSetting.CurrentRow.Index == 5)
                        {
                            _chip1 = input;
                            return;
                        }
                        if (dgvSetting.CurrentRow.Index == 6)
                        {
                            _chip2 = input;
                            return;
                        }
                        if (dgvSetting.CurrentRow.Index == 7)
                        {
                            _chip3 = input;
                            return;
                        }
                        if (dgvSetting.CurrentRow.Index == 8)
                        {
                            _chip4 = input;
                            return;
                        }
                        if (dgvSetting.CurrentRow.Index == 9)
                        {
                            _chip5 = input;
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Value is Null, Empty or White space", @"Error 0x8", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error 0x9", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Layout_UpdateDataGridViewValue();
        }

        private void DgvSetting_SelectionChanged(object sender, EventArgs e)
        {
            dgvSetting.ClearSelection();
        }

        #endregion Position Settings

        #region ModeSettings

        private enum PositionMode
        {
            Normal,
            Background,
            Picture
        }

        private void PositionSelectMode(object sender)
        {
            PositionChangeMode();
        }

        private void PositionChangeMode()
        {
            if (Layout_radNormal.Checked)
            {
                _layoutMode = PositionMode.Normal;
            }
            if (Layout_radPicture.Checked)
            {
                _layoutMode = PositionMode.Picture;
            }
            if (Layout_radBackGround.Checked)
            {
                _layoutMode = PositionMode.Background;
            }

            Layout_ChangeMode();
        }

        private void LayoutLoadMode()
        {
            switch (_layoutMode)
            {
                case PositionMode.Normal:
                    Layout_radNormal.Checked = true;
                    break;

                case PositionMode.Picture:
                    Layout_radPicture.Checked = true;
                    break;

                case PositionMode.Background:
                    Layout_radBackGround.Checked = true;
                    break;
            }
        }

        private void Layout_ChangeMode()
        {
            groupResult.Visible = _layoutMode == PositionMode.Picture;

            Size = _layoutMode == PositionMode.Picture ? new Size(1055, 575) : new Size(665, 575);

            //  panel5.Size = _layoutMode == PositionMode.Background ? new Size(405, 340) : new Size(280, 340);
            panel5.Size = _layoutMode == PositionMode.Picture ? new Size(280, 340) : new Size(405, 340);

            Layout_radNormal.Location = new Point(3, 301);
            Layout_radBackGround.Location = new Point(129, 301);
            Layout_radPicture.Location = new Point(3, 322);

            txtSettingsName.Location = new Point(61, 3);
        }

        #endregion ModeSettings

        #region CatcherControl

        private void Layout_CatcherController(Layout_ControlType modeType)
        {
            if (Variable.Catcher() == null) return;
            var screenCatcher = Variable.Catcher();
            switch (modeType)
            {
                case Layout_ControlType.Up:
                    checked
                    {
                        screenCatcher.Top--;
                    }

                    break;

                case Layout_ControlType.Down:
                    checked
                    {
                        screenCatcher.Top++;
                    }

                    break;

                case Layout_ControlType.Right:
                    checked
                    {
                        screenCatcher.Left++;
                    }

                    break;

                case Layout_ControlType.Left:
                    checked
                    {
                        screenCatcher.Left--;
                    }

                    break;

                case Layout_ControlType.DecHeight:
                    checked
                    {
                        screenCatcher.Height--;
                    }

                    break;

                case Layout_ControlType.DecWidth:
                    checked
                    {
                        screenCatcher.Width--;
                    }

                    break;

                case Layout_ControlType.IncHeight:
                    checked
                    {
                        screenCatcher.Height++;
                    }

                    break;

                case Layout_ControlType.IncWidth:
                    checked
                    {
                        screenCatcher.Width++;
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(modeType), modeType, null);
            }
        }

        private enum Layout_ControlType
        {
            Up,
            Right,
            Down,
            Left,
            DecHeight,
            DecWidth,
            IncHeight,
            IncWidth
        }

        internal static void Layout_CatcherShow()
        {
            if (Variable.Catcher() == null || Variable.Catcher().IsDisposed)
            {
                Variable.ScreenCatcher(new ScreenCatcher());
            }
            Variable.Catcher().Show();
        }

        private void Layout_Catcher()
        {
            try
            {
                Layout_CatcherShow();
                if (PosX2 > 0 && PosY2 > 0 && CatcherX2 > 0 && CatcherY2 > 0)
                {
                    Variable.Catcher().GetPosition(PosX2, PosY2, CatcherX2, CatcherY2);
                    tmResult.Stop();
                }
                tmCatcher.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error 0x10", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TmCatcher_Tick(object sender, EventArgs e)
        {
            try
            {
                Variable.Catcher().GetBitMap();
                _picBit2 = Variable.Catcher().PicShow;
                PosX2 = Variable.Catcher().RecLeft;
                PosY2 = Variable.Catcher().RecTop;
                CatcherX2 = Variable.Catcher().RecWidth;
                CatcherY2 = Variable.Catcher().RecHeight;
                picResult.Image = _picBit2;
                lblResultXY.Text = $@"({PosX2}, {PosY2}) ({CatcherX2}, {CatcherY2})";
                tmResult.Start();
            }
            catch
            {
            }
            if (Variable.Catcher() != null && Variable.Catcher().IsDisposed)
            {
                tmCatcher.Stop();
                tmResult.Stop();

                btnSetResult.Enabled = true;
                btnSetResult.Text = @"Set Result";
            }
        }

        #endregion CatcherControl

        #region Result

        private void TmResult_Tick(object sender, EventArgs e)
        {
            try
            {
                picResult.Image = ScreenCatcher.BuildBitmap(PosX2, PosY2, CatcherX2, CatcherY2);
            }
            catch
            {
            }
        }

        private void BtnSetResult_Click(object sender, EventArgs e)
        {
            if (btnSetResult.Text == @"Set Result")
            {
                Layout_Catcher();
                btnSetResult.Text = @"Confirm Result";
            }
            else
            {
                Variable.Catcher().Close();
                btnSetResult.Text = @"Set Result";
            }
        }

        private void LinklbShowTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                tmCatcher.Stop();
                _frmResultImage.GetPicture((Bitmap)picResult.Image, int.Parse(txtResultXCount.Text), int.Parse(txtResultYCount.Text));
                _frmResultImage.ShowDialog();
            }
            catch
            {
            }
        }

        private void TmRealtimeResult_Tick(object sender, EventArgs e)
        {
            if (tmCatcher.Enabled)
                return;
            try
            {
                picResult2.Image = ScreenCatcher.BuildBitmap(PosX2, PosY2, CatcherX2, CatcherY2);
                Layout_GetScore((Bitmap)picResult2.Image, int.Parse(txtResultXCount.Text), int.Parse(txtResultYCount.Text));
            }
            catch
            {
            }
        }

        private void BtnResultUp_Click(object sender, EventArgs e)
        {
            Layout_CatcherController(Layout_ControlType.Up);
        }

        private void BtnResultYDec_Click(object sender, EventArgs e)
        {
            Layout_CatcherController(Layout_ControlType.DecHeight);
        }

        private void BtnResultRight_Click(object sender, EventArgs e)
        {
            Layout_CatcherController(Layout_ControlType.Right);
        }

        private void BtnResultXInc_Click(object sender, EventArgs e)
        {
            Layout_CatcherController(Layout_ControlType.IncWidth);
        }

        private void BtnResultYInc_Click(object sender, EventArgs e)
        {
            Layout_CatcherController(Layout_ControlType.IncHeight);
        }

        private void BtnResultDown_Click(object sender, EventArgs e)
        {
            Layout_CatcherController(Layout_ControlType.Down);
        }

        private void BtnResultXDec_Click(object sender, EventArgs e)
        {
            Layout_CatcherController(Layout_ControlType.DecWidth);
        }

        private void BtnResultLeft_Click(object sender, EventArgs e)
        {
            Layout_CatcherController(Layout_ControlType.Left);
        }

        #endregion Result

        #region Function Get PTB

        private void BtStart_Click(object sender, EventArgs e)
        {
            btStart.Text = btStart.Text.EndsWith("หยุด") ? "เริ่ม" : "หยุด";
            try
            {
                switch (btStart.Text)
                {
                    case "หยุด":
                        tmStart.Start();
                        tmRealtimeResult.Start();
                        btnSetResult.Enabled = false;
                        tmScore.Start();
                        _scoreFirstTime = true;
                        //_strFirst = true;
                        break;

                    case "เริ่ม":
                        tmStart.Stop();
                        tmRealtimeResult.Stop();
                        btnSetResult.Enabled = true;
                        tmScore.Stop();
                        _scoreFirstTime = false;
                        // _strFirst = false;
                        break;
                }
            }
            catch
            {
            }
        }

        private void TmStart_Tick(object sender, EventArgs e)
        {
            _player = 0;
            _banker = 0;
            _tie = 0;
            _empty = 0;
            _lastWin = null;
            try
            {
                var columnsCount = int.Parse(txtResultXCount.Text);
                var rowCount = int.Parse(txtResultYCount.Text);

                //add
                try
                {
                    if (dataGridView1.ColumnCount < columnsCount)
                    {
                        for (var i = 0; i < columnsCount; i++)
                        {
                            dataGridView1.Columns.Add(i.ToString(), i.ToString());

                            for (var j = 0; j < rowCount; j++)
                            {
                                if (dataGridView1.RowCount < rowCount)
                                {
                                    dataGridView1.Rows.Add("");
                                }
                            }
                        }
                    }
                }
                catch
                {
                }

                //update value
                try
                {
                    if (dataGridView1.ColumnCount == columnsCount && dataGridView1.RowCount == rowCount)
                    {
                        for (var i = 0; i < columnsCount; i++)
                        {
                            for (var j = 0; j < rowCount; j++)
                            {
                                var str = Layout_Bitmap2Char(j, i);
                                dataGridView1[i, j].Value = str;
                                if (str == "B")
                                {
                                    dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.Red;
                                    _banker++;
                                    _lastWin = "Banker";
                                }

                                if (str == "T")
                                {
                                    dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.LimeGreen;
                                    _tie++;
                                    _lastWin = "Tie";
                                }

                                if (str == "P")
                                {
                                    dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.Blue;
                                    _player++;
                                    _lastWin = "Player";
                                }

                                if (str == " ")
                                {
                                    dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.White;
                                    _empty++;
                                }

                                if (str == "Error")
                                {
                                    dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.Black;
                                }
                            }
                        }

                        dataGridView1.ClearSelection();
                    }
                }
                catch
                {
                }

                _all = _player + _banker + _tie;
                lbScrore.Text = $@"Player: {_player}   Banker: {_banker}   Tie: {_tie}   Empty: {_empty}   All: {_all}/{_player + _banker + _tie + _empty}   LastWin: {_lastWin}";
            }
            catch
            {
            }
        }

        private string Layout_Bitmap2Char(int row, int cell)
        {
            try
            {
                picBitmap.Image = (Bitmap)dgvCurrentResultImg.Rows[row].Cells[cell].Value;
                var img = new Bitmap(picBitmap.Image);
                var pixel = img.GetPixel(BitWidth / 2, BitHeight / 2);

                if (pixel.R > pixel.G && pixel.R > pixel.B)
                {
                    return "B";
                }

                if (pixel.G > pixel.R && pixel.G > pixel.B)
                {
                    return "T";
                }

                if (pixel.B > pixel.R && pixel.B > pixel.G)
                {
                    return "P";
                }
                if (pixel.B == pixel.R && pixel.R == pixel.G)
                {
                    pixel = img.GetPixel(BitWidth / 2, (BitHeight / 2) - 1);
                    if (pixel.R > pixel.G && pixel.R > pixel.B)
                    {
                        return "B";
                    }
                    if (pixel.G > pixel.R && pixel.G > pixel.B)
                    {
                        return "T";
                    }

                    if (pixel.B > pixel.R && pixel.B > pixel.G)
                    {
                        return "P";
                    }

                    if (pixel.B == pixel.R && pixel.R == pixel.G)
                    {
                        pixel = img.GetPixel(BitWidth / 2, (BitHeight / 2) - 2);
                        if (pixel.R > pixel.G && pixel.R > pixel.B)
                        {
                            return "B";
                        }
                        if (pixel.G > pixel.R && pixel.G > pixel.B)
                        {
                            return "T";
                        }

                        if (pixel.B > pixel.R && pixel.B > pixel.G)
                        {
                            return "P";
                        }
                        if (pixel.B == pixel.R && pixel.R == pixel.G)
                        {
                            pixel = img.GetPixel(BitWidth / 2, (BitHeight / 2) + 1);
                            if (pixel.R > pixel.G && pixel.R > pixel.B)
                            {
                                return "B";
                            }
                            if (pixel.G > pixel.R && pixel.G > pixel.B)
                            {
                                return "T";
                            }

                            if (pixel.B > pixel.R && pixel.B > pixel.G)
                            {
                                return "P";
                            }
                            if (pixel.B == pixel.R && pixel.R == pixel.G)
                            {
                                pixel = img.GetPixel(BitWidth / 2, (BitHeight / 2) + 2);
                                if (pixel.R > pixel.G && pixel.R > pixel.B)
                                {
                                    return "B";
                                }
                                if (pixel.G > pixel.R && pixel.G > pixel.B)
                                {
                                    return "T";
                                }

                                if (pixel.B > pixel.R && pixel.B > pixel.G)
                                {
                                    return "P";
                                }
                            }
                        }
                    }

                    return " ";
                }
                return "Error";
            }
            catch
            {
                return "Error";
            }
        }

        private unsafe void Layout_GetScore(Bitmap picture, int xCount, int yCount)
        {
            var frmLayout = new FrmMain();
            void* ptr = stackalloc byte[44];
            try
            {
                if (xCount > 0 & yCount > 0 && picture != null && picture.Width >= 10 && picture.Height >= 10)
                {
                    frmLayout.PosX2 = xCount;
                    frmLayout.PosY2 = yCount;
                    *(int*)((byte*)ptr + 8) = 0;
                    *(int*)((byte*)ptr + 4) = 0;
                    var list = Layout_GridBuild(frmLayout, picture, ref *(int*)((byte*)ptr + 8), ref *(int*)((byte*)ptr + 4));
                    *(int*)((byte*)ptr + 8) = checked(*(int*)((byte*)ptr + 8) + 6);
                    *(int*)((byte*)ptr + 4) = checked(*(int*)((byte*)ptr + 4) + 6);
                    var list2 = new List<string>();
                    dgvCurrentResultImg.Columns.Clear();
                    ref var ptr2 = ref *(int*)((byte*)ptr + 12);
                    var num = 0;
                    *(int*)((byte*)ptr + 28) = checked(xCount - 1);
                    ptr2 = num;
                    while (*(int*)((byte*)ptr + 12) <= *(int*)((byte*)ptr + 28))
                    {
                        var dataGridViewImageColumn = new DataGridViewImageColumn();
                        dataGridViewImageColumn.Width = *(int*)((byte*)ptr + 8);
                        BitWidth = dataGridViewImageColumn.Width;
                        dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
                        dgvCurrentResultImg.Columns.Add(dataGridViewImageColumn);
                        *(int*)((byte*)ptr + 12) = checked(*(int*)((byte*)ptr + 12) + 1);
                    }
                    ref var ptr3 = ref *(int*)((byte*)ptr + 16);
                    var num2 = 0;
                    *(int*)((byte*)ptr + 32) = checked(yCount - 1);
                    ptr3 = num2;
                    while (*(int*)((byte*)ptr + 16) <= *(int*)((byte*)ptr + 32))
                    {
                        dgvCurrentResultImg.Rows.Add(list2.ToArray());
                        dgvCurrentResultImg.Rows[checked(dgvCurrentResultImg.Rows.Count - 1)].Height = *(int*)((byte*)ptr + 4);
                        BitHeight = *(int*)((byte*)ptr + 4);
                        *(int*)((byte*)ptr + 16) = checked(*(int*)((byte*)ptr + 16) + 1);
                    }
                    dgvCurrentResultImg.ClearSelection();
                    *(int*)ptr = 0;
                    ref var ptr4 = ref *(int*)((byte*)ptr + 20);
                    var num3 = 0;
                    *(int*)((byte*)ptr + 36) = checked(xCount - 1);
                    ptr4 = num3;
                    while (*(int*)((byte*)ptr + 20) <= *(int*)((byte*)ptr + 36))
                    {
                        ref var ptr5 = ref *(int*)((byte*)ptr + 24);
                        var num4 = 0;
                        *(int*)((byte*)ptr + 40) = checked(yCount - 1);
                        ptr5 = num4;
                        while (*(int*)((byte*)ptr + 24) <= *(int*)((byte*)ptr + 40))
                        {
                            var value = new Bitmap(*(int*)((byte*)ptr + 8), *(int*)((byte*)ptr + 4));
                            if (*(int*)ptr < list.Count)
                            {
                                value = list[*(int*)ptr];
                                dgvCurrentResultImg.Rows[*(int*)((byte*)ptr + 24)].Cells[*(int*)((byte*)ptr + 20)].Value = value;
                                dgvCurrentResultImg.Rows[*(int*)((byte*)ptr + 24)].Cells[*(int*)((byte*)ptr + 20)].Style.BackColor = Color.DarkGray;
                            }
                            *(int*)ptr = checked(*(int*)ptr + 1);
                            *(int*)((byte*)ptr + 24) = checked(*(int*)((byte*)ptr + 24) + 1);
                        }
                        *(int*)((byte*)ptr + 20) = checked(*(int*)((byte*)ptr + 20) + 1);
                    }
                }
            }
            catch
            {
            }
        }

        internal static unsafe List<Bitmap> Layout_GridBuild(FrmMain frmLayout, Bitmap picture, ref int posX, ref int posY)
        {
            void* ptr = stackalloc byte[48];
            var list = new List<Bitmap>();
            *(int*)((byte*)ptr + 4) = 0;
            *(int*)ptr = 0;
            if (frmLayout != null && picture.Width > 10 && picture.Height > 10)
            {
                if (frmLayout.PosX2 > 0 & frmLayout.PosY2 > 0)
                {
                    var d = new decimal(picture.Width / (double)frmLayout.PosX2);
                    var d2 = new decimal(picture.Height / (double)frmLayout.PosY2);
                    ref var ptr2 = ref *(int*)((byte*)ptr + 16);
                    var num = 0;
                    *(int*)((byte*)ptr + 40) = checked(frmLayout.PosX2 - 1);
                    ptr2 = num;
                    while (*(int*)((byte*)ptr + 16) <= *(int*)((byte*)ptr + 40))
                    {
                        *(int*)((byte*)ptr + 8) = (int)Math.Round((Convert.ToDouble(decimal.Multiply(d, new decimal(*(int*)((byte*)ptr + 16)))) + 0.5));
                        *(int*)((byte*)ptr + 12) = 0;
                        if (*(int*)((byte*)ptr + 16) < checked(frmLayout.PosX2 - 1))
                        {
                            *(int*)((byte*)ptr + 20) = (int)Math.Round((Convert.ToDouble(decimal.Multiply(d, new decimal(checked(*(int*)((byte*)ptr + 16) + 1)))) + 0.5));
                            *(int*)((byte*)ptr + 12) = checked(*(int*)((byte*)ptr + 20) - *(int*)((byte*)ptr + 8));
                        }
                        else
                        {
                            *(int*)((byte*)ptr + 12) = checked(picture.Width - *(int*)((byte*)ptr + 8));
                        }
                        ref var ptr3 = ref *(int*)((byte*)ptr + 32);
                        var num2 = 0;
                        *(int*)((byte*)ptr + 44) = checked(frmLayout.PosY2 - 1);
                        ptr3 = num2;
                        while (*(int*)((byte*)ptr + 32) <= *(int*)((byte*)ptr + 44))
                        {
                            *(int*)((byte*)ptr + 28) = (int)Math.Round((Convert.ToDouble(decimal.Multiply(d2, new decimal(*(int*)((byte*)ptr + 32)))) + 0.5));
                            *(int*)((byte*)ptr + 24) = 0;
                            if (*(int*)((byte*)ptr + 32) < checked(frmLayout.PosY2 - 1))
                            {
                                *(int*)((byte*)ptr + 36) = (int)Math.Round((Convert.ToDouble(decimal.Multiply(d2, new decimal(checked(*(int*)((byte*)ptr + 32) + 1)))) + 0.5));
                                *(int*)((byte*)ptr + 24) = checked(*(int*)((byte*)ptr + 36) - *(int*)((byte*)ptr + 28));
                            }
                            else
                            {
                                *(int*)((byte*)ptr + 24) = checked(picture.Height - *(int*)((byte*)ptr + 28));
                            }
                            if (*(int*)((byte*)ptr + 24) > 5 & *(int*)((byte*)ptr + 12) > 5)
                            {
                                var rect = new Rectangle(*(int*)((byte*)ptr + 8), *(int*)((byte*)ptr + 28), *(int*)((byte*)ptr + 12), *(int*)((byte*)ptr + 24));
                                var item = picture.Clone(rect, PixelFormat.Format32bppArgb);
                                list.Add(item);
                                if (*(int*)((byte*)ptr + 12) > *(int*)((byte*)ptr + 4))
                                {
                                    *(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 12);
                                }
                                if (*(int*)((byte*)ptr + 24) > *(int*)ptr)
                                {
                                    *(int*)ptr = *(int*)((byte*)ptr + 24);
                                }
                            }
                            *(int*)((byte*)ptr + 32) = checked(*(int*)((byte*)ptr + 32) + 1);
                        }
                        *(int*)((byte*)ptr + 16) = checked(*(int*)((byte*)ptr + 16) + 1);
                    }
                }
            }
            posX = *(int*)((byte*)ptr + 4);
            posY = *(int*)ptr;
            return list;
        }

        /// <summary>
        /// 1 = ถ้าค่าเปลี่ยนแปลง,
        /// 2 = ถ้าค่าเพิ่มขึ้น,
        /// 3 = ถ้าค่าลดลง
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        private bool Layout_NumberChanging(int mode)
        {
            if (_scoreFirstTime)
            {
                _scoreFirstTime = false;
                _allNow = _all;
                _allMax = _all;
                return true;
            }

            switch (mode)
            {
                case 1:
                    if (_allNow != _all) // ถ้า all เปลี่ยนแปลง
                    {
                        _allNow = _all;
                        return true;
                    }
                    break;

                case 2:
                    if (_allMax < _all) // ถ้า all เพิ่มขึ้น
                    {
                        _allMax = _all;
                        return true;
                    }
                    break;

                case 3:
                    if (_allMax > _allNow) // ถ้า all น้อยลง
                    {
                        return true;
                    }
                    break;

                case 0:
                    return false;
            }

            return false;
        }

        private void TmScore_Tick(object sender, EventArgs e)
        {
            _allChanging1 = Layout_NumberChanging(1);
            _allChanging2 = Layout_NumberChanging(2);
            _allChanging3 = Layout_NumberChanging(3);
            try
            {
                var columnsCount = int.Parse(txtResultXCount.Text);
                var rowCount = int.Parse(txtResultYCount.Text);

                if (_allChanging1)
                {
                    if (dataGridView1.ColumnCount == columnsCount && dataGridView1.RowCount == rowCount)
                    {
                        for (var i = 0; i < columnsCount; i++)
                        {
                            for (var j = 0; j < rowCount; j++)
                            {
                                var str = Layout_Bitmap2Char(j, i);
                                dataGridView1[i, j].Value = str;
                                if (str == " ")
                                {
                                    str = "X";
                                }
                            }
                        }
                    }
                    _allChanging1 = Layout_NumberChanging(0);
                }
            }
            catch
            {
            }
        }

        #endregion Function Get PTB

        #endregion Layout

        #region Formula

        #region Variable

        private FormulaMode _formulaSelected;

        #endregion Variable

        #region Mode

        private enum FormulaMode
        {
            Custom,
            GoodLine,
            GoodLineFix,
            GoodLineRandom,
            Lock,
            Follow,
            AI,
            Random
        }

        private void Formula_btCustom_Click(object sender, EventArgs e)
        {
            CustomEdit();
        }

        private void FormulaAllRadioCheckedChanged(object sender)
        {
            FormulaChangeMode();
        }

        private void FormulaChangeMode()
        {
            if (Formula_radCustom.Checked)
            {
                _formulaSelected = FormulaMode.Custom;
            }
            if (Formula_radGoodLine.Checked)
            {
                _formulaSelected = FormulaMode.GoodLine;
            }
            if (Formula_radGoodLineFix.Checked)
            {
                _formulaSelected = FormulaMode.GoodLineFix;
            }
            if (Formula_radGoodLineRandom.Checked)
            {
                _formulaSelected = FormulaMode.GoodLineRandom;
            }
            if (Formula_radLock.Checked)
            {
                _formulaSelected = FormulaMode.Lock;
            }
            if (Formula_radFollow.Checked)
            {
                _formulaSelected = FormulaMode.Follow;
            }
            if (Formula_radAI.Checked)
            {
                _formulaSelected = FormulaMode.AI;
            }
            if (Formula_radRandom.Checked)
            {
                _formulaSelected = FormulaMode.Random;
            }
        }

        private void FormulaLoadValue()
        {
            _formulaSelected = (FormulaMode)Settings.Default._formulaSelected;
            Formula_cbGoodLineFix.SelectedIndex = Settings.Default._formulaGoodLineFix;
            Formula_cbLock.SelectedIndex = Settings.Default._formulaLock;
            Formula_cbFollow.SelectedIndex = Settings.Default._formulaFollow;

            switch (_formulaSelected)
            {
                case FormulaMode.Custom:
                    Formula_radCustom.Checked = true;
                    break;

                case FormulaMode.GoodLine:
                    Formula_radGoodLine.Checked = true;
                    break;

                case FormulaMode.GoodLineFix:
                    Formula_radGoodLineFix.Checked = true;
                    break;

                case FormulaMode.GoodLineRandom:
                    Formula_radGoodLineRandom.Checked = true;
                    break;

                case FormulaMode.Lock:
                    Formula_radLock.Checked = true;

                    break;

                case FormulaMode.Follow:
                    Formula_radFollow.Checked = true;

                    break;

                case FormulaMode.AI:
                    Formula_radAI.Checked = true;
                    break;

                case FormulaMode.Random:
                    Formula_radRandom.Checked = true;
                    break;
            }
        }

        #endregion Mode

        #region Custom

        #region Variable

        private List<string> _customValueFollowAdverse;


        private List<string> _customValueNumber;
        private static List<string> _customValueFollowAdverseSaved = new List<string>();

        private static List<string> _customValueNumberSaved = new List<string>();

        private short _customSelectedListbox;
        private static string _customLoadValue2Array;

        #endregion Variable

        #region Load/Save

        private void CustomLoad()
        {
            _customLoadValue2Array = CustomDefaultValue();
            if (!string.IsNullOrWhiteSpace(Settings.Default._customValue))
            {
                _customLoadValue2Array = Settings.Default._customValue;
            }

            CustomValue2ArrayList();
        }

        public static void CustomValue2ArrayList()
        {
            checked
            {
                try
                {
                    var array = _customLoadValue2Array.Split(';');
                    _customValueFollowAdverseSaved.Clear();
                    _customValueNumberSaved.Clear();
                    var num = array.Length - 1;
                    for (var i = 0; i <= num; i++)
                    {
                        var array2 = array[i].Split('=');
                        _customValueFollowAdverseSaved.Add(array2[0]);
                        _customValueNumberSaved.Add(array2[1]);
                    }
                }
                catch // if
                {
                    _customLoadValue2Array = CustomDefaultValue();
                    var array3 = _customLoadValue2Array.Split(';');
                    _customValueFollowAdverseSaved.Clear();
                    _customValueNumberSaved.Clear();
                    var num2 = array3.Length - 1;
                    for (var j = 0; j <= num2; j++)
                    {
                        var array4 = array3[j].Split('=');
                        _customValueFollowAdverseSaved.Add(array4[0]);
                        _customValueNumberSaved.Add(array4[1]);
                    }
                }
            }
        }

        private void CustomEdit()
        {
            FormulaBox.Visible = true;
            FormulaGroupMode.Enabled = false;
            _customValueFollowAdverse = _customValueFollowAdverseSaved;
            _customValueNumber = _customValueNumberSaved;
            checked
            {
                if (_customValueFollowAdverse.Count > 0)
                {
                    Custom_listbox.Items.Clear();
                    var num = _customValueFollowAdverse.Count - 1;
                    for (var i = 0; i <= num; i++)
                    {
                        Custom_listbox.Items.Add(_customValueFollowAdverse[i]);
                    }
                }
                CustomList2Label();
            }
        }

        private void Custom_btSave_Click(object sender, EventArgs e)
        {
            if (Custom_listbox.Items.Count == 0)
            {
                MessageBox.Show(@"Setting Betting Unit!!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _customValueFollowAdverse.Clear();
            checked
            {
                for (var i = 0; i <= Custom_listbox.Items.Count - 1; i++)
                {
                    _customValueFollowAdverse.Add(Custom_listbox.Items[i].ToString());
                }

                _customValueFollowAdverseSaved = _customValueFollowAdverse;
                _customValueNumberSaved = _customValueNumber;
                CustomSaveValue();
                FormulaGroupMode.Enabled = true;
                FormulaBox.Visible = false;
            }
        }

        private void CustomSaveValue()
        {
            CustomSaveValue(_customValueFollowAdverse, _customValueNumber);

            Settings.Default.Save();
        }

        public static void CustomSaveValue(List<string> dd, List<string> dd2)
        {
            var text = "";
            checked
            {
                int num = dd.Count - 1;
                for (int i = 0; i <= num; i++)
                {
                    if (i > 0)
                    {
                        text += ";";
                    }
                    text = text + dd[i] + "=" + dd2[i];
                }

                Settings.Default._customValue = text;
            }
        }

        #endregion Load/Save

        #region Value

        public static string CustomDefaultValue()
        {
            return "1,1=X;1,2,1,2=X" + ";2,2=X;3,3=X;4,4=X" + ";1,2,3=X;1,3,2,1=X" + ";5=O;6=O;7=O;8=O;9=O;10=O;11=O;12=O;13=O;14=O;15=O;16=O;17=O;18=O;19=O;20=O";
        }

        private void CustomList2Label()
        {
            Formula_lbTotal.Text = $@"Total: {Custom_listbox.Items.Count}";
        }

        private void Custom_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            _customSelectedListbox = checked((short)Custom_listbox.SelectedIndex);
            if (_customSelectedListbox < 0)
            {
                Custom_txtNum.Text = null;
                Custom_radFollow.Checked = false;
                Custom_radAdverse.Checked = false;
                return;
            }

            Custom_txtNum.Text = Custom_listbox.SelectedItem.ToString();

            if (_customValueNumber[_customSelectedListbox] == "O")
            {
                Custom_radFollow.Checked = true;
                return;
            }
            Custom_radAdverse.Checked = true;
        }

        private void Custom_txtNum_TextChanged(object sender, EventArgs e)
        {
            var array = Custom_txtNum.Text.Trim().Split(',');
            CustomPanelResult.Controls.Clear();

            CustomPanelResultPB.Controls.Clear();
            CustomPanelResultBP.Controls.Clear();

            var num = checked((short)(array.Length - 1));
            for (short num2 = 0; num2 <= num; num2 += 1)
            {
                try
                {
                    if (Math.Abs(int.Parse(array[num2])) != 0)
                    {
                        short x;
                        short num3;
                        checked
                        {
                            var num5 = (short)(num2 * 16);
                            x = num5;
                            num3 = (short)Math.Round(int.Parse(array[num2]) - 1.0);
                        }
                        for (short num4 = 0; num4 <= num3; num4 += 1)
                        {
                            var y = (short)checked(num4 * 16);

                            var value = new Label
                            {
                                Font = new Font("Segoe UI", 9),
                                AutoSize = false,
                                Size = new Size(16, 16),
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(0)
                            };

                            var valueP = new Label
                            {
                                Font = new Font("Segoe UI", 9),
                                AutoSize = false,
                                Size = new Size(16, 16),
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(0),
                                BackColor = Color.Blue,
                                ForeColor = Color.White
                            };

                            var valueB = new Label
                            {
                                Font = new Font("Segoe UI", 9),
                                AutoSize = false,
                                Size = new Size(16, 16),
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(0),
                                BackColor = Color.Red,
                                ForeColor = Color.White
                            };

                            if (num2 % 2 == 0)
                            {
                                value.BackColor = Color.Silver;
                                value.Text = @"X";
                                valueP.Text = @"P";
                                valueB.Text = @"B";
                            }
                            else
                            {
                                value.BackColor = Color.Gray;
                                value.Text = @"O";

                                valueP.BackColor = Color.Red;
                                valueP.Text = @"B";

                                valueB.BackColor = Color.Blue;
                                valueB.Text = @"P";
                            }
                            value.Location = new Point(x, y);
                            CustomPanelResult.Controls.Add(value);

                            valueP.Location = new Point(x, y);
                            CustomPanelResultPB.Controls.Add(valueP);

                            valueB.Location = new Point(x, y);
                            CustomPanelResultBP.Controls.Add(valueB);
                        }
                    }
                }
                catch
                {
                }
            }
        }

        #endregion Value

        #region Button Control, Save Settings

        private void CustomConfigCheckedChanged(object sender)
        {
            try
            {
                if (_customSelectedListbox <= -1) return;

                if (Custom_radFollow.Checked)
                {
                    _customValueNumber[_customSelectedListbox] = "O";
                    return;
                }
                if (Custom_radAdverse.Checked)
                {
                    _customValueNumber[_customSelectedListbox] = "X";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n Try Again", @"Error 0x11", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Custom_btAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Custom_txtNum.Text)) return;
            Custom_listbox.Items.Add(Custom_txtNum.Text.Trim());
            var item = Custom_radFollow.Checked ? "X" : "O";
            _customValueFollowAdverse.Add(Custom_txtNum.Text.Trim());
            _customValueNumber.Add(item);
            CustomList2Label();
        }

        private void Custom_btDel_Click(object sender, EventArgs e)
        {
            checked
            {
                var num = Custom_listbox.SelectedIndex;

                _customSelectedListbox = (short)Custom_listbox.SelectedIndex;
                if (_customSelectedListbox == -1) return;
                _customValueNumber.RemoveAt(_customSelectedListbox);
                Custom_listbox.Items.RemoveAt(_customSelectedListbox);
                if (num == 0)
                {
                    Custom_listbox.SelectedIndex = Custom_listbox.Items.Count == 0 ? -1 : 0;
                }
                else if (num >= Custom_listbox.Items.Count)
                {
                    Custom_listbox.SelectedIndex = num - 1;
                }
                else
                {
                    Custom_listbox.SelectedIndex = num;
                }
                CustomList2Label();
            }
        }

        private void Custom_btClear_Click(object sender, EventArgs e)
        {
            Custom_listbox.Items.Clear();
            _customValueNumber.Clear();
            CustomList2Label();
        }

        private void Custom_btDefault_Click(object sender, EventArgs e)
        {
            var array = CustomDefaultValue().Split(';');
            Custom_listbox.Items.Clear();
            _customValueNumber.Clear();
            checked
            {
                for (var i = 0; i <= array.Length - 1; i++)
                {
                    var array2 = array[i].Split('=');
                    Custom_listbox.Items.Add(array2[0]);
                    _customValueNumber.Add(array2[1]);
                }
                Custom_listbox.ClearSelected();
                Custom_txtNum.Text = null;
                Custom_radFollow.Checked = false;
                Custom_radAdverse.Checked = false;
                CustomList2Label();
            }
        }

        private void Custom_btClose_Click(object sender, EventArgs e)
        {
            CustomEdit();
            FormulaGroupMode.Enabled = true;
            FormulaBox.Visible = false;
        }

        #endregion Button Control, Save Settings

        #endregion Custom

        #endregion Formula

        #region Betting System

        #region Variable

        private string _lbDetailPp = @"- Increase stakes next step when you win
- Return to first stakes when you lose";

        private string _lbDetailNp = @"- Increase stakes next step when you lose
- Return to first stakes when you win";

        private string _lbDetailFib = @"- Increase stakes next step when you lose
- Decrease 2 step for stakes when you win";

        private string _txtPp, _txtNp, _txtFib;
        private BettingMode _bettingEditor, _bettingSelected;

        #endregion Variable

        #region Mode

        private enum BettingMode
        {
            PP,
            NP,
            PPNP,

            Fib,

            AI,
            OneShot,
            X2
        }

        private void Betting_btPP_Click(object sender, EventArgs e)
        {
            BettingEditMode(BettingMode.PP);
        }

        private void Betting_btNP_Click(object sender, EventArgs e)
        {
            BettingEditMode(BettingMode.NP);
        }

        private void Betting_btFib_Click(object sender, EventArgs e)
        {
            BettingEditMode(BettingMode.Fib);
        }

        private void BettingEditMode(BettingMode mode)
        {
            BettingBox.Visible = true;
            _bettingEditor = mode;
            switch (mode)
            {
                case BettingMode.PP:
                    BettingBox.Text = @"Positive Progression";
                    Betting_lbDetails.Text = _lbDetailPp;

                    break;

                case BettingMode.NP:
                    BettingBox.Text = @"Negative Progression";
                    Betting_lbDetails.Text = _lbDetailNp;
                    break;

                case BettingMode.Fib:
                    BettingBox.Text = @"Fibonacci";
                    Betting_lbDetails.Text = _lbDetailFib;
                    break;
            }
            BettingTextToDataGridView();
            Betting_GroupMode.Enabled = false;
        }

        private void Betting_cbPP_CheckedChanged(object sender)
        {
            BettingChangeMode();
        }

        private void BettingChangeMode()
        {
            if (Betting_radPP.Checked)
            {
                _bettingSelected = BettingMode.PP;
            }
            if (Betting_radNP.Checked)
            {
                _bettingSelected = BettingMode.NP;
            }
            if (Betting_radPPNP.Checked)
            {
                _bettingSelected = BettingMode.PPNP;
            }
            if (Betting_radFib.Checked)
            {
                _bettingSelected = BettingMode.Fib;
            }
            if (Betting_radAI.Checked)
            {
                _bettingSelected = BettingMode.AI;
            }
            if (Betting_radONE.Checked)
            {
                _bettingSelected = BettingMode.OneShot;
            }
            if (Betting_radX2.Checked)
            {
                _bettingSelected = BettingMode.X2;
            }
        }

        #endregion Mode

        #region Value

        private void BettingLoadValue()
        {
            _txtPp = Settings.Default.txtPP;
            _txtNp = Settings.Default.txtNP;
            _txtFib = Settings.Default.txtFib;
            _bettingSelected = (BettingMode)Settings.Default._bettingSelected;
            switch (_bettingSelected)
            {
                case BettingMode.PP:
                    Betting_radPP.Checked = true;
                    break;

                case BettingMode.NP:
                    Betting_radNP.Checked = true;
                    break;

                case BettingMode.PPNP:
                    Betting_radPPNP.Checked = true;
                    break;

                case BettingMode.Fib:
                    Betting_radFib.Checked = true;
                    break;

                case BettingMode.AI:
                    Betting_radAI.Checked = true;
                    break;

                case BettingMode.OneShot:
                    Betting_radONE.Checked = true;
                    break;

                case BettingMode.X2:
                    Betting_radX2.Checked = true;
                    break;
            }
        }

        private void BettingSaveValue()
        {
            Settings.Default.txtPP = _txtPp;
            Settings.Default.txtNP = _txtNp;
            Settings.Default.txtFib = _txtFib;
            Settings.Default.Save();
        }

        private void BettingTextToDataGridView()
        {
            var text = "";
            switch (_bettingEditor)
            {
                case BettingMode.PP:
                    text = _txtPp;
                    break;

                case BettingMode.NP:
                    text = _txtNp;
                    break;

                case BettingMode.Fib:
                    text = _txtFib;
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
                    Betting_DataGridToTxt();
                }
            }
        }

        private void Betting_DataGridToTxt()
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

                switch (_bettingEditor)
                {
                    case BettingMode.PP:
                        _txtPp = text;
                        break;

                    case BettingMode.NP:
                        _txtNp = text;
                        break;

                    case BettingMode.Fib:
                        _txtFib = text;
                        break;
                }
            }
        }

        private void DgvBetting_SelectionChanged(object sender, EventArgs e)
        {
            dgvBetting.ClearSelection();
        }

        private void Betting_btDel_Click(object sender, EventArgs e)
        {
            if (dgvBetting.RowCount > 0)
            {
                if (dgvBetting.CurrentRow != null) dgvBetting.Rows.RemoveAt(dgvBetting.CurrentRow.Index);
            }

            Betting_DataGridToTxt();
        }

        private void Betting_btClear_Click(object sender, EventArgs e)
        {
            if (dgvBetting.RowCount > 0)
            {
                dgvBetting.Rows.Clear();
                Betting_DataGridToTxt();
            }
        }

        private void Betting_btDefault_Click(object sender, EventArgs e)
        {
            switch (_bettingEditor)
            {
                case BettingMode.PP:
                    _txtPp = "1-3-2-4";

                    break;

                case BettingMode.NP:
                    _txtNp = "1-2";

                    break;

                case BettingMode.Fib:
                    _txtFib = "1-1-2-3-5-8-13-21-34-55-89-144-233-377-610-987-1597-2584";
                    break;
            }

            BettingTextToDataGridView();
        }

        private void Betting_btAdd_Click(object sender, EventArgs e)
        {
            dgvBetting.Rows.Add(checked(dgvBetting.RowCount + 1), int.Parse(Betting_txtNumber.Text));
            Betting_DataGridToTxt();
        }

        private void Betting_btClose_Click(object sender, EventArgs e)
        {
            BettingLoadValue();
            Betting_GroupMode.Enabled = true;
            BettingBox.Visible = false;
        }

        private void Betting_btSave_Click(object sender, EventArgs e)
        {
            if (dgvBetting.RowCount == 0)
            {
                MessageBox.Show(@"Setting Betting Unit!!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BettingSaveValue();
            Betting_GroupMode.Enabled = true;
            BettingBox.Visible = false;
        }

        #endregion Value

        #endregion Betting System

        #endregion Settings

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {
            }
        }
    }
}