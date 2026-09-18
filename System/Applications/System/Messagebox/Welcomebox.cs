using Cobalt.GetIMG;
using Cosmos.System.Graphics;
using CosmosTTF;
using NexusOS.System.Graphics;
using NexusOS.System.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusOS.System.Applications.System.Messagebox
{
    public class Welcomebox : Process
    {
        public static Bitmap CachedWindow;

        public override void Run()
        {
            // Main Application Code
            Window.DrawTop(this);

            int x = WindowData.WinPos.X;
            int y = WindowData.WinPos.Y;
            int width = WindowData.WinPos.Width;
            int height = WindowData.WinPos.Height;

            Interface.MainCanvas.DrawFilledRectangle(Interface.Colors.MainColor, x, y + Window.TopSize, width, height-Window.TopSize);

            if (CachedWindow == null)
            {
                Interface.MainCanvas.DrawCenteredCachedTTFString("Welcome to Nexus OS! System is running as LiveISO, which means you don't need to\ninstall anything to use basic features of this system! If you would want to install some\nother programs or apps, you need Install OS First.", width, x, y + 30, 20, TTFManager.CachedFont.KMB18);
                CachedWindow = TakeBitmap.GetImage(x, y + Window.TopSize, width, height - Window.TopSize);
            }
            else
                Interface.MainCanvas.DrawImage(CachedWindow, x, y + Window.TopSize);
        }
    }
}
