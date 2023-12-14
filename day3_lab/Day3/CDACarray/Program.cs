using System.Threading.Tasks.Dataflow;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace CDACarray
{
    internal class Program
    {


        //1. CDAC YCP has certain number of batches.each batch has certain number of students
        // accept number of batches. for each batch accept number of students.
        // create an array to store mark for each student (1 student has only 1 subject mark)
        //accept the marks.
        //display the marks.





        //batch->student
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome CDAC ");
            Console.Write("Enter the no. of batches");
            int batches =int.Parse(Console.ReadLine()); 

            Console.WriteLine("Batches: "+batches);


            int[][] marks = new int[batches][];

         


            Console.WriteLine();
            for (int i = 0; i < batches; i++)
            {
                Console.WriteLine($"Enter the no. of students for batch {i}");

                marks[i]=new int[int.Parse(Console.ReadLine())];


            }
            Console.WriteLine("Input");
            for (int i = 0;i < marks.Length; i++)
            {
                Console.WriteLine($"Batch : {i}");
                for(int j = 0; j < marks[i].Length; j++)
                {
                    Console.WriteLine($"Enter the marks for student {j} : ");
                    marks[i][j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Display");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine($"Batch : {i}");
                for (int j = 0; j < marks[i].Length; j++)
                {
                    Console.Write($"Marks for student {j} : ");
                    Console.WriteLine(marks[i][j]);
                }
            }



        }
    }
}