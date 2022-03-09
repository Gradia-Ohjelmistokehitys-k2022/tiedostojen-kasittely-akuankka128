namespace fstat
{
    static class Program_12_5_
    {
        public static void Main()
        {
            FileStream x = File.Open("text1.txt", FileMode.Open, FileAccess.Read);
            
            // Stack allocation allows for increased
            // throughput and higher CPU cache hits
            Span<byte> buffer = new(new byte[x.Length]);
            x.Read(buffer);

            Console.WriteLine(string.Join(',', buffer.ToArray()));
        }
    }
}
