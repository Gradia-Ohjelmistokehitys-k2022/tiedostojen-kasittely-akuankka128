using FStat;

namespace fstat
{
    static class Program_12_2_
    {
        public static void Main()
        {
            // I'm sure this wasn't what you meant by
            // "Jatka tehtävän 12.1 pääohjelmaa," but
            // I'm doing it anyway
            Program_12_1_.Main(new string[]
            {
                "--file",
                "placeholder"
            });

            // QOTD: What's the worst way you've seen
            // someone write data to a file?
            FileStream x = File.Create("text1.txt");
            Span<byte> data = new(new byte[]
            {
                0x48, 0x65, 0x6C, 0x6C,
                0x6F, 0x2C, 0x20, 0x77,
                0x6F, 0x72, 0x6C, 0x64,
                0x21, 0x0A
            });

            x.Write(data);
        }
    }
}
