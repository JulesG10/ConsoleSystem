using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSystem.GUI.ConsoleElement.CenterWindows
{
    class HelpInfoWindow : WindowDesignProperties
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
        public Size size { get; set; }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void CreateWindow()
        {
            throw new NotImplementedException();
        }

        public void Move(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
