

namespace fstat
{
    static class Program_12_8_
    {
        public static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                throw new ArgumentException("no file was given as an argument");
            }

            string file = Path.GetFullPath(args[0]);
            FileStream fs = File.OpenRead(file);
            Span<byte> buffer = new Span<byte>(new byte[1]);

            while(fs.Read(buffer) > 0)
            {
                Console.Write("0x" + buffer[0].ToString("X2") + ' ');
                fs.Seek(10, SeekOrigin.Current);
            }
        }
    }
}
