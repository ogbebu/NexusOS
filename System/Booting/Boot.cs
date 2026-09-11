using NexusOS.System.Shell;
using System;
using System.Threading;

namespace NexusOS.System.Booting
{
    public static class Boot
    {
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
            Printing.WriteDebug(message);
            Thread.Sleep(50);
        }
        private static void WriteMagenta(string name, string message, int delay = 50)
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

            WriteFail("Loading system package: nexus.graphics-stack");
            WriteDebug("This package does not exist in current system version!");

            WriteFail("Loading system package: nexus.audio-driver");
            WriteDebug("This package does not exist in current system version!");

            Console.WriteLine("");

            WriteMagenta("COSMOS", "Bootloader is starting NexusOS, please wait!", 300);

            WriteMagenta("NEXUS", "NexusOS Booted Successfully, Welcome to Nexus!", 500);

            Console.WriteLine("");
        }
    }
}