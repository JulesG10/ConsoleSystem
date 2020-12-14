using ConsoleSystem.Events;
using ConsoleSystem.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSystem.GUI.Controls
{
    class RangeButton : IConsoleControlsProperties
    {
        public string textContent { get; private set; }
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int DefaultValue { get; private set; }  = 0;
        public int IncrementValue { get; private set; }  = 1;
        public event EventHandler<RangeButtonActiveEventArgs> ValueChange;

        public RangeButton(string value,int defaultV,int incr)
        {
            this.textContent = value;
            this.DefaultValue = defaultV;
            this.IncrementValue = incr;
        }

        public void Add()
        {
            this.DefaultValue += this.IncrementValue;
            OnAdd(new RangeButtonActiveEventArgs(true,false,this.DefaultValue,this.IncrementValue));
        }

        public void Min()
        {
            this.DefaultValue -= this.IncrementValue;
            OnAdd(new RangeButtonActiveEventArgs(false, true, this.DefaultValue, this.IncrementValue));
        }

        protected virtual void OnMin(RangeButtonActiveEventArgs e)
        {
            ValueChange?.Invoke(this, e);
        }

        protected virtual void OnAdd(RangeButtonActiveEventArgs e)
        {
            ValueChange?.Invoke(this, e);
        }


        public void Create(int x, int y)
        {
            this.X = x;
            this.Y = y;
            
                Console.SetCursorPosition(x, y);
            
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(textContent);
            Console.BackgroundColor = ConsoleColor.Black;
            GlobalMemroy.RegisterRangeButton(this);
        }

    }
}
