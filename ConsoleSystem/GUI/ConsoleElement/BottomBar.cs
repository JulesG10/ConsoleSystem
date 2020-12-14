using System;
using System.Drawing;
using ConsoleSystem.GUI.Controls;
using ConsoleSystem.GUI.ClearConsoleElement;
using ConsoleSystem.GUI.ConsoleElement.CenterWindows;

namespace ConsoleSystem.GUI.ConsoleElement
{
    class BottomBar : IConsoleElementProperties
    {
        public BottomBar(int w, int h)
        {
            this.Height = h;
            this.Width = w;
            H = h;
            W = w;
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public static int H { get; private set; }
        public static int W { get; private set; }
        public static bool Menu_Open = false;
        public static readonly int MENU_HEIGHT = 2;
        private SettingWindow sw;
        private FileWindow fw;
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

        public static void ClearAllWindow()
        {
            if (HelpInfoWindow.Open)
                new ClearHelp(W,H).Clear();
            if (SettingWindow.Open)
                new ClearSettings(W, H).Clear();
            new ClearFile();

        }

        private void Files_ButtonActive(object sender, Events.ButtonActiveEventArgs e)
        {
            if (!FileWindow.Open)
            {
                fw = new FileWindow(this.Width, this.Height);
                fw.CreateWindow();
            }
            else
            {
                if (fw != null)
                    fw.Close();
            }
        }

        private void Setting_ButtonActive(object sender, Events.ButtonActiveEventArgs e)
        {
            if (!SettingWindow.Open)
            {
                sw = new SettingWindow(this.Width, this.Height);
                sw.CreateWindow();
            }
            else
            {
                if(sw!=null)
                    sw.Close();
            }
                
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
