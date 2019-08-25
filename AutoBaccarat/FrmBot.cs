using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoBaccarat.Properties;
using AutoBaccarat.Setting;
using Bunifu.Framework.UI;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
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

            InitLocalization();
            StatusLoad();
            LoadSave();
            MenuControl(btnMain);
            LoadValues();
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
        private void LoadSave()
        {
            cbTopMost.CheckedState = Settings.Default.SetTopMost;
            cbMove.CheckedState = Settings.Default.MoveCur;
            cbInvert.CheckedState = Settings.Default.BetInvert;
            cbDoubleConfirmClick.CheckedState = Settings.Default.ConfirmClick;

            SetTopMost();
        }
        private void FrmBot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.SetTopMost = cbTopMost.CheckedState;
            Settings.Default.MoveCur = cbMove.CheckedState;
            Settings.Default.BetInvert = cbInvert.CheckedState;
            Settings.Default.ConfirmClick = cbDoubleConfirmClick.CheckedState;
            Settings.Default.Lang = cbLanguages.SelectedIndex;

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
            //MenuControl(btnLogs);
        }
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            MenuControl(btnSettings);
        }

        private void MenuControl(BunifuFlatButton button)
        {
            //if (button == btnLogs)
            //{
            //    var frmSum = new FrmSummary();
            //    frmSum.ShowDialog();
            //    frmSum.Dispose();
            //    return;
            //}

            btnMain.Normalcolor = Color.FromArgb(65, 65, 65);
           // btnLogs.Normalcolor = Color.CornflowerBlue;
            btnSettings.Normalcolor = Color.FromArgb(65, 65, 65);
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

        #region Status
        private void StatusLoad()
        {
            //dgvStatus.Rows.Clear();

            //dgvStatus.Rows.Add(stringLoader.RunTime, null, "0", null);
            //dgvStatus.Rows.Add(stringLoader.Round, "0", stringLoader.MaxProfit, "0");
            //dgvStatus.Rows.Add(stringLoader.Win, "0", stringLoader.Balance, "0");
            //dgvStatus.Rows.Add(stringLoader.Lose, "0", stringLoader.Amount, "0");
            //dgvStatus.Rows.Add(stringLoader.MaxConWin, "0", stringLoader.Stake, "0x0");
            //dgvStatus.Rows.Add(stringLoader.MaxConLose, "0", stringLoader.Unit, "0x0");
            //dgvStatus.Rows.Add(stringLoader.WinLose, "0", stringLoader.Bettings, "");

            //dgvStatus[3, 3].Style.ForeColor = Color.DarkGoldenrod;

            //dgvStatus[3, 6].Style.ForeColor = Color.White;
            //dgvStatus[3, 6].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvStatus.ClearSelection();

            dgvBigRoad.Columns.Add("_colbig0", "_colbig0");
        }
        private void StatusUpdate()
        {
            lbValueRound.Text = BotValues.Result.Count.ToString(); // Round
            lbValueWin.Text = BotValues.TotalWin.ToString();
            lbValueLose.Text = BotValues.TotalLose.ToString();
            lbValueMaxConWin.Text = BotValues.MaxContinuousWin.ToString();
            lbValueMaxConLose.Text = BotValues.MaxContinuousLose.ToString();

            var value = BotValues.TotalWin - BotValues.TotalLose;
            lbValueWL.Text = value.ToString();
            lbValueWL.ForeColor = ChangeForeColor(value);

            lbValueMaxProfit.Text = BotValues.MaxProfit.ToString();
            lbValueBalance.Text = BotValues.LastMoneyBalance.ToString("#,##0.##");
            lbValueBalance.ForeColor = ChangeForeColor((int)BotValues.LastMoneyBalance);

            lbValueAmount.Text = @"0";
            lbValueStake.Text = @"0x0";
            lbValueBettings.Text = "";
            if (BotValues.BettingSuggest.Count > 0)
            {
                var lastBetSuggestValue = BotValues.BettingSuggest[BotValues.BettingSuggest.Count - 1];
                short lastUnit = 0;
                if (BotValues.Unit[BotValues.Unit.Count - 1] > 0 & (lastBetSuggestValue == 1 | lastBetSuggestValue == 2))
                {
                    lbValueStake.Text = ValueForBot.Chip + "x" + (int)BotValues.Unit[BotValues.Unit.Count - 1];
                    lbValueBettings.Text = ConvertTypeGame2String(lastBetSuggestValue);
                    lbValueBettings.BackColor = ChangeColorByType(lastBetSuggestValue);

                    lastUnit = BotValues.Unit[BotValues.Unit.Count - 1];
                }

                lbValueAmount.Text = (ValueForBot.Chip * (double)lastUnit).ToString("#,##0");
            }

          

            //dgvStatus[1, 1].Value = BotValues.Result.Count.ToString(); // Round
            //dgvStatus[1, 2].Value = BotValues.TotalWin;
            //dgvStatus[1, 3].Value = BotValues.TotalLose;
            //dgvStatus[1, 4].Value = BotValues.MaxContinuousWin;
            //dgvStatus[1, 5].Value = BotValues.MaxContinuousLose;

            //var value = BotValues.TotalWin - BotValues.TotalLose;
            //dgvStatus[1, 6].Value = value;
            //dgvStatus[1, 6].Style.ForeColor = DataGridForeColor(value);

            //dgvStatus[3, 1].Value = BotValues.MaxProfit;
            //dgvStatus[3, 2].Value = BotValues.LastMoneyBalance.ToString("#,##0.##");
            //dgvStatus[3, 2].Style.ForeColor = DataGridForeColor((int)BotValues.LastMoneyBalance);

            //dgvStatus[3, 3].Value = "0";
            //dgvStatus[3, 4].Value = "0x0";
            //dgvStatus[3, 6].Value = "";
            //if (BotValues.BettingSuggest.Count > 0)
            //{
            //    var lastBetSuggestValue = BotValues.BettingSuggest[BotValues.BettingSuggest.Count - 1];
            //    short lastUnit = 0;
            //    if (BotValues.Unit[BotValues.Unit.Count - 1] > 0 & (lastBetSuggestValue == 1 | lastBetSuggestValue == 2))
            //    {
            //        dgvStatus[3, 4].Value = ValueForBot.Chip + "x" + (int)BotValues.Unit[BotValues.Unit.Count - 1];
            //        dgvStatus[3, 6].Value = ConvertTypeGame2String(lastBetSuggestValue);
            //        dgvStatus[3, 6].Style.BackColor = ChangeColorByType(lastBetSuggestValue);

            //        lastUnit = BotValues.Unit[BotValues.Unit.Count - 1];
            //    }

            //    dgvStatus[3, 3].Value = (ValueForBot.Chip * (double)lastUnit).ToString("#,##0");
            //}

            //dgvStatus.ClearSelection();

        }
        private void ClearSelected(object sender, EventArgs e)
        {
            //dgvStatus.ClearSelection();
            dgvGoodLine.ClearSelection();
            dgvBigRoad.ClearSelection();
        }
        private void UpdateBotSettings()
        {

            lbValueLayout.Text = LayoutValues.ListName;

            //lbValueFormula.Text = ValueForBot.Formula == stringLoader.Custom
            //    ? ValueForBot.Formula + $@" ({FormulaValues.ListName})"
            //    : ValueForBot.Formula;
           
            if (ValueForBot.Formula == "Follow")
            {
                lbValueFormula.Text = StringLoader.Follow;
            }
            else if (ValueForBot.Formula == "AI")
            {
                lbValueFormula.Text = StringLoader.AI;
            }
            else if (ValueForBot.Formula == "Lock")
            {
                lbValueFormula.Text = StringLoader.Lock;
            }
            else if (ValueForBot.Formula == "GoodLineFix")
            {
                lbValueFormula.Text = StringLoader.GoodLineFix;
            }
            else if (ValueForBot.Formula == "GoodLineRandom")
            {
                lbValueFormula.Text = StringLoader.GoodLineRandom;
            }
            else if (ValueForBot.Formula == "GoodLine")
            {
                lbValueFormula.Text = StringLoader.GoodLine;
            }
            else if (ValueForBot.Formula == "Fixed")
            {
                lbValueFormula.Text = StringLoader.Fixed;
            }
            else if (ValueForBot.Formula == "Custom")
            {
                lbValueFormula.Text = StringLoader.Custom;
            }
            else if (ValueForBot.Formula == "Random")
            {
                lbValueFormula.Text = StringLoader.Random;
            }


            lbValueBet.Text = ValueForBot.Betting;
            lbValueChip.Text = ValueForBot.Chip.ToString();
            lbValueStop.Text = ValueForBot.StopRound;
            lbValueStopWin.Text = ValueForBot.StopWin;
            lbValueStopLose.Text = ValueForBot.StopLose;
            lbValueStopMore.Text = ValueForBot.StopMore;
            lbValueStopLess.Text = ValueForBot.StopLess;

            lbValueMode.Text = ValueForBot.Mode == 0
                ? StringLoader.NormalMode
                : StringLoader.BackgroundMode;

        }
        #endregion

        #region Display Values
        private bool _switchColor;
        private static Color EasyChangeColor(bool status, string type)
        {
            return status
                ? type == "P" ? Color.RoyalBlue :
                type == "B" ? Color.Red : Color.FromArgb(82, 82, 82)
                : Color.FromArgb(82, 82, 82);
        }
        private static Color EasyChangeForeColor(bool status, string type) =>
            status ? Color.White :
            type == "P" ? Color.RoyalBlue :
            type == "B" ? Color.Red : Color.White;
        private void TmDisplay_Tick(object sender, EventArgs e)
        {
            _switchColor = !_switchColor;

            #region Bot Status

            if (_statusRunBot)
            {
                var statusRunningBot = _statusRunningBot;
                lblStatus.Visible = _switchColor;
                switch (statusRunningBot)
                {
                    case 0:
                        lblStatus.Text = StringLoader.Ready;
                        numberStatus.Value = 1;
                        break;
                    case 1:
                        lblStatus.Text = StringLoader.Betting;
                        numberStatus.Value = 2;
                        break;
                    case 2:
                        lblStatus.Text = StringLoader.Wait;
                        numberStatus.Value = 3;
                        break;
                    case 3:
                        break;
                    default:
                        if (statusRunningBot != 100)
                        {
                            if (statusRunningBot == 200)
                            {
                                lblStatus.Text = StringLoader.Save;
                                numberStatus.Value = 4;
                            }
                        }
                        else
                        {
                            lblStatus.Text = StringLoader.Betting;
                            numberStatus.Value = 2;
                        }
                        break;
                }

            }
            else
            {
                lblStatus.Visible = true;
            }

            #endregion

            #region Bet Suggest Lighting

            string value;
            try
            {
                value = lbValueBettings.Text;
               // value = dgvStatus[3, 6].Value.ToString();
            }
            catch
            {
                value = "";
            }
            if (value != "")
            {
                lbValueBettings.BackColor = EasyChangeColor(_switchColor, value);
                lbValueBettings.ForeColor = EasyChangeForeColor(_switchColor, value);
                //dgvStatus[3, 6].Style.BackColor = EasyChangeColor(_switchColor, value);
                //dgvStatus[3, 6].Style.ForeColor = EasyChangeForeColor(_switchColor, value);
            }

            #endregion
     

        }

        #endregion

        #region Values For Bot
        private readonly GetAppName _getApp = new GetAppName();
        private void LoadValues()
        {
            ValueForBot.Formula = FormulaValues.FormulaSelected.ToString();
            ValueForBot.Betting = BetSystemValues.BettingSelected.ToString();

            if (BetSystemValues.ChipSelected == 0)
            {
                ValueForBot.Chip = int.Parse(LayoutValues.Chip1);
            }
            else if (BetSystemValues.ChipSelected == 1)
            {
                ValueForBot.Chip = int.Parse(LayoutValues.Chip2);
            }
            else if (BetSystemValues.ChipSelected == 2)
            {
                ValueForBot.Chip = int.Parse(LayoutValues.Chip3);
            }
            else if (BetSystemValues.ChipSelected == 3)
            {
                ValueForBot.Chip = int.Parse(LayoutValues.Chip4);
            }
            else if (BetSystemValues.ChipSelected == 4)
            {
                ValueForBot.Chip = int.Parse(LayoutValues.Chip5);
            }

            ValueForBot.StopRound = BetSystemValues.BetStopRound;
            ValueForBot.StopWin = BetSystemValues.BetStopWin;
            ValueForBot.StopLose = BetSystemValues.BetStopLose;
            ValueForBot.StopLess = BetSystemValues.BetStopLess;
            ValueForBot.StopMore = BetSystemValues.BetStopMore;

            ValueForBot.ValuePP = BetSystemValues.ValuePP;
            ValueForBot.ValueNP = BetSystemValues.ValueNP;
            ValueForBot.ValueFib = BetSystemValues.ValueFib;

            ValueForBot.GoodLineFix = (byte) (FormulaValues.GoodLineFix + 1);
            ValueForBot.Lock = (byte) (FormulaValues.Lock + 1);
            ValueForBot.Follow = (byte) (FormulaValues.Follow + 1);

            ValueForBot.CustomValueNumber = FormulaValues.ValueNumber;
            ValueForBot.CustomValueType = FormulaValues.ValueType;
            ValueForBot.Fixed = FormulaValues.Fixed;

            ValueForBot.Mode = (byte) LayoutValues.ModeSelected;

            var positionStart = LayoutValues.PositionStart.Split('(', ',', ')');
            ValueForBot.PositionStart = new Point(int.Parse(positionStart[1]), int.Parse(positionStart[2]));
            var positionPlayer = LayoutValues.PositionPlayer.Split('(', ',', ')');
            ValueForBot.PositionPlayer = new Point(int.Parse(positionPlayer[1]), int.Parse(positionPlayer[2]));
            var positionBanker = LayoutValues.PositionBanker.Split('(', ',', ')');
            ValueForBot.PositionBanker = new Point(int.Parse(positionBanker[1]), int.Parse(positionBanker[2]));
            var positionTie = LayoutValues.PositionTie.Split('(', ',', ')');
            ValueForBot.PositionTie = new Point(int.Parse(positionTie[1]), int.Parse(positionTie[2]));

            var positionConP = LayoutValues.PositionConP.Split('(', ',', ')');
            ValueForBot.PositionConfirmPlayer = new Point(int.Parse(positionConP[1]), int.Parse(positionConP[2]));

            var positionConB = LayoutValues.PositionConB.Split('(', ',', ')');
            ValueForBot.PositionConfirmBanker = new Point(int.Parse(positionConB[1]), int.Parse(positionConB[2]));

            
                var colorStart = GetColor.Hex2Color(LayoutValues.HexColorStart);
                ValueForBot.ColorStart = colorStart;
                var colorPlayer = GetColor.Hex2Color(LayoutValues.HexColorPlayer);
                ValueForBot.ColorPlayer = colorPlayer;
                var colorBanker = GetColor.Hex2Color(LayoutValues.HexColorBanker);
                ValueForBot.ColorBanker = colorBanker;
                var colorTie = GetColor.Hex2Color(LayoutValues.HexColorTie);
                ValueForBot.ColorTie = colorTie;
            
            if (ValueForBot.Mode == 1)
            {
                var addIHandle = LayoutValues.ProcessStart;
                var split = addIHandle.Split(new[] { " % " }, StringSplitOptions.None);
                GetAppName.App = split[0];
                GetAppName.Class = split[1];
                GetIHandle();
            }

            var positionChip1 = LayoutValues.PositionChip1.Split('(', ',', ')');
            ValueForBot.PositionChip1 = new Point(int.Parse(positionChip1[1]), int.Parse(positionChip1[2]));

            var positionChip2 = LayoutValues.PositionChip2.Split('(', ',', ')');
            ValueForBot.PositionChip2 = new Point(int.Parse(positionChip2[1]), int.Parse(positionChip2[2]));

            var positionChip3 = LayoutValues.PositionChip3.Split('(', ',', ')');
            ValueForBot.PositionChip3 = new Point(int.Parse(positionChip3[1]), int.Parse(positionChip3[2]));

            var positionChip4 = LayoutValues.PositionChip4.Split('(', ',', ')');
            ValueForBot.PositionChip4 = new Point(int.Parse(positionChip4[1]), int.Parse(positionChip4[2]));

            var positionChip5 = LayoutValues.PositionChip5.Split('(', ',', ')');
            ValueForBot.PositionChip5 = new Point(int.Parse(positionChip5[1]), int.Parse(positionChip5[2]));

            UpdateBotSettings();
        }
        private void GetIHandle()
        {
            _getApp.AppName();
            IHandle = GetAppName.appName;
        }

        #endregion

        #region Big Road Control

        private bool _backUpBigRoad;
        private int _bigRoadLastValue, _bigRoadNewColumn, _bigRoadNewLine =-1;
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
             LoadValues();
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
            // _amountBetChip = "";
            AddScore(type, DateTime.Now.ToString("HH:mm:ss"));
            if (type == 1 | type == 2)
            {
                UpdateBigRoad(BotValues.ScorePbt);
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
                            UpdateBigRoad(BotValues.ScorePbt);
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
        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (BotValues.Result.Count != 0 && MessageBox.Show(StringLoader.WantClear, StringLoader.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BotValues.BigRoad.Clear();
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
            _timeRunning = 0;
            _resultType = 3;
            _valueP = 0;
            _valueB = 0;
            _valueT = 0;
            _fibonacci = 1;

            #region Clear Bot Values

            BotValues.TotalWin = 0;
            BotValues.TotalLose = 0;
            BotValues.LastMoneyBalance = 0.0;
            BotValues.MaxProfit = 0;
            BotValues.MaxContinuousWin = 0;
            BotValues.MaxContinuousLose = 0;
            BotValues.GoodLineValue1 = 0;
            BotValues.GoodLineValue2 = 0;
            BotValues.GoodLineValue3 = 0;
            BotValues.GoodLineValue4 = 0;
            BotValues.GoodLineValue5 = 0;
            BotValues.GoodLineValue6 = 0;
            BotValues.GoodLineValueSum = 0;
            BotValues.Result.Clear();
            BotValues.ScorePbt.Clear();
            BotValues.Unit.Clear();
            BotValues.BettingSuggest.Clear();
            BotValues.WinLose.Clear();
            BotValues.ChipLast.Clear();
            BotValues.Step.Clear();
            BotValues.Balance.Clear();
            BotValues.LastHighResult.Clear();

            #endregion
            
            _bigRoadNewLine = -1;
            _bigRoadNewColumn = 0;
            _bigRoadLastValue = 0;
            
            UpdateDisplay();

            lbline1.Text = @"0";
            lbline2.Text = @"0";
            lbline3.Text = @"0";
            lbline4.Text = @"0";
            lbline5.Text = @"0";
            lbline6.Text = @"0";
            lblineSum.Text = @"0";
            lbShowLine1.BackColor = Color.FromArgb(82, 82, 82);
            lbShowLine2.BackColor = Color.FromArgb(82, 82, 82);
            lbShowLine3.BackColor = Color.FromArgb(82, 82, 82);
            lbShowLine4.BackColor = Color.FromArgb(82, 82, 82);
            lbShowLine5.BackColor = Color.FromArgb(82, 82, 82);
            lbShowLine6.BackColor = Color.FromArgb(82, 82, 82);
            lbShowLine7.BackColor = Color.FromArgb(82, 82, 82);
            //dgvStatus[3, 6].Style.BackColor = Color.White;
            lbValueBettings.BackColor = Color.FromArgb(82, 82, 82);
        }
        #endregion

        #region Display Update

        private short _resultType = 3;
        private short _goodLineResult;
        private int _valueP, _valueB, _valueT, _fibonacci;
        private void AddScore(short resultType, string timeValue)
        {
            #region Variable

            _resultType = 3;
            short bettingSuggest = 3;
            var unitValue = 0;
            var winOrLose = "";

            var formula = ValueForBot.Formula;
            var betSystem = ValueForBot.Betting;
            var chipValue = ValueForBot.Chip;
            var modeType = ValueForBot.Mode;

            var lastMoneyBalance = 0.0;
            var moneyCost = 0.0;

            #endregion

            BotValues.Result.Add(resultType);
            //BotValues.ListTime.Add(timeValue);

            checked
            {
                if (resultType != 0)
                {
                    BotValues.ScorePbt.Add(resultType);

                    #region Good Line Control

                    if (BotValues.ScorePbt.Count <= 6)
                    {
                        BotValues.LastHighResult.Add(int.Parse(lbP.Text) > int.Parse(lbB.Text) ? (short)1 : (short)2);
                    }
                    else
                    {
                        var newResult = ConvertTypeGame2String(resultType);
                        var oldScore1 = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 2]);
                        var oldScore2 = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 3]);
                        var oldScore3 = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 4]);
                        var oldScore4 = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 5]);
                        var oldScore5 = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 6]);
                        var oldScore6 = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 7]);
                        var lastHighResult = ConvertTypeGame2String(BotValues.LastHighResult[BotValues.LastHighResult.Count - 1]);

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
                        dgv6Line[1, dgv6Line.RowCount - 1].Style.ForeColor = ChangeColorByType(resultType);
                        dgv6Line[2, dgv6Line.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(resultType, BotValues.ScorePbt[BotValues.ScorePbt.Count - 2]);
                        dgv6Line[3, dgv6Line.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(resultType, BotValues.ScorePbt[BotValues.ScorePbt.Count - 3]);
                        dgv6Line[4, dgv6Line.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(resultType, BotValues.ScorePbt[BotValues.ScorePbt.Count - 4]);
                        dgv6Line[5, dgv6Line.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(resultType, BotValues.ScorePbt[BotValues.ScorePbt.Count - 5]);
                        dgv6Line[6, dgv6Line.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(resultType, BotValues.ScorePbt[BotValues.ScorePbt.Count - 6]);
                        dgv6Line[7, dgv6Line.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(resultType, BotValues.ScorePbt[BotValues.ScorePbt.Count - 7]);
                        dgv6Line[8, dgv6Line.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(resultType, BotValues.LastHighResult[BotValues.LastHighResult.Count - 1]);

                        if (goodLine1 == "W")
                        {
                            ref var ptr = ref BotValues.GoodLineValue1;
                            BotValues.GoodLineValue1 = ptr + 1;
                        }
                        if (goodLine2 == "W")
                        {
                            ref var ptr = ref BotValues.GoodLineValue2;
                            BotValues.GoodLineValue2 = ptr + 1;
                        }
                        if (goodLine3 == "W")
                        {
                            ref var ptr = ref BotValues.GoodLineValue3;
                            BotValues.GoodLineValue3 = ptr + 1;
                        }
                        if (goodLine4 == "W")
                        {
                            ref var ptr = ref BotValues.GoodLineValue4;
                            BotValues.GoodLineValue4 = ptr + 1;
                        }
                        if (goodLine5 == "W")
                        {
                            ref var ptr = ref BotValues.GoodLineValue5;
                            BotValues.GoodLineValue5 = ptr + 1;
                        }
                        if (goodLine6 == "W")
                        {
                            ref var ptr = ref BotValues.GoodLineValue6;
                            BotValues.GoodLineValue6 = ptr + 1;
                        }
                        if (goodLineSum == "W")
                        {
                            ref var ptr = ref BotValues.GoodLineValueSum;
                            BotValues.GoodLineValueSum = ptr + 1;
                        }

                        var prevSixScore = BotValues.ScorePbt.Count - 6;
                        var goodLinePer1 = BotValues.GoodLineValue1 / (double)prevSixScore;
                        var goodLinePer2 = BotValues.GoodLineValue2 / (double)prevSixScore;
                        var goodLinePer3 = BotValues.GoodLineValue3 / (double)prevSixScore;
                        var goodLinePer4 = BotValues.GoodLineValue4 / (double)prevSixScore;
                        var goodLinePer5 = BotValues.GoodLineValue5 / (double)prevSixScore;
                        var goodLinePer6 = BotValues.GoodLineValue6 / (double)prevSixScore;
                        var goodLinePerSum = BotValues.GoodLineValueSum / (double)prevSixScore;
                        lbline1.Text = goodLinePer1.ToString("#%");
                        lbline2.Text = goodLinePer2.ToString("#%");
                        lbline3.Text = goodLinePer3.ToString("#%");
                        lbline4.Text = goodLinePer4.ToString("#%");
                        lbline5.Text = goodLinePer5.ToString("#%");
                        lbline6.Text = goodLinePer6.ToString("#%");
                        lblineSum.Text = goodLinePerSum.ToString("#%");

                        int numCheckLastGoodLine;
                        short newLine1;
                        short newLine2;
                        short newLine3;
                        short newLine4;
                        short newLine5;
                        short newLine6;
                        unchecked
                        {
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
                            var lastOldScore1 = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 1 - numCheckLastGoodLine]);
                            var lastOldScore2 = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 2 - numCheckLastGoodLine]);
                            var lastOldScore3 = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 3 - numCheckLastGoodLine]);
                            var lastOldScore4 = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 4 - numCheckLastGoodLine]);
                            var lastOldScore5 = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 5 - numCheckLastGoodLine]);
                            var lastOldScore6 = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 6 - numCheckLastGoodLine]);
                            var lastOldScoreSum = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 7 - numCheckLastGoodLine]);

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
                        _goodLineResult = DoubleArray2ShortArray(newResultGoodLine);
                        var item2 = BotValues.ScorePbt[BotValues.ScorePbt.Count - 1 - _goodLineResult];

                        lbline1.ForeColor = Color.DodgerBlue;
                        lbline2.ForeColor = Color.DodgerBlue;
                        lbline3.ForeColor = Color.DodgerBlue;
                        lbline4.ForeColor = Color.DodgerBlue;
                        lbline5.ForeColor = Color.DodgerBlue;
                        lbline6.ForeColor = Color.DodgerBlue;
                        lblineSum.ForeColor = Color.DodgerBlue;
                        switch (_goodLineResult)
                        {
                            case 0:
                                lbline1.ForeColor = Color.Lime;
                                break;
                            case 1:
                                lbline2.ForeColor = Color.Lime;
                                break;
                            case 2:
                                lbline3.ForeColor = Color.Lime;
                                break;
                            case 3:
                                lbline4.ForeColor = Color.Lime;
                                break;
                            case 4:
                                lbline5.ForeColor = Color.Lime;
                                break;
                            case 5:
                                lbline6.ForeColor = Color.Lime;
                                break;
                        }

                        BotValues.LastHighResult.Add(item2);
                    }

                    #endregion


                    if (BotValues.BigRoad.Count > 0)
                    {
                        if (BotValues.BigRoad[BotValues.BigRoad.Count - 1][BotValues.BigRoad[BotValues.BigRoad.Count - 1].Count - 1] == resultType)
                        {
                            BotValues.BigRoad[BotValues.BigRoad.Count - 1].Add(resultType);
                        }
                        else
                        {
                            BotValues.BigRoad.Add(new List<short>());
                            BotValues.BigRoad[BotValues.BigRoad.Count - 1].Add(resultType);
                        }
                    }
                    else
                    {
                        BotValues.BigRoad.Add(new List<short>());
                        BotValues.BigRoad[BotValues.BigRoad.Count - 1].Add(resultType);
                    }
                }

                #region UpdateValuePBT

                if (resultType == 1)
                {
                    ref var ptr = ref _valueP;
                    _valueP = ptr + 1;
                }
                else if (resultType == 2)
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

                #region Formula Control

                switch (formula)
                {
                    case "GoodLine":
                        {
                            if (BotValues.LastHighResult.Count >= 6)
                            {
                                bettingSuggest = BotValues.LastHighResult[BotValues.LastHighResult.Count - 1];
                            }

                            break;
                        }

                    case "GoodLineRandom":
                        {
                            if (BotValues.ScorePbt.Count >= 6)
                            {
                                var randomNumber = (short)RandomNumber(1, 6);
                                bettingSuggest = BotValues.ScorePbt[BotValues.ScorePbt.Count - randomNumber];
                               // lbShowLineRandom.Text = randomNumber.ToString();
                                _goodLineResult = randomNumber;
                            }

                            break;
                        }

                    case "GoodLineFix":
                        {
                            if (BotValues.ScorePbt.Count >= ValueForBot.GoodLineFix)
                            {
                                bettingSuggest = BotValues.ScorePbt[BotValues.ScorePbt.Count - ValueForBot.GoodLineFix];
                            }
                            _goodLineResult = ValueForBot.GoodLineFix;
                            break;
                        }

                    case "Lock":
                        bettingSuggest = ValueForBot.Lock;
                        break;

                    case "Random":
                        bettingSuggest = (short)RandomNumber(1, 2);
                        break;

                    default:
                        bettingSuggest = GetFormula(formula, BotValues.BigRoad, BotValues.Result, BotValues.ScorePbt);

                        if (formula == "Follow")
                        {
                            if (ValueForBot.Follow == 3 || ValueForBot.Follow == bettingSuggest)
                            {
                                bettingSuggest = BotValues.ScorePbt[BotValues.ScorePbt.Count - 1];
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

                if (BotValues.Unit.Count > 0)
                {
                    lastMoneyBalance = BotValues.Balance[BotValues.Balance.Count - 1];
                    var unitCount = BotValues.Unit[BotValues.Unit.Count - 1];
                    if (unitCount > 0)
                    {
                        var lastBetResult = ConvertTypeGame2String(BotValues.Result[BotValues.Result.Count - 1]);
                        var number = dgvLog.RowCount + 1;
                        var betResult = ConvertTypeGame2String(resultType);
                        BotValues.LastStep = BotValues.Step[BotValues.Step.Count - 1];

                        var num23 = BotValues.BettingSuggest[BotValues.BettingSuggest.Count - 1];
                        var betSuggest = ConvertTypeGame2String(num23);
                        var chipLast = BotValues.ChipLast[BotValues.ChipLast.Count - 1].ToString();
                        winOrLose = ConvertOldScore2WinLose(lastBetResult, betSuggest);
                        moneyCost = MoneyCost(resultType, unitCount, short.Parse(chipLast), winOrLose);

                        unchecked
                        {
                            lastMoneyBalance = BotValues.Balance[checked(BotValues.Balance.Count - 1)] + moneyCost;
                            if (lastMoneyBalance > BotValues.MaxProfit)
                            {
                                BotValues.MaxProfit = lastMoneyBalance;
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
                                BotValues.LastStep);
                        }
                        dgvLog["colResult", dgvLog.RowCount - 1].Style.ForeColor = ChangeColorByType(resultType);
                        dgvLog["colWL", dgvLog.RowCount - 1].Style.BackColor = ChangeBackColorLineGoodLine(resultType, num23);
                        dgvLog["colCost", dgvLog.RowCount - 1].Style.ForeColor = ChangeBackColorLineGoodLine(resultType, num23);
                        dgvLog["colBalance", dgvLog.RowCount - 1].Style.ForeColor = ChangeForeColor((int)Math.Round(lastMoneyBalance));
                        dgvLog.CurrentCell = dgvLog.Rows[dgvLog.Rows.Count - 1].Cells[0];
                        dgvLog.ClearSelection();
                        TopContinues();
                    }
                }
                else if (BotValues.Balance.Count > 0)
                {
                    lastMoneyBalance = BotValues.Balance[BotValues.Balance.Count - 1];
                }

                BotValues.LastMoneyBalance = lastMoneyBalance;

                #endregion


                if (cbInvert.CheckedState)
                {
                    bettingSuggest = BetInvert(bettingSuggest);
                }

                BotValues.BettingSuggest.Add(bettingSuggest);
                BotValues.WinLose.Add(winOrLose);

                //BotValues.MoneyCost.Add(moneyCost);
                //BotValues.BetSystem.Add(betSystem);
                //BotValues.Formula.Add(formula);

                BotValues.ChipLast.Add(chipValue);
                BotValues.Balance.Add(lastMoneyBalance);

                #region Bet System

                if (winOrLose == "W")
                {
                    if (moneyCost != 0.0)
                    {
                        ref var ptr = ref BotValues.TotalWin;
                        BotValues.TotalWin = ptr + 1;

                        if (_fibonacci <= 3)
                        {
                            _fibonacci = 1;
                        }
                        else
                        {
                            ptr = ref _fibonacci;
                            _fibonacci = ptr - 2;
                        }
                    }
                }
                else if (winOrLose == "L")
                {
                    if (moneyCost != 0.0)
                    {
                        ref var ptr = ref BotValues.TotalLose;
                        BotValues.TotalLose = ptr + 1;

                        ptr = ref _fibonacci;
                        _fibonacci = ptr + 1;
                    }
                }


                if (bettingSuggest == 1 | bettingSuggest == 2)
                {
                    unitValue = ChipUnit(betSystem, BotValues.LastStep);
                }
                if (unitValue == 0 && UnitCount(BotValues.Unit) >= ValueForBot.ForceValue)
                {
                    try
                    {
                        var value = ValueForBot.ForceType == 1 ? BotValues.ScorePbt[BotValues.ScorePbt.Count - 1] : BetInvert(BotValues.ScorePbt[BotValues.ScorePbt.Count - 1]);
                        BotValues.BettingSuggest[BotValues.BettingSuggest.Count - 1] = value;
                    }
                    catch
                    {
                    }


                    var checkUnitValue = (short)ChipUnit(betSystem, BotValues.LastStep);
                    if (checkUnitValue == 0)
                    {
                        checkUnitValue = 1;
                    }
                    unitValue = checkUnitValue;
                }

                #endregion

                BotValues.Unit.Add((short)unitValue);
                BotValues.Step.Add(BotValues.LastStep);

                UpdateDisplay();
            }
        }
        public void TopContinues()
        {
            BotValues.MaxContinuousWin = 0;
            BotValues.MaxContinuousLose = 0;
            var dgv = dgvLog;
            checked
            {
                if (dgv.RowCount > 0)
                {
                    short winResult = 0;
                    short loseResult = 0;
                    var rowCount = dgv.RowCount - 1;
                    for (var i = 0; i <= rowCount; i++)
                    {
                        var cost = (double)dgv["colCost", i].Value;

                        var winOrLose = dgv["colWL", i].Value.ToString();
                        if (!string.IsNullOrWhiteSpace(winOrLose))
                        {
                            if (cost > 0.0)
                            {
                                winResult += 1;
                                loseResult = 0;
                                if (winResult > BotValues.MaxContinuousWin)
                                {
                                    BotValues.MaxContinuousWin = winResult;
                                }
                            }
                            else if (cost < 0.0)
                            {
                                winResult = 0;
                                loseResult += 1;
                                if (loseResult > BotValues.MaxContinuousLose)
                                {
                                    BotValues.MaxContinuousLose = loseResult;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static short UnitCount(List<short> unitList)
        {
            short result = 0;
            checked
            {
                if (unitList.Count > 0)
                {
                    var num = unitList[unitList.Count - 1];
                    if (num == 0)
                    {
                        short num2 = 0;
                        var count = unitList.Count - 1;
                        while (count >= 0 && unitList[count] == 0 && unitList[count] == num)
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
                    try
                    {
                        lbT.Text = _valueT.ToString();
                        lbP.Text = _valueP.ToString();
                        lbB.Text = _valueB.ToString();
                    }
                    catch
                    {
                        lbT.Text = "0";
                        lbP.Text = "0";
                        lbB.Text = "0";
                    }
                   


                    BotValues.Summary = "";
                    var array = ArrayIntBigRoadCount(BotValues.BigRoad);
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
                    BotValues.Summary = str;
                    StatusUpdate();
                    if (BotValues.ScorePbt.Count >= 6)
                    {
                        lbShowLine1.Text = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 1]);
                        lbShowLine2.Text = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 2]);
                        lbShowLine3.Text = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 3]);
                        lbShowLine4.Text = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 4]);
                        lbShowLine5.Text = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 5]);
                        lbShowLine6.Text = ConvertTypeGame2String(BotValues.ScorePbt[BotValues.ScorePbt.Count - 6]);
                        lbShowLine7.Text = ConvertTypeGame2String(BotValues.LastHighResult[BotValues.LastHighResult.Count - 1]);

                        lbShowLine1.BackColor = ChangeColorByType(BotValues.ScorePbt[BotValues.ScorePbt.Count - 1]);
                        lbShowLine2.BackColor = ChangeColorByType(BotValues.ScorePbt[BotValues.ScorePbt.Count - 2]);
                        lbShowLine3.BackColor = ChangeColorByType(BotValues.ScorePbt[BotValues.ScorePbt.Count - 3]);
                        lbShowLine4.BackColor = ChangeColorByType(BotValues.ScorePbt[BotValues.ScorePbt.Count - 4]);
                        lbShowLine5.BackColor = ChangeColorByType(BotValues.ScorePbt[BotValues.ScorePbt.Count - 5]);
                        lbShowLine6.BackColor = ChangeColorByType(BotValues.ScorePbt[BotValues.ScorePbt.Count - 6]);
                        lbShowLine7.BackColor = ChangeColorByType(BotValues.LastHighResult[BotValues.LastHighResult.Count - 1]);
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

        public static short GetFormula(string formulaType, List<List<short>> bigRoad, List<short> listResult, List<short> listLastPBT)
        {
            short result = 3;
            checked
            {
                if (bigRoad.Count != 0)
                {
                    var result2 = bigRoad[bigRoad.Count - 1][bigRoad[bigRoad.Count - 1].Count - 1];
                    if (formulaType == "Custom")
                    {
                        short bigRoadOldCount = 0;
                        if (bigRoad.Count > 10)
                        {
                            bigRoadOldCount = (short)(bigRoad.Count - 10);
                        }

                        var text = "";
                        int roadOldCount = bigRoadOldCount;
                        var count = bigRoad.Count;
                        for (var i = roadOldCount; i <= count; i++)
                        {
                            if (i < bigRoad.Count)
                            {
                                if (text != "")
                                {
                                    text += ",";
                                }

                                text += bigRoad[i].Count.ToString();
                            }
                        }
                        return SplitFollowAdverseList(text, listResult);
                    }

                    if (formulaType == "AI")
                    {
                        if (bigRoad.Count == 1)
                        {
                            return result2;
                        }

                        if (bigRoad.Count == 2)
                        {
                            if (bigRoad[bigRoad.Count - 2].Count == bigRoad[bigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (bigRoad[bigRoad.Count - 1].Count >= 4)
                            {
                                return result2;
                            }

                            return result;
                        }
                        if (bigRoad.Count == 3)
                        {
                            if (bigRoad[bigRoad.Count - 3].Count == bigRoad[bigRoad.Count - 2].Count &
                                bigRoad[bigRoad.Count - 2].Count == bigRoad[bigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (bigRoad[bigRoad.Count - 3].Count > bigRoad[bigRoad.Count - 2].Count &
                                bigRoad[bigRoad.Count - 3].Count == bigRoad[bigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (bigRoad[bigRoad.Count - 3].Count == bigRoad[bigRoad.Count - 2].Count &
                                bigRoad[bigRoad.Count - 2].Count > bigRoad[bigRoad.Count - 1].Count)
                            {
                                return result2;
                            }

                            if (bigRoad[bigRoad.Count - 3].Count == 1 & bigRoad[bigRoad.Count - 2].Count == 2 &
                                bigRoad[bigRoad.Count - 1].Count == 3)
                            {
                                return BetInvert(result2);
                            }

                            if (bigRoad[bigRoad.Count - 3].Count == 5 & bigRoad[bigRoad.Count - 2].Count == 4 &
                                bigRoad[bigRoad.Count - 1].Count == 3)
                            {
                                return BetInvert(result2);
                            }

                            if (bigRoad[bigRoad.Count - 3].Count == 4 & bigRoad[bigRoad.Count - 2].Count == 3 &
                                bigRoad[bigRoad.Count - 1].Count == 2)
                            {
                                return BetInvert(result2);
                            }

                            if (bigRoad[bigRoad.Count - 1].Count >= 4)
                            {
                                return result2;
                            }

                            return result;
                        }
                        if (bigRoad.Count > 3 & bigRoad.Count < 6)
                        {
                            if (bigRoad[bigRoad.Count - 4].Count == bigRoad[bigRoad.Count - 3].Count &
                                bigRoad[bigRoad.Count - 3].Count == bigRoad[bigRoad.Count - 2].Count &
                                bigRoad[bigRoad.Count - 2].Count == bigRoad[bigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (bigRoad[bigRoad.Count - 4].Count == bigRoad[bigRoad.Count - 2].Count &
                                bigRoad[bigRoad.Count - 3].Count > bigRoad[bigRoad.Count - 4].Count &
                                bigRoad[bigRoad.Count - 3].Count > bigRoad[bigRoad.Count - 1].Count)
                            {
                                return result2;
                            }

                            if (bigRoad[bigRoad.Count - 4].Count == bigRoad[bigRoad.Count - 2].Count &
                                bigRoad[bigRoad.Count - 3].Count < bigRoad[bigRoad.Count - 4].Count &
                                bigRoad[bigRoad.Count - 3].Count > bigRoad[bigRoad.Count - 1].Count)
                            {
                                return result2;
                            }

                            if (bigRoad[bigRoad.Count - 4].Count > bigRoad[bigRoad.Count - 3].Count &
                                bigRoad[bigRoad.Count - 4].Count == bigRoad[bigRoad.Count - 2].Count &
                                bigRoad[bigRoad.Count - 3].Count == bigRoad[bigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (bigRoad[bigRoad.Count - 4].Count < bigRoad[bigRoad.Count - 3].Count &
                                bigRoad[bigRoad.Count - 4].Count == bigRoad[bigRoad.Count - 2].Count &
                                bigRoad[bigRoad.Count - 3].Count == bigRoad[bigRoad.Count - 1].Count)
                            {
                                return BetInvert(result2);
                            }

                            if (bigRoad[bigRoad.Count - 3].Count == 1 & bigRoad[bigRoad.Count - 2].Count == 2 &
                                bigRoad[bigRoad.Count - 1].Count == 3)
                            {
                                return BetInvert(result2);
                            }

                            if (bigRoad[bigRoad.Count - 4].Count == 1 & bigRoad[bigRoad.Count - 3].Count == 2 &
                                bigRoad[bigRoad.Count - 2].Count == 3 & bigRoad[bigRoad.Count - 1].Count <
                                bigRoad[bigRoad.Count - 2].Count)
                            {
                                return result2;
                            }

                            if (bigRoad[bigRoad.Count - 4].Count == 3 & bigRoad[bigRoad.Count - 3].Count == 4 &
                                bigRoad[bigRoad.Count - 2].Count == 3 & bigRoad[bigRoad.Count - 1].Count == 2)
                            {
                                return BetInvert(result2);
                            }

                            if (bigRoad[bigRoad.Count - 4].Count == 5 & bigRoad[bigRoad.Count - 3].Count == 4 &
                                bigRoad[bigRoad.Count - 2].Count == 3 & bigRoad[bigRoad.Count - 1].Count == 2)
                            {
                                return BetInvert(result2);
                            }

                            if (bigRoad[bigRoad.Count - 3].Count == 5 & bigRoad[bigRoad.Count - 2].Count == 4 &
                                bigRoad[bigRoad.Count - 1].Count == 3)
                            {
                                return BetInvert(result2);
                            }

                            if (bigRoad[bigRoad.Count - 3].Count == 4 & bigRoad[bigRoad.Count - 2].Count == 3 &
                                bigRoad[bigRoad.Count - 1].Count == 2)
                            {
                                return BetInvert(result2);
                            }

                            if (bigRoad[bigRoad.Count - 1].Count >= 4)
                            {
                                return result2;
                            }

                            return result;
                        }

                        if (bigRoad.Count < 6)
                        {
                            return result;
                        }

                        if (bigRoad[bigRoad.Count - 6].Count == bigRoad[bigRoad.Count - 3].Count &
                            bigRoad[bigRoad.Count - 5].Count == bigRoad[bigRoad.Count - 2].Count &
                            bigRoad[bigRoad.Count - 4].Count == bigRoad[bigRoad.Count - 1].Count)
                        {
                            return BetInvert(result2);
                        }

                        if (bigRoad[bigRoad.Count - 6].Count == bigRoad[bigRoad.Count - 3].Count &
                            bigRoad[bigRoad.Count - 5].Count == bigRoad[bigRoad.Count - 2].Count &
                            bigRoad[bigRoad.Count - 4].Count > bigRoad[bigRoad.Count - 1].Count)
                        {
                            return result2;
                        }

                        if (bigRoad[bigRoad.Count - 4].Count == bigRoad[bigRoad.Count - 3].Count &
                            bigRoad[bigRoad.Count - 3].Count == bigRoad[bigRoad.Count - 2].Count &
                            bigRoad[bigRoad.Count - 2].Count == bigRoad[bigRoad.Count - 1].Count)
                        {
                            return BetInvert(result2);
                        }

                        if (bigRoad[bigRoad.Count - 4].Count > bigRoad[bigRoad.Count - 3].Count &
                            bigRoad[bigRoad.Count - 4].Count == bigRoad[bigRoad.Count - 2].Count &
                            bigRoad[bigRoad.Count - 3].Count == bigRoad[bigRoad.Count - 1].Count)
                        {
                            return BetInvert(result2);
                        }

                        if (bigRoad[bigRoad.Count - 4].Count < bigRoad[bigRoad.Count - 3].Count &
                            bigRoad[bigRoad.Count - 4].Count == bigRoad[bigRoad.Count - 2].Count &
                            bigRoad[bigRoad.Count - 3].Count == bigRoad[bigRoad.Count - 1].Count)
                        {
                            return BetInvert(result2);
                        }

                        if (bigRoad[bigRoad.Count - 3].Count == 1 & bigRoad[bigRoad.Count - 2].Count == 2 &
                            bigRoad[bigRoad.Count - 1].Count == 3)
                        {
                            return BetInvert(result2);
                        }

                        if (bigRoad[bigRoad.Count - 4].Count == 1 & bigRoad[bigRoad.Count - 3].Count == 2 &
                            bigRoad[bigRoad.Count - 2].Count == 3 & bigRoad[bigRoad.Count - 1].Count <
                            bigRoad[bigRoad.Count - 2].Count)
                        {
                            return result2;
                        }

                        if (bigRoad[bigRoad.Count - 4].Count == 3 & bigRoad[bigRoad.Count - 3].Count == 4 &
                            bigRoad[bigRoad.Count - 2].Count == 3 & bigRoad[bigRoad.Count - 1].Count == 2)
                        {
                            return BetInvert(result2);
                        }

                        if (bigRoad[bigRoad.Count - 4].Count == 5 & bigRoad[bigRoad.Count - 3].Count == 4 &
                            bigRoad[bigRoad.Count - 2].Count == 3 & bigRoad[bigRoad.Count - 1].Count == 2)
                        {
                            return BetInvert(result2);
                        }

                        if (bigRoad[bigRoad.Count - 3].Count == 5 & bigRoad[bigRoad.Count - 2].Count == 4 &
                            bigRoad[bigRoad.Count - 1].Count == 3)
                        {
                            return BetInvert(result2);
                        }

                        if (bigRoad[bigRoad.Count - 3].Count == 4 & bigRoad[bigRoad.Count - 2].Count == 3 &
                            bigRoad[bigRoad.Count - 1].Count == 2)
                        {
                            return BetInvert(result2);
                        }

                        if (bigRoad[bigRoad.Count - 1].Count >= 4)
                        {
                            return result2;
                        }

                        return result;
                    }

                    if (formulaType == "Follow")
                    {
                        return listLastPBT[listLastPBT.Count - 1];
                    }

                    if (formulaType == "Fixed")
                    {
                        var array = ValueForBot.Fixed.Split('-');
                        var num = listResult.Count % array.Length;
                        var value = double.Parse(array[num]);
                        if (value == 1.0 | value == 2.0)
                        {
                            return short.Parse(array[num]);
                        }
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
                                        var left = ValueForBot.CustomValueType[num4];
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
                var winLoseCount = CountLast(dgvLog, (short)dgvLog.Columns["colWL"].Index, (short)dgvLog.Columns["colCost"].Index);
                var resultWinOrLose = "";
                if (dgvLog.RowCount > 0)
                {
                    resultWinOrLose = ResultLast(dgvLog, (short)dgvLog.Columns["colWL"].Index, (short)dgvLog.Columns["colCost"].Index);
                }

                if (system == "PP")
                {
                    try
                    {
                        //_betSystemValue = ValueForBot.ValuePP;
                        var splitPp = ValueForBot.ValuePP.Split('-');
                        var valueByPp = (short)splitPp.Length;
                        short step = 0;
                        if (BotValues.WinLose.Count > 0)
                        {
                            if (resultWinOrLose == "W")
                            {
                                var value = winLoseCount % valueByPp;
                                step = (short)value;
                            }
                            else
                            {
                                step = 0;
                            }
                        }
                        BotValues.LastStep = step;
                        return int.Parse(splitPp[step]);
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
                        var splitNp = ValueForBot.ValueNP.Split('-');
                        var valueByNp = (short)splitNp.Length;
                        short step = 0;
                        if (BotValues.WinLose.Count > 0)
                        {
                            if (resultWinOrLose == "L")
                            {
                                var value = winLoseCount % valueByNp;
                                step = (short)value;
                            }
                            else
                            {
                                step = 0;
                            }
                        }
                        BotValues.LastStep = step;
                        return int.Parse(splitNp[step]);
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
                        var splitPp = ValueForBot.ValuePP.Split('-');
                        var valueByPp = (short)splitPp.Length;
                        var splitNp = ValueForBot.ValueNP.Split('-');
                        var valueByNp = (short)splitNp.Length;

                        short step = 0;
                        if (BotValues.WinLose.Count > 0)
                        {
                            if (resultWinOrLose == "W")
                            {
                                var value = winLoseCount % valueByPp;
                                step = (short)value;
                                result = int.Parse(splitPp[step]);
                            }
                            else
                            {
                                var value = winLoseCount % valueByNp;
                                step = (short)value;
                                result = int.Parse(splitNp[step]);
                            }
                        }

                        BotValues.LastStep = step;
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
                        var valueAi = "1-3-2-4-3-6-4-7-5-8-6-9-7-10".Split('-');
                        var valueByAi = (short)valueAi.Length;
                        var num22 = (short)"1-2-4-8".Split('-').Length;
                        short step = 0;
                        if (BotValues.WinLose.Count > 0)
                        {
                            if (resultWinOrLose == "W")
                            {
                                var value = winLoseCount % valueByAi;
                                step = (short)value;
                            }
                            else
                            {
                                var value = winLoseCount % num22;
                                step = (short)value;
                            }
                        }

                        BotValues.LastStep = step;
                        return int.Parse(valueAi[step]);
                    }
                    catch
                    {
                    }
                }
                if (system == "Fibonacci")
                {
                    //_betSystemValue = "";
                    BotValues.LastStep = step_;
                    return SplitFib(_fibonacci, ValueForBot.ValueFib);

                }
                if (system == "OneShot")
                {
                    int sum;
                    if (BotValues.Balance.Count > 0)
                    {
                        //int num24 = (int)Math.Round(unchecked(Convert.ToDouble(Math.Abs(Convert.ToDecimal(this.lblTopProfit.Text))) - _listBalance[checked(_listBalance.Count - 1)]));
                        var num24 = (int)Math.Round(Convert.ToDouble(Math.Abs(Convert.ToDecimal(BotValues.MaxProfit))) - BotValues.Balance[checked(BotValues.Balance.Count - 1)]);

                        var num25 = ValueForBot.Chip;
                        if (num24 > num25)
                        {
                            if (resultWinOrLose == "W")
                            {
                                if (winLoseCount == 1)
                                {
                                    sum = (int)Math.Round(Math.Ceiling(num24 / (double)num25) + 1.0);
                                }
                                else
                                {
                                    sum = 1;
                                }
                            }
                            else
                            {
                                sum = 1;
                            }
                        }
                        else
                        {
                            sum = 1;
                        }
                    }
                    else
                    {
                        sum = 1;
                    }

                    BotValues.LastStep = step_;
                    return sum;
                }
                if (system == "X2")
                {
                    try
                    {
                        var valueX2 = "1-2-4-8-16-32-64-128-256-512-1024-2048-4096-8192-16384-32760".Split('-');
                        var valueByX2 = (short)valueX2.Length;
                        short step = 0;
                        if (BotValues.WinLose.Count > 0)
                        {
                            if (resultWinOrLose == "W")
                            {
                                var value = winLoseCount % valueByX2;
                                step = (short)value;
                            }
                            if (resultWinOrLose == "L")
                            {
                                var value = winLoseCount % valueByX2;
                                step = (short)value;
                            }
                        }

                        BotValues.LastStep = step;
                        return int.Parse(valueX2[step]);
                    }
                    catch
                    {
                    }
                }

                BotValues.LastStep = step_;
                return result;
            }
        }

        public short CountLast(DataGridView dgv, short colomn_WL, short colomn_Cost)
        {
            var text = "";
            short num = 0;
            if (dgv.RowCount != 0)
            {
                for (var lastRow = checked((short)(dgv.RowCount - 1)); lastRow >= 0; lastRow += -1)
                {
                    checked
                    {
                        if (lastRow == dgv.RowCount - 1)
                        {
                            //if (decimal.Compare(Convert.ToDecimal(dgv[colomn_Cost, lastRow].Value), 0m) != 0)
                            if (decimal.Parse(dgv[colomn_Cost, lastRow].Value.ToString()) != 0)
                            {
                                text = dgv[colomn_WL, lastRow].Value.ToString();
                                if (text == dgv[colomn_WL, lastRow].Value.ToString())
                                {
                                    num += 1;
                                }
                            }
                        }
                        //else if (decimal.Compare(Convert.ToDecimal(dgv[colomn_Cost, lastRow].Value), 0m) != 0)
                        else if (decimal.Parse(dgv[colomn_Cost, lastRow].Value.ToString()) != 0)
                        {
                            if (text == "")
                            {
                                text = dgv[colomn_WL, lastRow].Value.ToString();
                                if (text == dgv[colomn_WL, lastRow].Value.ToString())
                                {
                                    num += 1;
                                }
                            }
                            else
                            {
                                if (text != dgv[colomn_WL, lastRow].Value.ToString())
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
        private static Color ChangeForeColor(int value)
        {
            return value == 0 ? Color.White : value > 0 ? Color.LimeGreen : Color.Red;
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

        #region Setting
        private void CbTopMost_Click(object sender, EventArgs e)
        {
            SetTopMost();
        }
        private void SetTopMost()
        {
            TopMost = cbTopMost.CheckedState;
        }

   
        #region Button Show Form Setting

        private void BtnBetSystem_Click(object sender, EventArgs e)
        {
            Hide();
            var betSys = new FrmBetSystem();
            BotValues.LclzManager.LocalizeForm(betSys);
            betSys.ShowDialog();
            betSys.Dispose();
            Show();
            LoadValues();
        }

        private void BtnFormula_Click(object sender, EventArgs e)
        {
            Hide();
            var formula = new FrmFormula();
            BotValues.LclzManager.LocalizeForm(formula);
            formula.ShowDialog();
            formula.Dispose();
            Show();
            LoadValues();
        }

        private void BtnLayout_Click(object sender, EventArgs e)
        {
            Hide();
            var layout = new FrmLayout();
            BotValues.LclzManager.LocalizeForm(layout);
            layout.ShowDialog();
            layout.Dispose();
            Show();
            LoadValues();
        }

        private void BtnLine_Click(object sender, EventArgs e)
        {

        }




        #endregion

        #endregion

        #region Bot
        private string _amountBetChip;
        private bool _statusRunBot, _ready;
        private int _timeRunning, _timeStart, _statusRunningBot;

        public string Title => "Auto Baccarat" + (_statusRunBot ? " - Running" : "");

        private readonly CancellationTokenSource _run = new CancellationTokenSource();
        private readonly CancellationTokenSource _cancel = new CancellationTokenSource();
        private CancellationToken _cToken;
        private void BtnStart_Click(object sender, EventArgs e)
        {
            ClickStart();
        }
        private async void ClickStart()
        {
            btnStart.Text = btnStart.Text.EndsWith(StringLoader.Stop) ? StringLoader.Start : StringLoader.Stop;
            try
            {
                _cancel.Cancel();

                if (btnStart.Text == StringLoader.Stop)
                {
                    _cToken = _run.Token;
                    panelLeft.Enabled = false;
                    LoadValues();

                    _statusRunBot = true;

                    tmTimeRunning.Start();

                    if (ValueForBot.Mode == 0)
                    {
                        await Task.Factory.StartNew(BotsNormal, _cToken);
                    }
                    if (ValueForBot.Mode == 1)
                    {
                        await Task.Factory.StartNew(BotsBackground, _cToken);
                    }
                   
                }
                else if (btnStart.Text == StringLoader.Start)
                {
                    _cToken = _cancel.Token;
                    panelLeft.Enabled = true;

                    _statusRunBot = false;
                    tmTimeRunning.Stop();
                    _statusRunningBot = 0;
                    _switchColor = false;
                }

                Text = Title;
            }
            catch
            {
            }
        }


        #region Normal Mode

       private async Task BotsNormal()
       {
           if (!_statusRunBot)return;
           while (_statusRunBot)
           {
               await Task.Run(CheckColorStartTimeNormal, _cToken);
               await Task.Run(AutoClickNormal, _cToken);
               await Task.Run(CheckColorResultNormal, _cToken);
               await Task.Run(AddClickToBigRoad, _cToken);
           }
        }
        private void Bots_Normal_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (Bots_Normal.CancellationPending) return;
            while (!Bots_Normal.CancellationPending)
            {
                CheckColorStartTimeNormal();
                AutoClickNormal();
                CheckColorResultNormal();
                AddClickToBigRoad();
            }
        }
        private void CheckColorStartTimeNormal()
        {
            if (!_statusRunBot) return;
            checked
            {
                try
                {
                    var bitmap = new Bitmap(1, 1);
                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(ValueForBot.PositionStart, new Point(0, 0), new Size(1, 1));
                    }
                    var pixel = bitmap.GetPixel(0, 0);
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

                    Application.DoEvents();
                }
                catch
                {

                }
            }
        }
        private void AutoClickNormal()
        {
            if (!_statusRunBot) return;
            if (_statusRunningBot != 1) return;
            _statusRunningBot = 100;
            checked
            {
                if (BotValues.BettingSuggest.Count > 0)
                {
                    AutoClickNormal(BotValues.BettingSuggest[BotValues.BettingSuggest.Count - 1], BotValues.Unit[BotValues.Unit.Count - 1]);
                }

                _statusRunningBot = 2;
            }
        }
        private void AutoClickNormal(short bettingSuggest, int lastUnit)
        {
            if (!_statusRunBot) return;
            checked
            {
                if (_statusRunBot)
                {

                    lastUnit *= ValueForBot.Chip;

                    var chip1 = int.Parse(LayoutValues.Chip1);
                    var chip2 = int.Parse(LayoutValues.Chip2);
                    var chip3 = int.Parse(LayoutValues.Chip3);
                    var chip4 = int.Parse(LayoutValues.Chip4);
                    var chip5 = int.Parse(LayoutValues.Chip5);

                    short amountChip1 = 0;
                    short amountChip2 = 0;
                    short amountChip3 = 0;
                    short amountChip4 = 0;
                    short amountChip5 = 0;

                    _amountBetChip = "";
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
                            ref var ptr = ref _amountBetChip;
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
                            ref var ptr = ref _amountBetChip;
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
                            ref var ptr = ref _amountBetChip;
                            _amountBetChip = string.Concat(ptr, ",", chip1.ToString(), "x", amountChip1.ToString());
                        }
                    }

                    if (amountChip5 > 0)
                    {
                        Win32Bot.MouseClick(ValueForBot.PositionChip5);
                        Thread.Sleep(200);
                        int timesClick = amountChip5;
                        for (var i = 1; i <= timesClick; i++)
                        {
                            ClickBettingNormal(bettingSuggest);
                            Thread.Sleep(700);

                        }
                    }
                    if (amountChip4 > 0)
                    {
                        Win32Bot.MouseClick(ValueForBot.PositionChip4);
                        Thread.Sleep(200);
                        int timesClick = amountChip4;
                        for (var j = 1; j <= timesClick; j++)
                        {
                            ClickBettingNormal(bettingSuggest);
                            Thread.Sleep(700);
                        }
                    }
                    if (amountChip3 > 0)
                    {
                        Win32Bot.MouseClick(ValueForBot.PositionChip3);
                        Thread.Sleep(200);
                        int timesClick = amountChip3;
                        for (var k = 1; k <= timesClick; k++)
                        {
                            ClickBettingNormal(bettingSuggest);
                            Thread.Sleep(700);
                        }
                    }
                    if (amountChip2 > 0)
                    {
                        Win32Bot.MouseClick(ValueForBot.PositionChip2);
                        Thread.Sleep(200);
                        int timesClick = amountChip2;
                        for (var l = 1; l <= timesClick; l++)
                        {
                            ClickBettingNormal(bettingSuggest);
                            Thread.Sleep(700);
                        }
                    }
                    if (amountChip1 > 0)
                    {
                        Win32Bot.MouseClick(ValueForBot.PositionChip1);
                        Thread.Sleep(200);
                        int timesClick = amountChip1;
                        for (var m = 1; m <= timesClick; m++)
                        {
                            ClickBettingNormal(bettingSuggest);
                            Thread.Sleep(700);
                        }
                    }

                    Thread.Sleep(1000);
                    if (bettingSuggest == 1)
                    {
                        Win32Bot.MouseClick(ValueForBot.PositionConfirmPlayer);
                        Thread.Sleep(100);
                        Win32Bot.MouseClick(ValueForBot.PositionConfirmPlayer);
                    }
                    else if (bettingSuggest == 2)
                    {
                        Win32Bot.MouseClick(ValueForBot.PositionConfirmBanker);
                        Thread.Sleep(100);
                        Win32Bot.MouseClick(ValueForBot.PositionConfirmBanker);
                    }

                    if (cbDoubleConfirmClick.CheckedState)
                    {
                        Thread.Sleep(1000);
                        if (bettingSuggest == 1)
                        {
                            Win32Bot.MouseClick(ValueForBot.PositionConfirmPlayer);
                            Thread.Sleep(100);
                            Win32Bot.MouseClick(ValueForBot.PositionConfirmPlayer);
                        }
                        else if (bettingSuggest == 2)
                        {
                            Win32Bot.MouseClick(ValueForBot.PositionConfirmBanker);
                            Thread.Sleep(100);
                            Win32Bot.MouseClick(ValueForBot.PositionConfirmBanker);
                        }
                    }

                    if (cbMove.CheckedState)
                    {
                        Thread.Sleep(700);
                        Cursor.Position = new Point(ValueForBot.PositionStart.X+10, ValueForBot.PositionStart.Y+10);
                        Thread.Sleep(50);
                        Application.DoEvents();
                    }

                    Thread.Sleep(100);
                    //dgvStatus[3, 5].Value = _amountBetChip;
                    lbValueUnit.Text = _amountBetChip;
                }
            }
        }
        private void ClickBettingNormal(short bettingSuggest)
        {
            if (bettingSuggest == 1)
            {
                Win32Bot.MouseClick(ValueForBot.PositionPlayer);
            }
            else if (bettingSuggest == 2)
            {
                Win32Bot.MouseClick(ValueForBot.PositionBanker);
            }
        }
        
        private void CheckColorResultNormal()
        {
            if (!_statusRunBot) return;
            checked
            {
                try
                {
                    if (_statusRunningBot != 2) return;

                    try
                    {
                        var bitmap = new Bitmap(1, 1);
                        using (var graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.CopyFromScreen(ValueForBot.PositionPlayer, new Point(0, 0), new Size(1, 1));
                        }
                        var pixel = bitmap.GetPixel(0, 0);
                        Invalidate();
                        ValueForBot.NewColorPlayer = pixel;
                    }
                    catch
                    {
                    }

                    try
                    {

                        var bitmap2 = new Bitmap(1, 1);
                        using (var graphics2 = Graphics.FromImage(bitmap2))
                        {
                            graphics2.CopyFromScreen(ValueForBot.PositionBanker, new Point(0, 0), new Size(1, 1));
                        }
                        var pixel2 = bitmap2.GetPixel(0, 0);
                        Invalidate();
                        ValueForBot.NewColorBanker = pixel2;
                    }
                    catch
                    {
                    }

                    try
                    {

                        var bitmap2 = new Bitmap(1, 1);
                        using (var graphics2 = Graphics.FromImage(bitmap2))
                        {
                            graphics2.CopyFromScreen(ValueForBot.PositionTie, new Point(0, 0), new Size(1, 1));
                        }
                        var pixel = bitmap2.GetPixel(0, 0);
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
                            _resultType = 1;
                            goto skip;
                        }

                        if ((ValueForBot.NewColorBanker.R >= ValueForBot.ColorBanker.R + 15 - 10 & ValueForBot.NewColorBanker.R <= ValueForBot.ColorBanker.R + 15 + 10) &
                            (ValueForBot.NewColorBanker.G >= ValueForBot.ColorBanker.G + 45 - 10 & ValueForBot.NewColorBanker.G <= ValueForBot.ColorBanker.G + 45 + 10) &
                            (ValueForBot.NewColorBanker.B >= ValueForBot.ColorBanker.B - 10 & ValueForBot.NewColorBanker.B <= ValueForBot.ColorBanker.B + 10) &
                            !_ready)
                        {
                            _resultType = 2;
                            goto skip;
                        }

                        if ((ValueForBot.NewColorTie.R >= ValueForBot.ColorTie.R + 15 - 10 & ValueForBot.NewColorTie.R <= ValueForBot.ColorTie.R + 15 + 10) &
                            (ValueForBot.NewColorTie.G >= ValueForBot.ColorTie.G + 45 - 10 & ValueForBot.NewColorTie.G <= ValueForBot.ColorTie.G + 45 + 10) &
                            (ValueForBot.NewColorTie.B >= ValueForBot.ColorTie.B - 10 & ValueForBot.NewColorTie.B <= ValueForBot.ColorTie.B + 10) &
                            !_ready)
                        {
                            _resultType = 0;
                        }

                    skip:

                        if (_resultType == 1 | _resultType == 2 | _resultType == 0)
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

        #endregion

        #region BackGround Mode

        public static IntPtr IHandle;
        private async Task BotsBackground()
        {
           // if (!_statusRunBot) return;
            if (!_statusRunBot) return;
            while (_statusRunBot)
            {
                await Task.Run(CheckColorStartTimeBackGround, _cToken);
                await Task.Run(AutoClickBackGround, _cToken);
                await Task.Run(CheckColorResultBackGround, _cToken);
                await Task.Run(AddClickToBigRoad, _cToken);
            }
        }
        private  void Bots_BackGround_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (Bots_BackGround.CancellationPending) return;
            while (!Bots_BackGround.CancellationPending)
            {
                CheckColorStartTimeBackGround();
                AutoClickBackGround();
                CheckColorResultBackGround();
                AddClickToBigRoad();
            }
        }
        private void CheckColorStartTimeBackGround()
        {
            if (!_statusRunBot) return;
            checked
            {
                try
                {
                    var bitmap = GetColor.GetColorString(IHandle, ValueForBot.PositionStart.X, ValueForBot.PositionStart.Y);
                    var newColorStart = GetColor.Hex2Color(bitmap);
                 
                    ValueForBot.NewColorStart = newColorStart;


                    //if (_statusRunBot && _statusRunningBot == 0 && ValueForBot.NewColorStart.R >= ValueForBot.ColorStart.R - 10 & ValueForBot.NewColorStart.R <= ValueForBot.ColorStart.R + 10 &  ValueForBot.NewColorStart.G >= ValueForBot.ColorStart.G - 10 & ValueForBot.NewColorStart.G <= ValueForBot.ColorStart.G + 10 & ValueForBot.NewColorStart.B >= ValueForBot.ColorStart.B - 10 & ValueForBot.NewColorStart.B <= ValueForBot.ColorStart.B + 10)
                    if (_statusRunBot && _statusRunningBot == 0 && GetColor.ColorCompare(ValueForBot.NewColorStart, ValueForBot.ColorStart,10))
                    {
                        _statusRunningBot = 1;
                        Thread.Sleep(200);
                        Application.DoEvents();
                    }

                    //if (ValueForBot.NewColorStart.R >= ValueForBot.ColorStart.R - 10 & ValueForBot.NewColorStart.R <= ValueForBot.ColorStart.R + 10 & 
                    //    ValueForBot.NewColorStart.G >= ValueForBot.ColorStart.G - 10 & ValueForBot.NewColorStart.G <= ValueForBot.ColorStart.G + 10 & 
                    //    ValueForBot.NewColorStart.B >= ValueForBot.ColorStart.B - 10 & ValueForBot.NewColorStart.B <= ValueForBot.ColorStart.B + 10)

                    _ready = GetColor.ColorCompare(ValueForBot.NewColorStart, ValueForBot.ColorStart, 10);
                   
                }
                catch
                {

                }
            }
        }
        private void AutoClickBackGround()
        {
            if (!_statusRunBot) return;
            if (_statusRunningBot != 1) return;
            _statusRunningBot = 100;
            checked
            {
                if (BotValues.BettingSuggest.Count > 0)
                {
                    AutoClickBackGround(BotValues.BettingSuggest[BotValues.BettingSuggest.Count - 1], BotValues.Unit[BotValues.Unit.Count - 1]);
                }

                _statusRunningBot = 2;
            }
        }
        private void AutoClickBackGround(short bettingSuggest, int lastUnit)
        {
            if (!_statusRunBot) return;
            checked
            {
                if (_statusRunBot)
                {

                    lastUnit *= ValueForBot.Chip;

                    var chip1 = int.Parse(LayoutValues.Chip1);
                    var chip2 = int.Parse(LayoutValues.Chip2);
                    var chip3 = int.Parse(LayoutValues.Chip3);
                    var chip4 = int.Parse(LayoutValues.Chip4);
                    var chip5 = int.Parse(LayoutValues.Chip5);

                    short amountChip1 = 0;
                    short amountChip2 = 0;
                    short amountChip3 = 0;
                    short amountChip4 = 0;
                    short amountChip5 = 0;
                    _amountBetChip = "";
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
                            ref var ptr = ref _amountBetChip;
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
                            ref var ptr = ref _amountBetChip;
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
                            ref var ptr = ref _amountBetChip;
                            _amountBetChip = string.Concat(ptr, ",", chip1.ToString(), "x", amountChip1.ToString());
                        }
                    }

                    if (amountChip5 > 0)
                    {
                        Win32Bot.ClickToBG(IHandle, ValueForBot.PositionChip5.X, ValueForBot.PositionChip5.Y);
                        Thread.Sleep(200);
                        int timesClick = amountChip5;
                        for (var i = 1; i <= timesClick; i++)
                        {
                            ClickBettingBackGround(bettingSuggest);
                            Thread.Sleep(700);

                        }
                    }
                    if (amountChip4 > 0)
                    {
                        Win32Bot.ClickToBG(IHandle, ValueForBot.PositionChip4.X, ValueForBot.PositionChip4.Y);
                        Thread.Sleep(200);
                        int timesClick = amountChip4;
                        for (var j = 1; j <= timesClick; j++)
                        {
                            ClickBettingBackGround(bettingSuggest);
                            Thread.Sleep(700);
                        }
                    }
                    if (amountChip3 > 0)
                    {
                        Win32Bot.ClickToBG(IHandle, ValueForBot.PositionChip3.X, ValueForBot.PositionChip3.Y);
                        Thread.Sleep(200);
                        int timesClick = amountChip3;
                        for (var k = 1; k <= timesClick; k++)
                        {
                            ClickBettingBackGround(bettingSuggest);
                            Thread.Sleep(700);
                        }
                    }
                    if (amountChip2 > 0)
                    {
                        Win32Bot.ClickToBG(IHandle, ValueForBot.PositionChip2.X, ValueForBot.PositionChip2.Y);
                        Thread.Sleep(200);
                        int timesClick = amountChip2;
                        for (var l = 1; l <= timesClick; l++)
                        {
                            ClickBettingBackGround(bettingSuggest);
                            Thread.Sleep(700);
                        }
                    }
                    if (amountChip1 > 0)
                    {
                        Win32Bot.ClickToBG(IHandle, ValueForBot.PositionChip1.X, ValueForBot.PositionChip1.Y);
                        Thread.Sleep(200);
                        int timesClick = amountChip1;
                        for (var m = 1; m <= timesClick; m++)
                        {
                            ClickBettingBackGround(bettingSuggest);
                            Thread.Sleep(700);
                        }
                    }

                    Thread.Sleep(1000);
                    if (bettingSuggest == 1)
                    {
                        Win32Bot.ClickToBG(IHandle, ValueForBot.PositionConfirmPlayer.X, ValueForBot.PositionConfirmPlayer.Y);
                        Thread.Sleep(100);
                        Win32Bot.ClickToBG(IHandle, ValueForBot.PositionConfirmPlayer.X, ValueForBot.PositionConfirmPlayer.Y);
                    }
                    else if (bettingSuggest == 2)
                    {
                        Win32Bot.ClickToBG(IHandle, ValueForBot.PositionConfirmBanker.X, ValueForBot.PositionConfirmBanker.Y);
                        Thread.Sleep(100);
                        Win32Bot.ClickToBG(IHandle, ValueForBot.PositionConfirmBanker.X, ValueForBot.PositionConfirmBanker.Y);
                    }

                    if (cbDoubleConfirmClick.CheckedState)
                    {
                        Thread.Sleep(1000);
                        if (bettingSuggest == 1)
                        {
                            Win32Bot.ClickToBG(IHandle, ValueForBot.PositionConfirmPlayer.X, ValueForBot.PositionConfirmPlayer.Y);
                            Thread.Sleep(100);
                            Win32Bot.ClickToBG(IHandle, ValueForBot.PositionConfirmPlayer.X, ValueForBot.PositionConfirmPlayer.Y);
                        }
                        else if (bettingSuggest == 2)
                        {
                            Win32Bot.ClickToBG(IHandle, ValueForBot.PositionConfirmBanker.X, ValueForBot.PositionConfirmBanker.Y);
                            Thread.Sleep(100);
                            Win32Bot.ClickToBG(IHandle, ValueForBot.PositionConfirmBanker.X, ValueForBot.PositionConfirmBanker.Y);
                        }
                    }


                    Thread.Sleep(100);
                    //  dgvStatus[3, 5].Value = _amountBetChip;
                    lbValueUnit.Text = _amountBetChip;
                }
            }
        }
        private void ClickBettingBackGround(short bettingSuggest)
        {
            if (bettingSuggest == 1)
            {
                Win32Bot.ClickToBG(IHandle, ValueForBot.PositionPlayer.X, ValueForBot.PositionPlayer.Y);
            }
            else if (bettingSuggest == 2)
            {
                Win32Bot.ClickToBG(IHandle, ValueForBot.PositionBanker.X, ValueForBot.PositionBanker.Y);
            }
        }
        private void CheckColorResultBackGround()
        {
            if (!_statusRunBot) return;
            checked
            {
                try
                {
                    if (_statusRunningBot != 2) return;

                    try
                    {
                        var bitmap = GetColor.GetColorString(IHandle, ValueForBot.PositionPlayer.X, ValueForBot.PositionPlayer.Y);
                        var newColorPlayer = GetColor.Hex2Color(bitmap);
                        ValueForBot.NewColorPlayer = newColorPlayer;
                    }
                    catch
                    {
                    }

                    try
                    {
                        var bitmap = GetColor.GetColorString(IHandle, ValueForBot.PositionBanker.X, ValueForBot.PositionBanker.Y);
                        var newColorBanker = GetColor.Hex2Color(bitmap);
                        ValueForBot.NewColorBanker = newColorBanker;
                    }
                    catch
                    {
                    }

                    try
                    {
                        var bitmap = GetColor.GetColorString(IHandle, ValueForBot.PositionTie.X, ValueForBot.PositionTie.Y);
                        var newColorTie = GetColor.Hex2Color(bitmap);
                        ValueForBot.NewColorTie = newColorTie;
                    }
                    catch
                    {
                    }

                    if (_statusRunBot)
                    {
                        //if ((ValueForBot.NewColorPlayer.R >= ValueForBot.ColorPlayer.R + 15 - 10 & 
                        //     ValueForBot.NewColorPlayer.R <= ValueForBot.ColorPlayer.R + 15 + 10) &
                        //    (ValueForBot.NewColorPlayer.G >= ValueForBot.ColorPlayer.G + 45 - 10 & 
                        //     ValueForBot.NewColorPlayer.G <= ValueForBot.ColorPlayer.G + 45 + 10) &
                        //    (ValueForBot.NewColorPlayer.B >= ValueForBot.ColorPlayer.B - 10 & 
                        //     ValueForBot.NewColorPlayer.B <= ValueForBot.ColorPlayer.B + 10) &
                        //    !_ready)

                        //if (newColor.R >= oldColor.R - colorRMore & newColor.R <= oldColor.R + colorRLess &
                        //    newColor.G >= oldColor.G - colorGMore & newColor.G <= oldColor.G + colorGLess &
                        //    newColor.B >= oldColor.B - colorBMore & newColor.B <= oldColor.B + colorBLess)
                        
                            if (GetColor.ColorCompare(ValueForBot.NewColorPlayer, ValueForBot.ColorPlayer, 
                                5,25, 
                                35,55,
                                10,10,
                                GetColor.CompareMode.Increase, GetColor.CompareMode.Increase,
                                GetColor.CompareMode.Increase, GetColor.CompareMode.Increase,
                                GetColor.CompareMode.Delete, GetColor.CompareMode.Increase) &
                            !_ready)
                        {
                            _resultType = 1;
                            goto skip;
                        }

                        //if ((ValueForBot.NewColorBanker.R >= ValueForBot.ColorBanker.R + 15 - 10 &
                        //     ValueForBot.NewColorBanker.R <= ValueForBot.ColorBanker.R + 15 + 10) &
                        //    (ValueForBot.NewColorBanker.G >= ValueForBot.ColorBanker.G + 45 - 10 & 
                        //     ValueForBot.NewColorBanker.G <= ValueForBot.ColorBanker.G + 45 + 10) &
                        //    (ValueForBot.NewColorBanker.B >= ValueForBot.ColorBanker.B - 10 & 
                        //     ValueForBot.NewColorBanker.B <= ValueForBot.ColorBanker.B + 10) &
                        //    !_ready)
                        if (GetColor.ColorCompare(ValueForBot.NewColorBanker, ValueForBot.ColorBanker,
                                5, 25,
                                35, 55,
                                10, 10,
                                GetColor.CompareMode.Increase, GetColor.CompareMode.Increase,
                                GetColor.CompareMode.Increase, GetColor.CompareMode.Increase,
                                GetColor.CompareMode.Delete, GetColor.CompareMode.Increase) &
                            !_ready)
                        {
                            _resultType = 2;
                            goto skip;
                        }

                        //if (ValueForBot.NewColorTie.R >= ValueForBot.ColorTie.R + 15 - 10 &
                        //    ValueForBot.NewColorTie.R <= ValueForBot.ColorTie.R + 15 + 10 &
                        //    ValueForBot.NewColorTie.G >= ValueForBot.ColorTie.G + 45 - 10 &
                        //    ValueForBot.NewColorTie.G <= ValueForBot.ColorTie.G + 45 + 10 &
                        //    ValueForBot.NewColorTie.B >= ValueForBot.ColorTie.B - 10 & 
                        //    ValueForBot.NewColorTie.B <= ValueForBot.ColorTie.B + 10 &
                        //    !_ready)
                        if (GetColor.ColorCompare(ValueForBot.NewColorTie, ValueForBot.ColorTie,
                                5, 25,
                                35, 55,
                                10, 10,
                                GetColor.CompareMode.Increase, GetColor.CompareMode.Increase,
                                GetColor.CompareMode.Increase, GetColor.CompareMode.Increase,
                                GetColor.CompareMode.Delete, GetColor.CompareMode.Increase) &
                            !_ready)
                        {
                            _resultType = 0;
                        }

                        skip:

                        if (_resultType == 1 | _resultType == 2 | _resultType == 0)
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
        #endregion
        private void AddClickToBigRoad()
        {
            if (!_statusRunBot) return;
            if (_statusRunningBot != 3 & (_resultType != 1 | _resultType != 2 | _resultType != 0)) return;
            _statusRunningBot = 200;

            if (_resultType == 1)
            {
                AddValue2BigRoadClick("P");
            }
            else if (_resultType == 2)
            {
                AddValue2BigRoadClick("B");
            }
            else if (_resultType == 0)
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
                    if (stopRound != 0 && stopRound <= BotValues.Result.Count)
                    {
                       ClickStart();
                        return;
                    }

                    if (stopWin != 0 && stopWin <= BotValues.TotalWin)
                    {
                        ClickStart();
                        return;
                    }
                    if (stopLose != 0 && stopLose <= BotValues.TotalLose)
                    {
                        ClickStart();
                        return;
                    }
                    if (stopMore != 0 && stopMore <= BotValues.LastMoneyBalance)
                    {
                        ClickStart();
                        return;
                    }
                    if (stopLess != 0 && stopLess <= -Math.Abs(BotValues.LastMoneyBalance))
                    {
                        ClickStart();
                        return;
                    }
                }

                _statusRunningBot = 0;
            }
        }
        private void TmTimeRunning_Tick(object sender, EventArgs e)
        {
            lbValueRunTime.Text = CalculateInt2Time(_timeRunning);
           // dgvStatus[2, 0].Value =  CalculateInt2Time(_timeRunning);
            ref var ptr = ref _timeStart;
            checked
            {
                _timeStart = ptr + 1;

                ptr = ref _timeRunning;
                _timeRunning = ptr + 1;
            }
        }
        private string CalculateInt2Time(int value)
        {
            var sec = value % 60;
            checked
            {
                var min = (int)Math.Round((value - sec) / 60.0 % 60.0);
                var hr = (int)Math.Round((value - (sec + min * 60)) / 3600.0 % 60.0);
                return string.Concat(hr.ToString("00"), ":", min.ToString("00"), ":", sec.ToString("00"));
            }
        }
        
        #endregion

        #region Languages
        private void InitLocalization()
        {
            BotValues.InitLocalization();
            cbLanguages.DataSource = BotValues.LclzManager.GetLangList();
            if (cbLanguages.Items.Count == 0)
            {
                cbLanguages.Enabled = false;
            }
            else
            {
                try
                {
                    cbLanguages.SelectedIndex = Settings.Default.Lang;
                }
                catch
                {
                    cbLanguages.SelectedIndex = 0;
                }
                LoadLanguage();
            }
            
        }

        private void CbLanguages_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            LoadSelectedLanguage();
            BotValues.LoadLanguage(this);
            BotValues.LocalizeSpecialCases();
            StatusLoad();
            UpdateBotSettings();
        }
        private void LoadSelectedLanguage()
        {
            if (cbLanguages.SelectedItem == null)
            {
                return;
            }
            BotValues.LclzManager.LoadLanguageFromFile(((LangInfo)cbLanguages.SelectedItem).File);
        }

        #endregion
        
        #region GetValueString

        private void Button1_Click(object sender, EventArgs e)
        {
         
            //LocalizeFormNew(this);
            //LocalizeFormNew(_frmBet);
            //LocalizeFormNew(_frmBetEdit);
            //LocalizeFormNew(_frmFormula);
            //LocalizeFormNew(_frmFormulaCustom);
            //LocalizeFormNew(_frmFormulaFixed);
            //LocalizeFormNew(_frmLayout);
        }

        //private static string startupPath = Application.StartupPath;
        //readonly IniReader ini = new IniReader(startupPath + @"//string.ini");
        //public void LocalizeFormNew(Form form)
        //{
        //    var name = form.Name;
        //    foreach (object obj in form.Controls)
        //    {
        //        var control = (Control)obj;
        //        switch (control.GetType().Name.ToLower())
        //        {
        //            case "label":
        //            case "checkbox":
        //            case "linklabel":
        //            case "button":
        //            case "bunifuflatbutton":
        //            case "king99label":
        //            case "king99textbox":
        //            case "king99radiobutton":
        //            case "king99button":
        //            case "king99checkbox":
        //            case "king99headerlabel":
        //                ini.WriteString(name, control.Name, "");
        //                break;

        //            case "tablelayoutpanel":
        //            case "panel":
        //            case "tabcontrol":
        //            case "king99tabcontrol":
        //            case "king99theme":
        //            case "bunifucards":
        //                LocalizeChildControlsNew(control, name);
        //                break;
        //            case "tabpage":
        //                ini.WriteString(name, control.Name, "");
        //                LocalizeChildControlsNew(control, name);
        //                break;
        //            case "groupbox":
        //            case "king99groupbox":
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
        //            case "bunifuflatbutton":
        //            case "king99label":
        //            case "king99textbox":
        //            case "king99radiobutton":
        //            case "king99button":
        //            case "king99checkbox":
        //            case "king99headerlabel":
        //                ini.WriteString(section, control2.Name, "");
        //                break;
        //            case "tablelayoutpanel":
        //            case "panel":
        //            case "tabcontrol":
        //            case "king99tabcontrol":
        //            case "bunifucards":
        //                LocalizeChildControlsNew(control2, section);
        //                break;
        //            case "tabpage":
        //                ini.WriteString(section, control2.Name, "");
        //                LocalizeChildControlsNew(control2, section);
        //                break;
        //            case "groupbox":
        //            case "king99groupbox":
        //                ini.WriteString(section, control2.Name, "");
        //                LocalizeChildControlsNew(control2, section);
        //                break;
        //        }
        //    }
        //}

        #endregion
    }
}
