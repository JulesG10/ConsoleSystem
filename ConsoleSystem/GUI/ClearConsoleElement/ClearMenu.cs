using System;
using System.Drawing;
using ConsoleSystem.GUI.ConsoleElement;
using ConsoleSystem.Save;

namespace ConsoleSystem.GUI.ClearConsoleElement
{
    class ClearMenu : IClearConsoleElementProperties
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public ClearMenu(int w,int h)
        {
            this.Height = h;
            this.Width = w;
        }

        public void Clear()
        {
            if(Menu.BatteryThread!=null && Menu.BatteryThread.IsAlive){
                Menu.BatteryThread.Abort();
            }
            if (Menu.TimeThread != null && Menu.TimeThread.IsAlive)
            {
                Menu.TimeThread.Abort();
            }

            if (Menu.help != null)
            {
                GlobalMemroy.RemoveButton(Menu.help);
            }
            int startPosTop = this.Height - (Menu.MENU_HEIGHT);
            for (int y = startPosTop; y < this.Height - (BottomBar.MENU_HEIGHT + 1); y++)
            {
                for (int x = 0; x < Menu.MENU_WIDTH; x++)
                {
                    Draw.DrawPixel(Color.FromArgb(GUI.Draw.Colors[(int)ConsoleColor.Blue]),new Point(x, y));
                }
            }
        }
    }
}
