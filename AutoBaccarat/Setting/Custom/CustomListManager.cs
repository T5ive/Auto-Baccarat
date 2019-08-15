using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    public class CustomListManager
    {
        private readonly string _custom;
        private readonly Dictionary<string, Dictionary<string, string>> _currentCustomDict = new Dictionary<string, Dictionary<string, string>>();
        public CustomListManager()
        {
              var startupPath = Application.StartupPath;
            _custom = startupPath + "\\Custom\\";
        }
        public List<CustomInfo> GetCustomList()
        {
            if (!Directory.Exists(_custom))
            {
                return null;
            }
            var files = Directory.GetFiles(_custom, "*.dat");
            if (files.Length == 0)
            {
                AddNewCustom();
                FormulaValues.LoadListCount = 0;
                files = Directory.GetFiles(_custom, "*.dat");
            }
            return files.Select(text => new CustomInfo
            {
                File = text,
                Name = IniReader.ReadStringFromIni("General", "Name", text)
            }).ToList();
            
        }
        public void LoadValuesFromFile(string lngFile)
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
                FormulaValues.ReadCustomValue = newString;
            }
        }

        private static string RandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[19];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
                if (i == 4)
                {
                    stringChars[i] = '-';
                }
                if (i == 9)
                {
                    stringChars[i] = '-';
                }
                if (i == 14)
                {
                    stringChars[i] = '-';
                }
            }

            var finalString = new string(stringChars);
            return finalString;
        }

        public static void AddNewCustom()
        {
            var name = RandomString();
            IniReader.WriteString("General", "Name", "New Custom", Application.StartupPath + "\\Custom\\" + name + ".dat");
            IniReader.WriteString("Values", "Custom", FormulaValues.DefaultValue(), Application.StartupPath + "\\Custom\\" + name + ".dat");
        }

        public static void SaveValue()
        {
            var fileName = new IniReader (FormulaValues.ListLoad[FormulaValues.LoadListCount].File);
            var path = fileName.Path;
            var file = new FileInfo(path);
            file.Delete();

            IniReader.WriteString("General", "Name", FormulaValues.ListName, path);
            IniReader.WriteString("Values", "Custom", FormulaValues.ReadCustomValue, path);
        }
    }
}
