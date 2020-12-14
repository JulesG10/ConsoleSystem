using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using ConsoleSystem.GUI;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.IO;
using System.Threading;

namespace ConsoleSystem
{
    class Program
    {
        private static int mode;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        public enum StdHandle : int
        {
            STD_INPUT_HANDLE = -10,
            STD_OUTPUT_HANDLE = -11,
            STD_ERROR_HANDLE = -12,
        }

        [Flags]
        private enum ConsoleInputModes : uint
        {
            ENABLE_PROCESSED_INPUT = 0x0001,
            ENABLE_LINE_INPUT = 0x0002,
            ENABLE_ECHO_INPUT = 0x0004,
            ENABLE_WINDOW_INPUT = 0x0008,
            ENABLE_MOUSE_INPUT = 0x0010,
            ENABLE_INSERT_MODE = 0x0020,
            ENABLE_QUICK_EDIT_MODE = 0x0040,
            ENABLE_EXTENDED_FLAGS = 0x0080,
            ENABLE_AUTO_POSITION = 0x0100
        }

        [Flags]
        private enum ConsoleOutputModes : uint
        {
            ENABLE_PROCESSED_OUTPUT = 0x0001,
            ENABLE_WRAP_AT_EOL_OUTPUT = 0x0002,
            ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004,
            DISABLE_NEWLINE_AUTO_RETURN = 0x0008,
            ENABLE_LVB_GRID_WORLDWIDE = 0x0010
        }

        public static void DisableSelection()
        {
            IntPtr consoleHandle = GetStdHandle((int)StdHandle.STD_INPUT_HANDLE);
            UInt32 consoleMode;
            bool Enable = false;
            GetConsoleMode(consoleHandle, out consoleMode);
            if (Enable)
                consoleMode |= ((uint)ConsoleInputModes.ENABLE_QUICK_EDIT_MODE);
            else
                consoleMode &= ~((uint)ConsoleInputModes.ENABLE_QUICK_EDIT_MODE);

            consoleMode |= ((uint)ConsoleInputModes.ENABLE_EXTENDED_FLAGS);

            SetConsoleMode(consoleHandle, consoleMode);
        }

        public static void DisableScrollBar()
        {
            try
            {
                Console.BufferWidth = Console.WindowWidth;
                Console.BufferHeight = Console.WindowHeight;
            }
            catch { }
        }

        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            DisableSelection();
            DisableScrollBar();
            new Content();
        }
    }
}
