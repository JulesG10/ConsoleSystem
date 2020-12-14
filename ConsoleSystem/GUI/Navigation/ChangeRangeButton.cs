using ConsoleSystem.Save;
using System;
using ConsoleSystem.GUI.Controls;

namespace ConsoleSystem.GUI.Navigation
{
    class ChangeRangeButton
    {

        public static void Next()
        {
            if (!(GlobalMemroy.ButtonActualIndex + 1 >= GlobalMemroy.CountButton()))
            {
                RangeButton lastBtn = GlobalMemroy.GetRangeButton();
                GlobalMemroy.ButtonActualIndex++;
                RangeButton actualBtn = GlobalMemroy.GetRangeButton();
                Change(lastBtn, actualBtn);
            }
            else
            {
                Back();
            }
        }

        private static void Change(RangeButton lastB, RangeButton newB)
        {
            if (lastB != null && newB != null)
            {
                Console.SetCursorPosition(lastB.X, lastB.Y);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(lastB.textContent);
                Console.BackgroundColor = ConsoleColor.Black;

                Console.SetCursorPosition(newB.X, newB.Y);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(newB.textContent);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void Back()
        {
            if (GlobalMemroy.ButtonActualIndex - 1 > -1)
            {
                RangeButton lastBtn = GlobalMemroy.GetRangeButton();
                GlobalMemroy.ButtonActualIndex--;
                RangeButton actualBtn = GlobalMemroy.GetRangeButton();
                Change(lastBtn, actualBtn);
            }
        }
    }
}
