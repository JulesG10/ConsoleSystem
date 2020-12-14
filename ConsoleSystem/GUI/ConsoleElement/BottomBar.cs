using System;
using System.Drawing;
using ConsoleSystem.GUI.Controls;
using ConsoleSystem.GUI.ClearConsoleElement;

namespace ConsoleSystem.GUI.ConsoleElement
{
    class BottomBar : IConsoleElementProperties
    {
        public BottomBar(int w, int h)
        {
            this.Height = h;
            this.Width = w;
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public static bool Menu_Open = false;
        public static readonly int MENU_HEIGHT = 2;
        private readonly Color MENU_COLOR = Color.FromArgb(GUI.Draw.Colors[(int)ConsoleColor.Gray]);

        public void Draw()
        {
            int startPosTop = this.Height - MENU_HEIGHT;
            for (int y = startPosTop; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    GUI.Draw.DrawPixel(this.MENU_COLOR, new Point(x, y));
                }
            }
            Button menu = new Button("Home");
            menu.Create(10, startPosTop - (int)MENU_HEIGHT / 2);
            menu.ButtonActive += Menu_ButtonActive;

            Button Setting = new Button("Setting");
            Setting.Create(20, startPosTop - (int)MENU_HEIGHT / 2);
            Setting.ButtonActive += Setting_ButtonActive;

            Button Files = new Button("Files");
            Files.Create(33, startPosTop - (int)MENU_HEIGHT / 2);
            Files.ButtonActive += Files_ButtonActive;
        }

        private void Files_ButtonActive(object sender, Events.ButtonActiveEventArgs e)
        {
            
        }

        private void Setting_ButtonActive(object sender, Events.ButtonActiveEventArgs e)
        {
            
        }

        private void Menu_ButtonActive(object sender, Events.ButtonActiveEventArgs e)
        {
            if (!Menu_Open)
            {
                Menu_Open = true;
                new Menu(this.Width, this.Height);
            }
            else
            {
                ClearMenu Cm = new ClearMenu(this.Width, this.Height);
                Cm.Clear();
                Menu_Open = false;
            }
        }
    }
}
