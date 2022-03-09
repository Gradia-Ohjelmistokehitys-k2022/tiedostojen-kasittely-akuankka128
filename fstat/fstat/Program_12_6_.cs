namespace fstat
{
    static class Program_12_6_
    {
        public static void Main()
        {
            // Check if file exists because
            // FileMode.Truncate doesn't
            // create files automatically
            if (!File.Exists("binary.bin"))
                File.Create("binary.bin").Close();

            FileStream x = File.Open("binary.bin", FileMode.Truncate, FileAccess.ReadWrite);
            BinaryWriter bw = new(x);

            unchecked
            {
                bw.Write((float)Math.PI);
                // Intentional overflow
                bw.Write((int)4294967295);

                // Reset stream for reading
                // without closing it
                bw.Flush();
                x.Position = 0;
            }

            BinaryReader br = new(x);

            // Single-precision float..
            float f = br.ReadSingle();
            int i = br.ReadInt32();
            
            Console.WriteLine("{0} {1}", f, i);

            // Close + free resources
            x.Close();
            br.Dispose();
            bw.Dispose();
        }
    }
}
