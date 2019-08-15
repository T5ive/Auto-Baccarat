using System.Reflection;
using AutoBaccarat.Properties;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    public static class BetSystemValues
    {

        public static BettingMode BettingSelected, EditMode;
        public static string ValuePP, ValueNP, ValueFib;
        public static string BetStopRound, BetStopWin, BetStopLose, BetStopLess, BetStopMore;
        public static byte ChipSelected;
        public static int ChipValue;
        public static void LoadBetSystem()
        {
            BettingSelected = (BettingMode)Settings.Default.BettingSelected;
            BetSystemEditLoadValue();
            ChipLoadValue();
        }

        public enum BettingMode
        {
            PP,
            NP,
            PPNP,

            Fibonacci,

            AI,
            OneShot,
            X2
        }
       
        public static void BetSystemEditLoadValue()
        {
            ValuePP = Settings.Default.ValuePP;
            ValueNP = Settings.Default.ValueNP;
            ValueFib = Settings.Default.ValueFib;
        }

        public static void ChipLoadValue()
        {
            BetStopRound = Settings.Default.BetStopRound;
            BetStopWin = Settings.Default.BetStopWin;
            BetStopLose = Settings.Default.BetStopLose;
            BetStopLess = Settings.Default.BetStopLess;
            BetStopMore = Settings.Default.BetStopMore;
            ChipSelected = Settings.Default.ChipSelected;
        }
        
    }
}
