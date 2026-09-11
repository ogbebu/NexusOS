using NexusOS.System.Graphics;
using NexusOS.System.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusOS.System.Applications.System
{
    public class Welcomebox : Process
    {
        public override void Run()
        {
            Window.DrawTop(this);

            int x = WindowData.WinPos.X;
            int y = WindowData.WinPos.Y;
            int width = WindowData.WinPos.Width;
            int height = WindowData.WinPos.Height;

            Interface.MainCanvas.DrawFilledRectangle(Interface.Colors.MainColor, x, y + Window.TopSize, width, height-Window.TopSize);
        }
    }
}
