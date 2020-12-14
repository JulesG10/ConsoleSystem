using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSystem.GUI.ClearConsoleElement
{
    interface IClearConsoleElementProperties
    {
        void Clear();
        int Height { get; set; }
        int Width { get; set; }
    }
}
