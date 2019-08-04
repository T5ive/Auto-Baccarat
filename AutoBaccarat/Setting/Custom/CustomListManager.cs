using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBaccarat
{
   public class CustomListManager
    {
        private readonly string _custom;
        private readonly Dictionary<string, Dictionary<string, string>> _currentCustomDict = new Dictionary<string, Dictionary<string, string>>();
        public CustomListManager()
        {
              var startupPath = Application.StartupPath;
            _custom = startupPath + "\\custom\\";
        }
        public List<CustomInfo> GetCustomList()
        {
            if (!Directory.Exists(_custom))
            {
                return null;
            }
            var files = Directory.GetFiles(_custom, "*.dat");
            return files.Select(text => new CustomInfo
            {
                File = text,
                Name = IniReader.ReadStringFromIni("General", "Name", text)
            }).ToList();
        }
        public void LoadLanguageFromFile(string lngFile)
        {
           string newString = null;
            _currentCustomDict.Clear();
            var iniReader = new IniReader(lngFile);

            var sectionList = iniReader.GetSectionList();
            foreach (var text in sectionList)
            {
                var dictionary = new Dictionary<string, string>();
                var keyList = iniReader.GetKeyList(text);
                foreach (var key in keyList)
                {
                    dictionary[key] = iniReader.ReadString(text, key);
                    if (text == "Values")
                    {
                        newString += dictionary[key];
                    }
                }
                _currentCustomDict[text] = dictionary;
                FrmMain._customLoadValue2Array = newString;
            }
        }

        

    }
}
