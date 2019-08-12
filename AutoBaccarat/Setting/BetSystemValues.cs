using AutoBaccarat.Properties;

namespace AutoBaccarat
{
   public static class BetSystemValues
    {

        public static BettingMode BettingSelected, EditMode;
        public static string ValuePP, ValueNP, ValueFib;
        public static string BetStopRound, BetStopWin, BetStopLose, BetStopLess, BetStopMore;
        public static void LoadBetSystem()
        {
            BettingSelected = (BettingMode)Settings.Default.BettingSelected;
            BetSystemEditLoadValue();
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
        
    }
}
