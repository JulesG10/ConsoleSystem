using System;
using ConsoleSystem.GUI.Controls;
using System.Drawing;
using ConsoleSystem.Save;


namespace ConsoleSystem.GUI.ConsoleElement.CenterWindows
{
    class SettingWindow : WindowDesignProperties
    {
        public static bool Open = false;
        public int Height { get; set; }
        public int Width { get; set; }
        public Size size { get; set; } = new Size(20,20);

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

        }
    }
}
