using Cosmos.System;
using Cosmos.System.Graphics;
using NexusOS.System.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexusOS.System.Applications.System;
using System.Drawing;
using Cosmos.System.Graphics.Fonts;

namespace NexusOS.System.Graphics
{
    public static class Interface
    {
        // Configuration:
        public static int ScreenSizeX = 1920, ScreenSizeY = 1080;
        public static Colors Colors = new Colors();
        public static Bitmap Wallpaper, Cursor;
        public static SVGAIICanvas MainCanvas;

        // Variables:
        public static Process CurrentProcess;
        public static int MouseX, MouseY;
        public static bool Clicked;
        static int oldX, oldY;

        // Fonts:
        public static PCScreenFont DefaultFont = PCScreenFont.Default;

        // Starting Interface:
        public static void StartInterface()
        {
            MainCanvas = new SVGAIICanvas(new Mode((uint) ScreenSizeX, (uint) ScreenSizeY, ColorDepth.ColorDepth32));

            MouseManager.ScreenWidth = (uint) ScreenSizeX;
            MouseManager.ScreenHeight = (uint) ScreenSizeY;
            MouseManager.X = (uint) ScreenSizeX / 2;
            MouseManager.Y = (uint) ScreenSizeY / 2;

            // Autostart Apps - Here for now
            ProcessManager.Start(new Welcomebox { WindowData = new WindowData { WinPos = new Rectangle(ScreenSizeX / 2, ScreenSizeY / 2, 800, 400) }, Name = "Welome to Nexus!", User = "System", PID = 784 });
        }

        // Moving Windows:
        public static void Interact()
        {
            if (CurrentProcess != null)
            {
                CurrentProcess.WindowData.WinPos.X = (int)MouseManager.X - oldX;
                CurrentProcess.WindowData.WinPos.Y = (int)MouseManager.Y - oldY;
            }
            else if (MouseManager.MouseState == MouseState.Left && !Clicked)
            {
                foreach (var proc in ProcessManager.ProcessList)
                {
                    if (proc.WindowData.Moveable)
                    {
                        continue;
                    }
                    if (MouseX > proc.WindowData.WinPos.X && MouseX < proc.WindowData.WinPos.X + proc.WindowData.WinPos.Width)
                    {
                        if (MouseY > proc.WindowData.WinPos.Y && MouseY < proc.WindowData.WinPos.Y + Window.TopSize)
                        {
                            CurrentProcess = proc;

                            oldX = MouseX - proc.WindowData.WinPos.X;
                            oldY = MouseY - proc.WindowData.WinPos.Y;
                        }
                    }
                }
            }
        }

        // Updating Interface:
        public static void Update()
        {
            MouseX = (int)MouseManager.X;
            MouseY = (int)MouseManager.Y;

            MainCanvas.DrawImage(Wallpaper, 0, 0);

            Interact();
            ProcessManager.Update();

            MainCanvas.DrawImageAlpha(Cursor, (int)MouseManager.X, (int)MouseManager.Y);

            if (MouseManager.MouseState == MouseState.Left)
            { 
                Clicked = true; 
            }
            else if (MouseManager.MouseState == MouseState.None && Clicked)
            { 
                Clicked = false; 
                CurrentProcess = null;
            }

            MainCanvas.Display();
        }
    }
}
