using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    public class LocalizationManager
    {
        public LocalizationManager()
        {
            var startupPath = Application.StartupPath;
            _langDir = startupPath + "\\lng\\";
        }

        public List<LangInfo> GetLangList()
        {
            if (!Directory.Exists(_langDir))
            {
                return null;
            }
            var files = Directory.GetFiles(_langDir, "*.lng");
            return files.Select(text => new LangInfo {File = text, Name = IniReader.ReadStringFromIni("General", "LanguageName", text), Version = IniReader.ReadStringFromIni("General", "Version", text), RightToLeft = IniReader.ReadStringFromIni("General", "RightToLeft", text)}).ToList();
        }

        public void LoadLanguageFromFile(string lngFile)
        {
            _currentLangDict.Clear();
            var iniReader = new IniReader(lngFile);
            _currentRightToLeft = iniReader.ReadString("General", "RightToLeft");
            var sectionList = iniReader.GetSectionList();
            foreach (var text in sectionList)
            {
                var dictionary = new Dictionary<string, string>();
                var keyList = iniReader.GetKeyList(text);
                foreach (var key in keyList)
                {
                    dictionary[key] = iniReader.ReadString(text, key);
                }
                _currentLangDict[text] = dictionary;
            }
        }

        public void LocalizeForm(Form form, bool adjustRightToLeft)
        {
            var name = form.Name;
            foreach (var obj in form.Controls)
            {
                var control = (Control)obj;
                //if (control.GetType().Name == "King99Theme")
                //{
                //    TranslateControlText(control, name);
                    LocalizeChildControls(control, name);
                //}
            }
            if (adjustRightToLeft)
            {
                AdjustRightToLeftLayout(form);
            }
        }

        private void LocalizeChildControls(Control control, string section)
        {
            foreach (var obj in control.Controls)
            {
                var control2 = (Control)obj;
                switch (control2.GetType().Name)
                {
                    case "Label":
                    case "CheckBox":
                    case "LinkLabel":
                    case "Button":
                    case "King99Label":
                    case "King99TextBox":
                    case "King99RadioButton":
                    case "King99Button":
                    case "King99Checkbox":
                    case "King99HeaderLabel":
                    case "BunifuFlatButton":
                        TranslateControlText(control2, section);
                        break;
                    case "BunifuCards":
                    case "TableLayoutPanel":
                    case "Panel":
                    case "Tabcontrol":
                    case "King99TabControl":
                    case "King99GroupBox":
                    case "TabPage":
                    case "GroupBox":
                        TranslateControlText(control2, section);
                        LocalizeChildControls(control2, section);
                        break;
                }
            }
        }
        //public void LocalizeForm(Form _form, bool adjustRightToLeft)
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

        //            case "King99label":
        //            case "King99textbox":
        //            case "King99radiobutton":
        //            case "King99button":
        //            case "King99checkbox":
        //            case "King99headerlabel":
        //                TranslateControlText(control, name);
        //                break;

        //            case "tablelayoutpanel":
        //            case "panel":
        //            case "tabcontrol":
        //            case "King99tabcontrol":
        //            case "King99theme":
        //                LocalizeChildControls(control, name);
        //                break;
        //            case "tabpage":
        //                TranslateControlText(control, name);
        //                LocalizeChildControls(control, name);
        //                break;
        //            case "groupbox":
        //            case "King99groupbox":
        //                TranslateControlText(control, name);
        //                LocalizeChildControls(control, name);
        //                break;
        //        }
        //    }
        //    if (adjustRightToLeft)
        //    {
        //        AdjustRightToLeftLayout(_form);
        //    }
        //}

        //private void LocalizeChildControls(Control control, string section)
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

        //            case "King99label":
        //            case "King99textbox":
        //            case "King99radiobutton":
        //            case "King99button":
        //            case "King99checkbox":
        //            case "King99headerlabel":
        //                TranslateControlText(control2, section);
        //                break;
        //            case "tablelayoutpanel":
        //            case "panel":
        //            case "tabcontrol":
        //            case "King99tabcontrol":
        //            case "King99theme":
        //                LocalizeChildControls(control2, section);
        //                break;
        //            case "tabpage":
        //                TranslateControlText(control2, section);
        //                LocalizeChildControls(control2, section);
        //                break;
        //            case "groupbox":
        //            case "King99groupbox":
        //                TranslateControlText(control2, section);
        //                LocalizeChildControls(control2, section);
        //                break;
        //        }
        //    }
        //}

        public void LocalizeForm(Form form)
        {
            LocalizeForm(form, true);
        }
        private void AdjustRightToLeftLayout(Form form)
        {
            if (_currentRightToLeft == "true" && form.RightToLeft != RightToLeft.Yes)
            {
                form.RightToLeft = RightToLeft.Yes;
                return;
            }
            if (_currentRightToLeft != "true" && form.RightToLeft == RightToLeft.Yes)
            {
                form.RightToLeft = RightToLeft.No;
            }
        }

        private void TranslateControlText(Control control, string section)
        {
            if (_currentLangDict.ContainsKey(section) && _currentLangDict[section].ContainsKey(control.Name))
            {
                control.Text = _currentLangDict[section][control.Name];
            }
        }

        public string TranslateMessageInner(string section, string messageId, string def)
        {
            if (_currentLangDict.ContainsKey(section) && _currentLangDict[section].ContainsKey(messageId))
            {
                return _currentLangDict[section][messageId].Replace("\\r\\n", "\r\n");
            }
            return def.Replace("\\r\\n", "\r\n");
        }

        public string TranslateMessage(string messageId, string def)
        {
            var section = "Messages";
            return TranslateMessageInner(section, messageId, def);
        }

        public string TranslateTooltip(string messageId, string def)
        {
            var section = "Tooltips";
            return TranslateMessageInner(section, messageId, def);
        }

        public string TranslateMessageWithParams(string messageId, string def, params string[] Params)
        {
            var key = "Messages";
            if (_currentLangDict.ContainsKey(key) && _currentLangDict[key].ContainsKey(messageId))
            {
                return string.Format(_currentLangDict[key][messageId].Replace("\\r\\n", "\r\n"), Params);
            }
            return string.Format(def, Params);
        }

        private readonly Dictionary<string, Dictionary<string, string>> _currentLangDict = new Dictionary<string, Dictionary<string, string>>();


        private readonly string _langDir;

        private string _currentRightToLeft = "";
    }
}
