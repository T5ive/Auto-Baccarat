using AutoBaccarat.Properties;
using AutoBaccarat.Setting.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TFive_Class;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]

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
            LoadSettings();
            InitLocalization();
            LoadSelectedLanguage();
            Settings_cbLangua.SelectedIndex = Settings.Default.Lang;
            LoadLanguage();
            StatusLoad();

            MainSettingsLoad();
            
            Layout_CallPosition();
            FormulaLoadValue();
            Layout_LoadFiles2List();
            BettingLoadValue();
            CustomLoad();
            SettingChipSelected();
         
            Size = new Size(740, 575);
       //  Size = new Size(975, 575);
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

        private void LoadSettings()
        {
            Settings_cbTopMost.CheckedState = Settings.Default.topMost;
            Settings_cbMove.CheckedState = Settings.Default.moveCur;
            Settings_cbCheckSettings.CheckedState = Settings.Default.checkSettings;
            Settings_cbInvert.CheckedState = Settings.Default.betInv;
            Settings_cbDoubleClick.CheckedState = Settings.Default.doubleClick;
            Setting_TopMost();
        }
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseSetting();
        }

        private void CloseSetting()
        {
            Settings.Default.Location = Location;
            Settings.Default.topMost = Settings_cbTopMost.CheckedState;
            Settings.Default.moveCur = Settings_cbMove.CheckedState;
            Settings.Default.checkSettings = Settings_cbCheckSettings.CheckedState;
            Settings.Default.betInv = Settings_cbInvert.CheckedState;
            Settings.Default.doubleClick = Settings_cbDoubleClick.CheckedState;
            Settings.Default.Lang = Settings_cbLangua.SelectedIndex;

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
                Size = new Size(740, 575);
              //  Size = new Size(975, 575);
                
            }
            if (TabMainControl.SelectedTab == TabMainControl.TabPages["tabLogs"])
            {
                Size = new Size(935, 575);
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
                Size = new Size(785, 575);
            }

            if (tabSettings.SelectedTab == tabSettings.TabPages["tabFormula"])
            {
                Size = new Size(785, 575);
            }

            if (tabSettings.SelectedTab == tabSettings.TabPages["tabBetting"])
            {
                Size = new Size(785, 575);
            }
        }

        #endregion Tab Control

        #region DashBoard
        
        #region Status

        private void StatusLoad()
        {
            dgvStatus.Rows.Clear();
            dgvStatus.Font = new Font("Segoe UI", 9);

            dgvStatus.Rows.Add(stringLoader.RunTime, null, "0", null);
            dgvStatus.Rows.Add(stringLoader.Round, "0", stringLoader.MaxProfit, "0");
            dgvStatus.Rows.Add(stringLoader.Win, "0", stringLoader.Balance, "0");
            dgvStatus.Rows.Add(stringLoader.Lose, "0", stringLoader.Amount, "0");
            dgvStatus.Rows.Add(stringLoader.MaxConWin, "0", stringLoader.Stake, "0x0");
            dgvStatus.Rows.Add(stringLoader.MaxConLose, "0", stringLoader.Unit, "0x0");
            dgvStatus.Rows.Add(stringLoader.WinLose, "0", stringLoader.Bettings, "");

            dgvStatus[3, 3].Style.ForeColor = Color.DarkGoldenrod;

            //dgvStatus[3, 5].Style.ForeColor = Color.White;
            //dgvStatus[3, 5].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStatus[3, 6].Style.ForeColor = Color.White;
            dgvStatus[3, 6].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvStatus.ClearSelection();

            dgvBigRoad.Columns.Add("_colbig0", "_colbig0");
        }
        private void StatusUpdate()
        {

            dgvStatus[1, 1].Value = _listResult.Count.ToString(); // Round
            dgvStatus[1, 2].Value = _totalWin;
            dgvStatus[1, 3].Value = _totalLose;
            dgvStatus[1, 4].Value = _maxContinuesW;
            dgvStatus[1, 5].Value = _maxTopContinuesLose;
            var value = _totalWin - _totalLose;
            dgvStatus[1, 6].Value = value;
            dgvStatus[1, 6].Style.ForeColor = DataGridForeColor(value);

            dgvStatus[3, 1].Value = _maxProfit;
            dgvStatus[3, 2].Value = _lastMoneyBalance.ToString("#,##0.##");
            dgvStatus[3, 2].Style.ForeColor = DataGridForeColor((int)_lastMoneyBalance);


            //dgvStatus[3, 6].Value = ConvertTypeGame2String(_mostWin);
            //dgvStatus[3, 6].Style.BackColor = ChangeColorByType(_mostWin);

            dgvStatus[3, 3].Value = "0";
            dgvStatus[3, 4].Value = "0x0";
           // dgvStatus[3, 5].Value = "0x0";
            dgvStatus[3, 6].Value = "";
            if (_listBettingSuggest.Count > 0)
            {
                var lastBetSuggestValue = _listBettingSuggest[_listBettingSuggest.Count - 1];
                short lastUnit = 0;
                if (_listUnit[_listUnit.Count - 1] > 0 & (lastBetSuggestValue == 1 | lastBetSuggestValue == 2))
                {
                    dgvStatus[3, 4].Value = ValueForBot.Chip + "x" + (int)_listUnit[_listUnit.Count - 1];
                    dgvStatus[3, 6].Value = ConvertTypeGame2String(lastBetSuggestValue);
                    dgvStatus[3, 6].Style.BackColor = ChangeColorByType(lastBetSuggestValue);

                    lastUnit = _listUnit[_listUnit.Count - 1];
                }

                dgvStatus[3, 3].Value = (ValueForBot.Chip * (double)lastUnit).ToString("#,##0");
            }

            dgvStatus.ClearSelection();

        }
        private void CheckPlayerOrBankerHigh()
        {
            if (_valueP > _valueB)
            {
                //_mostWin = 1;
            }
            else if (_valueP < _valueB)
            {
                //_mostWin = 2;
            }
           
        }

        private void DgvStatus_SelectionChanged(object sender, EventArgs e)
        {
            dgvStatus.ClearSelection();
        }

        private void Dg6Line_SelectionChanged(object sender, EventArgs e)
        {
            dgvGoodLine.ClearSelection();
        }

        private void DgvLog_SelectionChanged(object sender, EventArgs e)
        {
            dgvLog.ClearSelection();
        }

        #endregion

        #region Big Road Control

        private void ButtonAddValue2BigRoad(object sender, EventArgs e)
        {
            var value = ((Button)sender).Text;
            switch (value)
            {
                case "P":
                    AddValue2BigRoadClick("P");
                    break;
                case "B":
                    AddValue2BigRoadClick("B");
                    break;
                case "T":
                    AddValue2BigRoadClick("T");
                    break;
            }
        }

        private void AddValue2BigRoadClick(string value)
        {
            LoadValue4Bot();
            _backUpBigRoad = false;
            short type = 0;
            switch (value)
            {
                case "P":
                    type = 1;
                    break;
                case "B":
                    type = 2;
                    break;
                case "T":
                    type = 0;
                    break;
            }
            _amountBetChip = "";
            AddPBT2List(type, DateTime.Now.ToString("HH:mm:ss"));
            if (type == 1 | type == 2)
            {
                UpdateBigRoad(_listScorePBT);
            }
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (_listResult.Count != 0 && MessageBox.Show(stringLoader.WantClear, stringLoader.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _listBigRoad.Clear();
                dgvBigRoad.Rows.Clear();
                dgvBigRoad.Columns.Clear();
                dgvBigRoad.Columns.Add("_colbig0", "_colbig0");
                dgvGoodLine.Rows.Clear();
                dgvLog.Rows.Clear();
                _backUpBigRoad = false;
                ClearMainDisplay();
            }
        }

        private void ClearMainDisplay()
        {
            _timeStart = 0;
            TypeOfPBT = 3;
            _valueP = 0;
            _valueB = 0;
            _valueT = 0;
            _totalWin = 0;
            _totalLose = 0;

           // _mostWin = 5;

            _lastMoneyBalance = 0.0;
            _timeRunning = 0;
            _maxProfit = 0;
            _maxContinuesW = 0;
            _maxTopContinuesLose = 0;

            _goodLine1 = 0;
            _goodLine2 = 0;
            _goodLine3 = 0;
            _goodLine4 = 0;
            _goodLine5 = 0;
            _goodLine6 = 0;
            _goodLineSum = 0;
            _listResult.Clear();
            _listScorePBT.Clear();
            _listUnit.Clear();
            _listBettingSuggest.Clear();
            _listTime.Clear();
            _listWinLose.Clear();
            _listFormula.Clear();
            _listBetSystem.Clear();
            _listChipLast.Clear();
 

            _listStep.Clear();
            _listBalance.Clear();
            _listLastHighResult.Clear();
            _listMoneyCost.Clear();
          
           

            _bigRoadNewLine = -1;
            _bigRoadNewColumn = 0;
            _bigRoadLastValue = 0;
            

            
            _fibonacci = 1;
            _winBackLoseGo = 1;
            _loseBackWinGo = 1;
            

          
            UpdateDisplay();

            lbline1.Text = "0";
            lbline2.Text = "0";
            lbline3.Text = "0";
            lbline4.Text = "0";
            lbline5.Text = "0";
            lbline6.Text = "0";
            lblineSum.Text = "0";
            lbShowLine1.BackColor = Color.FromArgb(240,240,240);
            lbShowLine2.BackColor = Color.FromArgb(240, 240, 240);
            lbShowLine3.BackColor = Color.FromArgb(240, 240, 240);
            lbShowLine4.BackColor = Color.FromArgb(240, 240, 240);
            lbShowLine5.BackColor = Color.FromArgb(240, 240, 240);
            lbShowLine6.BackColor = Color.FromArgb(240, 240, 240);
            lbShowLine7.BackColor = Color.FromArgb(240, 240, 240);
           // dgvStatus[3, 5].Style.BackColor = Color.FromArgb(240, 240, 240);
            dgvStatus[3, 6].Style.BackColor = Color.FromArgb(240, 240, 240);


            tFiveProgressBar1.Value = 0;
            tFiveProgressBar2.Value = 0;
            tFiveProgressBar3.Value = 0;
            tFiveProgressBar4.Value = 0;
            tFiveProgressBar5.Value = 0;
            tFiveProgressBar6.Value = 0;
            tFiveProgressBar7.Value = 0;
        }
        private void RemoveLastScore()
        {
            checked
            {
                if (_listResult.Count > 0)
                {
                    bool flag = _listResult[_listResult.Count - 1] != 0;
                    if (_listResult.Count > 0)
                    {
                        _listResult.RemoveAt(_listResult.Count - 1);
                    }
                    if (_listTime.Count > 0)
                    {
                        _listTime.RemoveAt(_listTime.Count - 1);
                    }
                    if (flag)
                    {
                        if (_listScorePBT.Count > 0)
                        {
                            _listScorePBT.RemoveAt(_listScorePBT.Count - 1);
                        }
                        if (_listLastHighResult.Count > 0)
                        {
                            _listLastHighResult.RemoveAt(_listLastHighResult.Count - 1);
                        }
                    }
                    if (_listBigRoad.Count > 0)
                    {
                        int index = _listBigRoad.Count - 1;
                        if (_listBigRoad[index].Count > 0)
                        {
                            _listBigRoad[index].RemoveAt(_listBigRoad[index].Count - 1);
                        }
                        if (_listBigRoad[index].Count == 0)
                        {
                            _listBigRoad.RemoveAt(_listBigRoad.Count - 1);
                        }
                    }
                    if (dgvGoodLine.RowCount > 0)
                    {
                        dgvGoodLine.Rows.RemoveAt(dgvGoodLine.RowCount - 1);
                    }
                    MiniClearDisplay();
                    UpdateDisplay();
                }
            }
        }
        
        private void MiniClearDisplay()
        {
            _backUpBigRoad = true;
            _listBackUpResult.Clear();
            _listBackUpResult.AddRange(_listResult);
            _listBackUpTime.Clear();
            _listBackUpTime.AddRange(_listTime);
            ClearMainDisplay();
            checked
            {
                int num = _listBackUpResult.Count - 1;
                for (int i = 0; i <= num; i++)
                {
                    if (i == _listBackUpResult.Count - 1)
                    {
                        _backUpBigRoad = false;
                    }
                    AddPBT2List(_listBackUpResult[i], _listBackUpTime[i]);
                }
            }
        }
        private void UpdateBigRoad(List<short> list)
        {
            checked
            {
                if (list.Count > 0)
                {
                    var listCount = list.Count - 1;

                    if (list[listCount] != 0)
                    {
                        if (_bigRoadLastValue == 0)
                        {
                            _bigRoadLastValue = list[listCount];
                            UpdateBigRoad(_listScorePBT);
                            return;
                        }
                        if (_bigRoadLastValue == list[listCount])
                        {
                            _bigRoadNewLine++;
                        }

                        if (_bigRoadLastValue != list[listCount])
                        {
                            _bigRoadNewLine = 0;
                            _bigRoadNewColumn++;
                            dgvBigRoad.Columns.Add("_colbig" + _bigRoadNewColumn, "_colbig" + _bigRoadNewColumn);
                        }



                        try
                        {
                            if (_bigRoadNewLine <= dgvBigRoad.RowCount)
                            {
                                dgvBigRoad.Rows.Add("");
                            }
                            var str = "";
                            var color = Color.Black;
                            if (list[listCount] == 1)
                            {
                                str = "P";
                                color = Color.RoyalBlue;
                            }
                            if (list[listCount] == 2)
                            {
                                str = "B";
                                color = Color.Red;
                            }
                            else if (list[listCount] == 0)
                            {
                                str = "T";
                                color = Color.LimeGreen;
                            }
                            dgvBigRoad.Rows[_bigRoadNewLine].Cells[_bigRoadNewColumn].Value = str;
                            dgvBigRoad.Rows[_bigRoadNewLine].Cells[_bigRoadNewColumn].Style.BackColor = color;



                        }
                        catch
                        {

                        }

                        _bigRoadLastValue = list[listCount];



                    }

                }
            }
        }

        private void DgvBigRoad_SelectionChanged(object sender, EventArgs e)
        {
            dgvBigRoad.ClearSelection();
        }

        #endregion

        #region Value For Bot

        private bool ShowDisplaySetting()
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
                    frmDisplay.Formula = _formulaSelected + stringLoader.Line + Formula_cbGoodLineFix.SelectedItem;
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
                return false;
            }
            frmDisplay.Dispose();
            return true;
        }
        private void LoadValue4Bot()
        {
            ValueForBot.Formula = _formulaSelected.ToString();
            ValueForBot.Betting = _bettingSelected.ToString();
            ValueForBot.Chip = int.Parse(Settings_cbChip.SelectedItem.ToString());

            ValueForBot.StopRound = Settings_txtStopRound.Text;
            ValueForBot.StopWin = Settings_txtStopWin.Text;
            ValueForBot.StopLose = Settings_txtStopLose.Text;
            ValueForBot.StopLess = Settings_txtStopLess.Text;
            ValueForBot.StopMore = Settings_txtStopMore.Text;

            ValueForBot.ValuePP = Settings.Default.txtPP;
            ValueForBot.ValueNP = Settings.Default.txtNP;
            ValueForBot.ValueFib = Settings.Default.txtFib;

            ValueForBot.GoodLineFix = int.Parse(Formula_cbGoodLineFix.SelectedItem.ToString()) + 1;
            ValueForBot.Lock = int.Parse(Formula_cbLock.SelectedIndex.ToString()) + 1;
            ValueForBot.Follow = int.Parse(Formula_cbFollow.SelectedIndex.ToString()) + 1;

            ValueForBot.CustomValueNumber = _customValueNumberSaved;
            ValueForBot.CustomValueFollowAdverse = _customValueFollowAdverseSaved;

            ValueForBot.Mode = LayoutValues.Mode;

            var positionStart = LayoutValues._pStart.Split('(', ',', ')');
            ValueForBot.Start = new Point(int.Parse(positionStart[1]), int.Parse(positionStart[2]));
            var positionPlayer = LayoutValues._pPlayer.Split('(', ',', ')');
            ValueForBot.Player = new Point(int.Parse(positionPlayer[1]), int.Parse(positionPlayer[2]));
            var positionBanker = LayoutValues._pBanker.Split('(', ',', ')');
            ValueForBot.Banker = new Point(int.Parse(positionBanker[1]), int.Parse(positionBanker[2]));
            var positionTie = LayoutValues._pTie.Split('(', ',', ')');
            ValueForBot.Tie = new Point(int.Parse(positionTie[1]), int.Parse(positionTie[2]));

            var positionConP = LayoutValues._pConP.Split('(', ',', ')');
            ValueForBot.ConfirmPlayer = new Point(int.Parse(positionConP[1]), int.Parse(positionConP[2]));

            var positionConB = LayoutValues._pConB.Split('(', ',', ')');
            ValueForBot.ConfirmBanker = new Point(int.Parse(positionConB[1]), int.Parse(positionConB[2]));

            if (ValueForBot.Mode == 0)
            {
                var colorStart = GetColor.Hex2Color(LayoutValues._pColorStart);
                ValueForBot.ColorStart = colorStart;
                var colorPlayer = GetColor.Hex2Color(LayoutValues._pColorPlayer);
                ValueForBot.ColorPlayer = colorPlayer;
                var colorBanker = GetColor.Hex2Color(LayoutValues._pColorBanker);
                ValueForBot.ColorBanker = colorBanker;
                var colorTie = GetColor.Hex2Color(LayoutValues._pColorTie);
                ValueForBot.ColorTie = colorTie;
            }
            else if (ValueForBot.Mode == 1)
            {
                //var colorStart = GetColor.Hex2Color(LayoutValues._pColorStart);
                //ValueForBot.ColorStart = colorStart;
                //var colorPlayer = GetColor.Hex2Color(LayoutValues._pColorPlayer);
                //ValueForBot.ColorStart = colorPlayer;
                //var colorBanker = GetColor.Hex2Color(LayoutValues._pColorBanker);
                //ValueForBot.ColorStart = colorBanker;
            }

            var positionChip1 = LayoutValues._pChip1.Split('(', ',', ')');
            ValueForBot.Chip1 = new Point(int.Parse(positionChip1[1]), int.Parse(positionChip1[2]));

            var positionChip2 = LayoutValues._pChip2.Split('(', ',', ')');
            ValueForBot.Chip2 = new Point(int.Parse(positionChip2[1]), int.Parse(positionChip2[2]));

            var positionChip3 = LayoutValues._pChip3.Split('(', ',', ')');
            ValueForBot.Chip3 = new Point(int.Parse(positionChip3[1]), int.Parse(positionChip3[2]));

            var positionChip4 = LayoutValues._pChip4.Split('(', ',', ')');
            ValueForBot.Chip4 = new Point(int.Parse(positionChip4[1]), int.Parse(positionChip4[2]));

            var positionChip5 = LayoutValues._pChip5.Split('(', ',', ')');
            ValueForBot.Chip5 = new Point(int.Parse(positionChip5[1]), int.Parse(positionChip5[2]));
         

        }

        #endregion

        #region Function Convert

        private static short BetInvert(short resultInput)
        {
            short result = 3;
            if (resultInput == 1)
            {
                result = 2;
            }
            else if (resultInput == 2)
            {
                result = 1;
            }
            return result;
        }
        private static string ConvertTypeGame2String(short result)
        {
            return result == 1 ? "P" : result == 2 ? "B" : result == 0 ? "T" : "";
        }
        private static string ConvertOldScore2WinLose(string newScore, string oldScore)
        {
            return newScore == "T" || newScore == oldScore ? "W" : "L";
        }
        private static Color ChangeColorByType(short type)
        {
            return type == 1 ? Color.RoyalBlue : type == 2 ? Color.Red : Color.LimeGreen;
        }
        private static Color ChangeBackColorLineGoodLine(short newScore, short oldScore)
        {
            return newScore == 0 || newScore == oldScore ? Color.LimeGreen : Color.Red;
        }
        private static Color ProgressbarColor(double value)
        {
            return value < 40.0 ? Color.Red : value < 60.0 ? Color.Orange : Color.LimeGreen;
        }
        private static Color DataGridForeColor(int value)
        {
            return value == 0 ? Color.DodgerBlue : value > 0 ? Color.LimeGreen : Color.Red;
        }
        private static short DoubleArray2ShortArray(double[] result)
        {
            var resultValue = 0.0;
            var count = 0;
            checked
            {
                var resultLength = result.Length - 1;
                for (var i = 0; i <= resultLength; i++)
                {
                    if (result[i] > resultValue)
                    {
                        count = i;
                        resultValue = result[i];
                    }
                }
                return (short)count;
            }
        }
        private static int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max + 1);
        }


        #endregion

        #region Function Calculator

        public static double MoneyCost(short resultInput, short unit, short chipValue, string checkLastResult)
        {
            var result = 0.0;

            if (resultInput == 1 | resultInput == 2)
            {
                if (checkLastResult == "W")
                {
                    if (resultInput == 1)
                    {
                        result = unit * chipValue;
                    }
                    else if (resultInput == 2)
                    {
                        result = unit * chipValue * 0.95;
                    }
                }
                else
                {
                    result = checked(unchecked(unit * chipValue) * -1);
                }
            }
            else
            {
                result = 0.0;
            }
            return result;
        }

        #endregion

        #region Display Value

        private bool _switchColor;
        private static Color EasyChangeColor(bool status, string type)
        {
            return status
                ? type == "P" ? Color.RoyalBlue :
                type == "B" ? Color.Red : Color.FromArgb(240, 240, 240)
                : Color.FromArgb(240, 240, 240);
        }
        private static Color EasyChangeForeColor(bool status, string type) =>
            status ? Color.White :
            type == "P" ? Color.RoyalBlue :
            type == "B" ? Color.Red : Color.White;

        private void TmDisplay_Tick(object sender, EventArgs e)
        {
            _switchColor = !_switchColor;

            if (_statusRunBot) 
            {
                int statusRunningBot = _statusRunningBot;
                lblStatus.Visible = _switchColor;
                switch (statusRunningBot)
                {
                    case 0:
                        lblStatus.Text = stringLoader.Ready;
                        numberStatus.Value = 1;
                        break;
                    case 1:
                        lblStatus.Text = stringLoader.Bettings;
                        numberStatus.Value = 2;
                        break;
                    case 2:
                        lblStatus.Text = stringLoader.Wait;
                        numberStatus.Value = 3;
                        break;
                    case 3:
                        break;
                    default:
                        if (statusRunningBot != 100)
                        {
                            if (statusRunningBot == 200)
                            {
                                lblStatus.Text = stringLoader.Save;
                                numberStatus.Value = 4;
                            }
                        }
                        else
                        {
                            lblStatus.Text = stringLoader.Bettings;
                            numberStatus.Value = 2;
                        }
                        break;
                }
            //    this.lblBot_Status.Visible = this.bool_4;
            }
            else
            {
                lblStatus.Visible = true;
            }


            string value;
            try
            {
                value = dgvStatus[3, 6].Value.ToString();
            }
            catch
            {
                value = "";
            }
            if (value != "")
            {
                dgvStatus[3, 6].Style.BackColor = EasyChangeColor(_switchColor, value);
                dgvStatus[3, 6].Style.ForeColor = EasyChangeForeColor(_switchColor, value);
            }

            if (_listScorePBT.Count > 6)
            {
                switch (_goodLineBetThis)
                {
                    case 1:
                        lbShowLine1.Visible = _switchColor;
                        return;
                    case 2:
                        lbShowLine2.Visible = _switchColor;
                        return;
                    case 3:
                        lbShowLine3.Visible = _switchColor;
                        return;
                    case 4:
                        lbShowLine4.Visible = _switchColor;
                        return;
                    case 5:
                        lbShowLine5.Visible = _switchColor;
                        return;
                    case 6:
                        lbShowLine6.Visible = _switchColor;
                        return;
                    case 7:
                        lbShowLine7.Visible = _switchColor;
                        break;
                    default:
                        return;
                }
            }
        }

        #endregion

        #region Var

        private int _bigRoadLastValue, _bigRoadNewColumn, _bigRoadNewLine = -1;
        private string _customSumLikeCount;
        
        private List<double> _listBalance = new List<double>();
        private List<double> _listMoneyCost = new List<double>();
        private List<int> _listChipLast = new List<int>();
        private List<List<short>> _listBigRoad = new List<List<short>>();
        private List<short> _listBackUpResult = new List<short>();
        private List<short> _listBettingSuggest = new List<short>();
        private List<short> _listLastHighResult = new List<short>();
        private List<short> _listResult = new List<short>();
        private List<short> _listScorePBT = new List<short>();
        private List<short> _listStep = new List<short>();
        private List<short> _listUnit = new List<short>();
        private List<string> _listBackUpTime = new List<string>();
        private List<string> _listBetSystem = new List<string>();
        private List<string> _listFormula = new List<string>();
        private List<string> _listTime = new List<string>();
        private List<string> _listWinLose = new List<string>();

        private int _fibonacci,
            _goodLine1,
            _goodLine2,
            _goodLine3,
            _goodLine4,
            _goodLine5,
            _goodLine6,
            _goodLineSum,
            _loseBackWinGo,
            _maxContinuesW,
            _maxTopContinuesLose,
            _totalLose,
            _totalWin,
            _valueB,
            _valueP,
            _valueT,
            _winBackLoseGo;

        private short TypeOfPBT = 3;
        private short _goodLineBetThis, _lastStep;
        
        private double _maxProfit, _lastMoneyBalance;
        
        private bool _backUpBigRoad;

        private short _forceValue, _forceType;
        private short Betshort_0, Betshort_1, Betshort_3, Betshort_2;
        #endregion

        #region Display Update

        private void AddPBT2List(short PBT_Type120, string timeValue)
        {
            TypeOfPBT = 3;
            short bettingSuggest = 3;
            var unitValue = 0;
            var winOrLose = "";

            var formula = ValueForBot.Formula;
            var betSystem = ValueForBot.Betting;
            var chipValue = ValueForBot.Chip;
            var modeType = ValueForBot.Mode;

            var lastMoneyBalance = 0.0;
            var moneyCost = 0.0;

            _listResult.Add(PBT_Type120);
            _listTime.Add(timeValue);

            checked
            {
                if (PBT_Type120 != 0)
                {
                    _listScorePBT.Add(PBT_Type120);

                    #region Good Line Control

                    if (_listScorePBT.Count <= 6)
                    {
                        _listLastHighResult.Add(int.Parse(lbP.Text) > int.Parse(lbB.Text) ? (short)1 : (short)2);
                    }
                    else
                    {
                        var newResult = ConvertTypeGame2String(PBT_Type120);
                        var oldScore1 = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 2]);
                        var oldScore2 = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 3]);
                        var oldScore3 = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 4]);
                        var oldScore4 = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 5]);
                        var oldScore5 = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 6]);
                        var oldScore6 = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 7]);
                        var lastHighResult = ConvertTypeGame2String(_listLastHighResult[_listLastHighResult.Count - 1]);

                        var goodLine1 = ConvertOldScore2WinLose(newResult, oldScore1);
                        var goodLine2 = ConvertOldScore2WinLose(newResult, oldScore2);
                        var goodLine3 = ConvertOldScore2WinLose(newResult, oldScore3);
                        var goodLine4 = ConvertOldScore2WinLose(newResult, oldScore4);
                        var goodLine5 = ConvertOldScore2WinLose(newResult, oldScore5);
                        var goodLine6 = ConvertOldScore2WinLose(newResult, oldScore6);
                        var goodLineSum = ConvertOldScore2WinLose(newResult, lastHighResult);

                        var dgv6Line = dgvGoodLine;
                        dgv6Line.Rows.Add(
                            dgv6Line.RowCount + 1,
                            newResult,
                            goodLine1,
                            goodLine2,
                            goodLine3,
                            goodLine4,
                            goodLine5,
                            goodLine6,
                            goodLineSum);
                        dgv6Line.CurrentCell = dgv6Line.Rows[dgv6Line.Rows.Count - 1].Cells[0];
                        dgv6Line.ClearSelection();
                        dgv6Line[1, dgv6Line.RowCount - 1].Style.ForeColor = ChangeColorByType(PBT_Type120);
                        dgv6Line[2, dgv6Line.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(PBT_Type120, _listScorePBT[_listScorePBT.Count - 2]);
                        dgv6Line[3, dgv6Line.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(PBT_Type120, _listScorePBT[_listScorePBT.Count - 3]);
                        dgv6Line[4, dgv6Line.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(PBT_Type120, _listScorePBT[_listScorePBT.Count - 4]);
                        dgv6Line[5, dgv6Line.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(PBT_Type120, _listScorePBT[_listScorePBT.Count - 5]);
                        dgv6Line[6, dgv6Line.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(PBT_Type120, _listScorePBT[_listScorePBT.Count - 6]);
                        dgv6Line[7, dgv6Line.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(PBT_Type120, _listScorePBT[_listScorePBT.Count - 7]);
                        dgv6Line[8, dgv6Line.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(PBT_Type120, _listLastHighResult[_listLastHighResult.Count - 1]);

                        if (goodLine1 == "W")
                        {
                            ref var ptr = ref _goodLine1;
                            _goodLine1 = ptr + 1;
                        }
                        if (goodLine2 == "W")
                        {
                            ref var ptr = ref _goodLine2;
                            _goodLine2 = ptr + 1;
                        }
                        if (goodLine3 == "W")
                        {
                            ref var ptr = ref _goodLine3;
                            _goodLine3 = ptr + 1;
                        }
                        if (goodLine4 == "W")
                        {
                            ref var ptr = ref _goodLine4;
                            _goodLine4 = ptr + 1;
                        }
                        if (goodLine5 == "W")
                        {
                            ref var ptr = ref _goodLine5;
                            _goodLine5 = ptr + 1;
                        }
                        if (goodLine6 == "W")
                        {
                            ref var ptr = ref _goodLine6;
                            _goodLine6 = ptr + 1;
                        }
                        if (goodLineSum == "W")
                        {
                            ref var ptr = ref _goodLineSum;
                            _goodLineSum = ptr + 1;
                        }

                        var prevSixScore = _listScorePBT.Count - 6;
                        var goodLinePer1 = _goodLine1 / (double)prevSixScore;
                        var goodLinePer2 = _goodLine2 / (double)prevSixScore;
                        var goodLinePer3 = _goodLine3 / (double)prevSixScore;
                        var goodLinePer4 = _goodLine4 / (double)prevSixScore;
                        var goodLinePer5 = _goodLine5 / (double)prevSixScore;
                        var goodLinePer6 = _goodLine6 / (double)prevSixScore;
                        var goodLinePerSum = _goodLineSum / (double)prevSixScore;
                        lbline1.Text = goodLinePer1.ToString("#%");
                        lbline2.Text = goodLinePer2.ToString("#%");
                        lbline3.Text = goodLinePer3.ToString("#%");
                        lbline4.Text = goodLinePer4.ToString("#%");
                        lbline5.Text = goodLinePer5.ToString("#%");
                        lbline6.Text = goodLinePer6.ToString("#%");
                        lblineSum.Text = goodLinePerSum.ToString("#%");

                        tFiveProgressBar1.Value = (int)Math.Round(goodLinePer1 * 100.0);
                        tFiveProgressBar2.Value = (int)Math.Round(goodLinePer2 * 100.0);
                        tFiveProgressBar3.Value = (int)Math.Round(goodLinePer3 * 100.0);
                        tFiveProgressBar4.Value = (int)Math.Round(goodLinePer4 * 100.0);
                        tFiveProgressBar5.Value = (int)Math.Round(goodLinePer5 * 100.0);
                        tFiveProgressBar6.Value = (int)Math.Round(goodLinePer6 * 100.0);
                        tFiveProgressBar7.Value = (int)Math.Round(goodLinePerSum * 100.0);

                        int numCheckLastGoodLine;
                        short newLine1;
                        short newLine2;
                        short newLine3;
                        short newLine4;
                        short newLine5;
                        short newLine6;
                        unchecked
                        {
                            tFiveProgressBar1.Color1 = ProgressbarColor(goodLinePer1 * 100.0);
                            tFiveProgressBar2.Color1 = ProgressbarColor(goodLinePer2 * 100.0);
                            tFiveProgressBar3.Color1 = ProgressbarColor(goodLinePer3 * 100.0);
                            tFiveProgressBar4.Color1 = ProgressbarColor(goodLinePer4 * 100.0);
                            tFiveProgressBar5.Color1 = ProgressbarColor(goodLinePer5 * 100.0);
                            tFiveProgressBar6.Color1 = ProgressbarColor(goodLinePer6 * 100.0);
                            tFiveProgressBar7.Color1 = ProgressbarColor(goodLinePerSum * 100.0);

                            tFiveProgressBar1.Color2 = ProgressbarColor(goodLinePer1 * 100.0);
                            tFiveProgressBar2.Color2 = ProgressbarColor(goodLinePer2 * 100.0);
                            tFiveProgressBar3.Color2 = ProgressbarColor(goodLinePer3 * 100.0);
                            tFiveProgressBar4.Color2 = ProgressbarColor(goodLinePer4 * 100.0);
                            tFiveProgressBar5.Color2 = ProgressbarColor(goodLinePer5 * 100.0);
                            tFiveProgressBar6.Color2 = ProgressbarColor(goodLinePer6 * 100.0);
                            tFiveProgressBar7.Color2 = ProgressbarColor(goodLinePerSum * 100.0);

                            numCheckLastGoodLine = 0;
                            newLine1 = 0;
                            newLine2 = 0;
                            newLine3 = 0;
                            newLine4 = 0;
                            newLine5 = 0;
                            newLine6 = 0;
                        }

                        for (var i = dgv6Line.RowCount - 1; i >= 0; i += -1)
                        {
                            var lastOldScore1 = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 1 - numCheckLastGoodLine]);
                            var lastOldScore2 = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 2 - numCheckLastGoodLine]);
                            var lastOldScore3 = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 3 - numCheckLastGoodLine]);
                            var lastOldScore4 = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 4 - numCheckLastGoodLine]);
                            var lastOldScore5 = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 5 - numCheckLastGoodLine]);
                            var lastOldScore6 = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 6 - numCheckLastGoodLine]);
                            var lastOldScoreSum = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 7 - numCheckLastGoodLine]);

                            var newGoodLine1 = ConvertOldScore2WinLose(lastOldScore1, lastOldScore2);
                            var newGoodLine2 = ConvertOldScore2WinLose(lastOldScore1, lastOldScore3);
                            var newGoodLine3 = ConvertOldScore2WinLose(lastOldScore1, lastOldScore4);
                            var newGoodLine4 = ConvertOldScore2WinLose(lastOldScore1, lastOldScore5);
                            var newGoodLine5 = ConvertOldScore2WinLose(lastOldScore1, lastOldScore6);
                            var newGoodLine6 = ConvertOldScore2WinLose(lastOldScore1, lastOldScoreSum);

                            if (newGoodLine1 == "W")
                            {
                                newLine1 += 1;
                            }
                            if (newGoodLine2 == "W")
                            {
                                newLine2 += 1;
                            }
                            if (newGoodLine3 == "W")
                            {
                                newLine3 += 1;
                            }
                            if (newGoodLine4 == "W")
                            {
                                newLine4 += 1;
                            }
                            if (newGoodLine5 == "W")
                            {
                                newLine5 += 1;
                            }
                            if (newGoodLine6 == "W")
                            {
                                newLine6 += 1;
                            }

                            numCheckLastGoodLine++;
                            if (numCheckLastGoodLine >= 5)
                            {
                                break;
                            }
                        }

                        double[] newResultGoodLine =
                        {
                            newLine1,
                            newLine2,
                            newLine3,
                            newLine4,
                            newLine5,
                            newLine6
                        };
                        _goodLineBetThis = DoubleArray2ShortArray(newResultGoodLine);
                        var item2 = _listScorePBT[_listScorePBT.Count - 1 - _goodLineBetThis];
                        _listLastHighResult.Add(item2);
                    }

                    #endregion


                    if (_listBigRoad.Count > 0)
                    {
                        if (_listBigRoad[_listBigRoad.Count - 1][_listBigRoad[_listBigRoad.Count - 1].Count - 1] == PBT_Type120)
                        {
                            _listBigRoad[_listBigRoad.Count - 1].Add(PBT_Type120);
                        }
                        else
                        {
                            _listBigRoad.Add(new List<short>());
                            _listBigRoad[_listBigRoad.Count - 1].Add(PBT_Type120);
                        }
                    }
                    else
                    {
                        _listBigRoad.Add(new List<short>());
                        _listBigRoad[_listBigRoad.Count - 1].Add(PBT_Type120);
                    }
                }

                #region UpdateValuePBT

                if (PBT_Type120 == 1)
                {
                    ref var ptr = ref _valueP;
                    _valueP = ptr + 1;
                }
                else if (PBT_Type120 == 2)
                {
                    ref var ptr = ref _valueB;
                    _valueB = ptr + 1;
                }
                else
                {
                    ref var ptr = ref _valueT;
                    _valueT = ptr + 1;
                }

                #endregion

                CheckPlayerOrBankerHigh();

                #region Formula Control

                switch (formula)
                {
                    case "GoodLine":
                        {
                            if (_listLastHighResult.Count >= 6)
                            {
                                bettingSuggest = _listLastHighResult[_listLastHighResult.Count - 1];
                            }

                            break;
                        }

                    case "GoodLineRandom":
                        {
                            if (_listScorePBT.Count >= 6)
                            {
                                //  short num20 = (short)Math.Round(Conversion.Val(Class12.smethod_8("1,2,3,4,5,6")));
                                var randomNumber = (short)RandomNumber(1, 6);
                                bettingSuggest = _listScorePBT[_listScorePBT.Count - randomNumber];
                                lbShowLineRandom.Text = randomNumber.ToString();
                                _goodLineBetThis = randomNumber;
                            }

                            break;
                        }

                    case "GoodLineFix":
                        {
                            if (_listScorePBT.Count >= ValueForBot.GoodLineFix)
                            {
                                bettingSuggest = _listScorePBT[_listScorePBT.Count - ValueForBot.GoodLineFix];
                            }
                            _goodLineBetThis = (short)ValueForBot.GoodLineFix;
                            break;
                        }

                    case "Lock":
                        bettingSuggest = (short)ValueForBot.Lock;
                        break;

                    case "Random":
                        bettingSuggest = (short)RandomNumber(1, 2);
                        break;

                    default:
                        bettingSuggest = GetFormula(formula, _listBigRoad, _listResult, _listScorePBT);

                        if (formula == "Follow")
                        {
                            if (ValueForBot.Follow == 3 || ValueForBot.Follow == bettingSuggest)
                            {
                                bettingSuggest = _listScorePBT[_listScorePBT.Count - 1];
                            }
                            else
                            {
                                bettingSuggest = 3;
                            }
                        }

                        break;
                }

                #endregion

                #region Logs Control

                if (_listUnit.Count > 0)
                {
                    lastMoneyBalance = _listBalance[_listBalance.Count - 1];
                    var unitCount = _listUnit[_listUnit.Count - 1];
                    if (unitCount > 0)
                    {
                        var lastBetResult = ConvertTypeGame2String(_listResult[_listResult.Count - 1]);
                        var number = dgvLog.RowCount + 1;
                        var betResult = ConvertTypeGame2String(PBT_Type120);
                        _lastStep = _listStep[_listStep.Count - 1];

                        var num23 = _listBettingSuggest[_listBettingSuggest.Count - 1];
                        var betSuggest = ConvertTypeGame2String(num23);
                        var chipLast = _listChipLast[_listChipLast.Count - 1].ToString();
                        winOrLose = ConvertOldScore2WinLose(lastBetResult, betSuggest);
                        moneyCost = MoneyCost(PBT_Type120, unitCount, short.Parse(chipLast), winOrLose);

                        unchecked
                        {
                            lastMoneyBalance = _listBalance[checked(_listBalance.Count - 1)] + moneyCost;
                            if (lastMoneyBalance > _maxProfit)
                            {
                                _maxProfit = lastMoneyBalance;
                            }

                            dgvLog.Rows.Add(
                                number,
                                timeValue,
                                betSuggest,
                                betResult,
                                winOrLose,
                                moneyCost,
                                lastMoneyBalance,
                                formula,
                                betSystem,
                                chipLast,
                                unitCount,
                                modeType,
                                _lastStep);
                        }
                        dgvLog["colResult", dgvLog.RowCount - 1].Style.ForeColor = ChangeColorByType(PBT_Type120);
                        dgvLog["colWL", dgvLog.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(PBT_Type120, num23);
                        dgvLog["colCost", dgvLog.RowCount - 1].Style.ForeColor = ChangeBackColorLineGoodLine(PBT_Type120, num23);
                        dgvLog["colBalance", dgvLog.RowCount - 1].Style.ForeColor = DataGridForeColor((int)Math.Round(lastMoneyBalance));
                        dgvLog.CurrentCell = dgvLog.Rows[dgvLog.Rows.Count - 1].Cells[0];
                        dgvLog.ClearSelection();
                        TopContinues();
                    }
                }
                else if (_listBalance.Count > 0)
                {
                    lastMoneyBalance = _listBalance[_listBalance.Count - 1];
                }

                _lastMoneyBalance = lastMoneyBalance;

                #endregion


                if (Settings_cbInvert.CheckedState)
                {
                    bettingSuggest = BetInvert(bettingSuggest);
                }

                _listBettingSuggest.Add(bettingSuggest);
                _listWinLose.Add(winOrLose);
                _listMoneyCost.Add(moneyCost);
                _listBetSystem.Add(betSystem);
                _listFormula.Add(formula);
                _listChipLast.Add(chipValue);
                _listBalance.Add(lastMoneyBalance);

                #region Bet System

                if (winOrLose == "W")
                {
                    if (moneyCost != 0.0)
                    {
                        ref var ptr = ref _totalWin;
                        _totalWin = ptr + 1;

                        if (_fibonacci <= 3)
                        {
                            _fibonacci = 1;
                        }
                        else
                        {
                            ptr = ref _fibonacci;
                            _fibonacci = ptr - 2;
                        }
                        if (_winBackLoseGo >= Betshort_0)
                        {
                            ptr = ref _winBackLoseGo;
                            _winBackLoseGo = ptr - Betshort_0;
                        }
                        else
                        {
                            _winBackLoseGo = 1;
                        }

                        ptr = ref _loseBackWinGo;
                        _loseBackWinGo = ptr + Betshort_3;
                    }
                }
                else if (winOrLose == "L")
                {
                    if (moneyCost != 0.0)
                    {
                        ref var ptr = ref _totalLose;
                        _totalLose = ptr + 1;

                        ptr = ref _fibonacci;
                        _fibonacci = ptr + 1;

                        if (_loseBackWinGo >= Betshort_2)
                        {
                            ptr = ref _loseBackWinGo;
                            _loseBackWinGo = ptr - Betshort_2;
                        }
                        else
                        {
                            _loseBackWinGo = 1;
                        }
                        ptr = ref _winBackLoseGo;
                        _winBackLoseGo = ptr + Betshort_1;
                    }
                }


                if (bettingSuggest == 1 | bettingSuggest == 2)
                {
                    unitValue = ChipUnit(betSystem, _lastStep);
                }
                if (unitValue == 0 && UnitCount(_listUnit) >= _forceValue)
                {
                    try
                    {
                        var value = _forceType == 1 ? _listScorePBT[_listScorePBT.Count - 1] : BetInvert(_listScorePBT[_listScorePBT.Count - 1]);
                        _listBettingSuggest[_listBettingSuggest.Count - 1] = value;
                    }
                    catch
                    {
                    }


                    var checkUnitValue = (short)ChipUnit(betSystem, _lastStep);
                    if (checkUnitValue == 0)
                    {
                        checkUnitValue = 1;
                    }
                    unitValue = checkUnitValue;
                }

                #endregion


                _listUnit.Add((short)unitValue);
                _listStep.Add(_lastStep);

                UpdateDisplay();
            }
        }
        public void TopContinues()
        {
            _maxContinuesW = 0;
            _maxTopContinuesLose = 0;
            var dgv = dgvLog;
            checked
            {
                if (dgv.RowCount > 0)
                {
                    short num = 0;
                    short num2 = 0;
                    var rowCount = dgv.RowCount - 1;
                    for (var i = 0; i <= rowCount; i++)
                    {

                        var cost = (double)dgv["colCost", i].Value;

                        var winOrLose = dgv["colWL", i].Value.ToString();
                        if (!string.IsNullOrWhiteSpace(winOrLose))
                        {
                            if (cost > 0.0)
                            {
                                num += 1;
                                num2 = 0;
                                if (num > _maxContinuesW)
                                {
                                    _maxContinuesW = num;
                                }
                            }
                            else if (cost < 0.0)
                            {
                                num = 0;
                                num2 += 1;
                                if (num2 > _maxTopContinuesLose)
                                {
                                    _maxTopContinuesLose = num2;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static short UnitCount(List<short> unit_list)
        {
            short result = 0;
            checked
            {
                if (unit_list.Count > 0)
                {
                    var num = unit_list[unit_list.Count - 1];
                    if (num == 0)
                    {
                        short num2 = 0;
                        var count = unit_list.Count - 1;
                        while (count >= 0 && unit_list[count] == 0 && unit_list[count] == num)
                        {
                            num2 += 1;
                            count += -1;
                        }
                        result = num2;
                    }
                }
                return result;
            }
        }
        private void UpdateDisplay()
        {
            checked
            {
                if (!_backUpBigRoad)
                {
                    lbT.Text = _valueT.ToString();
                    lbP.Text = _valueP.ToString();
                    lbB.Text = _valueB.ToString();


                    _customSumLikeCount = "";
                    var array = ArrayIntBigRoadCount(_listBigRoad);
                    var list = new List<int>();
                    var str = "";
                    var num2 = array.Length - 1;
                    for (var i = 0; i <= num2; i++)
                    {

                        /////5555555
                        var num3 = array[i];

                        if (num3 > 0)
                        {
                            list.Add(num3);
                            if (list.Count > 1)
                            {
                                str += ",";
                            }
                            str = str + i + ":" + list[list.Count - 1];
                        }
                    }
                    _customSumLikeCount = str;
                    StatusUpdate();
                    if (_listScorePBT.Count >= 6)
                    {
                        lbShowLine1.Text = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 1]);
                        lbShowLine2.Text = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 2]);
                        lbShowLine3.Text = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 3]);
                        lbShowLine4.Text = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 4]);
                        lbShowLine5.Text = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 5]);
                        lbShowLine6.Text = ConvertTypeGame2String(_listScorePBT[_listScorePBT.Count - 6]);
                        lbShowLine7.Text = ConvertTypeGame2String(_listLastHighResult[_listLastHighResult.Count - 1]);

                        lbShowLine1.BackColor = ChangeColorByType(_listScorePBT[_listScorePBT.Count - 1]);
                        lbShowLine2.BackColor = ChangeColorByType(_listScorePBT[_listScorePBT.Count - 2]);
                        lbShowLine3.BackColor = ChangeColorByType(_listScorePBT[_listScorePBT.Count - 3]);
                        lbShowLine4.BackColor = ChangeColorByType(_listScorePBT[_listScorePBT.Count - 4]);
                        lbShowLine5.BackColor = ChangeColorByType(_listScorePBT[_listScorePBT.Count - 5]);
                        lbShowLine6.BackColor = ChangeColorByType(_listScorePBT[_listScorePBT.Count - 6]);
                        lbShowLine7.BackColor = ChangeColorByType(_listLastHighResult[_listLastHighResult.Count - 1]);
                    }

                }


            }
        }
        public static int[] ArrayIntBigRoadCount(List<List<short>> BigRoad)
        {
            var array = new int[101];
            checked
            {
                if (BigRoad.Count != 0)
                {
                    Array.Clear(array, 0, array.Length);
                    var num = BigRoad.Count - 1;
                    for (var i = 0; i <= num; i++)
                    {
                        var count = BigRoad[i].Count;
                        var array2 = array;
                        var num2 = count;
                        ref var ptr = ref array2[num2];
                        array2[num2] = ptr + 1;
                    }
                }
                return array;
            }
        }

        #endregion

        #region Formula

        public static short GetFormula(string formulaType, List<List<short>> BigRoad, List<short> listResult, List<short> listLastPBT)
        {
            short result = 3;
            checked
            {
                if (BigRoad.Count != 0)
                {
                    var result2 = BigRoad[BigRoad.Count - 1][BigRoad[BigRoad.Count - 1].Count - 1];
                    if (formulaType == "Custom")
                    {
                        short bigRoadOldCount = 0;
                        if (BigRoad.Count > 10)
                        {
                            bigRoadOldCount = (short)(BigRoad.Count - 10);
                        }

                        var text = "";
                        int roadOldCount = bigRoadOldCount;
                        var count = BigRoad.Count;
                        for (var i = roadOldCount; i <= count; i++)
                        {
                            if (i < BigRoad.Count)
                            {
                                if (text != "")
                                {
                                    text += ",";
                                }

                                text += BigRoad[i].Count.ToString();
                            }
                        }
                        return SplitFollowAdverseList(text, listResult);
                    }

                    if (formulaType == "AI")
                    {
                        if (BigRoad.Count == 1)
                        {
                            return result2;
                        }

                        if (BigRoad.Count == 2)
                        {
                            if (BigRoad[BigRoad.Count - 2].Count == BigRoad[BigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 1].Count >= 4)
                            {
                                return result2;
                            }

                            return result;
                        }
                        if (BigRoad.Count == 3)
                        {
                            if (BigRoad[BigRoad.Count - 3].Count == BigRoad[BigRoad.Count - 2].Count &
                                BigRoad[BigRoad.Count - 2].Count == BigRoad[BigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 3].Count > BigRoad[BigRoad.Count - 2].Count &
                                BigRoad[BigRoad.Count - 3].Count == BigRoad[BigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 3].Count == BigRoad[BigRoad.Count - 2].Count &
                                BigRoad[BigRoad.Count - 2].Count > BigRoad[BigRoad.Count - 1].Count)
                            {
                                return result2;
                            }

                            if (BigRoad[BigRoad.Count - 3].Count == 1 & BigRoad[BigRoad.Count - 2].Count == 2 &
                                BigRoad[BigRoad.Count - 1].Count == 3)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 3].Count == 5 & BigRoad[BigRoad.Count - 2].Count == 4 &
                                BigRoad[BigRoad.Count - 1].Count == 3)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 3].Count == 4 & BigRoad[BigRoad.Count - 2].Count == 3 &
                                BigRoad[BigRoad.Count - 1].Count == 2)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 1].Count >= 4)
                            {
                                return result2;
                            }

                            return result;
                        }
                        if (BigRoad.Count > 3 & BigRoad.Count < 6)
                        {
                            if (BigRoad[BigRoad.Count - 4].Count == BigRoad[BigRoad.Count - 3].Count &
                                BigRoad[BigRoad.Count - 3].Count == BigRoad[BigRoad.Count - 2].Count &
                                BigRoad[BigRoad.Count - 2].Count == BigRoad[BigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 4].Count == BigRoad[BigRoad.Count - 2].Count &
                                BigRoad[BigRoad.Count - 3].Count > BigRoad[BigRoad.Count - 4].Count &
                                BigRoad[BigRoad.Count - 3].Count > BigRoad[BigRoad.Count - 1].Count)
                            {
                                return result2;
                            }

                            if (BigRoad[BigRoad.Count - 4].Count == BigRoad[BigRoad.Count - 2].Count &
                                BigRoad[BigRoad.Count - 3].Count < BigRoad[BigRoad.Count - 4].Count &
                                BigRoad[BigRoad.Count - 3].Count > BigRoad[BigRoad.Count - 1].Count)
                            {
                                return result2;
                            }

                            if (BigRoad[BigRoad.Count - 4].Count > BigRoad[BigRoad.Count - 3].Count &
                                BigRoad[BigRoad.Count - 4].Count == BigRoad[BigRoad.Count - 2].Count &
                                BigRoad[BigRoad.Count - 3].Count == BigRoad[BigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 4].Count < BigRoad[BigRoad.Count - 3].Count &
                                BigRoad[BigRoad.Count - 4].Count == BigRoad[BigRoad.Count - 2].Count &
                                BigRoad[BigRoad.Count - 3].Count == BigRoad[BigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 3].Count == 1 & BigRoad[BigRoad.Count - 2].Count == 2 &
                                BigRoad[BigRoad.Count - 1].Count == 3)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 4].Count == 1 & BigRoad[BigRoad.Count - 3].Count == 2 &
                                BigRoad[BigRoad.Count - 2].Count == 3 & BigRoad[BigRoad.Count - 1].Count <
                                BigRoad[BigRoad.Count - 2].Count)
                            {
                                return result2;
                            }

                            if (BigRoad[BigRoad.Count - 4].Count == 3 & BigRoad[BigRoad.Count - 3].Count == 4 &
                                BigRoad[BigRoad.Count - 2].Count == 3 & BigRoad[BigRoad.Count - 1].Count == 2)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 4].Count == 5 & BigRoad[BigRoad.Count - 3].Count == 4 &
                                BigRoad[BigRoad.Count - 2].Count == 3 & BigRoad[BigRoad.Count - 1].Count == 2)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 3].Count == 5 & BigRoad[BigRoad.Count - 2].Count == 4 &
                                BigRoad[BigRoad.Count - 1].Count == 3)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 3].Count == 4 & BigRoad[BigRoad.Count - 2].Count == 3 &
                                BigRoad[BigRoad.Count - 1].Count == 2)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 1].Count >= 4)
                            {
                                return result2;
                            }

                            return result;
                        }
                        else
                        {
                            if (BigRoad.Count < 6)
                            {
                                return result;
                            }

                            if (BigRoad[BigRoad.Count - 6].Count == BigRoad[BigRoad.Count - 3].Count &
                                BigRoad[BigRoad.Count - 5].Count == BigRoad[BigRoad.Count - 2].Count &
                                BigRoad[BigRoad.Count - 4].Count == BigRoad[BigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 6].Count == BigRoad[BigRoad.Count - 3].Count &
                                BigRoad[BigRoad.Count - 5].Count == BigRoad[BigRoad.Count - 2].Count &
                                BigRoad[BigRoad.Count - 4].Count > BigRoad[BigRoad.Count - 1].Count)
                            {
                                return result2;
                            }

                            if (BigRoad[BigRoad.Count - 4].Count == BigRoad[BigRoad.Count - 3].Count &
                                BigRoad[BigRoad.Count - 3].Count == BigRoad[BigRoad.Count - 2].Count &
                                BigRoad[BigRoad.Count - 2].Count == BigRoad[BigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 4].Count > BigRoad[BigRoad.Count - 3].Count &
                                BigRoad[BigRoad.Count - 4].Count == BigRoad[BigRoad.Count - 2].Count &
                                BigRoad[BigRoad.Count - 3].Count == BigRoad[BigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 4].Count < BigRoad[BigRoad.Count - 3].Count &
                                BigRoad[BigRoad.Count - 4].Count == BigRoad[BigRoad.Count - 2].Count &
                                BigRoad[BigRoad.Count - 3].Count == BigRoad[BigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 3].Count == 1 & BigRoad[BigRoad.Count - 2].Count == 2 &
                                BigRoad[BigRoad.Count - 1].Count == 3)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 4].Count == 1 & BigRoad[BigRoad.Count - 3].Count == 2 &
                                BigRoad[BigRoad.Count - 2].Count == 3 & BigRoad[BigRoad.Count - 1].Count <
                                BigRoad[BigRoad.Count - 2].Count)
                            {
                                return result2;
                            }

                            if (BigRoad[BigRoad.Count - 4].Count == 3 & BigRoad[BigRoad.Count - 3].Count == 4 &
                                BigRoad[BigRoad.Count - 2].Count == 3 & BigRoad[BigRoad.Count - 1].Count == 2)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 4].Count == 5 & BigRoad[BigRoad.Count - 3].Count == 4 &
                                BigRoad[BigRoad.Count - 2].Count == 3 & BigRoad[BigRoad.Count - 1].Count == 2)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 3].Count == 5 & BigRoad[BigRoad.Count - 2].Count == 4 &
                                BigRoad[BigRoad.Count - 1].Count == 3)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 3].Count == 4 & BigRoad[BigRoad.Count - 2].Count == 3 &
                                BigRoad[BigRoad.Count - 1].Count == 2)
                            {
                                return BetInvert(result2);
                            }

                            if (BigRoad[BigRoad.Count - 1].Count >= 4)
                            {
                                return result2;
                            }

                            return result;
                        }
                    }

                    if (formulaType == "Follow")
                    {
                        return listLastPBT[listLastPBT.Count - 1];
                    }
                    result = 3;
                }
                return result;
            }


        }
        public static short SplitFollowAdverseList(string count, List<short> listResult)
        {
            short result = 3;
            checked
            {
                if (!(listResult.Count == 0 | count.Length == 0))
                {
                    for (var i = listResult.Count - 1; i >= 0; i += -1)
                    {
                        if (listResult[i] != 0)
                        {
                            var num = listResult[i];
                            var text = count;
                            var num2 = (short)(count.Length - 1);
                            short num3 = 0;
                            while (num3 <= num2)
                            {
                                var num4 = (short)ValueForBot.CustomValueNumber.IndexOf(text);
                                unchecked
                                {
                                    if (num4 != -1)
                                    {
                                        var left = ValueForBot.CustomValueFollowAdverse[num4];
                                        if (left == "X")
                                        {
                                            result = BetInvert(num);
                                            break;
                                        }
                                        if (left == "O")
                                        {
                                            result = num;
                                        }
                                        break;
                                    }

                                    if (text.Length <= 1)
                                    {
                                        break;
                                    }
                                    text = text.Remove(0, 1);
                                    num3 += 1;
                                }
                            }
                            return result;
                        }
                    }
                }
                return result;
            }
        }

        #endregion

        #region Bet System

        public int ChipUnit(string system, short step_)
        {
            var result = 0;
            checked
            {
                var num = CountLast(dgvLog, (short)dgvLog.Columns["colWL"].Index, (short)dgvLog.Columns["colCost"].Index);
                var left = "";
                if (dgvLog.RowCount > 0)
                {
                    left = ResultLast(dgvLog, (short)dgvLog.Columns["colWL"].Index, (short)dgvLog.Columns["colCost"].Index);
                }

                if (system == "PP")
                {
                    try
                    {
                        //_betSystemValue = ValueForBot.ValuePP;
                        var array10 = ValueForBot.ValuePP.Split('-');
                        var num27 = (short)array10.Length;
                        short num28 = 0;
                        if (_listWinLose.Count > 0)
                        {
                            if (left == "W")
                            {
                                var value = num % num27;
                                num28 = (short)value;
                            }
                            else
                            {
                                num28 = 0;
                            }
                        }
                        _lastStep = 28;
                        return int.Parse(array10[num28]);
                    }
                    catch
                    {

                    }
                }
                if (system == "NP")
                {
                    try
                    {
                        //_betSystemValue = ValueForBot.ValueNP;
                        var array = ValueForBot.ValueNP.Split('-');
                        var num3 = (short)array.Length;
                        short num4 = 0;
                        if (_listWinLose.Count > 0)
                        {
                            if (left == "L")
                            {
                                var value = num % num3;
                                num4 = (short)value;
                            }
                            else
                            {
                                num4 = 0;
                            }
                        }
                        _lastStep = num4;
                        return int.Parse(array[num4]);
                    }
                    catch
                    {

                    }
                }
                if (system == "PPNP")
                {
                    try
                    {
                        //_betSystemValue = ValueForBot.ValuePP + "," + ValueForBot.ValueNP;
                        var valuePp = ValueForBot.ValuePP.Split('-');
                        var valuePpLength = (short)valuePp.Length;
                        var valueNp = ValueForBot.ValueNP.Split('-');
                        var valueNpLength = (short)valueNp.Length;

                        short num11 = 0;
                        if (_listWinLose.Count > 0)
                        {
                            if (left == "W")
                            {
                                var value = num % valuePpLength;
                                num11 = (short)value;
                                result = int.Parse(valuePp[num11]);
                            }
                            else
                            {
                                var value = num % valueNpLength;
                                num11 = (short)value;

                                result = int.Parse(valueNp[num11]);
                            }
                        }

                        _lastStep = num11;
                        return result;
                    }
                    catch
                    {

                    }
                }
                if (system == "AI")
                {
                    try
                    {
                        //_betSystemValue = "";
                        var array9 = "1-3-2-4-3-6-4-7-5-8-6-9-7-10".Split('-');
                        var num21 = (short)array9.Length;
                        var num22 = (short)"1-2-4-8".Split('-').Length;
                        short num23 = 0;
                        if (_listWinLose.Count > 0)
                        {
                            if (left == "W")
                            {
                                var value = num % num21;
                                num23 = (short)value;
                            }
                            else
                            {
                                var value = num % num22;
                                num23 = (short)value;
                            }
                        }

                        _lastStep = num23;
                        return int.Parse(array9[num23]);
                    }
                    catch
                    {
                    }
                }
                if (system == "Fibonacci")
                {
                    //_betSystemValue = "";
                    _lastStep = step_;
                    return SplitFib(_fibonacci, ValueForBot.ValueFib);

                }
                if (system == "OneShot")
                {
                    int num26;
                    if (_listBalance.Count > 0)
                    {
                        //int num24 = (int)Math.Round(unchecked(Convert.ToDouble(Math.Abs(Convert.ToDecimal(this.lblTopProfit.Text))) - _listBalance[checked(_listBalance.Count - 1)]));
                        var num24 = (int)Math.Round(Convert.ToDouble(Math.Abs(Convert.ToDecimal(_maxProfit))) - _listBalance[checked(_listBalance.Count - 1)]);

                        var num25 = ValueForBot.Chip;
                        if (num24 > num25)
                        {
                            if (left == "W")
                            {
                                if (num == 1)
                                {
                                    num26 = (int)Math.Round(Math.Ceiling(num24 / (double)num25) + 1.0);
                                }
                                else
                                {
                                    num26 = 1;
                                }
                            }
                            else
                            {
                                num26 = 1;
                            }
                        }
                        else
                        {
                            num26 = 1;
                        }
                    }
                    else
                    {
                        num26 = 1;
                    }

                    _lastStep = step_;
                    return num26;
                }

                _lastStep = step_;
                return result;
            }
        }

        public short CountLast(DataGridView dgv, short colomn_WL, short colomn_Cost)
        {
            var text = "";
            short num = 0;
            if (dgv.RowCount != 0)
            {
                for (var num2 = checked((short)(dgv.RowCount - 1)); num2 >= 0; num2 += -1)
                {
                    checked
                    {
                        if (num2 == dgv.RowCount - 1)
                        {
                            if (decimal.Compare(Convert.ToDecimal(dgv[colomn_Cost, num2].Value), 0m) != 0)
                            {
                                text = dgv[colomn_WL, num2].Value.ToString();
                                if (text == dgv[colomn_WL, num2].Value.ToString())
                                {
                                    num += 1;
                                }
                            }
                        }
                        else if (decimal.Compare(Convert.ToDecimal(dgv[colomn_Cost, num2].Value), 0m) != 0)
                        {
                            if (text == "")
                            {
                                text = dgv[colomn_WL, num2].Value.ToString();
                                if (text == dgv[colomn_WL, num2].Value.ToString())
                                {
                                    num += 1;
                                }
                            }
                            else
                            {
                                if (dgv[colomn_WL, num2].Value.ToString() != text)
                                {
                                    break;
                                }
                                num += 1;
                            }
                        }
                    }
                }
            }
            return num;
        }

        public string ResultLast(DataGridView dgv, short colomn_WL, short colomn_Cost)
        {
            var text = "";
            if (dgv.RowCount != 0)
            {
                for (var num2 = checked((short)(dgv.RowCount - 1)); num2 >= 0; num2 += -1)
                {
                    checked
                    {
                        if (num2 == dgv.RowCount - 1)
                        {
                            if (decimal.Compare(Convert.ToDecimal(dgv[colomn_Cost, num2].Value), 0m) != 0)
                            {
                                text = dgv[colomn_WL, num2].Value.ToString();
                                if (text == dgv[colomn_WL, num2].Value.ToString())
                                {
                                }
                            }
                        }
                        else if (decimal.Compare(Convert.ToDecimal(dgv[colomn_Cost, num2].Value), 0m) != 0)
                        {
                            if (text == "")
                            {
                                text = dgv[colomn_WL, num2].Value.ToString();
                                if (text == dgv[colomn_WL, num2].Value.ToString())
                                {
                                }
                            }
                            else
                            {
                                if (dgv[colomn_WL, num2].Value.ToString() != text)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return text;
        }

        public static int SplitFib(int fibValue, string strFib)
        {
            var array = strFib.Split('-');
            checked
            {
                return int.Parse(fibValue <= array.Length ? array[fibValue - 1] : array[0]);
            }
        }

        #endregion


        #endregion

        #region Logs

        private void Logs_btnSummary_Click(object sender, EventArgs e)
        {

        }

        private void Logs_btnExport_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Settings

        #region Main Settings

        private void MainSettingsLoad()
        {

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

        private Bitmap _picBit2;
        public int PosX2, PosY2, CatcherX2, CatcherY2, BitWidth, BitHeight;
        private int _player, _banker, _tie, _empty, _all, _allNow, _allMax;
        private bool _allChanging1, _allChanging2, _allChanging3, _scoreFirstTime, _layoutCancel, _layoutYes;
        private bool _layoutListFirstTime = true;

        private string _lastWin,
            _pStart,
            _pPlayer,
            _pBanker,
            _pTie,
            _pConP,
            _pConB,
            _pChip1,
            _pChip2,
            _pChip3,
            _pChip4,
            _pChip5,
            _pColorStart,
            _pColorPlayer,
            _pColorBanker,
            _pColorTie,
            _xCount,
            _yCount,
            _posPic,
            _chip1,
            _chip2,
            _chip3,
            _chip4,
            _chip5,
            _save,

            _pProcessStart,
            _pProcessPlayer,
            _pProcessBanker,
            _pProcessTie,
            _pProcessConP,
            _pProcessConB,
            _pProcessChip1,
            _pProcessChip2,
            _pProcessChip3,
            _pProcessChip4,
            _pProcessChip5,
            _pRGBStart,
            _pRGBPlayer,
            _pRGBBanker,
            _pRGBTie;


        private static PositionMode _layoutMode;

        #endregion Variable

        #region Load/SaveSetting

        private void Layout_CallPosition()
        {
            dgvSetting.Rows.Clear();
            dgvGoodLine.Font = new Font("Segoe UI", 9);
            dgvSetting.Font = new Font("Segoe UI", 9);

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

        private void EasyAdd(DataGridView dgv, string name, string button, string position, object chipValue = null, string color = " ", string processName = " ", string colorRGB = " ")
        {
            if(chipValue == null)
            {
                chipValue = " ";
            }
            dgv.Rows.Add(name, button, position, chipValue, color, processName, colorRGB);
        }

        private bool _checkFileFirstTime;
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
                    _checkFileFirstTime = true;
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
                    var msgResult = MessageBox.Show($@"[{LayoutValues.NameList}] {stringLoader.Modified}",
                        stringLoader.Confirmation, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
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
                  
                    Layout_LoadList2Data();
                    Layout_GetValue4Check();
                }

                SettingChipSelected();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stringLoader.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var array = list[i].Split('|');
                    switch (i)
                    {
                        case 0:
                            _pStart = array[0];
                            _pColorStart = array[2];

                            _pProcessStart = array[3];
                            _pRGBStart = array[4];
                            break;

                        case 1:
                            _pPlayer = array[0];
                            _pColorPlayer = array[2];

                            _pProcessPlayer = array[3];
                            _pRGBPlayer = array[4];
                            break;

                        case 2:
                            _pBanker = array[0];
                            _pColorBanker = array[2];

                            _pProcessBanker = array[3];
                            _pRGBBanker = array[4];
                            break;

                        case 3:
                            _pTie = array[0];
                            _pColorTie = array[2];

                            _pProcessTie = array[3];
                            _pRGBTie = array[4];
                            break;

                        case 4:
                            _pConP = array[0];
                            _pProcessConP = array[3];
                            break;

                        case 5:
                            _pConB = array[0];
                            _pProcessConB = array[3];
                            break;

                        case 6:
                            _pChip1 = array[0];
                            _chip1 = array[1];
                            _pProcessChip1 = array[3];
                            break;

                        case 7:
                            _pChip2 = array[0];
                            _chip2 = array[1];
                            _pProcessChip2 = array[3];
                            break;

                        case 8:
                            _pChip3 = array[0];
                            _chip3 = array[1];
                            _pProcessChip3 = array[3];
                            break;

                        case 9:
                            _pChip4 = array[0];
                            _chip4 = array[1];
                            _pProcessChip4 = array[3];
                            break;

                        case 10:
                            _pChip5 = array[0];
                            _chip5 = array[1];
                            _pProcessChip5 = array[3];
                            break;

                        case 11:
                            _layoutMode = (PositionMode)int.Parse(array[0]);
                            break;
                    }
                }
               
                dgvSetting[2, 0].Value = _pStart;
                dgvSetting[2, 1].Value = _pPlayer;
                dgvSetting[2, 2].Value = _pBanker;
                dgvSetting[2, 3].Value = _pTie;

                dgvSetting[2, 4].Value = _pConP;
                dgvSetting[2, 5].Value = _pConB;

                dgvSetting[2, 6].Value = _pChip1;
                dgvSetting[2, 7].Value = _pChip2;
                dgvSetting[2, 8].Value = _pChip3;
                dgvSetting[2, 9].Value = _pChip4;
                dgvSetting[2, 10].Value = _pChip5;

                dgvSetting[3, 6].Value = _chip1;
                dgvSetting[3, 7].Value = _chip2;
                dgvSetting[3, 8].Value = _chip3;
                dgvSetting[3, 9].Value = _chip4;
                dgvSetting[3, 10].Value = _chip5;

                dgvSetting[4, 0].Value = _pColorStart;
                dgvSetting[4, 1].Value = _pColorPlayer;
                dgvSetting[4, 2].Value = _pColorBanker;
                dgvSetting[4, 3].Value = _pColorTie;

                dgvSetting[5, 0].Value = _pProcessStart;
                dgvSetting[5, 1].Value = _pProcessPlayer;
                dgvSetting[5, 2].Value = _pProcessBanker;
                dgvSetting[5, 3].Value = _pProcessPlayer;
                dgvSetting[5, 4].Value = _pProcessConP;
                dgvSetting[5, 5].Value = _pProcessConB;
                dgvSetting[5, 6].Value = _pProcessChip1;
                dgvSetting[5, 7].Value = _pProcessChip2;
                dgvSetting[5, 8].Value = _pProcessChip3;
                dgvSetting[5, 9].Value = _pProcessChip4;
                dgvSetting[5, 10].Value = _pProcessChip5;

                dgvSetting[6, 0].Value = _pRGBStart;
                dgvSetting[6, 1].Value = _pRGBPlayer;
                dgvSetting[6, 2].Value = _pRGBBanker;
                dgvSetting[6, 3].Value = _pRGBPlayer;

 LayoutLoadMode();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stringLoader.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($@"[{str}] {stringLoader.NotFound}", stringLoader.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _save = $"{(int)_layoutMode}";
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
                        stringLoader.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
                            dgv[2, i].Value.ToString(), "|",
                            dgv[3, i].Value.ToString(), "|",
                            dgv[4, i].Value.ToString(), "|",
                            dgv[5, i].Value.ToString(), "|",
                            dgv[6, i].Value.ToString());
                        streamWriter.Write(value);
                        streamWriter.Write(Environment.NewLine);
                    }
                    streamWriter.Write(another);
                    streamWriter.Write(Environment.NewLine);
                    streamWriter.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, stringLoader.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LayoutValues._pTie != _pTie ||
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
                LayoutValues._pColorStart != _pColorStart ||
                LayoutValues._pColorPlayer != _pColorPlayer ||
                LayoutValues._pColorBanker != _pColorBanker ||
                LayoutValues._pColorTie != _pColorTie ||
                LayoutValues._pProcessStart != _pProcessStart ||
                LayoutValues._pProcessPlayer != _pProcessPlayer ||
                LayoutValues._pProcessBanker != _pProcessBanker ||
                LayoutValues._pProcessTie != _pProcessTie ||
                LayoutValues._pProcessConP != _pProcessConP ||
                LayoutValues._pProcessConB != _pProcessConB ||
                LayoutValues._pProcessChip1 != _pProcessChip1 ||
                LayoutValues._pProcessChip2 != _pProcessChip2 ||
                LayoutValues._pProcessChip3 != _pProcessChip3 ||
                LayoutValues._pProcessChip4 != _pProcessChip4 ||
                LayoutValues._pProcessChip5 != _pProcessChip5 ||
                LayoutValues._pRGBStart != _pRGBStart ||
                LayoutValues._pRGBPlayer != _pRGBPlayer ||
                LayoutValues._pRGBBanker != _pRGBBanker||
                LayoutValues._pRGBTie != _pRGBTie)

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
 
            LayoutValues.Mode = (int)_layoutMode;

            LayoutValues._pStart = dgvSetting[2, 0].Value.ToString();
            LayoutValues._pPlayer = dgvSetting[2, 1].Value.ToString();
            LayoutValues._pBanker = dgvSetting[2, 2].Value.ToString();
            LayoutValues._pTie = dgvSetting[2, 3].Value.ToString();

            LayoutValues._pConP = dgvSetting[2, 4].Value.ToString();
            LayoutValues._pConB = dgvSetting[2, 5].Value.ToString();

            LayoutValues._pChip1 = dgvSetting[2, 6].Value.ToString();
            LayoutValues._pChip2 = dgvSetting[2, 7].Value.ToString();
            LayoutValues._pChip3 = dgvSetting[2, 8].Value.ToString();
            LayoutValues._pChip4 = dgvSetting[2, 9].Value.ToString();
            LayoutValues._pChip5 = dgvSetting[2, 10].Value.ToString();

            LayoutValues._chip1 = dgvSetting[3, 6].Value.ToString();
            LayoutValues._chip2 = dgvSetting[3, 7].Value.ToString();
            LayoutValues._chip3 = dgvSetting[3, 8].Value.ToString();
            LayoutValues._chip4 = dgvSetting[3, 9].Value.ToString();
            LayoutValues._chip5 = dgvSetting[3, 10].Value.ToString();

            LayoutValues._pColorStart = dgvSetting[4, 0].Value.ToString();
            LayoutValues._pColorPlayer = dgvSetting[4, 1].Value.ToString();
            LayoutValues._pColorBanker = dgvSetting[4, 2].Value.ToString();
            LayoutValues._pColorTie = dgvSetting[4, 3].Value.ToString();

            LayoutValues._pProcessStart = dgvSetting[5, 0].Value.ToString();
            LayoutValues._pProcessPlayer = dgvSetting[5, 1].Value.ToString();
            LayoutValues._pProcessBanker = dgvSetting[5, 2].Value.ToString();
            LayoutValues._pProcessTie = dgvSetting[5, 3].Value.ToString();

            LayoutValues._pProcessConP = dgvSetting[5, 4].Value.ToString();
            LayoutValues._pProcessConB = dgvSetting[5, 5].Value.ToString();

            LayoutValues._pProcessChip1 = dgvSetting[5, 6].Value.ToString();
            LayoutValues._pProcessChip2 = dgvSetting[5, 7].Value.ToString();
            LayoutValues._pProcessChip3 = dgvSetting[5, 8].Value.ToString();
            LayoutValues._pProcessChip4 = dgvSetting[5, 9].Value.ToString();
            LayoutValues._pProcessChip5 = dgvSetting[5, 10].Value.ToString();

            LayoutValues._pRGBStart = dgvSetting[6, 0].Value.ToString();
            LayoutValues._pRGBPlayer = dgvSetting[6, 1].Value.ToString();
            LayoutValues._pRGBBanker = dgvSetting[6, 2].Value.ToString();
            LayoutValues._pRGBTie = dgvSetting[6, 3].Value.ToString();


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
            _pTie = dgvSetting[2, 3].Value.ToString();

            _pConP = dgvSetting[2, 4].Value.ToString();
            _pConB = dgvSetting[2, 5].Value.ToString();

            _pChip1 = dgvSetting[2, 6].Value.ToString();
            _pChip2 = dgvSetting[2, 7].Value.ToString();
            _pChip3 = dgvSetting[2, 8].Value.ToString();
            _pChip4 = dgvSetting[2, 9].Value.ToString();
            _pChip5 = dgvSetting[2, 10].Value.ToString();

            _chip1 = dgvSetting[3, 6].Value.ToString();
            _chip2 = dgvSetting[3, 7].Value.ToString();
            _chip3 = dgvSetting[3, 8].Value.ToString();
            _chip4 = dgvSetting[3, 9].Value.ToString();
            _chip5 = dgvSetting[3, 10].Value.ToString();

            _pColorStart = dgvSetting[4, 0].Value.ToString();
            _pColorPlayer = dgvSetting[4, 1].Value.ToString();
            _pColorBanker = dgvSetting[4, 2].Value.ToString();
            _pColorTie = dgvSetting[4, 3].Value.ToString();

            _pProcessStart = dgvSetting[5, 0].Value.ToString();
            _pProcessPlayer = dgvSetting[5, 1].Value.ToString();
            _pProcessBanker = dgvSetting[5, 2].Value.ToString();
            _pProcessTie = dgvSetting[5, 3].Value.ToString();

            _pProcessConP = dgvSetting[5, 4].Value.ToString();
            _pProcessConB = dgvSetting[5, 5].Value.ToString();
            _pProcessChip1 = dgvSetting[5, 6].Value.ToString();
            _pProcessChip2 = dgvSetting[5, 7].Value.ToString();
            _pProcessChip3 = dgvSetting[5, 8].Value.ToString();
            _pProcessChip4 = dgvSetting[5, 9].Value.ToString();
            _pProcessChip5 = dgvSetting[5, 10].Value.ToString();

            _pRGBStart = dgvSetting[6, 0].Value.ToString();
            _pRGBPlayer = dgvSetting[6, 1].Value.ToString();
            _pRGBBanker = dgvSetting[6, 2].Value.ToString();
            _pRGBTie = dgvSetting[6, 3].Value.ToString();


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
                if (!_checkFileFirstTime)
                {
                    if (Layout_CheckEdit())
                    {
                        var msgResult = MessageBox.Show($@"[{LayoutValues.NameList}] {stringLoader.Modified}",
                            stringLoader.Confirmation, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (msgResult == DialogResult.Yes)
                        {
                            Layout_SaveLayoutList();

                        }
                        if (msgResult == DialogResult.Cancel)
                        {
                            return;
                        }
                    }

                    _checkFileFirstTime = false;
                }
                

                Layout_CallPosition();
                _save = "15|6|(0, 0) (0, 0)|0";
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
                MessageBox.Show(ex.Message, stringLoader.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
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
                MessageBox.Show(ex.Message, stringLoader.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    if (_layoutMode == PositionMode.Normal)
                    {
                        Visible = false;
                        using (var getColor = new FrmColorInfo())
                        {
                            getColor.Mode = 0;
                            getColor.ShowDialog();
                        }
                        Visible = true;
                        if (Values.CloseFrom)
                        {
                            dgvSetting[column + 1, row].Value = $"({Values.CheckX},{Values.CheckY})";
                            if (row == 0 | row == 1 | row == 2 | row==3)
                            {
                                dgvSetting[column + 3, row].Value = $"{Values.Color}";
                                dgvSetting[column + 5, row].Value = $"{Values.RgbColor.R},{Values.RgbColor.G},{Values.RgbColor.B}";
                            }

                            Values.CloseFrom = false;
                        }
                    }

                    if (_layoutMode == PositionMode.Background)
                    {
                        Visible = false;
                        using (var getColor = new FrmColorInfo())
                        {
                            getColor.Mode = 1;
                            getColor.ShowDialog();
                        }
                        Visible = true;
                        if (Values.CloseFrom)
                        {
                            dgvSetting[column + 1, row].Value = $"({Values.CheckX},{Values.CheckY})";
                            if (row == 0 | row == 1 | row == 2|row==3)
                            {
                                dgvSetting[column + 3, row].Value = $"{Values.Color}";
                            }

                            dgvSetting[column + 4, row].Value = $"{Values.TitleName}";
                            Values.CloseFrom = false;
                        }
                    }

                    //else
                    //{
                    //    Visible = false;
                    //    using (var layer = new LayerForm())
                    //    {
                    //        layer.ShowDialog();
                    //    }
                    //    Visible = true;

                    //    if (Values.CloseFrom)
                    //    {
                    //        dgvSetting[column + 1, row].Value = $"({Values.CheckX},{Values.CheckY})";
                    //        dgvSetting[column + 3, row].Value = $"{Values.Color}";
                    //        Values.CloseFrom = false;
                    //    }
                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stringLoader.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (e.ColumnIndex == 3 && dgvSetting.CurrentRow.Index >= 5)
                {
                    var column = e.ColumnIndex;
                    var row = e.RowIndex;
                    var oldValue = dgvSetting[column, row].Value.ToString();
                    var input = TFiveInputBox.Show(stringLoader.InputChip, oldValue, true);

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
                        MessageBox.Show(stringLoader.InputChipNull, stringLoader.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stringLoader.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Background
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
           
            if (Layout_radBackGround.Checked)
            {
                _layoutMode = PositionMode.Background;
            }
            
        }

        private void LayoutLoadMode()
        {
            switch (_layoutMode)
            {
                case PositionMode.Normal:
                    Layout_radNormal.Checked = true;
                    break;

                case PositionMode.Background:
                    Layout_radBackGround.Checked = true;
                    break;
            }
        }


        #endregion ModeSettings
 
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

        private List<string> _customValueNumber;
        private List<string> _customValueFollowAdverse;
        private static List<string> _customValueNumberSaved = new List<string>();
        private static List<string> _customValueFollowAdverseSaved = new List<string>();
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
                    _customValueNumberSaved.Clear();
                    _customValueFollowAdverseSaved.Clear();
                    var num = array.Length - 1;
                    for (var i = 0; i <= num; i++)
                    {
                        var array2 = array[i].Split('=');
                        _customValueNumberSaved.Add(array2[0]);
                        _customValueFollowAdverseSaved.Add(array2[1]);
                    }
                }
                catch // if
                {
                    _customLoadValue2Array = CustomDefaultValue();
                    var array3 = _customLoadValue2Array.Split(';');
                    _customValueNumberSaved.Clear();
                    _customValueFollowAdverseSaved.Clear();
                    var num2 = array3.Length - 1;
                    for (var j = 0; j <= num2; j++)
                    {
                        var array4 = array3[j].Split('=');
                        _customValueNumberSaved.Add(array4[0]);
                        _customValueFollowAdverseSaved.Add(array4[1]);
                    }
                }
            }
        }

        private void CustomEdit()
        {
            FormulaBox.Visible = true;
            FormulaGroupMode.Enabled = false;
            Size = new Size(1165, 575);
            _customValueNumber = _customValueNumberSaved;
            _customValueFollowAdverse = _customValueFollowAdverseSaved;
            checked
            {
                if (_customValueNumber.Count > 0)
                {
                    Custom_listbox.Items.Clear();
                    var num = _customValueNumber.Count - 1;
                    for (var i = 0; i <= num; i++)
                    {
                        Custom_listbox.Items.Add(_customValueNumber[i]);
                    }
                }
                CustomList2Label();
            }
        }

        private void Custom_btSave_Click(object sender, EventArgs e)
        {
            if (Custom_listbox.Items.Count == 0)
            {
                MessageBox.Show(stringLoader.SetBetUnit, stringLoader.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _customValueNumber.Clear();
            checked
            {
                for (var i = 0; i <= Custom_listbox.Items.Count - 1; i++)
                {
                    _customValueNumber.Add(Custom_listbox.Items[i].ToString());
                }

                _customValueNumberSaved = _customValueNumber;
                _customValueFollowAdverseSaved = _customValueFollowAdverse;
                CustomSaveValue();
                FormulaGroupMode.Enabled = true;
                FormulaBox.Visible = false;
                Size = new Size(785, 575);
            }
        }

        private void CustomSaveValue()
        {
            CustomSaveValue(_customValueNumber, _customValueFollowAdverse);

            Settings.Default.Save();
        }

        public static void CustomSaveValue(List<string> ValueNumber, List<string> ValueFollowAdverse)
        {
            var text = "";
            checked
            {
                var num = ValueNumber.Count - 1;
                for (var i = 0; i <= num; i++)
                {
                    if (i > 0)
                    {
                        text += "|";
                    }
                    text = text + ValueNumber[i] + "=" + ValueFollowAdverse[i];
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
            Custom_lbTotal.Text = $@"{stringLoader.Total}: {Custom_listbox.Items.Count}";
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

            if (_customValueFollowAdverse[_customSelectedListbox] == "O")
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
                    _customValueFollowAdverse[_customSelectedListbox] = "O";
                    return;
                }
                if (Custom_radAdverse.Checked)
                {
                    _customValueFollowAdverse[_customSelectedListbox] = "X";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + $"\n {stringLoader.TryAgain}", stringLoader.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Custom_btAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Custom_txtNum.Text)) return;
            Custom_listbox.Items.Add(Custom_txtNum.Text.Trim());
            var item = Custom_radFollow.Checked ? "X" : "O";
            _customValueNumber.Add(Custom_txtNum.Text.Trim());
            _customValueFollowAdverse.Add(item);
            CustomList2Label();
        }

        private void Custom_btDel_Click(object sender, EventArgs e)
        {
            checked
            {
                var num = Custom_listbox.SelectedIndex;

                _customSelectedListbox = (short)Custom_listbox.SelectedIndex;
                if (_customSelectedListbox == -1) return;
                _customValueFollowAdverse.RemoveAt(_customSelectedListbox);
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
            _customValueFollowAdverse.Clear();
            CustomList2Label();
        }

        private void Custom_btDefault_Click(object sender, EventArgs e)
        {
            var array = CustomDefaultValue().Split(';');
            Custom_listbox.Items.Clear();
            _customValueFollowAdverse.Clear();
            checked
            {
                for (var i = 0; i <= array.Length - 1; i++)
                {
                    var array2 = array[i].Split('=');
                    Custom_listbox.Items.Add(array2[0]);
                    _customValueFollowAdverse.Add(array2[1]);
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
            Size = new Size(785, 575);
        }

        #endregion Button Control, Save Settings

        #endregion Custom

        #endregion Formula

        #region Betting System

        #region Variable

      

        private string _txtPp, _txtNp, _txtFib;
        private BettingMode _bettingEditor, _bettingSelected;

        #endregion Variable

        #region Mode

        private enum BettingMode
        {
            PP,
            NP,
            PPNP,

            Fibonacci,

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
            BettingEditMode(BettingMode.Fibonacci);
        }

        private void BettingEditMode(BettingMode mode)
        {
            BettingBox.Visible = true;
            _bettingEditor = mode;
            switch (mode)
            {
                case BettingMode.PP:
                    BettingBox.Text = stringLoader.PP;
                    Betting_lbDetails.Text = $@"{stringLoader.DetailPp1}"+Environment.NewLine+ $@"{stringLoader.DetailPp2}";

                    break;

                case BettingMode.NP:
                    BettingBox.Text = stringLoader.NP;
                    Betting_lbDetails.Text = $@"{stringLoader.DetailNp1}" + Environment.NewLine + $@"{stringLoader.DetailNp2}";
                    break;

                case BettingMode.Fibonacci:
                    BettingBox.Text = stringLoader.Fib;
                    Betting_lbDetails.Text = $@"{stringLoader.DetailFib1}" + Environment.NewLine + $@"{stringLoader.DetailFib2}";
                    break;
            }
            BettingTextToDataGridView();
            Betting_GroupMode.Enabled = false;
            Size = new Size(815, 575);
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
                _bettingSelected = BettingMode.Fibonacci;
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

            BettingSaveValue();
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

                case BettingMode.Fibonacci:
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
            Settings.Default._bettingSelected = (int)_bettingSelected;
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

                case BettingMode.Fibonacci:
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

                    case BettingMode.Fibonacci:
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

                case BettingMode.Fibonacci:
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
            Size = new Size(785, 575);
        }

        private void Betting_btSave_Click(object sender, EventArgs e)
        {
            if (dgvBetting.RowCount == 0)
            {
                MessageBox.Show(stringLoader.SetBetUnit, stringLoader.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BettingSaveValue();
            Size = new Size(785, 575);
            Betting_GroupMode.Enabled = true;
            BettingBox.Visible = false;
        }

        #endregion Value

        #endregion Betting System

        #endregion Settings

        #region Bot
        
        private string _amountBetChip;
        private bool _statusRunBot, _ready;
        private int _timeRunning, _timeStart, _statusRunningBot;
        private void BtStart_Click(object sender, EventArgs e)
        {
            ClickStart();
        }
        private void ClickStart()
        {
            btStart.Text = btStart.Text.EndsWith(stringLoader.Stop) ? stringLoader.Start : stringLoader.Stop;
            try
            {
                if (btStart.Text == stringLoader.Stop)
                {
                    if (Settings_cbCheckSettings.CheckedState)
                    {
                        if (!ShowDisplaySetting())
                        {
                            btStart.Text = stringLoader.Start;
                            return;
                        }
                    }

                    Layout_Position.Enabled = false;
                    Main_BetSettings.Enabled = false;
                    Main_Program.Enabled = false;
                    Main_Force.Enabled = false;
                    panel7.Enabled = false;
                    panel1.Enabled = false;
                    panel10.Enabled = false;
                    panel2.Enabled = false;
                    LoadValue4Bot();
                    RunBot(true, ValueForBot.Mode);
                }
                else if (btStart.Text == stringLoader.Start)
                {
                    Layout_Position.Enabled = true;
                    Main_BetSettings.Enabled = true;
                    Main_Program.Enabled = true;
                    Main_Force.Enabled = true;
                    panel7.Enabled = true;
                    panel1.Enabled = true;
                    panel10.Enabled = true;
                    panel2.Enabled = true;
                    RunBot(false, ValueForBot.Mode);
                }
            }
            catch
            {
            }
        }
        private void TmTimeRunning_Tick(object sender, EventArgs e)
        {
            dgvStatus[2, 0].Value = CalculateInt2Time(_timeRunning);
            ref int ptr = ref _timeStart;
            checked
            {
                _timeStart = ptr + 1;

                ptr = ref _timeRunning;
                _timeRunning = ptr + 1;

            }
        }
        public static string CalculateInt2Time(int value)
        {
            var sec = value % 60;
            checked
            {
                var min = (int)Math.Round((value - sec) / 60.0 % 60.0);
                var hr = (int)Math.Round((value - (sec + min * 60)) / 3600.0 % 60.0);
                return string.Concat(hr.ToString("00"), ":", min.ToString("00"), ":", sec.ToString("00"));
            }
        }
        private void RunBot(bool status, int mode)
        {
            _statusRunBot = status;
            if (_statusRunBot)
            {
                tmTimeRunning.Start();

                if (mode == 0)
                {
                    Bots_Worker.RunWorkerAsync();
                }

                if (mode == 1)
                {

                }

               
            }
            else
            {
                tmTimeRunning.Stop();

                if (mode == 0)
                {
                    Bots_Worker.CancelAsync();
                }

                if (mode == 1)
                {

                }
                

                _switchColor = false;
            }
        }

        #region Normal Mode

        private void Bots_Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (!Bots_Worker.CancellationPending)
            {
                CheckColorStartTime();
                AutoClick();
                CheckColorResult();
                AddClickToRoadBig();
            }
        }
        private void CheckColorStartTime()
        {
            checked
            {
                try
                {
                    //    if(_statusRunningBot != 0) return;

                    Bitmap bitmap = new Bitmap(1, 1);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(ValueForBot.Start, new Point(0, 0), new Size(1, 1));
                    }
                    Color pixel = bitmap.GetPixel(0, 0);
                    Invalidate();
                    ValueForBot.NewColorStart = pixel;

                    if (_statusRunBot && _statusRunningBot == 0 &&
                        (ValueForBot.NewColorStart.R >= ValueForBot.ColorStart.R - 10 &
                         ValueForBot.NewColorStart.R <= ValueForBot.ColorStart.R + 10) &
                        (ValueForBot.NewColorStart.G >= ValueForBot.ColorStart.G - 10 &
                         ValueForBot.NewColorStart.G <= ValueForBot.ColorStart.G + 10) &
                        (ValueForBot.NewColorStart.B >= ValueForBot.ColorStart.B - 10 &
                         ValueForBot.NewColorStart.B <= ValueForBot.ColorStart.B + 10))
                    {
                        _statusRunningBot = 1;
                        Thread.Sleep(200);
                        Application.DoEvents();
                    }

                    if ((ValueForBot.NewColorStart.R >= ValueForBot.ColorStart.R - 10 &
                         ValueForBot.NewColorStart.R <= ValueForBot.ColorStart.R + 10) &
                        (ValueForBot.NewColorStart.G >= ValueForBot.ColorStart.G - 10 &
                         ValueForBot.NewColorStart.G <= ValueForBot.ColorStart.G + 10) &
                        (ValueForBot.NewColorStart.B >= ValueForBot.ColorStart.B - 10 &
                         ValueForBot.NewColorStart.B <= ValueForBot.ColorStart.B + 10))
                    {
                        _ready = true;
                    }
                    else
                    {
                        _ready = false;
                    }


                    // Thread.Sleep(50);
                    Application.DoEvents();
                }
                catch
                {

                }
            }
        }
        private void AutoClick()
        {
            if (_statusRunningBot != 1) return;
            _statusRunningBot = 100;
            checked
            {
                if (_listBettingSuggest.Count > 0)
                {
                    AutoClick(_listBettingSuggest[_listBettingSuggest.Count - 1], _listUnit[_listUnit.Count - 1]);
                }

                _statusRunningBot = 2;
            }
        }
        private void AutoClick(short bettingSuggest, int lastUnit)
        {
            checked
            {
                if (_statusRunBot)
                {

                    lastUnit = lastUnit * ValueForBot.Chip;

                    var chip1 = int.Parse(LayoutValues._chip1);
                    var chip2 = int.Parse(LayoutValues._chip2);
                    var chip3 = int.Parse(LayoutValues._chip3);
                    var chip4 = int.Parse(LayoutValues._chip4);
                    var chip5 = int.Parse(LayoutValues._chip5);

                    short amountChip1 = 0;
                    short amountChip2 = 0;
                    short amountChip3 = 0;
                    short amountChip4 = 0;
                    short amountChip5 = 0;
                    if (lastUnit >= chip5)
                    {
                        amountChip5 = (short)Math.Floor((double)lastUnit / chip5);
                        lastUnit -= amountChip5 * chip5;
                        if (_amountBetChip == "")
                        {
                            _amountBetChip = chip5 + "x" + amountChip5;
                        }
                        else
                        {
                            _amountBetChip = "," + chip5 + "x" + amountChip5;
                        }
                    }
                    if (lastUnit >= chip4)
                    {
                        amountChip4 = (short)Math.Floor((double)lastUnit / chip4);
                        lastUnit -= amountChip4 * chip4;
                        if (_amountBetChip == "")
                        {
                            _amountBetChip = chip4 + "x" + amountChip4;
                        }
                        else
                        {
                            _amountBetChip = "," + chip4 + "x" + amountChip4;
                        }
                    }
                    if (lastUnit >= chip3)
                    {
                        amountChip3 = (short)Math.Floor((double)lastUnit / chip3);
                        lastUnit -= amountChip3 * chip3;
                        if (_amountBetChip == "")
                        {
                            _amountBetChip = chip3 + "x" + amountChip3;
                        }
                        else
                        {
                            ref string ptr = ref _amountBetChip;
                            _amountBetChip = string.Concat(ptr, ",", chip3.ToString(), "x", amountChip3.ToString());
                        }
                    }
                    if (lastUnit >= chip2)
                    {
                        amountChip2 = (short)Math.Floor((double)lastUnit / chip2);
                        lastUnit -= amountChip2 * chip2;
                        if (_amountBetChip == "")
                        {
                            _amountBetChip = chip2 + "x" + amountChip2;
                        }
                        else
                        {
                            ref string ptr = ref _amountBetChip;
                            _amountBetChip = string.Concat(ptr, ",", chip2.ToString(), "x", amountChip2.ToString());
                        }
                    }
                    if (lastUnit >= chip1)
                    {
                        amountChip1 = (short)Math.Floor((double)lastUnit / chip1);
                        if (_amountBetChip == "")
                        {
                            _amountBetChip = chip1 + "x" + amountChip1;
                        }
                        else
                        {
                            ref string ptr = ref _amountBetChip;
                            _amountBetChip = string.Concat(ptr, ",", chip1.ToString(), "x", amountChip1.ToString());
                        }
                    }

                    if (amountChip5 > 0)
                    {
                        Win32Bot.MouseClick(ValueForBot.Chip5);
                        Thread.Sleep(200);
                        int timesClick = amountChip5;
                        for (int i = 1; i <= timesClick; i++)
                        {
                            Win32Bot.MouseClick(ValueForBot.Chip5);
                            Thread.Sleep(700);

                        }
                    }
                    if (amountChip4 > 0)
                    {
                        Win32Bot.MouseClick(ValueForBot.Chip4);
                        Thread.Sleep(200);
                        int timesClick = amountChip4;
                        for (int j = 1; j <= timesClick; j++)
                        {
                            Win32Bot.MouseClick(ValueForBot.Chip4);
                            Thread.Sleep(700);
                        }
                    }
                    if (amountChip3 > 0)
                    {
                        Win32Bot.MouseClick(ValueForBot.Chip3);
                        Thread.Sleep(200);
                        int timesClick = amountChip3;
                        for (int k = 1; k <= timesClick; k++)
                        {
                            Win32Bot.MouseClick(ValueForBot.Chip3);
                            Thread.Sleep(700);
                        }
                    }
                    if (amountChip2 > 0)
                    {
                        Win32Bot.MouseClick(ValueForBot.Chip2);
                        Thread.Sleep(200);
                        int timesClick = amountChip2;
                        for (int l = 1; l <= timesClick; l++)
                        {
                            Win32Bot.MouseClick(ValueForBot.Chip2);
                            Thread.Sleep(700);
                        }
                    }
                    if (amountChip1 > 0)
                    {
                        Win32Bot.MouseClick(ValueForBot.Chip1);
                        Thread.Sleep(200);
                        int timesClick = amountChip1;
                        for (int m = 1; m <= timesClick; m++)
                        {
                            Win32Bot.MouseClick(ValueForBot.Chip1);
                            Thread.Sleep(700);
                        }
                    }

                    ClickBetting(bettingSuggest);

                    if (Settings_cbMove.CheckedState)
                    {
                        Cursor.Position = new Point(0, 0);
                        Thread.Sleep(50);
                        Application.DoEvents();
                    }

                    Thread.Sleep(100);
                    dgvStatus[3, 5].Value = _amountBetChip;
                }
            }
        }
        private void ClickBetting(short bettingSuggest)
        {
            if (bettingSuggest == 1)
            {
                Win32Bot.MouseClick(ValueForBot.Player);
            }
            else if (bettingSuggest == 2)
            {
                Win32Bot.MouseClick(ValueForBot.Banker);
            }

            if (Settings_cbDoubleClick.CheckedState)
            {
                Thread.Sleep(700);
                if (bettingSuggest == 1)
                {
                    Win32Bot.MouseClick(ValueForBot.ConfirmPlayer);
                }
                else if (bettingSuggest == 2)
                {
                    Win32Bot.MouseClick(ValueForBot.ConfirmBanker);
                }
            }
        }
        private void CheckColorResult()
        {
            checked
            {
                try
                {
                    if (_statusRunningBot != 2) return;

                    try
                    {
                        Bitmap bitmap = new Bitmap(1, 1);
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.CopyFromScreen(ValueForBot.Player, new Point(0, 0), new Size(1, 1));
                        }
                        Color pixel = bitmap.GetPixel(0, 0);
                        Invalidate();
                        ValueForBot.NewColorPlayer = pixel;
                    }
                    catch
                    {
                    }

                    try
                    {

                        Bitmap bitmap2 = new Bitmap(1, 1);
                        using (Graphics graphics2 = Graphics.FromImage(bitmap2))
                        {
                            graphics2.CopyFromScreen(ValueForBot.Banker, new Point(0, 0), new Size(1, 1));
                        }
                        Color pixel2 = bitmap2.GetPixel(0, 0);
                        Invalidate();
                        ValueForBot.NewColorBanker = pixel2;
                    }
                    catch
                    {
                    }

                    try
                    {

                        Bitmap bitmap2 = new Bitmap(1, 1);
                        using (Graphics graphics2 = Graphics.FromImage(bitmap2))
                        {
                            graphics2.CopyFromScreen(ValueForBot.Tie, new Point(0, 0), new Size(1, 1));
                        }
                        Color pixel = bitmap2.GetPixel(0, 0);
                        Invalidate();
                        ValueForBot.NewColorTie = pixel;
                    }
                    catch
                    {
                    }

                    if (_statusRunBot)
                    {
                        if ((ValueForBot.NewColorPlayer.R >= ValueForBot.ColorPlayer.R + 15 - 10 & ValueForBot.NewColorPlayer.R <= ValueForBot.ColorPlayer.R + 15 + 10) &
                            (ValueForBot.NewColorPlayer.G >= ValueForBot.ColorPlayer.G + 45 - 10 & ValueForBot.NewColorPlayer.G <= ValueForBot.ColorPlayer.G + 45 + 10) &
                            (ValueForBot.NewColorPlayer.B >= ValueForBot.ColorPlayer.B - 10 & ValueForBot.NewColorPlayer.B <= ValueForBot.ColorPlayer.B + 10) &
                            !_ready)
                        {
                            TypeOfPBT = 1;
                            goto skip;
                        }

                        if ((ValueForBot.NewColorBanker.R >= ValueForBot.ColorBanker.R + 15 - 10 & ValueForBot.NewColorBanker.R <= ValueForBot.ColorBanker.R + 15 + 10) &
                            (ValueForBot.NewColorBanker.G >= ValueForBot.ColorBanker.G + 45 - 10 & ValueForBot.NewColorBanker.G <= ValueForBot.ColorBanker.G + 45 + 10) &
                            (ValueForBot.NewColorBanker.B >= ValueForBot.ColorBanker.B - 10 & ValueForBot.NewColorBanker.B <= ValueForBot.ColorBanker.B + 10) &
                            !_ready)
                        {
                            TypeOfPBT = 2;
                            goto skip;
                        }

                        if ((ValueForBot.NewColorTie.R >= ValueForBot.ColorTie.R + 15 - 10 & ValueForBot.NewColorTie.R <= ValueForBot.ColorTie.R + 15 + 10) &
                            (ValueForBot.NewColorTie.G >= ValueForBot.ColorTie.G + 45 - 10 & ValueForBot.NewColorTie.G <= ValueForBot.ColorTie.G + 45 + 10) &
                            (ValueForBot.NewColorTie.B >= ValueForBot.ColorTie.B - 10 & ValueForBot.NewColorTie.B <= ValueForBot.ColorTie.B + 10) &
                            !_ready)
                        {
                            TypeOfPBT = 0;
                        }

                    skip:

                        if (TypeOfPBT == 1 | TypeOfPBT == 2 | TypeOfPBT == 0)
                        {
                            _statusRunningBot = 3;
                            Thread.Sleep(100);
                            Application.DoEvents();
                        }
                        //Thread.Sleep(50);
                        //Application.DoEvents();
                    }


                }
                catch
                {

                }
            }
        }
        private void AddClickToRoadBig()
        {
            if (_statusRunningBot != 3 & (TypeOfPBT != 1 | TypeOfPBT != 2 | TypeOfPBT != 0)) return;
            _statusRunningBot = 200;

            if (TypeOfPBT == 1)
            {
                AddValue2BigRoadClick("P");
            }
            else if (TypeOfPBT == 2)
            {
                AddValue2BigRoadClick("B");
            }
            else if (TypeOfPBT == 0)
            {
                AddValue2BigRoadClick("T");
            }

            var stopRound = int.Parse(ValueForBot.StopRound);
            var stopWin = int.Parse(ValueForBot.StopWin);
            var stopLose = int.Parse(ValueForBot.StopLose);
            var stopMore = int.Parse(ValueForBot.StopMore);
            var stopLess = int.Parse(ValueForBot.StopLess);


            checked
            {
                _timeStart = 0;


                if (_statusRunBot)
                {
                    if (stopRound != 0 && stopRound >= _listResult.Count)
                    {
                        ClickStart();
                        return;
                    }

                    if (stopWin != 0 && stopWin >= _totalWin)
                    {
                        ClickStart();
                        return;
                    }
                    if (stopLose != 0 && stopLose >= _totalLose)
                    {
                        ClickStart();
                        return;
                    }
                    if (stopMore != 0 && stopMore >= _lastMoneyBalance)
                    {
                        ClickStart();
                        return;
                    }
                    if (stopLess != 0 && stopLess <= -Math.Abs(_lastMoneyBalance))
                    {
                        ClickStart();
                        return;
                    }

                }

                _statusRunningBot = 0;
            }
        }

        #endregion


        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                label3.Text = ValueForBot.NewColorStart.ToString();
                label4.Text = ValueForBot.ColorStart.ToString();

                label5.Text = ValueForBot.NewColorPlayer.ToString();
                label6.Text = ValueForBot.ColorPlayer.ToString();

                label7.Text = ValueForBot.NewColorBanker.ToString();
                label8.Text = ValueForBot.ColorBanker.ToString();

                label11.Text = ValueForBot.NewColorTie.ToString();
                label12.Text = ValueForBot.ColorTie.ToString();

                label9.Text = _ready.ToString();


            }
            catch
            {

            }
        }
        #endregion

        #region LoadString

        private void InitLocalization()
        {
            LclzManager = new LocalizationManager(this);
            Settings_cbLangua.DataSource = LclzManager.GetLangList();
            if (Settings_cbLangua.Items.Count == 0)
            {
                Settings_cbLangua.Enabled = false;
            }
        }

        public LocalizationManager LclzManager;
        private void Settings_cbLangua_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            LoadSelectedLanguage();
            LclzManager.LocalizeForm(this);
            LocalizeSpecialCases();
            StatusLoad();
        }
        public void LoadSelectedLanguage()
        {
            if (Settings_cbLangua.SelectedItem == null)
            {
                return;
            }
            LclzManager.LoadLanguageFromFile(((LangInfo)Settings_cbLangua.SelectedItem).File);
        }

        private void LocalizeSpecialCases()
        {
            stringLoader.RunTime = LclzManager.TranslateMessage("RunTime", "Operating Time:");
            stringLoader.Round = LclzManager.TranslateMessage("Round", "Round:");
            stringLoader.Win = LclzManager.TranslateMessage("Win", "Win:");
            stringLoader.Lose = LclzManager.TranslateMessage("Lose", "Lose:");
            stringLoader.MaxConWin = LclzManager.TranslateMessage("MaxConWin", "Maximum Continuous Win:");
            stringLoader.MaxConLose = LclzManager.TranslateMessage("MaxConLose", "Maximum Continuous Lose:");
            stringLoader.WinLose = LclzManager.TranslateMessage("WinLose", "Win/Lose:");

            stringLoader.MaxProfit = LclzManager.TranslateMessage("MaxProfit", "Maximum Profit:");
            stringLoader.Balance = LclzManager.TranslateMessage("Balance", "Balance:");
            stringLoader.Amount = LclzManager.TranslateMessage("Amount", "Bet Amount:");
            stringLoader.Stake = LclzManager.TranslateMessage("Stake", "Stake/Unit:");
            stringLoader.Unit = LclzManager.TranslateMessage("Unit", "Bet Unit:");
            stringLoader.Bettings = LclzManager.TranslateMessage("Bettings", "Betting:");

            stringLoader.Warning = LclzManager.TranslateMessage("Warning", "WARNING!");

            stringLoader.WantClear = LclzManager.TranslateMessage("WantClear", "Do you want to clear?");
            stringLoader.Line = LclzManager.TranslateMessage("Line", "Line");
            stringLoader.Ready = LclzManager.TranslateMessage("Ready", "Ready");
            stringLoader.Wait = LclzManager.TranslateMessage("Wait", "Wait Result");
            stringLoader.Save = LclzManager.TranslateMessage("Save", "Saving");

            stringLoader.Confirmation = LclzManager.TranslateMessage("Confirmation", "Confirmation");
            stringLoader.Modified = LclzManager.TranslateMessage("Modified", "was modified, do you want to save it now?");
            stringLoader.Error = LclzManager.TranslateMessage("Error", "Error!");
            stringLoader.NotFound = LclzManager.TranslateMessage("NotFound", "not found!");
            stringLoader.Delete = LclzManager.TranslateMessage("Delete", "Confirm to delete");
            stringLoader.InputChip = LclzManager.TranslateMessage("InputChip", "Please Input A Chip Value");
            stringLoader.InputChipNull = LclzManager.TranslateMessage("InputChipNull", "Value is Null, Empty or White space");

            stringLoader.SetBetUnit = LclzManager.TranslateMessage("SetBetUnit", "Setting Betting Unit!!");
            stringLoader.Total = LclzManager.TranslateMessage("Total", "Total");
            stringLoader.TryAgain = LclzManager.TranslateMessage("TryAgain", "Try Again");


            stringLoader.PP = LclzManager.TranslateMessage("PP", "Positive Progression");
            stringLoader.NP = LclzManager.TranslateMessage("NP", "Negative Progression");
            stringLoader.Fib = LclzManager.TranslateMessage("Fib", "Fibonacci");
            stringLoader.DetailPp1 = LclzManager.TranslateMessage("DetailPp1", "- Increase stakes next step when you win");
            stringLoader.DetailPp2 = LclzManager.TranslateMessage("DetailPp2", "- Return to first stakes when you lose");

            stringLoader.DetailNp1 = LclzManager.TranslateMessage("DetailNp1", "- Increase stakes next step when you lose");
            stringLoader.DetailNp2 = LclzManager.TranslateMessage("DetailNp2", "- Return to first stakes when you win");

            stringLoader.DetailFib1 = LclzManager.TranslateMessage("DetailFib1", "- Increase stakes next step when you lose");
            stringLoader.DetailFib2 = LclzManager.TranslateMessage("DetailFib2", "- Decrease 2 step for stakes when you win");

            stringLoader.Start = LclzManager.TranslateMessage("Start", "Start");
            stringLoader.Stop = LclzManager.TranslateMessage("Stop", "Stop");
        }

        #endregion

        #region GetValueString

        //IniReader ini = new IniReader("string");
        //public void LocalizeFormNew(Form _form)
        //{
        //    string name = _form.Name;
        //    foreach (object obj in _form.Controls)
        //    {
        //        Control control = (Control)obj;
        //        switch (control.GetType().Name.ToLower())
        //        {
        //            case "label":
        //            case "checkbox":
        //            case "linklabel":
        //            case "button":

        //            case "tfivelabel":
        //            case "tfivetextbox":
        //            case "tfiveradiobutton":
        //            case "tfivebutton":
        //            case "tfivecheckbox":
        //            case "tfiveheaderlabel":
        //                ini.WriteString(name, control.Name, "");
        //                break;

        //            case "tablelayoutpanel":
        //            case "panel":
        //            case "tabcontrol":
        //            case "tfivetabcontrol":
        //            case "tfivetheme":
        //                LocalizeChildControlsNew(control, name);
        //                break;
        //            case "tabpage":
        //                ini.WriteString(name, control.Name, "");
        //                LocalizeChildControlsNew(control, name);
        //                break;
        //            case "groupbox":
        //            case "tfivegroupbox":
        //                ini.WriteString(name, control.Name, "");
        //                LocalizeChildControlsNew(control, name);
        //                break;
        //        }
        //    }

        //}

        //private void LocalizeChildControlsNew(Control control, string section)
        //{
        //    foreach (object obj in control.Controls)
        //    {
        //        Control control2 = (Control)obj;
        //        switch (control2.GetType().Name.ToLower())
        //        {
        //            case "label":
        //            case "checkbox":
        //            case "linklabel":
        //            case "button":

        //            case "tfivelabel":
        //            case "tfivetextbox":
        //            case "tfiveradiobutton":
        //            case "tfivebutton":
        //            case "tfivecheckbox":
        //            case "tfiveheaderlabel":
        //                ini.WriteString(section, control2.Name, "");
        //                break;
        //            case "tablelayoutpanel":
        //            case "panel":
        //            case "tabcontrol":
        //            case "tfivetabcontrol":
        //                LocalizeChildControlsNew(control2, section);
        //                break;
        //            case "tabpage":
        //                ini.WriteString(section, control2.Name, "");
        //                LocalizeChildControlsNew(control2, section);
        //                break;
        //            case "groupbox":
        //            case "tfivegroupbox":
        //                ini.WriteString(section, control2.Name, "");
        //                LocalizeChildControlsNew(control2, section);
        //                break;
        //        }
        //    }
        //}

        #endregion
        
    }
}