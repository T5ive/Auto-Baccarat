using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.DataViz.WinForms;
using Bunifu.Json.Linq;

namespace AutoBaccarat
{
    public partial class FrmSum : Form
    {
        public double Balance;
        public FrmSum()
        {
            InitializeComponent();
        }

        private void FrmSum_Load(object sender, EventArgs e)
        {
            dgvBigRoad.Columns.Add("_colbig0", "_colbig0");
            dgvWL.Columns.Add("_colwl0", "_colwl0");
            UpdateBigRoad(BotValues.ScorePbt);
            UpdateWinLose(BotValues.WinLose);

            ChartScore();
            ChartWinLoseAndBalance();
        }

        #region Big Road
        private int _bigRoadLastValue, _bigRoadNewColumn, _bigRoadNewLine = -1;

        private int _player,_banker;
        private void ChartScore()
        {
            var canvas = new Canvas();
            var dataValue = new DataPoint(BunifuDataViz._type.Bunifu_line);
            var dataValue2 = new DataPoint(BunifuDataViz._type.Bunifu_line);
          checked
            {
                if (BotValues.ScorePbt.Count != 0)
                {
                    _chartScoreValue = 0;
                    _player = 0;
                    _banker = 0;
                    var listCount = BotValues.ScorePbt.Count - 1;
                    for (int i = 0; i <= listCount; i++)
                    {
                        if (BotValues.ScorePbt[i] == 1 | BotValues.ScorePbt[i] == 2)
                        {
                            if (BotValues.ScorePbt[i] == 1)
                            {
                                _player++;
                            }
                            else
                            {
                                _banker++;
                            }

                            dataValue.addLabely(i.ToString(), _player);
                            dataValue2.addLabely(i.ToString(), _banker);
                        }
                    }
                }
            }

            canvas.addData(dataValue);
            canvas.addData(dataValue2);
            DataScore.colorSet.Add(Color.RoyalBlue);
            DataScore.colorSet.Add(Color.Red);


            DataScore.Render(canvas);
        }
        private void UpdateBigRoad(List<short> list)
        {
            checked
            {
                if (list.Count > 0)
                {
                    var listCount = list.Count - 1;
                    for (int i = 0; i <= listCount; i++)
                    {
                        if (list[i] != 0)
                        {
                            if (_bigRoadLastValue == 0)
                            {
                                _bigRoadLastValue = list[i];
                                UpdateBigRoad(BotValues.ScorePbt);
                                return;
                            }
                            if (_bigRoadLastValue == list[i])
                            {
                                _bigRoadNewLine++;
                            }

                            if (_bigRoadLastValue != list[i])
                            {
                                _bigRoadNewLine = 0;
                                _bigRoadNewColumn++;
                                dgvBigRoad.Columns.Add("_colbig" + _bigRoadNewColumn, "_colbig" + _bigRoadNewColumn);
                            }

                            try
                            {
                                if (_bigRoadNewLine == dgvBigRoad.RowCount)
                                {
                                    dgvBigRoad.Rows.Add("");
                                }
                                var str = "";
                                var color = Color.Black;
                                if (list[i] == 1)
                                {
                                    str = "P";
                                    color = Color.RoyalBlue;
                                }
                                if (list[i] == 2)
                                {
                                    str = "B";
                                    color = Color.Red;
                                }
                                else if (list[i] == 0)
                                {
                                    str = "T";
                                    color = Color.LimeGreen;
                                }
                                dgvBigRoad.Rows[_bigRoadNewLine].Cells[_bigRoadNewColumn].Value = str;
                                dgvBigRoad.Rows[_bigRoadNewLine].Cells[_bigRoadNewColumn].Style.BackColor = color;

                            }
                            catch
                            {
                                dgvBigRoad.Rows.Add("");
                            }
                            _bigRoadLastValue = list[i];
                        }
                    }

                }
            }
        }
        private void DgvBigRoad_SelectionChanged(object sender, EventArgs e)
        {
            dgvBigRoad.ClearSelection();
        }

