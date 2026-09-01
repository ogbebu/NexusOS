using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusOS.System.Shell
{
    public static class Printing
    {
        public static void WriteSuccess(string success)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[SUCCESS] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(success);
        }
        public static void WriteWarning(string warn)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[WARNING] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(warn);
        }
        public static void WriteError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[ERROR] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(error);
        }
        public static void WriteInfo(string info)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[INFO] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(info);
        }

        public static void WriteMagenta(string bracketText, string text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[" + bracketText + "] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
        }

        public static void WriteGrayText(string symbol, string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(symbol + " " + text);
        }

        public static string CenterText(string text)
        {
            int width = 90;
            int padding = (width - text.Length) / 2;

            string centeredText = text.PadLeft(padding + text.Length).PadRight(width);
            return centeredText;
        }
    }
}
