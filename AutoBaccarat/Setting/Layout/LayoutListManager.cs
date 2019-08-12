using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AutoBaccarat.Setting;

namespace AutoBaccarat
{
   public class LayoutListManager
    {
        private readonly string _layout;
        private readonly Dictionary<string, Dictionary<string, string>> _currentLayoutDict = new Dictionary<string, Dictionary<string, string>>();
        public LayoutListManager()
        {
            var startupPath = Application.StartupPath;
            _layout = startupPath + "\\Layout\\";
        }
        public List<LayoutInfo> GetLayoutList()
        {
            if (!Directory.Exists(_layout))
            {
                return null;
            }
            var files = Directory.GetFiles(_layout, "*.dat");
            if (files.Length == 0)
            {
                AddNewLayout();
                LayoutValues.LoadListCount = 0;
                files = Directory.GetFiles(_layout, "*.dat");
            }
            return files.Select(text => new LayoutInfo
            {
                File = text,
                Name = IniReader.ReadStringFromIni("General", "Name", text)
            }).ToList();

        }
        public void LoadValuesFromFile(string lngFile)
        {
            _currentLayoutDict.Clear();
            LayoutValues.ListValues.Clear();
            var iniReader = new IniReader(lngFile);

            var sectionList = iniReader.GetSectionList();
            foreach (var section in sectionList)
            {
                var dictionary = new Dictionary<string, string>();
                var keyList = iniReader.GetKeyList(section);
                foreach (var key in keyList)
                {
                    dictionary[key] = iniReader.ReadString(section, key);
                    if (section == "Values")
                    {
                        LayoutValues.ListValues.Add(dictionary[key]);
                    }
                }

                _currentLayoutDict[section] = dictionary;
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

        public static void AddNewLayout()
        {
            var name = RandomString();
            IniReader.WriteString("General", "Name", "New Layout", Application.StartupPath + "\\Layout\\" + name + ".dat");
            IniReader.WriteString("Values", "Start", " | | | | ", Application.StartupPath + "\\Layout\\" + name + ".dat");
            IniReader.WriteString("Values", "Player", " | | | | ", Application.StartupPath + "\\Layout\\" + name + ".dat");
            IniReader.WriteString("Values", "Banker", " | | | | ", Application.StartupPath + "\\Layout\\" + name + ".dat");
            IniReader.WriteString("Values", "Tie", " | | | | ", Application.StartupPath + "\\Layout\\" + name + ".dat");
            IniReader.WriteString("Values", "Confirm Player", " | | | | ", Application.StartupPath + "\\Layout\\" + name + ".dat");
            IniReader.WriteString("Values", "Confirm Banker", " | | | | ", Application.StartupPath + "\\Layout\\" + name + ".dat");
            IniReader.WriteString("Values", "Chip 1", " |5| | | ", Application.StartupPath + "\\Layout\\" + name + ".dat");
            IniReader.WriteString("Values", "Chip 2", " |10| | | ", Application.StartupPath + "\\Layout\\" + name + ".dat");
            IniReader.WriteString("Values", "Chip 3", " |20| | | ", Application.StartupPath + "\\Layout\\" + name + ".dat");
            IniReader.WriteString("Values", "Chip 4", " |50| | | ", Application.StartupPath + "\\Layout\\" + name + ".dat");
            IniReader.WriteString("Values", "Chip 5", " |100| | | ", Application.StartupPath + "\\Layout\\" + name + ".dat");
            IniReader.WriteString("Values", "Mode", "0", Application.StartupPath + "\\Layout\\" + name + ".dat");
        }

        public static void SaveValue()
        {
            var fileName = new IniReader(FormulaValues.ListLoad[FormulaValues.LoadListCount].File);
            var path = fileName.Path;
            var file = new FileInfo(path);
            file.Delete();

            IniReader.WriteString("General", "Name", FormulaValues.ListName, path);
            IniReader.WriteString("Values", "Layout", FormulaValues.ReadCustomValue, path);
        }
    }
}
