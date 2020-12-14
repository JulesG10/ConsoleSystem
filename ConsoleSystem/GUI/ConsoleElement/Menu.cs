using System;
using System.Drawing;
using ConsoleSystem.GUI.Controls;
using System.Management;
using System.Threading;
using ConsoleSystem.GUI.ConsoleElement.CenterWindows;

namespace ConsoleSystem.GUI.ConsoleElement
{
    class Menu
    {
        public static readonly int MENU_HEIGHT = 10;
        public static readonly int MENU_WIDTH = 20;
        public static Thread TimeThread { get; private set; }
        public static Button help { get; private set; }
        private int W;
        private int H;
        public static Thread BatteryThread { get; private set; }
        private readonly Color MENU_COLOR = Color.FromArgb(GUI.Draw.Colors[(int)ConsoleColor.DarkGray]);

        private void Make(int startPosTop)
        {
            help = new Button("Aide/Info");
            help.Create(3, startPosTop + 3);
            help.ButtonActive += Help_ButtonActive;

            System.Windows.Forms.PowerStatus pwr = System.Windows.Forms.SystemInformation.PowerStatus;
            double batterylife = pwr.BatteryLifePercent;
            Label battryLevel = new Label($"Battery {(int)(batterylife * 100)}%", ConsoleColor.DarkGray);
            battryLevel.Create(3, startPosTop + 1);

            Label time = new Label($"Time {DateTime.Now.ToString("hh:mm:ss")}", ConsoleColor.DarkGray);
            time.Create(3, startPosTop + 2);
        }

        private void Help_ButtonActive(object sender, Events.ButtonActiveEventArgs e)
        {
            HelpInfoWindow win = new HelpInfoWindow(this.W,this.H);
            win.CreateWindow();
        }

        public Menu(int w, int h)
        {
            this.H = h;
            this.W = w;
            int startPosTop = h - (MENU_HEIGHT);
            for (int y = startPosTop; y < h - (BottomBar.MENU_HEIGHT + 1); y++)
            {
                for (int x = 0; x < MENU_WIDTH; x++)
                {
                    Draw.DrawPixel(MENU_COLOR, new Point(x, y));
                }
            }

            /* BUG: Console cursor can't be at the same place in same time...
             this.Make(startPosTop);
            */
            help = new Button("Aide/Info");
            help.Create(3, startPosTop + 3);
            help.ButtonActive += Help_ButtonActive;
            /**/

            BatteryThread = new Thread(() =>
            {
                while (true)
                {
                    System.Windows.Forms.PowerStatus pwr = System.Windows.Forms.SystemInformation.PowerStatus;
                    double batterylife = pwr.BatteryLifePercent;
                    Label battryLevel = new Label($"Battery {(int)(batterylife * 100)}%", ConsoleColor.DarkGray);
                    battryLevel.Create(3, startPosTop + 1);
                    /* BUG: Console cursor can't be at the same place in same time...
                    Thread.Sleep(60000);
                    */
                    break;
                    /**/

                }
            });
            BatteryThread.Start();


            TimeThread = new Thread(() =>
            {
                while (true)
                {
                    /* BUG: Console cursor can't be at the same place in same time...
                    Label time = new Label($"Time {DateTime.Now.ToString("hh:mm:ss")}", ConsoleColor.DarkGray);
                    time.Create(3, startPosTop + 2);
                    Thread.Sleep(1000);
                    */
                    Label time = new Label($"Date {DateTime.Now.ToString("d/MM/yyyy")}", ConsoleColor.DarkGray);
                    time.Create(3, startPosTop + 2);
                    break;
                    /**/
                }
            });
            TimeThread.Start();

        }
    }
}
