using System.Text;

namespace fstat
{
    static class Program_12_7_
    {
        public static void Main(string[] args)
        {
            // `.` and `..` are relative paths,
            // the former referring to the current
            // directory and the latter referring
            // to the parent directory
            string dir = args.Length > 0 ? args[0] : ".";
            string[] dre = Directory.GetFileSystemEntries(dir);
            Array.Sort(dre, (x, y) => y.Length - x.Length);

            // Header format
            Console.WriteLine("Date        Time      Size          Path");
            foreach (string fsent in dre)
            {
                string path = Path.Combine(dir, fsent);
                bool isDir = Directory.Exists(path);
                bool isFile = File.Exists(path);

                // See Program_12_8_.cs:22
                StringBuilder @string = new();

                DateTime cd;
                if (isFile) cd = File.GetCreationTime(path);
                else cd = Directory.GetCreationTime(path);
                
                @string.Append(cd.ToShortDateString().PadRight(12));
                @string.Append(cd.ToShortTimeString().PadLeft(8, '0').PadRight(10));

                long size = 0;
                if (isFile) size = new FileInfo(path).Length;
                @string.Append(size.ToString().PadRight(12) + "  ");

                @string.Append(fsent);
                if (isDir) @string.Append('\\');
                if (isFile)
                {
                    // Get extension and remove the period
                    // from the beginning of the string
                    string ext = Path.GetExtension(path);
                    if (ext.Length != 0) ext = ext[1..];

                    if (Program_12_7_h.EXECUTABLES.Contains(ext.ToUpper()))
                    {
                        // https://stackoverflow.com/a/38670146
                        @string.Append('*');
                    }
                }

                Console.WriteLine(@string);
            }
        }
    }
}
