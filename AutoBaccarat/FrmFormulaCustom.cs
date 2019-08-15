using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using AutoBaccarat.Properties;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    public partial class FrmFormulaCustom : Form
    {
        public FrmFormulaCustom()
        {
            InitializeComponent();
        }

        #region Load/Save
        private void FrmFormulaEdit_Load(object sender, EventArgs e)
        {
            LoadLocation();
            LoadFiles2List();
        }
        private void LoadLocation()
        {
            if (Settings.Default.LocationFormulaCustom == new Point(0, 0))
            {
                CenterToScreen();
            }
            else
            {
                Location = Settings.Default.LocationFormulaCustom;
            }
        }
        private void FrmFormulaEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            Settings.Default.LocationFormulaCustom = Location;
            Settings.Default.LoadCustomListCount = FormulaValues.LoadListCount;
            Settings.Default.Save();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (CheckEdit())
            {
                var msgResult = MessageBox.Show($@"[{FormulaValues.ListName}] {stringLoader.Modified}",
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
          //  Close();
        }
        private void SaveValue()
        {
            if (ListBoxValue.Items.Count == 0)
            {
                MessageBox.Show(stringLoader.SetBetUnit, stringLoader.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _valueNumber.Clear();
            checked
            {
                for (var i = 0; i <= ListBoxValue.Items.Count - 1; i++)
                {
                    _valueNumber.Add(ListBoxValue.Items[i].ToString());
                }

                FormulaValues.ValueNumber = _valueNumber;
                FormulaValues.ValueType = _valueType;
                SaveValue(FormulaValues.ValueNumber, FormulaValues.ValueType);
            }

            FormulaValues.ListName = txtName.Text;
            CustomListManager.SaveValue();
            SaveSettings();
            LoadFiles2List();
        }
        public static void SaveValue(List<string> valueNumber, List<string> valueType)
        {
            var text = "";
            checked
            {
                var num = valueNumber.Count - 1;
                for (var i = 0; i <= num; i++)
                {
                    if (i > 0)
                    {
                        text += "|";
                    }
                    text = text + valueNumber[i] + "=" + valueType[i];
                }
                FormulaValues.ReadCustomValue = text;
            }
        }

        #endregion

        #region File List Control

        private bool _customListFirstTime = true;
        private static List<string> _valueNumber;
        private static List<string> _valueType;
        private bool _cancel;
        private void LoadFiles2List()
        {
            try
            {
                checked
                {
                    FormulaValues.ListLoad = FormulaValues.ListMng.GetCustomList();
                    ListBoxLoad.DataSource = FormulaValues.ListLoad;
                    ListBoxLoad.SelectedIndex = Settings.Default.LoadCustomListCount;
                   
                }
                
            }
            catch
            {
            }
        }
        private void LoadList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_customListFirstTime)
                {
                    _customListFirstTime = false;
                    goto skip;
                }
                if (_cancel)
                {
                    _cancel = false;
                    return;
                }
                if (CheckEdit())
                {
                    var msgResult = MessageBox.Show($@"[{FormulaValues.ListName}] {stringLoader.Modified}",
                        stringLoader.Confirmation, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (msgResult == DialogResult.Yes)
                    {
                        SaveValue();
                        return;
                    }
                    if (msgResult == DialogResult.Cancel)
                    {
                        _cancel = true;
                        ListBoxLoad.SelectedIndex = FormulaValues.LoadListCount;
                        return;
                    }
                }

                skip:
                if (ListBoxLoad.SelectedItem == null)
                {
                    return;
                }

                FormulaValues.ListMng.LoadValuesFromFile(((CustomInfo)ListBoxLoad.SelectedItem).File);

                FormulaValues.StringSplit2Array();
                Array2ListBox();
                UpdateValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stringLoader.Error + @"03x1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Array2ListBox()
        {
            _valueNumber = FormulaValues.ValueNumber;
            _valueType = FormulaValues.ValueType;
            checked
            {
                if (_valueNumber.Count > 0)
                {
                    ListBoxValue.Items.Clear();
                    var num = _valueNumber.Count - 1;
                    for (var i = 0; i <= num; i++)
                    {
                        ListBoxValue.Items.Add(_valueNumber[i]);
                    }
                }
            }

            List2Label();
        }
        private void UpdateValue()
        {
            FormulaValues.LoadListCount = (byte)ListBoxLoad.SelectedIndex;
            FormulaValues.ListName = ListBoxLoad.SelectedItem.ToString();

            txtName.Text = ListBoxLoad.SelectedItem.ToString();
        }
        private void BtnAddList_Click(object sender, EventArgs e)
        {
            CustomListManager.AddNewCustom();
            LoadFiles2List();
        }
        private void BtnDelList_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListBoxLoad.SelectedItem != null)
                {
                    var itemList = ListBoxLoad.SelectedItem;

                    if (MessageBox.Show($@"{stringLoader.Delete} {itemList} ?", stringLoader.Confirmation,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                    {
                        var iniReader = new IniReader(((CustomInfo)ListBoxLoad.SelectedItem).File);
                        var path = iniReader.Path;
                        var file = new FileInfo(path);
                        file.Delete();

                        var num = ListBoxLoad.SelectedIndex;
                        if (num == 0)
                        {
                            FormulaValues.LoadListCount = 0;
                        }
                        if (num < ListBoxLoad.Items.Count)
                        {
                           FormulaValues.LoadListCount = (byte) (num - 1);
                        }
                        SaveSettings();
                        LoadFiles2List();


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stringLoader.Error + @"03x2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        
        #region Custom Control

        private short _listBoxValueCount;
        
        #region Value Control
        private void ListBoxValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            _listBoxValueCount = (short)ListBoxValue.SelectedIndex;
            if (_listBoxValueCount < 0)
            {
                txtNum.Text = null;
                radFollow.Checked = false;
                radAdverse.Checked = false;
                return;
            }

            txtNum.Text = ListBoxValue.SelectedItem.ToString();

            if (_valueType[_listBoxValueCount] == "O")
            {
                radFollow.Checked = true;
                return;
            }
            radAdverse.Checked = true;
        }
        private void TxtNum_TextChanged(object sender, EventArgs e)
        {
            AddCustomResult();
        }
        private void AddCustomResult()
        {
            var array = txtNum.Text.Trim().Split(',');
            PanelResult.Controls.Clear();
            PanelResultPB.Controls.Clear();
            PanelResultBP.Controls.Clear();

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
                            PanelResult.Controls.Add(value);

                            valueP.Location = new Point(x, y);
                            PanelResultPB.Controls.Add(valueP);

                            valueB.Location = new Point(x, y);
                            PanelResultBP.Controls.Add(valueB);
                        }
                    }
                }
                catch
                {
                }
            }
        }
        private void ConfigChecked(object sender)
        {
            try
            {
                if (_listBoxValueCount <= -1) return;

                if (radFollow.Checked)
                {
                    _valueType[_listBoxValueCount] = "O";
                    return;
                }
                if (radAdverse.Checked)
                {
                    _valueType[_listBoxValueCount] = "X";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + $"\n {stringLoader.TryAgain}", stringLoader.Error + @"03x3", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void List2Label()
        {
            lbTotal.Text = $@"{stringLoader.Total}: {ListBoxValue.Items.Count}";
        }
        private bool CheckEdit()
        {
            
            if (FormulaValues.ListName != txtName.Text)
            {
                return true;
            }

            try
            {
                var lastValue = CheckEditValue(_valueNumber, _valueType);
                return FormulaValues.ReadCustomValue != lastValue;
            }
            catch
            {
                return true;
            }
            

            
        }
        public static string CheckEditValue(List<string> valueNumber, List<string> valueType)
        {
            var text = "";
            checked
            {
                var num = valueNumber.Count - 1;
                for (var i = 0; i <= num; i++)
                {
                    if (i > 0)
                    {
                        text += "|";
                    }
                    text = text + valueNumber[i] + "=" + valueType[i];
                }

                return text;
            }
        }

        #endregion

        #region Button 

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNum.Text)) return;
            ListBoxValue.Items.Add(txtNum.Text.Trim());
            var type = radFollow.Checked ? "X" : "O";
            _valueNumber.Add(txtNum.Text.Trim());
            _valueType.Add(type);
            txtNum.Text = "";
            List2Label();
        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            checked
            {
                var num = ListBoxValue.SelectedIndex;

                _listBoxValueCount = (short)ListBoxValue.SelectedIndex;
                if (_listBoxValueCount == -1) return;
                _valueType.RemoveAt(_listBoxValueCount);
                ListBoxValue.Items.RemoveAt(_listBoxValueCount);

                if (num == 0)
                {
                    ListBoxValue.SelectedIndex = ListBoxValue.Items.Count == 0 ? -1 : 0;
                }
                else if (num >= ListBoxValue.Items.Count)
                {
                    ListBoxValue.SelectedIndex = num - 1;
                }
                else
                {
                    ListBoxValue.SelectedIndex = num;
                }
                List2Label();

            }
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            ListBoxValue.Items.Clear();
            _valueType.Clear();
            List2Label();
        }
        private void BtnDefault_Click(object sender, EventArgs e)
        {
            var array = FormulaValues.DefaultValue().Split('|');
            ListBoxValue.Items.Clear();
            _valueType.Clear();
            checked
            {
                for (var i = 0; i <= array.Length - 1; i++)
                {
                    var array2 = array[i].Split('=');
                    ListBoxValue.Items.Add(array2[0]);
                    _valueType.Add(array2[1]);
                }
                ListBoxValue.ClearSelected();
                txtNum.Text = null;
                radFollow.Checked = false;
                radAdverse.Checked = false;
            }
            List2Label();
        }








        #endregion

        #endregion

       
    }
}
