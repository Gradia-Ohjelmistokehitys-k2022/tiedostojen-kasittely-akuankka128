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

            // See Program_12_5_.cs:9
            Span<byte> buffer = stackalloc byte[1];

            while(fs.Read(buffer) > 0)
            {
                // StringBuilder is faster
                // than traditional concat
                StringBuilder sb = new(5);
                sb.Append("0x");
                sb.Append(buffer[0].ToString("X2"));
                sb.Append(' ');

                Console.Write(sb.ToString());

                // FileStream#Read moves the cursor
                // by one position when called, so
                // we should seek by 10 - 1 = 9 bytes
                fs.Seek(9, SeekOrigin.Current);
            }
        }
    }
}
