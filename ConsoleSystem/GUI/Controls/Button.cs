using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleSystem.Save;
using ConsoleSystem.Events;

namespace ConsoleSystem.GUI.Controls
{
    class Button : IConsoleControlsProperties
    {
        public string textContent { get; private set; }
        public int Id { get; set; }
        public int X { get ; set; }
        public int Y { get; set; }
        public event EventHandler<ButtonActiveEventArgs> ButtonActive;

        public Button(string value)
        {
            this.textContent = value;
        }

        public void Active()
        {
            OnActive(new ButtonActiveEventArgs());
        }

        protected virtual void OnActive(ButtonActiveEventArgs e)
        {
            ButtonActive?.Invoke(this, e);
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
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(textContent);
            Console.BackgroundColor = ConsoleColor.Black;
            GlobalMemroy.RegisterButton(this);
        }
    }
}
