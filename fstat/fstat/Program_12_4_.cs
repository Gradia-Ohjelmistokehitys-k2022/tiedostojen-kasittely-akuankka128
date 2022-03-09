namespace fstat
{
    static class Program_12_4_
    {
        public static void Main()
        {
            FileStream x = File.Open("text1.txt", FileMode.Append);
            StreamWriter y = new(x);
            y.WriteLine("woo-woo");
            y.Close();

            FileStream z = File.Open("text1.txt", FileMode.Open, FileAccess.Read);
            StreamReader w = new(z);

            string? line;

            while ((line = w.ReadLine()) != null)
                Program_12_3_.PrintList(line);

            w.Close();
        }
    }
}
