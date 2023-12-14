namespace day8_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            writeFile();
            readFile();

        }



        static void writeFile()
        {
            StreamWriter writer = File.CreateText("C:\\sahil_amar\\new.txt");
            writer.WriteLine("1.hello world");
            writer.WriteLine("2.this file is auto created at :" + System.DateTime.Now);
            writer.WriteLine("3.END");
            writer.Close();

            Console.WriteLine("File Created Successfully..");
        }

        static void readFile()
        {
            Console.WriteLine("File Reading...");

            string line;
            StreamReader reader = File.OpenText("C:\\sahil_amar\\new.txt");
           while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }



}
}