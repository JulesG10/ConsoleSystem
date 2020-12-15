using ConsoleSystem.GUI.ConsoleElement.CenterWindows;
using System;
using System.Drawing;

namespace ConsoleSystem.GUI.ClearConsoleElement
{
    class ClearFile : IClearConsoleElementProperties
    {
        public int Height { get; set; }
        public int Width { get; set; }
        private Size size = new Size(20, 15);

        public ClearFile(int w,int h)
        {
            this.Width = w;
            this.Height = h;
        }

        public void Clear()
        {
            FileWindow.Open = false;
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
        }
    }
}
