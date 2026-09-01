
// =============================================== \\
//    Licensed under the MIT License © Zeroday     \\
//       NexusOS | Current Version: 0.0.0.1        \\
// =============================================== \\

using Cosmos.System.FileSystem;
using NexusOS.System.Shell;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace NexusOS
{
    public class Kernel : Sys.Kernel
    {
        public static string Author = "Zeroday";
        public static string Version = "0.0.1";
        public static string Path = @"0:\";

        public static CosmosVFS VFS;
        
        protected override void BeforeRun()
        {
            // Booting Process [In future booting section will be included in System/Booting]
            Console.SetWindowSize(90, 30);
            Console.OutputEncoding = Cosmos.System.ExtendedASCII.CosmosEncodingProvider.Instance.GetEncoding(437);

            VFS = new Cosmos.System.FileSystem.CosmosVFS();
            Cosmos.System.FileSystem.VFS.VFSManager.RegisterVFS(VFS);

            Console.Clear();
            Printing.WriteSuccess("COSMOS Booted Successfully! Booting NexusOS.");
            Printing.WriteInfo("Welcome to NexusOS! System is running on version: " + Version);
            Console.WriteLine("");
        }

        protected override void Run()
        {
            Console.Write(Path + ">");
            var command = Console.ReadLine();
        }
    }
}
