using System;
using ConsoleSystem.GUI.Controls;
using System.Drawing;
using ConsoleSystem.Save;

namespace ConsoleSystem.GUI.ConsoleElement.CenterWindows
{
    class HelpInfoWindow : WindowDesignProperties
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Size size { get; set; } = new Size(10, 10);
        public static Button close;
        public static bool Open = false;

        public HelpInfoWindow(int w, int h)
        {
            this.Height = h;
            this.Width = w;
        }

        public  void Close()
        {
            int startPos = ((this.Height - this.size.Height) / 2);
            int endPos = startPos + this.size.Height;
            for (int y = startPos; y < endPos; y++)
            {
                for (int x = (this.Width - this.size.Width) / 2; x < (int)((this.Width - this.size.Width)); x++)
                {
                    GUI.Draw.DrawPixel(Color.FromArgb(GUI.Draw.Colors[(int)ConsoleColor.Blue]), new Point(x, y));
                }
            }
            GlobalMemroy.RemoveButton(close);
            Open = false;
        }

        public void CreateWindow()
        {
            BottomBar.ClearAllWindow();
            Open = true;
            int startPos = ((this.Height - this.size.Height) / 2);
            int endPos = startPos + this.size.Height;
            for (int y = startPos; y < endPos; y++)
            {
                for(int x=(this.Width - this.size.Width)/2;x<(int)((this.Width - this.size.Width) ); x++)
                {
                    
                    GUI.Draw.DrawPixel(Color.FromArgb(GUI.Draw.Colors[(int)ConsoleColor.Gray]), new Point(x, y));
                }
            }
            int wPos = (this.Width - this.size.Width) / 2;
            this.MakeLabel("Help/Info", wPos + 2, startPos );
            this.MakeLabel("Button: navigate with arrow keys [<][>]", wPos + 2, startPos + 2);
            this.MakeLabel("     | Click: press enter key [Enter]", wPos + 2, startPos + 3);
            this.MakeLabel("Range: navigate with tab key [Tab]", wPos + 2, startPos + 4);
            this.MakeLabel("     | Add: press enter key [+]", wPos + 2, startPos + 5);
            this.MakeLabel("     | Min: press enter key [-]", wPos + 2, startPos + 6);
            this.MakeLabel("Resize: you can resize the window with your mouse", wPos + 2, startPos + 7);
            this.MakeLabel("(it can be very slow and all the window will close)", wPos + 2, startPos + 8);
            close=new Button("[X]");
            close.Create((wPos + this.size.Width*2), startPos); ;
            close.ButtonActive += Btn_ButtonActive;
        }

        private void Btn_ButtonActive(object sender, Events.ButtonActiveEventArgs e)
        {
            this.Close();
        }

        private void MakeLabel(string value,int x,int y)
        {
            Label lb1 = new Label(value, ConsoleColor.Gray);
            lb1.Create(x,y);
        }
    }
}
