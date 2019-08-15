

using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoBaccarat.Setting
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    public static class LayoutValues
   {

       public static byte LoadListCount;
       public static string ListName;
       public static LayoutListManager ListMng = new LayoutListManager();
       public static List<LayoutInfo> ListLoad = new List<LayoutInfo>();
       public static List<string> ListValues = new List<string>();
       public static List<string> ListValuesSave = new List<string>();
        public static string PositionStart, PositionPlayer, PositionBanker, PositionTie,
           PositionConP, PositionConB,
           PositionChip1, PositionChip2, PositionChip3, PositionChip4, PositionChip5,
          
           HexColorStart, HexColorPlayer, HexColorBanker, HexColorTie,
           ProcessStart, ProcessPlayer, ProcessBanker, ProcessTie,
           ProcessConP, ProcessConB,
           ProcessChip1, ProcessChip2, ProcessChip3, ProcessChip4, ProcessChip5,
           RgbStart, RgbPlayer, RgbBanker, RgbTie,
           Chip1, Chip2, Chip3, Chip4, Chip5;


        public static void LoadLayout()
       {

           checked
           {
               try
               {
                   ListLoad = ListMng.GetLayoutList();
                   ListMng.LoadValuesFromFile(ListLoad[LoadListCount].File); // Add value to ReadCustomValue
                   ListName = ListLoad[LoadListCount].Name;
                   LoadListValue();
               }
               catch
               {
                   LoadListCount = 0;
                   LoadLayout();
               }
               
           }
           
       }

        public static void LoadListValue()
        {
            try
            {
                var num = ListValues.Count - 1;

                for (var i = 0; i < num; i++)
                {
                    var value = ListValues[i].Split('|');
                    var position = value[0];
                    var chipValue = value[1];
                    var hexColor = value[2];
                    var processName = value[3];
                    var rgbColor = value[4];
                    switch (i)
                    {
                        case 0:
                            PositionStart = position;
                            HexColorStart = hexColor;
                            ProcessStart = processName;
                            RgbStart = rgbColor;
                            break;

                        case 1:
                            PositionPlayer = position;
                            HexColorPlayer = hexColor;
                            ProcessPlayer = processName;
                            RgbPlayer = rgbColor;
                            break;

                        case 2:
                            PositionBanker = position;
                            HexColorBanker = hexColor;
                            ProcessBanker = processName;
                            RgbBanker = rgbColor;
                            break;

                        case 3:
                            PositionTie = position;
                            HexColorTie = hexColor;
                            ProcessTie = processName;
                            RgbTie = rgbColor;
                            break;

                        case 4:
                            PositionConP = position;
                            ProcessConP = processName;
                            break;

                        case 5:
                            PositionConB = position;
                            ProcessConB = processName;
                            break;

                        case 6:
                            PositionChip1 = position;
                            Chip1 = chipValue;
                            ProcessChip1 = processName;
                            break;

                        case 7:
                            PositionChip2 = position;
                            Chip2 = chipValue;
                            ProcessChip2 = processName;
                            break;

                        case 8:
                            PositionChip3 = position;
                            Chip3 = chipValue;
                            ProcessChip3 = processName;
                            break;

                        case 9:
                            PositionChip4 = position;
                            Chip4 = chipValue;
                            ProcessChip4 = processName;
                            break;

                        case 10:
                            PositionChip5 = position;
                            Chip5 = chipValue;
                            ProcessChip5 = processName;
                            break;
                    }
                }



            }
            catch
            {
                
            }
        }

        public static Mode ModeSelected;
        public enum Mode
        {
            Normal,
            Background
        }
    }
}
