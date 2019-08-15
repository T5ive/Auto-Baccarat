using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBaccarat
{
     public class ValueForBot
    {
        public static string Formula, Betting, StopRound, StopWin, StopLose, StopLess, StopMore, LayoutList, ValuePP, ValueNP, ValueFib, Fixed;
        public static byte GoodLineFix, Lock, Follow, Mode;
        public static int Chip;
        public static short ForceValue, ForceType;

        public static List<string> CustomValueType = new List<string>();
        public static List<string> CustomValueNumber = new List<string>();

        public static Point Start, Player, Banker,Tie, Chip1, Chip2, Chip3, Chip4, Chip5, ConfirmPlayer, ConfirmBanker;
        public static Color ColorStart, ColorPlayer, ColorBanker, ColorTie,NewColorStart, NewColorPlayer, NewColorBanker,NewColorTie;
    }
}
