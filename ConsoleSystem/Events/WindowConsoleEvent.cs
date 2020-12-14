using System;
using System.Threading;
using Gma.System.MouseKeyHook;

namespace ConsoleSystem.Events
{

    class WindowConsoleEvent
    {
        public event EventHandler<WindowResizeEventArgs> ConsoleWindowResize;
        public event EventHandler<ConsoleKeyInputArgs> ConsoleKeyInput;

        public void Listen()
        {
            int startHeight = Console.WindowHeight;
            int startWidth = Console.WindowWidth;
            new Thread(() =>
            {
                while (true)
                {
                    if (startHeight != Console.WindowHeight || startWidth != Console.WindowWidth)
                    {
                        startHeight = Console.WindowHeight;
                        startWidth = Console.WindowWidth;
                        OnConsoleWindowResize(new WindowResizeEventArgs(Console.WindowWidth, Console.WindowHeight));
                    }
                }
            }).Start();
            new Thread(() =>
            {
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki != null)
                    {
                        OnConsoleKeyInput(new ConsoleKeyInputArgs(cki));
                    }
                }
            }).Start();
        }

        protected virtual void OnConsoleKeyInput(ConsoleKeyInputArgs e)
        {
            ConsoleKeyInput?.Invoke(this, e);
        }

        protected virtual void OnConsoleWindowResize(WindowResizeEventArgs e)
        {
            ConsoleWindowResize?.Invoke(this, e);
        }
    }

}
