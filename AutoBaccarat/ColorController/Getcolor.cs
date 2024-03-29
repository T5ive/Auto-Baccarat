﻿
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
namespace AutoBaccarat
{
    public class GetColor
    {
        #region DllImport

        [DllImport("user32.dll", EntryPoint = "GetDC")]
        internal static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC")]
        internal static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        internal static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        internal static extern IntPtr DeleteDC(IntPtr hDc);
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        internal static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("gdi32.dll", EntryPoint = "BitBlt")]
        internal static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, int RasterOp);
        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        internal static extern IntPtr DeleteObject(IntPtr hDc);
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowDC(int window);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern uint GetPixel(int dc, int x, int y);
        [DllImport("user32.dll", SetLastError = true)]

        #endregion

        #region Var
        public static extern int ReleaseDC(int window, int dc);
        public static int GanX;
        public static int GanY;
        public static int WinSizeWidth;
        public static int WinSizeHeight;
        public const int MOUSEEVENTF_SRC_COPY = 0x00CC0020;
        public static bool Status;
        public static bool ckStatus;
        public static string ckColor = "";

        #endregion

        public static Color GetColorAt(int hwnd, int x, int y)
        {
            GanX = x;
            GanY = y;
            var dc = GetWindowDC(hwnd);
            var a = (int)GetPixel(dc, x, y);
            ReleaseDC(hwnd, dc);
            return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
        }
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public static Size GetControlSize(IntPtr iHandle) 
        {
            Rect pRect;
            var cSize = new Size();
            GetWindowRect(iHandle, out pRect);
            cSize.Width = pRect.Right - pRect.Left;
            cSize.Height = pRect.Bottom - pRect.Top;
            WinSizeWidth = cSize.Width;
            WinSizeHeight = cSize.Height;
            return cSize;
        } 
        private static bool HexConverter(int PixelColor, int Shade_Variation, IntPtr iHandle)
        {
            GetControlSize(iHandle);
            Status = false;
            var rect = Rectangle.FromLTRB(0, 0, WinSizeWidth, WinSizeHeight);
            var DColor = PixelColor.ToString();
            var PixelColor1 = Convert.ToInt32(DColor);
            var Pixel_Color = Color.FromArgb(PixelColor1);
            var hdcSrc = GetDC(iHandle);
            var hdcDest = CreateCompatibleDC(hdcSrc);
            var hBitmap = CreateCompatibleBitmap(hdcSrc, rect.Width, rect.Height);
            var hOld = SelectObject(hdcDest, hBitmap);
            BitBlt(hdcDest, 0, 0, rect.Width, rect.Height, hdcSrc, rect.X, rect.Y, MOUSEEVENTF_SRC_COPY);
            SelectObject(hdcDest, hOld);
            DeleteDC(hdcDest);
            ReleaseDC(iHandle, hdcSrc);
            var bmp = Image.FromHbitmap(hBitmap);
            var RegionIn_BitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            var Formatted_Color = new int[] { Pixel_Color.B, Pixel_Color.G, Pixel_Color.R };
            unsafe
            {
                var row = (byte*)RegionIn_BitmapData.Scan0 + GanY * RegionIn_BitmapData.Stride;
                if (row[GanX * 3] >= Formatted_Color[0] - Shade_Variation & row[GanX * 3] <= Formatted_Color[0] + Shade_Variation)//b
                {
                    if (row[GanX * 3 + 1] >= Formatted_Color[1] - Shade_Variation & row[GanX * 3 + 1] <= Formatted_Color[1] + Shade_Variation)//g
                    {
                        if (row[GanX * 3 + 2] >= Formatted_Color[2] - Shade_Variation & row[GanX * 3 + 2] <= Formatted_Color[2] + Shade_Variation)// R                           
                        {
                            Status = true;
                        }
                    }
                }
            }
            bmp.UnlockBits(RegionIn_BitmapData);
            DeleteObject(hBitmap);
            bmp.Dispose();
            return Status;
        }
        public static bool GETCOLOR(IntPtr iHandle, int x, int y, int PixelColor, int Shade_Variation)
        {
            return HexConverter(PixelColor, Shade_Variation, iHandle);
        }
        public static string GetColorString(IntPtr iHandle,int x, int y)
        {
            return HexConverterOLD(GetColorAt(iHandle.ToInt32(), x, y));
        }
        public static string GetColorString( int x, int y)
        {
            IntPtr appHandle = GetAppName.appName;
            return HexConverterOLD(GetColorAt(appHandle.ToInt32(), x, y));
        } 
        private static string HexConverterOLD(Color c)
        {
            return $"0x{c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2")}";
        } 
        public static bool GetColorFast(IntPtr iHandle, int x, int y, int PixelColorX, int Shade_Variation) 
        {
            
            var appHandle = iHandle;
            var hexStr = $"{PixelColorX:x}";
            hexStr = hexStr.ToUpper();
            if (hexStr.Length == 5)
            {
                hexStr = "0x0" + hexStr;
            }
            else
            {
                hexStr = "0x" + hexStr;
            }
            if (HexConverterOLD(GetColorAt(appHandle.ToInt32(), x, y)) == hexStr)
            {
              
                ckStatus = true;
                ckColor = HexConverterOLD(GetColorAt(appHandle.ToInt32(), x, y));
            }
            else
            {
                ckStatus = false;
                ckColor = HexConverterOLD(GetColorAt(appHandle.ToInt32(), x, y)) ;
            }
                     return ckStatus;
        }

        public static int StringColor(string color)
        {
            var ColorCut0x = color.Replace("0x", "");
            var intValue = int.Parse(ColorCut0x, System.Globalization.NumberStyles.HexNumber);
            return intValue;
        }

        public static Color Hex2Color(string color)
        {
            var ColorCut0x = color.Replace("0x", "#");
            return ColorTranslator.FromHtml(ColorCut0x);
        }
        public static Color GetColorToBG(string color)
        {
            var myColor = ColorTranslator.FromHtml(color);
            return myColor;
        }
        public static string HexConverter(System.Drawing.Color c)
        {
            return "0x" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static string RGBConverter(System.Drawing.Color c)
        {
            return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        }

        public static bool HexColorCompare(string newHexColor, string oldHexColor, int all)
        {
            var newColor = Hex2Color(newHexColor);
            var oldColor = Hex2Color(oldHexColor);
            if (ColorCompare(newColor, oldColor, all))
            {
                return true;
            }
            return false;
        }
        public static bool HexColorCompare(string newHexColor, string oldHexColor, int colorR, int colorG, int colorB)
        {
            var newColor = Hex2Color(newHexColor);
            var oldColor = Hex2Color(oldHexColor);
            if (ColorCompare(newColor, oldColor, colorR, colorG, colorB))
            {
                return true;
            }
            return false;
        }
        public static bool ColorCompare(Color newColor, Color oldColor, int all)
        {
            if (newColor.R >= oldColor.R - all & newColor.R <= oldColor.R + all &
                newColor.G >= oldColor.G - all & newColor.G <= oldColor.G + all &
                newColor.B >= oldColor.B - all & newColor.B <= oldColor.B + all)
            {
                return true;
            }

            return false;
        }
        public static bool ColorCompare(Color newColor, Color oldColor, int colorR, int colorG, int colorB)
        {
            if (newColor.R >= oldColor.R - colorR & newColor.R <= oldColor.R + colorR &
                newColor.G >= oldColor.G - colorG & newColor.G <= oldColor.G + colorG &
                newColor.B >= oldColor.B - colorB & newColor.B <= oldColor.B + colorB)
            {
                return true;
            }

            return false;
        }

        public static bool ColorCompare(Color newColor, Color oldColor, int colorRMore, int colorRLess, int colorGMore, int colorGLess, int colorBMore,   int colorBLess)
        {
            if (newColor.R >= oldColor.R - colorRMore & newColor.R <= oldColor.R + colorRLess &
                newColor.G >= oldColor.G - colorGMore & newColor.G <= oldColor.G + colorGLess &
                newColor.B >= oldColor.B - colorBMore & newColor.B <= oldColor.B + colorBLess)
            {
                return true;
            }

            return false;
        }

        public enum CompareMode
        {
            Increase,
            Delete
        }
        public static bool ColorCompare(Color newColor, Color oldColor, 
            int colorRMore, int colorRLess, 
            int colorGMore, int colorGLess, 
            int colorBMore, int colorBLess,
            CompareMode typeColorRMore, CompareMode typeColorRLess,
            CompareMode typeColorGMore, CompareMode typeColorGLess,
            CompareMode typeColorBMore, CompareMode typeColorBLess)
        {
            var colorR1 = oldColor.R;
            var colorG1 = oldColor.G;
            var colorB1 = oldColor.B;

            var colorR2 = oldColor.R;
            var colorG2 = oldColor.G;
            var colorB2 = oldColor.B;


            colorR1 = typeColorRMore == CompareMode.Delete ? (byte)(colorR1 - colorRMore) : (byte)(colorR1 + colorRMore);
            colorR2 = typeColorRLess == CompareMode.Delete ? (byte)(colorR2 - colorRLess) : (byte)(colorR2 + colorRLess);

            colorG1 = typeColorGMore == CompareMode.Delete ? (byte)(colorG1 - colorGMore) : (byte)(colorG1 + colorGMore);
            colorG2 = typeColorGLess == CompareMode.Delete ? (byte)(colorG2 - colorGLess) : (byte)(colorG2 + colorGLess);

            colorB1 = typeColorBMore == CompareMode.Delete ? (byte)(colorB1 - colorBMore) : (byte)(colorB1 + colorBMore);
            colorB2 = typeColorBLess == CompareMode.Delete ? (byte)(colorB2 - colorBLess) : (byte)(colorB2 + colorBLess);


            if (newColor.R >= colorR1 & newColor.R <= colorR2 &
                newColor.G >= colorG1 & newColor.G <= colorG2 &
                newColor.B >= colorB1 & newColor.B <= colorB2)
            {
                return true;
            }

            return false;
        }
    }
}

