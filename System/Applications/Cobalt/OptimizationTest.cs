using Cobalt.GetIMG;
using Cosmos.System;
using Cosmos.System.Graphics;
using CosmosTTF;
using NexusOS.System.Graphics;
using NexusOS.System.Processing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusOS.System.Applications.Cobalt
{
	public class OptimizationTest : Process
	{
		public Bitmap CachedWindow;
		public static bool Optimized = true;
		public override void Run()
		{
			Window.DrawTop(this);
			int x = WindowData.WinPos.X;
			int y = WindowData.WinPos.Y;
			int sizeX = WindowData.WinPos.Width;
			int sizeY = WindowData.WinPos.Height;
			if (CachedWindow == null)
			{
				if (Optimized)
				{
					Interface.MainCanvas.DrawFilledRectangle(Color.FromArgb(0, 100, 0), x, y + Window.TopSize, sizeX, sizeY - Window.TopSize);
					Interface.MainCanvas.DrawCenteredTTFString("Optimization: ON", sizeX, x, y + 30, 20, Interface.Colors.TextColor, "KMB", 18);
					CachedWindow = TakeBitmap.GetImage(x, y + Window.TopSize, sizeX, sizeY - Window.TopSize);
				}
				else
				{
					Interface.MainCanvas.DrawFilledRectangle(Color.FromArgb(100, 0, 0), x, y + Window.TopSize, sizeX, sizeY - Window.TopSize);
					Interface.MainCanvas.DrawCenteredTTFString("Optimization: OFF", sizeX, x, y + 30, 20, Interface.Colors.TextColor, "KMB", 18);
					CachedWindow = TakeBitmap.GetImage(x, y + Window.TopSize, sizeX, sizeY - Window.TopSize);
				}
			}
			else
				Interface.MainCanvas.DrawImage(CachedWindow, x, y + Window.TopSize);

			if(Interface.MouseX > x && Interface.MouseX < x + sizeX && Interface.MouseY > y + 25 && Interface.MouseY < y + sizeY && MouseManager.MouseState == MouseState.Left && !Interface.Clicked)
			{
				Optimized = !Optimized;
			}
			if(!Optimized)
			{
				CachedWindow = null;

				//AlphaImageRenderer.CachedWindow = null;
				//ResizedImageRenderer.CachedImage = null;
				//TTFBox.CachedWindow = null;

				foreach(var item in ProcessManager.ProcessList)
				{
					item.WindowData.CachedTop = null;
				}
			}
		}
	}
}
