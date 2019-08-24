using System;
using System.Windows.Forms;

namespace AutoBaccarat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // King99_Theme.CustomFont.LoadCustomFont();
            Application.Run(new FrmBot());
        }
    }
}
