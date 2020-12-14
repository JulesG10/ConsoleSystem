using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSystem.Events
{
    class RangeButtonActiveEventArgs
    {
        public bool Add { get; private set; }  = false;
        public bool Min { get; private set; }  = false;
        public int NewValue { get; private set; }  = 0;
        public int Increment { get; private set; }  = 1;

        public RangeButtonActiveEventArgs(bool add,bool min,int value,int incr)
        {
            this.Add = add;
            this.Min = min;
            this.Increment = incr;
            this.NewValue = value;
        }
    }
}
