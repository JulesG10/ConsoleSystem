using System;
using ConsoleSystem.Save;
using System.Drawing;
using ConsoleSystem.GUI.ConsoleElement.CenterWindows;

namespace ConsoleSystem.GUI.ClearConsoleElement
{
    class ClearSettings : IClearConsoleElementProperties
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public ClearSettings(int w,int h)
        {
            this.Height = h;
            this.Width = w;
        }

        public void Clear()
        {
            int startPos = ((this.Height - 20) / 2);
            int endPos = startPos + 20;
            int wPos = (this.Width - 20) / 2;

            for (int y = startPos; y < endPos; y++)
            {
                for (int x = wPos; x < (int)((this.Width - 20)); x++)
                {

                    GUI.Draw.DrawPixel(Color.FromArgb(GUI.Draw.Colors[(int)ConsoleColor.Blue]), new Point(x, y));
                }
            }
            GlobalMemroy.RemoveButton(SettingWindow.close);
            GlobalMemroy.RemoveButton(SettingWindow.invertColor);
            GlobalMemroy.RemoveButton(SettingWindow.takeScreenShot);
        }
    }
}
