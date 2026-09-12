using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusOS.Resources
{
    public static class Files
    {
        // Wallpapers Resources
        [ManifestResourceStream(ResourceName = "NexusOS.Resources.Wallpapers.Default.bmp")] public static byte[] DefaultWallpaper;

        // Cursors Resources
        [ManifestResourceStream(ResourceName = "NexusOS.Resources.Cursors.Cursor48.bmp")] public static byte[] Cursor48;

        // Fonts Resources
        [ManifestResourceStream(ResourceName = "NexusOS.Resources.Fonts.KodeMono-Bold.ttf")] public static byte[] KodeMonoBold;
    }
}
