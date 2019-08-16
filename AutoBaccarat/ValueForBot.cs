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

        public static Point PositionStart, PositionPlayer, PositionBanker,PositionTie, PositionChip1, PositionChip2, PositionChip3, PositionChip4, PositionChip5, PositionConfirmPlayer, PositionConfirmBanker;
        public static Color ColorStart, ColorPlayer, ColorBanker, ColorTie, NewColorStart, NewColorPlayer, NewColorBanker,NewColorTie;
    }
}
