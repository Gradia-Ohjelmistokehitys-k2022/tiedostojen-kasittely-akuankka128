using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fstat
{
    static class Program_12_6_
    {
        public static void Main()
        {
            if(!File.Exists("binary.bin"))
                File.Create("binary.bin").Close();

            FileStream x = File.Open("binary.bin", FileMode.Truncate, FileAccess.ReadWrite);
            BinaryWriter bw = new(x);
            unchecked
            {
                bw.Write((float)Math.PI);
                bw.Write((int)4294967295);
                bw.Flush();
                x.Position = 0;
            }

            BinaryReader br = new(x);
            float f = br.ReadSingle();
            int i = br.ReadInt32();
            Console.WriteLine("{0} {1}", f, i);

            x.Close();
            br.Dispose();
            bw.Dispose();
        }
    }
}
