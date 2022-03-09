namespace fstat
{
    static class Program_12_3_
    {
        public static void PrintTable<T>(T title, string line)
        {
#region Prevent overflow
            int strlen = line.Length;
            int conlen = Console.WindowWidth;

            if (strlen > conlen - 4)
            {
                line = string.Concat(line.AsSpan(0, conlen - 7), "...");
                strlen = line.Length;
            }

            int len = Math.Min(conlen, strlen);
#endregion

            string sep = new('-', len + 4);

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
            if (!File.Exists("text1.txt"))
                return;

            FileStream x = File.OpenRead("text1.txt");
            StreamReader reader = new(x);

            string? line;
            // int loops = 0;
            while ((line = reader.ReadLine()) != null)
            {
                // Example usage:
                // PrintTable(loops++, line);
                // PrintList(line);
                // PrintString(line);
            }
        }
    }
}
