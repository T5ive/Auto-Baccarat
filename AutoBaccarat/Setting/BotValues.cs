using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace AutoBaccarat
{
    [Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    public static class BotValues
    {
        public static void InitLocalization()
        {
            LclzManager = new LocalizationManager();
        }

        public static LocalizationManager LclzManager;
        public static void LoadLanguage(Form form)
        {
            LclzManager.LocalizeForm(form);
        }
        public static void LocalizeSpecialCases()
        {
            //stringLoader.RunTime = LclzManager.TranslateMessage("RunTime", "Operating Time:");
            //stringLoader.Round = LclzManager.TranslateMessage("Round", "Round:");
            //stringLoader.Win = LclzManager.TranslateMessage("Win", "Win:");
            //stringLoader.Lose = LclzManager.TranslateMessage("Lose", "Lose:");
            //stringLoader.MaxConWin = LclzManager.TranslateMessage("MaxConWin", "Maximum Continuous Win:");
            //stringLoader.MaxConLose = LclzManager.TranslateMessage("MaxConLose", "Maximum Continuous Lose:");
            //stringLoader.WinLose = LclzManager.TranslateMessage("WinLose", "Win/Lose:");

            //stringLoader.MaxProfit = LclzManager.TranslateMessage("MaxProfit", "Maximum Profit:");
            //stringLoader.Balance = LclzManager.TranslateMessage("Balance", "Balance:");
            //stringLoader.Amount = LclzManager.TranslateMessage("Amount", "Bet Amount:");
            //stringLoader.Stake = LclzManager.TranslateMessage("Stake", "Stake/Unit:");
            //stringLoader.Unit = LclzManager.TranslateMessage("Unit", "Bet Unit:");
            //stringLoader.Bettings = LclzManager.TranslateMessage("Bettings", "Betting:");

            StringLoader.Warning = LclzManager.TranslateMessage("Warning", "WARNING!");

            StringLoader.WantClear = LclzManager.TranslateMessage("WantClear", "Do you want to clear?");
            StringLoader.Line = LclzManager.TranslateMessage("Line", "Line");
            StringLoader.Ready = LclzManager.TranslateMessage("Ready", "Ready");
            StringLoader.Betting = LclzManager.TranslateMessage("Betting", "Betting");
            StringLoader.Wait = LclzManager.TranslateMessage("Wait", "Wait Result");
            StringLoader.Save = LclzManager.TranslateMessage("Save", "Saving");

            StringLoader.Confirmation = LclzManager.TranslateMessage("Confirmation", "Confirmation");
            StringLoader.Modified = LclzManager.TranslateMessage("Modified", "was modified, do you want to save it now?");
            StringLoader.Error = LclzManager.TranslateMessage("Error", "Error!");
            StringLoader.NotFound = LclzManager.TranslateMessage("NotFound", "not found!");
            StringLoader.Delete = LclzManager.TranslateMessage("Delete", "Confirm to delete");
            StringLoader.InputChip = LclzManager.TranslateMessage("InputChip", "Please Input A Chip Value");
            StringLoader.InputChipNull = LclzManager.TranslateMessage("InputChipNull", "Value is Null, Empty or White space");

            StringLoader.SetBetUnit = LclzManager.TranslateMessage("SetBetUnit", "Setting Betting Unit!!");
            StringLoader.Total = LclzManager.TranslateMessage("Total", "Total");
            StringLoader.TryAgain = LclzManager.TranslateMessage("TryAgain", "Try Again");

            StringLoader.PP = LclzManager.TranslateMessage("PP", "Positive Progression");
            StringLoader.NP = LclzManager.TranslateMessage("NP", "Negative Progression");
            StringLoader.Fib = LclzManager.TranslateMessage("Fib", "Fibonacci");
            StringLoader.DetailPp1 = LclzManager.TranslateMessage("DetailPp1", "- Increase stakes next step when you win");
            StringLoader.DetailPp2 = LclzManager.TranslateMessage("DetailPp2", "- Return to first stakes when you lose");

            StringLoader.DetailNp1 = LclzManager.TranslateMessage("DetailNp1", "- Increase stakes next step when you lose");
            StringLoader.DetailNp2 = LclzManager.TranslateMessage("DetailNp2", "- Return to first stakes when you win");

            StringLoader.DetailFib1 = LclzManager.TranslateMessage("DetailFib1", "- Increase stakes next step when you lose");
            StringLoader.DetailFib2 = LclzManager.TranslateMessage("DetailFib2", "- Decrease 2 step for stakes when you win");

            StringLoader.Start = LclzManager.TranslateMessage("Start", "Start");
            StringLoader.Stop = LclzManager.TranslateMessage("Stop", "Stop");

            StringLoader.FixedError = LclzManager.TranslateMessage("Fixed", "Setting Fixed Type!!");
            StringLoader.DetailFixed = LclzManager.TranslateMessage("DetailFixed", "- Fixed bets and loops");

            StringLoader.NormalMode = LclzManager.TranslateMessage("NormalMode", "Normal");
            StringLoader.BackgroundMode = LclzManager.TranslateMessage("BackgroundMode", "Background");
            
            StringLoader.Follow = LclzManager.TranslateMessage("Follow", "Follow");
            StringLoader.AI = LclzManager.TranslateMessage("AI", "Ai");
            StringLoader.Lock = LclzManager.TranslateMessage("Lock", "Lock");
            StringLoader.GoodLineFix = LclzManager.TranslateMessage("GoodLineFix", "Good Line Fix");
            StringLoader.GoodLineRandom = LclzManager.TranslateMessage("GoodLineRandom", "Good Line Random");
            StringLoader.GoodLine = LclzManager.TranslateMessage("GoodLine", "Good Line");
            StringLoader.Fixed = LclzManager.TranslateMessage("Fixed", "Fixed");
            StringLoader.Custom = LclzManager.TranslateMessage("Custom", "Custom");
            StringLoader.Random = LclzManager.TranslateMessage("Random", "Random");
        }

        
        public static List<double> Balance = new List<double>();
        public static List<double> MoneyCost = new List<double>();

        public static List<int> ChipLast = new List<int>();

        public static List<List<short>> BigRoad = new List<List<short>>();
        //public static List<short> BackUpResult = new List<short>();
        public static List<short> BettingSuggest = new List<short>();
        public static List<short> LastHighResult = new List<short>();
        public static List<short> Result = new List<short>();
        public static List<short> ScorePbt = new List<short>();
        public static List<short> Step = new List<short>();
        public static List<short> Unit = new List<short>();

        //public static List<string> BackUpTime = new List<string>();
        //public static List<string> BetSystem = new List<string>();
        //public static List<string> Formula = new List<string>();

        //public static List<string> ListTime = new List<string>();
        public static List<string> WinLose = new List<string>();
        public static short LastStep;
        public static double MaxProfit, LastMoneyBalance;
        public static string Summary;
        public static int GoodLineValue1,
            GoodLineValue2,
            GoodLineValue3,
            GoodLineValue4,
            GoodLineValue5,
            GoodLineValue6,
            GoodLineValueSum,
            MaxContinuousWin,
            MaxContinuousLose,
            TotalWin,
            TotalLose;
    }
}
