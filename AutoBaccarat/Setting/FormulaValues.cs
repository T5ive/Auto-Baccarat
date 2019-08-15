using System.Collections.Generic;
using System.Reflection;
using AutoBaccarat.Properties;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    public static class FormulaValues
    {
        public static FormulaMode FormulaSelected;
        public static byte GoodLineFix, Lock, Follow, ForceValue, LoadListCount;
        public static ForceType ForceSelected;
        public static string ReadCustomValue, ListName, Fixed;
        public static List<string> ValueNumber = new List<string>();
        public static List<string> ValueType = new List<string>();

        public static void LoadFormula()
        {
            FormulaSelected = (FormulaMode)Settings.Default.FormulaSelected;
            GoodLineFix = Settings.Default.FormulaGoodLineFix;
            Lock = Settings.Default.FormulaLock;
            Follow = Settings.Default.FormulaFollow;
            LoadListCount = Settings.Default.LoadCustomListCount;
            LoadFixed();
            LoadCustom();
        }

        public static CustomListManager ListMng = new CustomListManager();
        public static List<CustomInfo> ListLoad = new List<CustomInfo>();

        public static void LoadFixed()
        {
            Fixed = Settings.Default.Fixed;
        }
        public static void LoadCustom()
        {
            checked
            {
                try
                {
                    ListLoad = ListMng.GetCustomList();
                    ListMng.LoadValuesFromFile(ListLoad[LoadListCount].File); // Add value to ReadCustomValue
                    ListName = ListLoad[LoadListCount].Name;
                    StringSplit2Array();
                }
                catch
                {
                    LoadListCount = 0;
                    LoadCustom();
                }
               
            }
            
        }
        public static void StringSplit2Array()
        {
            checked
            {
                try
                {
                    ValueNumber.Clear();
                    ValueType.Clear();
                    var array = ReadCustomValue.Split('|');
                    var num = array.Length - 1;
                    for (var i = 0; i <= num; i++)
                    {
                        var array2 = array[i].Split('=');
                        ValueNumber.Add(array2[0]);
                        ValueType.Add(array2[1]);
                    }
                }
                catch
                {
                    ValueNumber.Clear();
                    ValueType.Clear();
                    ReadCustomValue = DefaultValue();
                    var array3 = ReadCustomValue.Split('|');
                    var num2 = array3.Length - 1;
                    for (var j = 0; j <= num2; j++)
                    {
                        var array4 = array3[j].Split('=');
                        ValueNumber.Add(array4[0]);
                        ValueType.Add(array4[1]);
                    }
                }
            }
        }
        public enum FormulaMode
        {
            Custom,
            GoodLine,
            GoodLineFix,
            GoodLineRandom,
            Lock,
            Follow,
            AI,
            Random,
            Fixed
        }
        public enum ForceType
        {
            Follow,
            Adverse
        }
        
        public static string DefaultValue()
        {
            return "1,1=X|1,2,1,2=X|2,2=X|3,3=X|4,4=X|1,2,3=X|1,3,2,1=X|5=O|6=O|7=O|8=O|9=O|10=O|11=O|12=O|13=O|14=O|15=O|16=O|17=O|18=O|19=O|20=O";
        }
    }
}
