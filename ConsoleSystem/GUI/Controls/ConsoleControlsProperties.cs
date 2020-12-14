using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSystem.GUI.Controls
{
    interface IConsoleControlsProperties
    {
        void Create(int x,int y);
        int Id { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
}
