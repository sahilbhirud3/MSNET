 namespace StringExtension
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome!");
            string str1 = "sahil";
            Console.Write("No of Vowels in string is : ");
            Console.WriteLine(str1.findVowelsCount());

        }
    }
    public static class StringExtension
    {
        public static int findVowelsCount(this string str1)
        {
            int count = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == 'a' || str1[i] == 'e' || str1[i] == 'i' || str1[i] == 'o' || str1[i] == 'u' || str1[i] == 'A' || str1[i] == 'E' || str1[i] == 'I' || str1[i] == 'O' || str1[i] == 'U')
                    count++;
            }
            return count;
        }
    }


}