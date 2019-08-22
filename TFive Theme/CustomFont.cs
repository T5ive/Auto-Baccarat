using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace King99_Theme
{
   public static class CustomFont
   {
        public static PrivateFontCollection MyFont = new PrivateFontCollection();
        public static Font NewFont;

        public static void LoadCustomFont()
        {
            var startupPath = Application.StartupPath;
            var name = startupPath + "\\Fonts\\Kanit-Regular.ttf";
            MyFont.AddFontFile(name);
            NewFont = new Font(MyFont.Families[0], 11);
        }
        public static Font GetCustomFont(int size)
        {
            return new Font(MyFont.Families[0], size);
        }
        //public static Font CustomFontSize11()
        //{
        //    //var startupPath = Application.StartupPath;
        //    //var name = startupPath + "\\Fonts\\Kanit-Regular.ttf";
        //    //var modernFont = new PrivateFontCollection();
        //    //modernFont.AddFontFile(name);
        //    //return new Font(modernFont.Families[0], 11);

        //    return new Font(MyFont.Families[0], 11);
        //}
        //public static Font LoadCustomFont(string name, int size)
        //{
        //    var startupPath = Application.StartupPath;
        //    name = startupPath + "\\Fonts\\" + name;
        //    var modernFont = new PrivateFontCollection();
        //    modernFont.AddFontFile(name);
        //    return new Font(modernFont.Families[0], size);
        //}
    }
}
