using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ConsoleSystem.GUI.Controls;

namespace ConsoleSystem.Save
{
    class GlobalMemroy
    {
        private static List<Tuple<Color, Point>> pixel = new List<Tuple<Color, Point>>();
        private static List<Button> ButtonList = new List<Button>();
        private static List<RangeButton> RangeButtonList = new List<RangeButton>();
        public static int ButtonActualIndex { get; set; } = 0;
        public static int RangeButtonActualIndex { get; set; } = 0;

        public static void RegisterButton(Button btn)
        {
            ButtonList.Add(btn);
            btn.Id = ButtonList.Count;
        }
        public static void RegisterRangeButton(RangeButton btn)
        {
            RangeButtonList.Add(btn);
            btn.Id = ButtonList.Count;
        }


        public static int CountRangeButton()
        {
            return RangeButtonList.Count;
        }
        public static int CountButton()
        {
            return ButtonList.Count;
        }

        public static void RemoveButton(Button btn)
        {
            ButtonList.Remove(btn);
        }

        public static Button GetButton()
        {
            try
            {
                return ButtonList[ButtonActualIndex];
            }
            catch
            {
                return null;
            }
        }
        public static RangeButton GetRangeButton()
        {
            if (RangeButtonList.Count > 0)
            {
                return RangeButtonList[RangeButtonActualIndex];
            }
            else
            {
                return null;
            }
                
        }

        public static void UpdatePixel(Color newColor,Point newCoord)
        {
            Tuple<Color, Point> update = null;
            foreach (Tuple<Color,Point> element in pixel)
            {
                if (element.Item2 == newCoord)
                {
                    update = element;
                }
            }
            if (update != null)
            {
                pixel.Remove(update);
                pixel.Add(new Tuple<Color, Point>(newColor, newCoord));
            }
            else
            {
                pixel.Remove(update);
                pixel.Add(new Tuple<Color, Point>(newColor, newCoord));
            }
        }

        public static void ClearButtonList()
        {
            ButtonList.Clear();
            ButtonActualIndex = 0;
        }

        public static void ResizeWindowPixel(int w,int h)
        {
            List<Tuple<Color, Point>> removeList = new List<Tuple<Color, Point>>();
            foreach (Tuple<Color, Point> element in pixel)
            {
                if (element.Item2.X > w || element.Item2.Y > h)
                {
                    removeList.Add(element);
                }
            }
            foreach(Tuple<Color, Point> removeElement in removeList)
            {
                pixel.Remove(removeElement);
            }
        }

        public static Color GetPixel(Point coord)
        {
            foreach (Tuple<Color, Point> element in pixel)
            {
                if (element.Item2 == coord)
                {
                    return element.Item1;
                }
            }
            return new Color();
        }
    }
}
