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
            stringLoader.RunTime = LclzManager.TranslateMessage("RunTime", "Operating Time:");
            stringLoader.Round = LclzManager.TranslateMessage("Round", "Round:");
            stringLoader.Win = LclzManager.TranslateMessage("Win", "Win:");
            stringLoader.Lose = LclzManager.TranslateMessage("Lose", "Lose:");
            stringLoader.MaxConWin = LclzManager.TranslateMessage("MaxConWin", "Maximum Continuous Win:");
            stringLoader.MaxConLose = LclzManager.TranslateMessage("MaxConLose", "Maximum Continuous Lose:");
            stringLoader.WinLose = LclzManager.TranslateMessage("WinLose", "Win/Lose:");

            stringLoader.MaxProfit = LclzManager.TranslateMessage("MaxProfit", "Maximum Profit:");
            stringLoader.Balance = LclzManager.TranslateMessage("Balance", "Balance:");
            stringLoader.Amount = LclzManager.TranslateMessage("Amount", "Bet Amount:");
            stringLoader.Stake = LclzManager.TranslateMessage("Stake", "Stake/Unit:");
            stringLoader.Unit = LclzManager.TranslateMessage("Unit", "Bet Unit:");
            stringLoader.Bettings = LclzManager.TranslateMessage("Bettings", "Betting:");

            stringLoader.Warning = LclzManager.TranslateMessage("Warning", "WARNING!");

            stringLoader.WantClear = LclzManager.TranslateMessage("WantClear", "Do you want to clear?");
            stringLoader.Line = LclzManager.TranslateMessage("Line", "Line");
            stringLoader.Ready = LclzManager.TranslateMessage("Ready", "Ready");
            stringLoader.Wait = LclzManager.TranslateMessage("Wait", "Wait Result");
            stringLoader.Save = LclzManager.TranslateMessage("Save", "Saving");

            stringLoader.Confirmation = LclzManager.TranslateMessage("Confirmation", "Confirmation");
            stringLoader.Modified = LclzManager.TranslateMessage("Modified", "was modified, do you want to save it now?");
            stringLoader.Error = LclzManager.TranslateMessage("Error", "Error!");
            stringLoader.NotFound = LclzManager.TranslateMessage("NotFound", "not found!");
            stringLoader.Delete = LclzManager.TranslateMessage("Delete", "Confirm to delete");
            stringLoader.InputChip = LclzManager.TranslateMessage("InputChip", "Please Input A Chip Value");
            stringLoader.InputChipNull = LclzManager.TranslateMessage("InputChipNull", "Value is Null, Empty or White space");

            stringLoader.SetBetUnit = LclzManager.TranslateMessage("SetBetUnit", "Setting Betting Unit!!");
            stringLoader.Total = LclzManager.TranslateMessage("Total", "Total");
            stringLoader.TryAgain = LclzManager.TranslateMessage("TryAgain", "Try Again");

            stringLoader.PP = LclzManager.TranslateMessage("PP", "Positive Progression");
            stringLoader.NP = LclzManager.TranslateMessage("NP", "Negative Progression");
            stringLoader.Fib = LclzManager.TranslateMessage("Fib", "Fibonacci");
            stringLoader.DetailPp1 = LclzManager.TranslateMessage("DetailPp1", "- Increase stakes next step when you win");
            stringLoader.DetailPp2 = LclzManager.TranslateMessage("DetailPp2", "- Return to first stakes when you lose");

            stringLoader.DetailNp1 = LclzManager.TranslateMessage("DetailNp1", "- Increase stakes next step when you lose");
            stringLoader.DetailNp2 = LclzManager.TranslateMessage("DetailNp2", "- Return to first stakes when you win");

            stringLoader.DetailFib1 = LclzManager.TranslateMessage("DetailFib1", "- Increase stakes next step when you lose");
            stringLoader.DetailFib2 = LclzManager.TranslateMessage("DetailFib2", "- Decrease 2 step for stakes when you win");

            stringLoader.Start = LclzManager.TranslateMessage("Start", "Start");
            stringLoader.Stop = LclzManager.TranslateMessage("Stop", "Stop");

            stringLoader.Fixed = LclzManager.TranslateMessage("Fixed", "Setting Fixed Type!!");
            stringLoader.DetailFixed = LclzManager.TranslateMessage("DetailFixed", "- Fixed bets and loops");
        }

        
        public static List<double> Balance = new List<double>();
        //public static List<double> MoneyCost = new List<double>();

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
