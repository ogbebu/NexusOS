
// =============================================== \\
//    Licensed under the MIT License © Zeroday     \\
//       NexusOS | Current Version: 0.0.0.1        \\
// =============================================== \\

// This project started as a learning project based on the tutorials below.
// Some parts were adapted from the tutorials, while most of the current functionality and 
// modifications were developed by me, both tutorials are in Polish, so subtitles are recommended.

// Szymekk - Jak zrobić własny system operacyjny? (Cosmos Tutorial) #1
// https://www.youtube.com/watch?v=aohtSDgARWw&t=45s
// Szymekk - Jak zrobić GUI do systemu? (Cosmos Tutorial) #2
// https://www.youtube.com/watch?v=oGZcq_4140U&t=216s

using Cosmos.System.FileSystem;
using NexusOS.System.Booting;
using NexusOS.System.Graphics;
using NexusOS.System.Shell;

using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using NexusOS.System.Core;

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
            Console.SetWindowSize(90, 30);
            Console.OutputEncoding = Cosmos.System.ExtendedASCII.CosmosEncodingProvider.Instance.GetEncoding(437);

            VFS = new Cosmos.System.FileSystem.CosmosVFS();
            Cosmos.System.FileSystem.VFS.VFSManager.RegisterVFS(VFS);

            Boot.BootPhase1();
        }

        protected override void Run()
        {
            Interface.Update();
            NexusCore.Optimize();
        }
    }
}

// To-Do:
// Start Setup
// Install OS
// Reboot
// Creating User
// Login
// Logout + Shutdown
