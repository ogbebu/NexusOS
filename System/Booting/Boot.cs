using Cobalt.TTF;
using Cosmos.System.Graphics;
using NexusOS.System.Graphics;
using NexusOS.System.Shell;
using System;
using System.IO;
using System.Threading;

namespace NexusOS.System.Booting
{
    public static class Boot
    {
        public static bool enabledDebugging = false;

        private static void WriteOk(string message)
        {
            Printing.WriteOk(message);
            Thread.Sleep(50);
        }
        private static void WriteFail(string message)
        {
            Printing.WriteFail(message);
            Thread.Sleep(50);
        }
        private static void WriteDebug(string message)
        {
            if (enabledDebugging == true)
            {
                Printing.WriteDebug(message);
                Thread.Sleep(50);
            }
        }
        private static void WriteMagenta(string name, string message, int delay)
        {
            Printing.WriteMagenta(name, message);
            Thread.Sleep(delay);
        }

        public static void BootPhase1()
        {
            // Code currently only working for Visual Effect
            Console.Clear();

            WriteOk("Loading system package: nexus.power-management");
            //PowerManager.Initialize();

            WriteOk("Loading system package: nexus.command-prompt");
            //ShellManager.Initialize();

            WriteOk("Loading system package: nexus.memory-manager");
            WriteOk("Loading system package: nexus.process-manager");
            WriteOk("Loading system package: nexus.file-system");
            WriteOk("Loading system package: nexus.device-manager");
            WriteOk("Loading system package: nexus.input-manager");
            WriteOk("Loading system package: nexus.network-manager");
            WriteOk("Loading system package: nexus.system-services");

            WriteFail("Loading system package: nexus.display-driver");
            WriteDebug("This package does not exist in current system version!");

            WriteFail("Loading system package: nexus.svga-interface");
            WriteDebug("This package does not exist in current system version!");

            WriteFail("Loading system package: nexus.processing-system");
            WriteDebug("This package does not exist in current system version!");

            WriteFail("Loading system package: nexus.threading-system");
            WriteDebug("This package does not exist in current system version!");

            WriteFail("Loading system package: nexus.interface-service");
            WriteDebug("This package does not exist in current system version!");

            WriteFail("Loading system package: nexus.audio-driver");
            WriteDebug("This package does not exist in current system version!");

            Console.WriteLine("");

            WriteMagenta("COSMOS", "Booted Successfully! Starting NexusOS, please wait!", 300);
            WriteMagenta("NEXUS", "NexusOS Booted Successfully, Welcome to Nexus!", 600);
            WriteMagenta("SYSTEM", "Starting nexus.interface-service, please wait!", 400);

            Console.WriteLine("");

            Thread.Sleep(1000);
        }
        
        public static void LoadInterfaceResources()
        {
            Interface.Wallpaper = new Bitmap(Resources.Files.DefaultWallpaper);
            Interface.Cursor = new Bitmap(Resources.Files.Cursor48);

            CosmosTTF.TTFManager.RegisterFont("KMB", Resources.Files.KodeMonoBold);

            Interface.StartInterface();
            TTFCache.CacheAllFonts();
        }
    
    }
}