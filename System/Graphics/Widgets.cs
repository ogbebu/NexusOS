using CosmosTTF;
using System;

namespace NexusOS.System.Graphics
{
    public static class Widgets
    {
        // Button Drawing
        public static void DrawCenteredTextButton(string text, int x, int y, int width, int height)
        {
            Interface.MainCanvas.DrawFilledRectangle(Interface.Colors.DarkerColor, x, y, width, height);
            Interface.MainCanvas.DrawRectangle(Interface.Colors.BorderColor, x, y, width, height);
            Interface.MainCanvas.DrawCenteredCachedTTFString( text, width, x, y + ((height / 2) - 9), 1,TTFManager.CachedFont.KMB18);
        }
        public static void DrawRoundedButton(int x, int y, int width, int height, int radius)
        {
            CustomDrawing.DrawFullRoundedRectangle(x, y, width, height, radius, Interface.Colors.DarkerColor);
            CustomDrawing.DrawOutlineRoundedRectangle(x, y, width, height, radius, Interface.Colors.BorderColor);
        }
        public static void DrawTextButton(string text, int x, int y, int textX, int textY, int width, int height)
        {
            Interface.MainCanvas.DrawFilledRectangle(Interface.Colors.DarkerColor, x, y, width, height);
            Interface.MainCanvas.DrawRectangle(Interface.Colors.BorderColor, x, y, width, height);
            Interface.MainCanvas.DrawStringTTFCached(text, TTFManager.CachedFont.KMB18, textX, textY + y + ((height / 2) - 9), 1);
        }
        public static void DrawButton(int x, int y, int width, int height)
        {
            Interface.MainCanvas.DrawFilledRectangle(Interface.Colors.DarkerColor, x, y, width, height);
            Interface.MainCanvas.DrawRectangle(Interface.Colors.BorderColor, x, y, width, height);
        }

        // Frame Drawing
        public static void DrawFrame(int x, int y, int width, int height)
        {
            Interface.MainCanvas.DrawFilledRectangle(Interface.Colors.DarkerColor, x, y, width, height);
            Interface.MainCanvas.DrawRectangle(Interface.Colors.BorderColor, x, y, width, height);
        }
        public static void DrawRoundedFrame(int x, int y, int width, int height, int radius)
        {
            CustomDrawing.DrawFullRoundedRectangle(x, y, width, height, radius, Interface.Colors.DarkerColor);
            CustomDrawing.DrawOutlineRoundedRectangle(x, y, width, height, radius, Interface.Colors.BorderColor);
        }
    }
}