using Cosmos.Core.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusOS.System.Core
{
    public static class NexusCore
    {
        static int lastHeapCollect;

        public static void Optimize()
        {
            if (lastHeapCollect >= 20)
            {
                Heap.Collect();
                lastHeapCollect = 0;
            }
            else
            {
                lastHeapCollect++;
            }
        }
    }
}
