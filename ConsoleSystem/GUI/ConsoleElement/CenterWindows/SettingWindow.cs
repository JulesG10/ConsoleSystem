using System;
using ConsoleSystem.GUI.Controls;
using System.Drawing;
using ConsoleSystem.Utils;
using System.Drawing.Imaging;
using System.Diagnostics;
using ConsoleSystem.Save;

namespace ConsoleSystem.GUI.ConsoleElement.CenterWindows
{
    class SettingWindow : WindowDesignProperties
    {
        public static bool Open = false;
        private Image imageDisplay;

        public int Height { get; set; }
        public int Width { get; set; }
        public Size size { get; set; } = new Size(20,10);
        public static Button takeScreenShot;
        public static Button invertColor;
        public static Button close;

        public SettingWindow(int w,int h)
        {
            this.Width = w;
            this.Height = h;
        }

        public void Close()
        {
            int startPos = ((this.Height - this.size.Height) / 2);
            int endPos = startPos + this.size.Height;
            int wPos = (this.Width - this.size.Width) / 2;

            for (int y = startPos; y < endPos; y++)
            {
                for (int x = wPos; x < (int)((this.Width - this.size.Width)); x++)
                {

                    GUI.Draw.DrawPixel(Color.FromArgb(GUI.Draw.Colors[(int)ConsoleColor.Blue]), new Point(x, y));
                }
            }
            GlobalMemroy.RemoveButton(SettingWindow.close);
            GlobalMemroy.RemoveButton(SettingWindow.invertColor);
            GlobalMemroy.RemoveButton(SettingWindow.takeScreenShot);
            Open = false;
        }

        public void CreateWindow()
        {
            BottomBar.ClearAllWindow();
            Open = true;
            int startPos = ((this.Height - this.size.Height) / 2);
            int endPos = startPos + this.size.Height;
            for (int y = startPos; y < endPos; y++)
            {
                
                for (int x = (this.Width - this.size.Width) / 2; x < (int)((this.Width - this.size.Width)); x++)
                {
                    GUI.Draw.DrawPixel(Color.FromArgb(GUI.Draw.Colors[(int)ConsoleColor.Gray]), new Point(x, y));
                }
            }
            int xw = (this.Width - this.size.Width) / 2;
            takeScreenShot = new Button("[o]");
            invertColor = new Button("[o]");
            close = new Button("[x]");

            this.CreateLine("Take screen shoot: ", takeScreenShot, new Point(xw+1,startPos+1));
            this.CreateLine("Invert colors: ", invertColor, new Point(xw + 1, startPos + 2));
            this.CreateInfoLine("Version: 0.3.1v", new Point(xw + 1, startPos + 4));
            this.CreateInfoLine($"Username:{Environment.UserName}", new Point(xw + 1, startPos + 4));
            this.CreateLine("", close, new Point(xw + 1, startPos + 5));

            close.ButtonActive += Close_ButtonActive;
            takeScreenShot.ButtonActive += TakeScreenShot_ButtonActive;
            invertColor.ButtonActive += InvertColor_ButtonActive;
        }

        private void Close_ButtonActive(object sender, Events.ButtonActiveEventArgs e)
        {
            this.Close();
        }

        private void InvertColor_ButtonActive(object sender, Events.ButtonActiveEventArgs e)
        {
            Array.Reverse(Draw.Colors);
        }

        private void TakeScreenShot_ButtonActive(object sender, Events.ButtonActiveEventArgs e)
        {
            ScreenCapture sc = new ScreenCapture();
            Image img = sc.CaptureScreen();
            this.imageDisplay = img;
            try
            {
                sc.CaptureWindowToFile(Process.GetCurrentProcess().MainWindowHandle, System.IO.Path.Combine(File.Captures.GetCaptureDir(), DateTime.Now.ToString("d-MM-yyyy")+".png"), ImageFormat.Png);

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = System.IO.Path.Combine(File.Captures.GetCaptureDir(), DateTime.Now.ToString("d-MM-yyyy") + ".png"),
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);

            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message, null, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public void CreateLine(string textInfo,Button btn,Point pos)
        {
            Label info = new Label(textInfo, ConsoleColor.Gray);
            info.Create(pos.X, pos.Y);
            btn.Create(pos.X + textInfo.Length, pos.Y);
        }

        public void CreateInfoLine(string textInfo, Point pos)
        {
            Label info = new Label(textInfo, ConsoleColor.Gray);
            info.Create(pos.X, pos.Y);
        }
    }
}
