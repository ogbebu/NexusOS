using NexusOS.System.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusOS.System.Graphics
{
    public static class Window
    {

        public static int TopSize = 30;

        public static void DrawTop(Process proc)
        {
            CustomDrawing.DrawTopRoundedRectangle(proc.WindowData.WinPos.X, proc.WindowData.WinPos.Y, proc.WindowData.WinPos.Width, proc.WindowData.WinPos.Height, TopSize, Interface.Colors.DarkColor);
            Interface.MainCanvas.DrawString(proc.Name, Interface.DefaultFont, Interface.Colors.TextColor, proc.WindowData.WinPos.X + 15, proc.WindowData.WinPos.Y + 8);
        }
    }
}
