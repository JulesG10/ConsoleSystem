using System;
using ConsoleSystem.Save;
using ConsoleSystem.GUI.Controls;

namespace ConsoleSystem.GUI.Navigation
{
    class ChangeButton
    {
        public static void Next()
        {
            if(!(GlobalMemroy.ButtonActualIndex+1 >= GlobalMemroy.CountButton()))
            {
                Button lastBtn = GlobalMemroy.GetButton();
                GlobalMemroy.ButtonActualIndex++;
                Button actualBtn = GlobalMemroy.GetButton();
                Change(lastBtn, actualBtn);
            }
        }

        private static void Change(Button lastB,Button newB)
        {
            if(lastB!=null && newB != null)
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

        public static void Back()
        {
            if (GlobalMemroy.ButtonActualIndex -1 > -1)
            {
                Button lastBtn = GlobalMemroy.GetButton();
                GlobalMemroy.ButtonActualIndex--;
                Button actualBtn = GlobalMemroy.GetButton();
                Change(lastBtn, actualBtn);
            }
        }

    }
}
