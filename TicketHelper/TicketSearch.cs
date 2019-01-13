using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TicketHelper
{
    public class TicketSearch
    {
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        private int left;
        private int right;
        private int top;
        private int bottom;
        private Color grapeColor;
        private decimal numPeople;

        public decimal NumPeople { get => numPeople; set => numPeople = value; }
        public int Left { get => left; set => left = value; }
        public int Right { get => right; set => right = value; }
        public int Top { get => top; set => top = value; }
        public int Bottom { get => bottom; set => bottom = value; }
        public Color GrapeColor { get => grapeColor; set => grapeColor = value; }

        public TicketSearch()
        {

        }

        public TicketSearch(int _left, int _right, int _top, int _bottom)
        {
            left = _left;
            right = _right;
            top = _top;
            bottom = _bottom;
        }


        public Pixel ColorSearch(Color data)
        {
            int width = right - left;
            int height = bottom - top;
            int ScreenWidth = Screen.PrimaryScreen.Bounds.Width - 1;
            int ScreenHeight = Screen.PrimaryScreen.Bounds.Height - 1;

            Bitmap screenBitmap = new Bitmap(ScreenWidth, ScreenHeight, PixelFormat.Format32bppArgb);

            using (Graphics gdest = Graphics.FromImage(screenBitmap))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, width, height, hSrcDC, left, top, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();

                    for (int i = top; i < bottom; i++)
                    {
                        for (int j = left; j < right; j++)
                        {
                            Color c = screenBitmap.GetPixel(j, i);

                            if (c == data)
                            {
                                Pixel foundpixel = new Pixel();
                                foundpixel.x = j;
                                foundpixel.y = i;
                                Console.WriteLine("found pixel = " + j + ", " + i);
                                return foundpixel;
                            }

                        }
                    }
                }
            }
            return null;
        }

    }
}
