using NexusOS.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusOS.System.Graphics
{
	public static class CustomDrawing
	{
		public static void DrawFullRoundedRectangle(int x, int y, int width, int height, int radius, Color col)
		{
			Interface.MainCanvas.DrawFilledRectangle(col, x + radius, y, width - 2 * radius, height);
            Interface.MainCanvas.DrawFilledRectangle(col, x, y + radius, radius, height - 2 * radius);
            Interface.MainCanvas.DrawFilledRectangle(col, x + width - radius, y + radius, radius, height - 2 * radius);
            Interface.MainCanvas.DrawFilledCircle(col, x + radius, y + radius, radius);
            Interface.MainCanvas.DrawFilledCircle(col, x + width - radius - 1, y + radius, radius);
            Interface.MainCanvas.DrawFilledCircle(col, x + radius, y + height - radius - 1, radius);
            Interface.MainCanvas.DrawFilledCircle(col, x + width - radius - 1, y + height - radius - 1, radius);
		}

        public static void DrawOutlineRoundedRectangle(int x, int y, int width, int height, int radius, Color col)
        {
            Interface.MainCanvas.DrawRectangle(col, x + radius, y, width - 2 * radius, height);
            Interface.MainCanvas.DrawRectangle(col, x, y + radius, radius, height - 2 * radius);
            Interface.MainCanvas.DrawRectangle(col, x + width - radius, y + radius, radius, height - 2 * radius);
            Interface.MainCanvas.DrawCircle(col, x + radius, y + radius, radius);
            Interface.MainCanvas.DrawCircle(col, x + width - radius - 1, y + radius, radius);
            Interface.MainCanvas.DrawCircle(col, x + radius, y + height - radius - 1, radius);
            Interface.MainCanvas.DrawCircle(col, x + width - radius - 1, y + height - radius - 1, radius);
        }

        public static void DrawTopRoundedRectangle(int x, int y, int width, int height, int radius, Color col)
		{
            Interface.MainCanvas.DrawFilledRectangle(col, x + radius, y, width - 2 * radius, height);
			Interface.MainCanvas.DrawFilledRectangle(col, x, y + radius, width, height - radius);
			Interface.MainCanvas.DrawFilledCircle(col, x + radius, y + radius, radius);
			Interface.MainCanvas.DrawFilledCircle(col, x + width - radius - 1, y + radius, radius);
		}
	}
}
