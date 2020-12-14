using System;

namespace ConsoleSystem.Events
{
    class WindowResizeEventArgs
    {
        public int Height { get; private set; } = Console.WindowHeight;
        public int Width { get; private set; } = Console.WindowWidth;

        public WindowResizeEventArgs(int width, int height)
        {
            this.Height = height;
            this.Width = width;
        }
    }
}
