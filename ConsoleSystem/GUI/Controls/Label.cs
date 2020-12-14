using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSystem.GUI.Controls
{
    class Label : IConsoleControlsProperties
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string textContent;
        public ConsoleColor background;
        public ConsoleColor text;
        public bool noSave = false;

        public Label(string value, ConsoleColor background,ConsoleColor text = ConsoleColor.Black)
        {
            this.textContent = value;
            this.background = background;
            this.text = text;
        }

        public void Create(int x, int y)
        {
            this.X = x;
            this.Y = y;
            try
            {
                Console.SetCursorPosition(x, y);
            }
            catch { }
            Console.BackgroundColor = this.background;
            Console.ForegroundColor = this.text;
            Console.Write(textContent);
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
