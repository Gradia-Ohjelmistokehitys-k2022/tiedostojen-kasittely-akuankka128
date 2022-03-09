namespace FStat
{
    static class Program_12_1_
    {
        static Dictionary<string, string> ParseArgs(string[] args)
        {
            // Store parsed arguments in key-value pairs
            Dictionary<string, string> result = new();

            for (int i = 0, last = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("--"))
                {
                    last = i;
                    result[args[i]] = args[++i];
                }
                else
                {
                    // If we have multiple/separated
                    // values per a single key
                    result[args[last]] += ' ' + args[i];
                }
            }

            return result;
        }

        public static void Main(string[] args)
        {
            Dictionary<string, string> parsed = ParseArgs(args);
            parsed.TryGetValue("--file", out string? filename);

            if (filename == null)
            {
                Console.WriteLine("No `--file` found. Check your syntax.");
                Environment.Exit(1);
            }
            
            const string exist = "fstat: file {0} exists";
            const string notexist = "fstat: file {0} doesn't exist";
            const string dir = "fstat: {0}: is a directory";

            if (File.Exists(filename)) Console.WriteLine(exist, filename);
            else if (Directory.Exists(filename)) Console.WriteLine(dir, filename);
            else Console.WriteLine(notexist, filename);
        }
    }
}