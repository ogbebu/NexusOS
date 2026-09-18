using Cobalt.TTF;
using System;
using System.IO;
using System.Threading;
using Cosmos.System.Graphics;

using NexusOS.System.Core;
using NexusOS.System.Shell;
using NexusOS.System.Graphics;
using System.Linq.Expressions;

namespace NexusOS.System.Booting
{
    public static class Boot
    {
        public static int IgnoredPackages = 0;

        private static void WriteSuccess(string message)
        {
            Printing.WriteSuccess(message);
            Thread.Sleep(50);
        }
        private static void WriteOk(string message)
        {
            Printing.WriteOk(message);
            Thread.Sleep(50);
        }
        private static void WriteFail(string message)
        {
            Printing.WriteFail(message);
            Thread.Sleep(50);
            IgnoredPackages++;
        }
        private static void WriteInfo(string message)
        {
            Printing.WriteInfo(message);
            Thread.Sleep(50);
        }
        private static void WriteDebug(string message)
        {
            if (NexusSettings.enabledDebugging == true)
            {
                Printing.WriteDebug(message);
                Thread.Sleep(50);
            }
        }

        public static void BootPhase1()
        {
            // Code currently only working for Visual Effect
            Console.Clear();

            WriteInfo("Loading System Packages");
            WriteOk("Loading system package: nexus.power-management");
            WriteOk("Loading system package: nexus.command-prompt");
            WriteOk("Loading system package: nexus.process-manager");
            WriteOk("Loading system package: nexus.file-system");
            WriteOk("Loading system package: nexus.system-services");
            WriteOk("Loading system package: nexus.svga-interface");
            WriteOk("Loading system package: nexus.processing-service");
            WriteOk("Loading system package: nexus.interface-service");

            WriteFail("Loading system package: nexus.memory-manager");
            WriteDebug("This package does not exist in current system version!");
            WriteFail("Loading system package: nexus.device-manager");
            WriteDebug("This package does not exist in current system version!");
            WriteFail("Loading system package: nexus.input-manager");
            WriteDebug("This package does not exist in current system version!");
            WriteFail("Loading system package: nexus.network-manager");
            WriteDebug("This package does not exist in current system version!");
            WriteFail("Loading system package: nexus.display-driver");
            WriteDebug("This package does not exist in current system version!");
            WriteFail("Loading system package: nexus.audio-driver");
            WriteDebug("This package does not exist in current system version!");

            Console.WriteLine("");

            if (IgnoredPackages != 0) 
                Printing.WriteDebug("Ignored unavailable packages, total ignored packages: " + IgnoredPackages);

            Console.WriteLine("");

            WriteSuccess("Nexus Booted Successfully! Starting Interface Service, please wait!");
            LoadInterfaceResources();

            WriteInfo("Starting Interface Service, please wait!"); 
            StartInterfaceService();

        }
        
        public static void LoadInterfaceResources()
        {
            try
            {
                Thread.Sleep(500);
                Interface.Wallpaper = new Bitmap(Resources.Files.DefaultWallpaper);
                Interface.Cursor = new Bitmap(Resources.Files.Cursor48);
                CosmosTTF.TTFManager.RegisterFont("KMB", Resources.Files.KodeMonoBold);
                WriteOk("Prepared and loaded Interface Service!");
            } 
            catch
            {
                Thread.Sleep(500);
                WriteFail("Failed to load Interface Service!");
            }
        }
    
        public static void StartInterfaceService()
        {
            try
            {
                Console.WriteLine("");
                Thread.Sleep(950);
                Interface.StartInterface();
                TTFCache.CacheAllFonts();
            }
            catch
            {
                WriteFail("Fatal System Error! | ID: 0013 | Description: Unable to load Interface Service!");
                Printing.WriteWarning("Nexus will automaticaly reboot in 3 seconds, please wait!");

                Thread.Sleep(3000);
                Cosmos.System.Power.Reboot();
            }
        }
    }
}