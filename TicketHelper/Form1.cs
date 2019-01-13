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

    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        private delegate void OnControlChange();

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        private Thread th;
        private static System.Timers.Timer aTimer;
        delegate void SetColorCallback(Color color);
        private bool isColorPickerMode = false;
        private int CompleteX;
        private int CompleteY;
        private int topLeftX = 0;
        private int topLeftY = 0;
        private int bottomRightX = Screen.PrimaryScreen.Bounds.Width;
        private int bottomRightY = Screen.PrimaryScreen.Bounds.Height;
        private Color seatColor;
        private Pixel FoundPixel;
        private int numGrape = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MouseHook.Start();
            th = new Thread(new ThreadStart(ThreadRun));
            th.Start();
        }

        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            th.Abort();
            MouseHook.stop();
        }

        private void timerFunction(object sender, System.Timers.ElapsedEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = tb_address.Text;
            get_http(url);
         
        }

        private void lb_showtime_Click(object sender, EventArgs e)
        {

        }

        private void get_ServerTime(string url)
        {
            System.Net.HttpWebRequest wReqFirst = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

            //요청 보내기 전 시간
            DateTime dtBefore = DateTime.Now;

            System.Net.HttpWebResponse wRespFirst = (System.Net.HttpWebResponse)wReqFirst.GetResponse();

            //요청 받은 후의 시간
            DateTime dtAfter = DateTime.Now;

            DateTime dtNosp = Convert.ToDateTime(wRespFirst.Headers["Date"].ToString());

            //요청에 걸린 시간을 계산하여 서버 시간을 보정해 준다. 그래봤자 최대 오차 999ms이지만...
            dtNosp = dtNosp.AddTicks(dtAfter.Ticks - dtBefore.Ticks);
        }

        private void get_http(string url)
        {
            // POST, GET 보낼 데이터 입력
            StringBuilder dataParams = new StringBuilder();
            dataParams.Append("client_id=#############################################");
            dataParams.Append("&client_secret=####################################");
            dataParams.Append("&refresh_token=####################################");
            dataParams.Append("&grant_type=refresh_token");

            // 요청 String -> 요청 Byte 변환
            byte[] byteDataParams = UTF8Encoding.UTF8.GetBytes(dataParams.ToString());

            /////////////////////////////////////////////////////////////////////////////////////
            /* POST */
            // HttpWebRequest 객체 생성, 설정
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";    // 기본값 "GET"
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteDataParams.Length;

            /* GET */
            // GET 방식은 Uri 뒤에 보낼 데이터를 입력하시면 됩니다.
            /*
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?" + dataParams);
            request.Method = "GET";
            */
            //////////////////////////////////////////////////////////////////////////////////////


            // 요청 Byte -> 요청 Stream 변환
            Stream stDataParams = request.GetRequestStream();
            stDataParams.Write(byteDataParams, 0, byteDataParams.Length);
            stDataParams.Close();

            // 요청, 응답 받기
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // 응답 Stream 읽기
            Stream stReadData = response.GetResponseStream();
            StreamReader srReadData = new StreamReader(stReadData, Encoding.Default);

            // 응답 Stream -> 응답 String 변환
            string strResult = srReadData.ReadToEnd();

            Console.WriteLine(strResult);
            Console.ReadLine();
            lb_showtime.Text = strResult;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lb_showtime.Text = DateTime.Now.ToLongTimeString();
        }



        private static Bitmap GetScreenShot()
        {
            Bitmap result = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            {
                using (Graphics gfx = Graphics.FromImage(result))
                {
                    gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                }
            }
            return result;
        }
        private static Point[] FindColor(Color color)
        {
            int searchValue = color.ToArgb();
            List<Point> result = new List<Point>();
            using (Bitmap bmp = GetScreenShot())
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        if (searchValue.Equals(bmp.GetPixel(x, y).ToArgb()))
                            result.Add(new Point(x, y));
                    }
                }
            }
            return result.ToArray();
        }



        private void ThreadRun()
        {
            while (true)
            {
                OnControlChange onControlChange = null;
                onControlChange = new OnControlChange(setMousePositionText);
                this.Invoke(onControlChange);

            }

        }

        private void setMousePositionText()
        {
            mouse_x.Text = Cursor.Position.X.ToString();
            mouse_y.Text = Cursor.Position.Y.ToString();
        }

        private string getColor(int x, int y)
        {
            string buf = "";
            
            buf = "X 좌표 : " + Control.MousePosition.X.ToString() + "\r\n";
            buf += "Y 좌표 : " + Control.MousePosition.Y.ToString() + "\r\n";

            seatColor = ScreenColor(Control.MousePosition.X, Control.MousePosition.Y);

            buf += "R : " + seatColor.R.ToString() + "\r\n";
            buf += "G : " + seatColor.G.ToString() + "\r\n";
            buf += "B : " + seatColor.B.ToString() + "\r\n";
            buf += "Code : " + ToHexString(seatColor.R).Substring(0, 2) + ToHexString(seatColor.G).Substring(0, 2) + ToHexString(seatColor.B).Substring(0, 2);
            SetColor(seatColor);
            return buf;
        }

        public string ToHexString(int nor)
        {
            byte[] bytes = BitConverter.GetBytes(nor);
            string hexString = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                hexString += bytes[i].ToString("X2");
            }
            return hexString;
        }

        private Color ScreenColor(int x, int y)
        {
            Size sz = new Size(1, 1);
            Bitmap bmp = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(x, y, 0, 0, sz);
            return bmp.GetPixel(0, 0);
        }

        private void SetColor(Color color)
        {
            if (this.panel1.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SetColor);
                try
                {
                    this.Invoke(d, new object[] { color });
                }
                catch { }
            }
            else
            {
                this.panel1.BackColor = color;
            }
        }


        private void ClickMouse()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0,0,0,0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public Pixel[] PixelSearch(int left, int top, int right, int bottom, Color data)
        {
            int width = right - left;
            int height = bottom - top;
            Bitmap screenBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            Pixel[] foundGrapes = new Pixel[4];
            for (int i = 0; i < 4; i++)
            {
                foundGrapes[i] = new Pixel();
            }

            int grapeIndex = 0;
            int grapeWidth = 1;
            bool foundWidth = false;
            int gapWidth = 1;
            
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
                        if (foundWidth)
                            break;

                        for (int j = left; j < right; j++)
                        {
                            if (foundWidth)
                                break;

                            Color c = screenBitmap.GetPixel(j, i);
                             
                            if (c == data)
                            {

                                if (grapeWidth == 1) // grape 길이 계산
                                {
                                    while (screenBitmap.GetPixel(j, i) == data)
                                    {
                                        j++;
                                        grapeWidth++;
                                    }
                                    
                                }
                                Color gapColor = screenBitmap.GetPixel(j + 1, i);
                                if (gapWidth == 1)    //사이 길이 계산
                                {
                                    
                                    while (j < right && screenBitmap.GetPixel(j, i) == gapColor)
                                    {
                                        j++;
                                        gapWidth++;
                                    }
                                }

                                if (grapeWidth > 1 && gapWidth > 1)
                                {
                                    foundWidth = true;
                                }
                            }                               
                        }
                    }
                    int grape_i = 0;

                    Console.WriteLine("grape width = " + grapeWidth + " gap width = " + gapWidth);
                    for (int i = top; i < bottom; i++)
                    {
                        for (int j = left; j < right; j++)
                        {
                            
                            for (grape_i = 0; grape_i < numGrape; grape_i++)
                            {
                                Color c = screenBitmap.GetPixel(j + grape_i * (grapeWidth + gapWidth), i);
                                if (c != data)
                                    break;

                            }
                            
                            if(grape_i == numGrape)
                            {
                                for (grape_i = 0; grape_i < numGrape; grape_i++)
                                {
                                    foundGrapes[grape_i].x = j + grape_i * (grapeWidth + gapWidth) + left;
                                    foundGrapes[grape_i].y = i + top;
                                    Console.WriteLine("Grape x = " + foundGrapes[grape_i].x + "y = " + foundGrapes[grape_i].y);
                                }
                                return foundGrapes;
                            }

                        }
                    }
                }
            }
            return null;
        }

        private void GrapeEvent(object sender, EventArgs e)
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            //Console.WriteLine("X = " + x.ToString() + " Y = " + y.ToString());
            string color = getColor(x, y);
            Console.WriteLine("Grape color = " + color);
            MouseHook.MouseAction -= GrapeEvent;
        }


        private void SaveCmplBtnEvent(object sender, EventArgs e)
        {
            CompleteX = Cursor.Position.X;
            CompleteY = Cursor.Position.Y;
            label_compX.Text = CompleteX.ToString();
            label_compY.Text = CompleteY.ToString();
            MouseHook.MouseAction -= SaveCmplBtnEvent;
        }

        private void SaveTopLeftPosEvent(object sender, EventArgs e)
        {
            topLeftX = Cursor.Position.X;
            topLeftY = Cursor.Position.Y;

            MouseHook.MouseAction -= SaveTopLeftPosEvent;
        }

        private void SaveBottomRightPosEvent(object sender, EventArgs e)
        {
            bottomRightX = Cursor.Position.X;
            bottomRightY = Cursor.Position.Y;

            MouseHook.MouseAction -= SaveBottomRightPosEvent;
        }

        private void GrapeNumSelect_ValueChanged(object sender, EventArgs e)
        {
            numGrape = Int32.Parse(GrapeNumSelect.Text) + 1;
            Console.WriteLine("numGrape changed = " + numGrape);
        }

        private void btnGetColor_click(object sender, EventArgs e)
        {

            MouseHook.MouseAction += new EventHandler(GrapeEvent);
            MessageBox.Show("포도알을 클릭하세요");
            isColorPickerMode = true;
            //System.Diagnostics.Debugger.Break();
        }


        private void btnSaveCmplBtn_Click(object sender, EventArgs e)
        {
            MouseHook.MouseAction += new EventHandler(SaveCmplBtnEvent);
            MessageBox.Show("확인버튼 위치를 클릭하세요");
        }

        private void btnStartSearch_Click(object sender, EventArgs e)
        {
            MouseHook.MouseAction += new EventHandler(SaveTopLeftPosEvent);
            MessageBox.Show("왼쪽위 모서리버튼 위치를 클릭하세요");
        }

        private void btnEndSearch_Click(object sender, EventArgs e)
        {
            MouseHook.MouseAction += new EventHandler(SaveBottomRightPosEvent);
            MessageBox.Show("오른쪽아래 모서리버튼 위치를 클릭하세요");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;

            
            Pixel[] foundPixels = new Pixel[4];

            foundPixels = PixelSearch(topLeftX, topLeftY, bottomRightX, bottomRightY, seatColor);
            if (foundPixels == null)
            {
                MessageBox.Show("좌석을 찾을수 없습니다.");
            }
            else
            {
                for (int i = 0; i < numGrape; i++)
                {
                    Cursor.Position = new Point(foundPixels[i].x + 3, foundPixels[i].y + 3);
                    ClickMouse();
                    
                }
                Cursor.Position = new Point(CompleteX + 3, CompleteY + 3);
                ClickMouse();
            }
        }


    }


    public class Pixel
    {
        public int x;
        public int y;
    }
}

