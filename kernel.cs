// =============================================== \\
//    Licensed under the MIT License © Zeroday     \\
//       NexusOS | Current Version: 0.0.0.1        \\
// =============================================== \\

using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace NexusOS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            // Simple Boot Message just to test is everything working correct.
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[SUCCESS] Cosmos booted successfully.");
            Console.WriteLine("[MESSAGE] Welcome to NexusOS!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected override void Run()
        {
            // Didn't changed anything here yet, just created project and updated Kernel.cs on Github.
            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);
        }
    }
}
