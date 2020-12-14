using System;
using System.Windows.Forms;

namespace ConsoleSystem.Events
{
    class ConsoleKeyInputArgs
    {
        public ConsoleKeyInfo KeyInfo { get; private set; }

        public ConsoleKeyInputArgs(ConsoleKeyInfo consoleKeyInfo)
        {
            this.KeyInfo = consoleKeyInfo;
        }
    }
}
