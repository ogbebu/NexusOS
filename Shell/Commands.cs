using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace NexusOS.System.Shell
{
    public static class Commands
    {
        public static void RunCommand(string command)
        {
            string[] words = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("");

            if (words.Length > 0)
            {
                // Basic Commands & More in Future
                if (words[0] == "info")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("[System Informations]");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("- Name: NexusOS");
                    Console.WriteLine("- Author: " + Kernel.Author);
                    Console.WriteLine("- Version: " + Kernel.Version);
                    Console.WriteLine("- Edition: Beta");
                }
                else if (words[0] == "disc")
                {
                    if (words.Length > 1)
                    {
                        if (words[1] == "--help")
                        {
                            Console.WriteLine("Disc Available Arguments:");
                            Console.WriteLine("--format | Format your disc [Required before installation]");
                            Console.WriteLine("--free-space | Shows free space on your disc");
                        }
                        else if (words[1] == "--free-space")
                        {
                            long free = Kernel.VFS.GetAvailableFreeSpace(Kernel.Path);
                            Console.WriteLine("Available Space: " + free / (1024 * 1024) + "MB");
                        }
                        else if (words[1] == "--format")
                        {
                            if (Kernel.VFS.Disks[0].Partitions.Count > 0)
                            {
                                Kernel.VFS.Disks[0].DeletePartition(0);
                            }

                            Kernel.VFS.Disks[0].Clear();
                            Kernel.VFS.Disks[0].CreatePartition((int)(Kernel.VFS.Disks[0].Size / (1024 * 1024)));
                            Kernel.VFS.Disks[0].FormatPartition(0, "FAT32", true);

                            Printing.WriteSuccess("Format Finished Successfully!");
                            Printing.WriteWarning("Nexus will Reboot in 3 seconds...");

                            Thread.Sleep(3000);

                            Cosmos.System.Power.Reboot();
                        }
                        else
                        {
                            Printing.WriteError("Unknown Argument! Type disc --help to see all available arguments!");
                        }
                    }
                    else
                    {
                        Printing.WriteError("Unknown Argument! Type disc --help to see all available arguments!");
                    }
                }
                else if (words[0] == "dir")
                {
                    var Directories = Directory.GetDirectories(Kernel.Path);
                    var Files = Directory.GetFiles(Kernel.Path);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Directories [" + Directories.Length + "]");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    for (int i = 0; i < Directories.Length; i++)
                    {
                        Console.WriteLine(Directories[i]);
                    }

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Files [" + Files.Length + "]");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    for (int i = 0; i < Files.Length; i++)
                    {
                        Console.WriteLine(Files[i]);
                    }

                }
                else
                {
                    Printing.WriteError("Unknown Command! Type help to see all available commands!");
                }

                Console.WriteLine("");
            }
        }
    }
}
