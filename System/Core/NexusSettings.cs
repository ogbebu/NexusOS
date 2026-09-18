using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusOS.System.Core
{
    public static class NexusSettings
    {
        // Booting Settings
        public static bool enabledDebugging = false; // Toggle debugging during system booting process [Default: false]
        public static bool fastBoot = false;         // Toggle fast boot for graphics mode [Default: false]

        // Behaviour Settings
        public static bool forceInstall = false;     // Forces user to install system first [Default: false]

        // Display Settings
        public static bool graphicsMode = true;      // Switches between bash & graphics modes [Default: true]
    }
}
