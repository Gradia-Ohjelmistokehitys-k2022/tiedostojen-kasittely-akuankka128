using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fstat
{
    static class Program_12_3_
    {
        public static void PrintTable<T>(T title, string line)
        {
            int strlen = line.Length;
            int conlen = Console.WindowWidth;

            if(strlen > conlen - 4)
            {
                line = line.Substring(0, conlen - 7) + "...";
                strlen = line.Length;
            }

            int len = Math.Min(conlen, strlen);
            string sep = new string('-', len + 4);

            Console.WriteLine(sep);
            Console.WriteLine("| Line " + title?.ToString()?.PadRight(len - 5) + " |");
            Console.WriteLine(sep);
            Console.WriteLine("| " + line.PadRight(len) + " |");
            Console.WriteLine(sep);
        }

        public static void PrintList(string line)
        {
            Console.WriteLine("* " + line);
        }

        public static void PrintString(string line)
        {
            Console.WriteLine(line);
        }

        public static void Main()
        {
            FileStream x;

            if (File.Exists("text1.txt"))
            {
                x = File.OpenRead("text1.txt");
                StreamReader reader = new(x);

                string? line;
                //int loops = 0;
                while((line = reader.ReadLine()) != null)
                {
                    // Example usage:
                    // PrintTable(loops++, line);
                    // PrintList(line);
                    // PrintString(line);
                }
            }
        }
    }
}
