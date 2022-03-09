

using System.Text;

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
            Span<byte> buffer = stackalloc byte[1];

            while(fs.Read(buffer) > 0)
            {
                StringBuilder sb = new(5);
                sb.Append("0x");
                sb.Append(buffer[0].ToString("X2"));
                sb.Append(' ');

                Console.Write(sb.ToString());
                fs.Seek(10, SeekOrigin.Current);
            }
        }
    }
}
