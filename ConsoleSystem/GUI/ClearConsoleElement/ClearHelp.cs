using ConsoleSystem.GUI.ConsoleElement.CenterWindows;
using ConsoleSystem.Save;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSystem.GUI.ClearConsoleElement
{
    class ClearHelp : IClearConsoleElementProperties
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public ClearHelp(int w,int h)
        {
            this.Width = w;
            this.Height = h;
        }

        public void Clear()
        {
            int startPos = ((this.Height - 10) / 2);
            int endPos = startPos + 10;
            for (int y = startPos; y < endPos; y++)
            {
                for (int x = (this.Width - 10) / 2; x < (int)((this.Width - 10)); x++)
                {
                    GUI.Draw.DrawPixel(Color.FromArgb(GUI.Draw.Colors[(int)ConsoleColor.Blue]), new Point(x, y));
                }
            }
            GlobalMemroy.RemoveButton(HelpInfoWindow.close);
            HelpInfoWindow.Open = false;
        }
    }
}
