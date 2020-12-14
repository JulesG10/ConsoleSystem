using System;
using System.Drawing;
using System.Threading;
using ConsoleSystem.Events;
using ConsoleSystem.Save;

namespace ConsoleSystem.GUI
{
    class Content
    {
        public Content()
        {
            this.Init();
        }

        private void Init()
        {
            WindowConsoleEvent ConsoleEvt = new WindowConsoleEvent();
            ConsoleEvt.ConsoleWindowResize += ConsoleWindowResize;
            ConsoleEvt.ConsoleKeyInput += ConsoleKeyInput;
            ConsoleEvt.Listen();
            this.CreateInterface(Console.WindowWidth, Console.WindowHeight);
        }

        private void ConsoleKeyInput(object sender, ConsoleKeyInputArgs e)
        {
            new Navigation.Action((int)e.KeyInfo.Key);
        }

        private void CreateInterface(int w, int h)
        {
            for (int x = 0; x < Math.Max(h, w); x++)
            {
                for (int y = 0; y < Math.Min(h, w); y++)
                {
                    Draw.DrawPixel(Color.FromArgb(Draw.Colors[(int)ConsoleColor.Blue]), new Point(x, y));
                }
            }
            GlobalMemroy.ClearButtonList();
            new Elements(w, h);
        }

        public void Update()
        {
            Console.Clear();
            GlobalMemroy.ResizeWindowPixel(Console.WindowWidth, Console.WindowHeight);
            this.CreateInterface(Console.WindowWidth, Console.WindowHeight);
        }

        private void ConsoleWindowResize(object sender, WindowResizeEventArgs e)
        {
            Program.DisableScrollBar();
            this.CreateInterface(e.Width, e.Height);
        }
    }
}
