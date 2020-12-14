using System;
using System.Linq;
using System.Drawing;
using ConsoleSystem.Save;
using System.Threading;

namespace ConsoleSystem.GUI
{
    class Draw
    {
        public static int[] Colors = {  
                        0x000000, //Black = 0
                        0x000080, //DarkBlue = 1
                        0x008000, //DarkGreen = 2
                        0x008080, //DarkCyan = 3
                        0x800000, //DarkRed = 4
                        0x800080, //DarkMagenta = 5
                        0x808000, //DarkYellow = 6
                        0xC0C0C0, //Gray = 7
                        0x808080, //DarkGray = 8
                        0x0000FF, //Blue = 9
                        0x00FF00, //Green = 10
                        0x00FFFF, //Cyan = 11
                        0xFF0000, //Red = 12
                        0xFF00FF, //Magenta = 13
                        0xFFFF00, //Yellow = 14
                        0xFFFFFF  //White = 15
                    };

        internal static void DrawPixel(object p, Point point)
        {
            throw new NotImplementedException();
        }

        public static void DrawPixel(Color cValue,Point coord,bool noSave = false)
        {
                Color[] cTable = Colors.Select(x => Color.FromArgb(x)).ToArray();
                char[] rList = new char[] { (char)9617, (char)9618, (char)9619, (char)9608 };
                int[] bestHit = new int[] { 0, 0, 4, int.MaxValue };

                for (int rChar = rList.Length; rChar > 0; rChar--)
                {
                    for (int cFore = 0; cFore < cTable.Length; cFore++)
                    {
                        for (int cBack = 0; cBack < cTable.Length; cBack++)
                        {
                            int R = (cTable[cFore].R * rChar + cTable[cBack].R * (rList.Length - rChar)) / rList.Length;
                            int G = (cTable[cFore].G * rChar + cTable[cBack].G * (rList.Length - rChar)) / rList.Length;
                            int B = (cTable[cFore].B * rChar + cTable[cBack].B * (rList.Length - rChar)) / rList.Length;
                            int iScore = (cValue.R - R) * (cValue.R - R) + (cValue.G - G) * (cValue.G - G) + (cValue.B - B) * (cValue.B - B);
                            if (!(rChar > 1 && rChar < 4 && iScore > 50000))
                            {
                                if (iScore < bestHit[3])
                                {
                                    bestHit[3] = iScore;
                                    bestHit[0] = cFore;
                                    bestHit[1] = cBack;
                                    bestHit[2] = rChar;
                                }
                            }
                        }
                    }
                }
                Console.ForegroundColor = (ConsoleColor)bestHit[0];
                Console.BackgroundColor = (ConsoleColor)bestHit[1];
                try { Console.SetCursorPosition(coord.X, coord.Y); } catch { }
                Console.Write(rList[bestHit[2] - 1]);
                if (!noSave)
                {
                    GlobalMemroy.UpdatePixel(cValue, coord);
                }
                Console.CursorVisible = false;
        }
    }
}
