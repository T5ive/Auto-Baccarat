using System;
using System.Runtime.InteropServices;

namespace AutoBaccarat
{
    public class GetAppName
    {
        [DllImport("User32.dll")] public static extern IntPtr FindWindow(string strClassName, string strWindowName);
        public static string App = "";
        public static string Class = "";
        public static IntPtr appName;

        public void AppName()
        {
            appName = FindWindow(Class, App);
        }
    }
}