        #endregion


        #region Win Lose Balance

        private int _winLoseNewColumn, _winLoseNewLine = -1;
        private string _winLoseLastValue;

        private int _chartScoreValue;
        private void ChartWinLoseAndBalance()
        {
            DataWinLose.colorSet.Clear();
            DataWinLose.colorSet.Add(Color.Black);

            DataBalance.colorSet.Clear();
            DataBalance.colorSet.Add(Color.Black);

            var canvasWinLose = new Canvas();
            var dataWinLose = new DataPoint(BunifuDataViz._type.Bunifu_line);

            var canvasBalance = new Canvas();
            var dataBalance = new DataPoint(BunifuDataViz._type.Bunifu_splineArea);

            checked
            {
                _chartScoreValue = 0;
                var listCount = BotValues.WinLose.Count - 1;
                for (int i = 0; i <= listCount; i++)
                {
                    if (BotValues.WinLose[i] == "W" | BotValues.WinLose[i] == "L")
                    {
                        if (BotValues.WinLose[i] == "W")
                        {
                            _chartScoreValue++;

                        }
                        else
                        {
                            _chartScoreValue--;

                        }

                        dataWinLose.addLabely(i.ToString(), _chartScoreValue);

                        if (BotValues.Balance.Count > i)
                        {
                            dataBalance.addLabely(i.ToString(), BotValues.Balance[i]);
                        }
                    }
                }

                DataWinLose.colorSet[0] = _chartScoreValue > 0 ? Color.Lime : _chartScoreValue < 0 ? Color.Red :  Color.Black;

                DataBalance.colorSet[0] = Balance > 0 ? Color.Lime : Balance < 0 ? Color.Red : Color.RoyalBlue;

            }

            canvasWinLose.addData(dataWinLose);
            DataWinLose.Render(canvasWinLose);

            canvasBalance.addData(dataBalance);
            DataBalance.Render(canvasBalance);

        }
        private void UpdateWinLose(List<string> list)
        {
            //_winLoseLastValue = null;
            var listCount = checked(list.Count - 1);
            checked
            {
                for (var i = 0; i <= listCount; i++)
                {
                    if (Math.Abs(BotValues.MoneyCost[i]) > 0 || Math.Abs(BotValues.MoneyCost[i]) < 0)
                    {
                        if (_winLoseLastValue == null)
                        {
                            _winLoseLastValue = list[i];
                            UpdateWinLose(BotValues.WinLose);
                            return;
                        }
                        if (_winLoseLastValue == null | _winLoseLastValue == list[i])
                        {
                            if (_winLoseLastValue != null)
                            {
                                _winLoseNewLine++;
                            }
                        }
                        else
                        {
                            _winLoseNewLine = 0;
                            _winLoseNewColumn++;
                            dgvWL.Columns.Add("_colwl" + _winLoseNewColumn, "_colwl" + _winLoseNewColumn);
                        }

                        try
                        {
                            if (_winLoseNewLine == dgvWL.RowCount)
                            {
                                dgvWL.Rows.Add("");
                            }

                            var str = "";
                            var color = Color.Black;
                            if (list[i] == "W")
                            {
                                str = "W";
                                color = Color.LimeGreen;
                            }

                            if (list[i] == "L")
                            {
                                str = "L";
                                color = Color.Red;
                            }

                            dgvWL.Rows[_winLoseNewLine].Cells[_winLoseNewColumn].Value = str;
                            dgvWL.Rows[_winLoseNewLine].Cells[_winLoseNewColumn].Style.BackColor = color;

                        }
                        catch
                        {
                            dgvWL.Rows.Add("");
                        }
                        _winLoseLastValue = list[i];
                    }
                }
            }
        }
        private void DgvWL_SelectionChanged(object sender, EventArgs e)
        {
            dgvWL.ClearSelection();
        }

        #endregion





    }
}
