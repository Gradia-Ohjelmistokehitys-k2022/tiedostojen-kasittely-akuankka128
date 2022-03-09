using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fstat
{
    static class Program_12_5_
    {
        public static void Main()
        {
            FileStream x = File.Open("text1.txt", FileMode.Open, FileAccess.Read);
            Span<byte> buffer = new(new byte[x.Length]);
            x.Read(buffer);

            Console.WriteLine(string.Join(',', buffer.ToArray()));
        }
    }
}
