using Cobalt.GetIMG;
using Cosmos.System.Graphics;
using CosmosTTF;
using NexusOS.System.Graphics;
using NexusOS.System.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NexusOS.System.Applications.System.Processes
{
    public class Taskbar : Process
    {
        public static Bitmap CachedWindow;
        public static int TaskbarSize = 80;

        public override void Run()
        {
            // Configuration Application Code
            int x = WindowData.WinPos.X;
            int y = WindowData.WinPos.Y;
            int width = WindowData.WinPos.Width;
            int height = WindowData.WinPos.Height;

            // Buttons Configuration
            int buttonY = y + Window.TopSize + 10;

            int menuButtonX = x + 35;
            int terminalButtonX = x + 245; // [+45]
            int explorerButtonX = x + 290; // [+45]

            // Frames Configuration
            int timeFrameX = width - 235;
            int trayFrameX = width - 450;

            // Drawing App Background
            Interface.MainCanvas.DrawFilledRectangle(Interface.Colors.MainColor, x, y + Window.TopSize, width, height - Window.TopSize);

            // Application Code [Menu Start, Icons, Shutdown, Programs etc.]
            if (CachedWindow == null)
            {
                // Taskbar Buttons [Clickable]
                Widgets.DrawCenteredTextButton("Menu Start", menuButtonX, buttonY, 200, 35);
                Widgets.DrawButton(terminalButtonX, buttonY, 35, 35);
                Widgets.DrawButton(explorerButtonX, buttonY, 35, 35);

                // Taskbar Time & Date [Interactable]
                Widgets.DrawFrame(timeFrameX, buttonY, 200, 35);
                Widgets.DrawFrame(trayFrameX, buttonY, 200, 35); // Icons: Internet, Sound, Notification
                Interface.MainCanvas.DrawCenteredCachedTTFString("18.09.2026, 20:00", 200, timeFrameX, buttonY + 9, 1, TTFManager.CachedFont.KMB18);

                // Cache Window [Optimization]
                CachedWindow = TakeBitmap.GetImage(x, y + Window.TopSize, width, height - Window.TopSize);
            }
            else
                Interface.MainCanvas.DrawImage(CachedWindow, x, y + Window.TopSize);
        }
    }
}
