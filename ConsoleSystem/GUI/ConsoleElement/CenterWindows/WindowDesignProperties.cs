using System.Drawing;

namespace ConsoleSystem.GUI.ConsoleElement.CenterWindows
{
    interface WindowDesignProperties
    {
        int Height { get; set; }
        int Width { get; set; }
        Size size { get; set; }
        void CreateWindow();
        void Close();
    }
}
