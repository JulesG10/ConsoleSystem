using System.Drawing;

namespace ConsoleSystem.GUI.ConsoleElement.CenterWindows
{
    interface WindowDesignProperties
    {
        int Height { get; set; }
        int Width { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int Id { get; set; }
        Size size { get; set; }
        void CreateWindow();
        void Close();
        void Move(int x, int y);
    }
}
