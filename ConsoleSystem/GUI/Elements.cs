using ConsoleSystem.GUI.ConsoleElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSystem.GUI
{
    class Elements
    {
        public Elements(int w,int h)
        {
            new BottomBar(w, h).Draw();
        }
    }
}
