using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace EmployeeArray
{

    //Create an array of Employee class objects
    //    Accept details for all Employees
    //    Display the Employee with highest Salary
    //    Accept EmpNo to be searched.Display all details for that employee.


    class Employee
    {
        private static int idGenerator;

        static Employee()
        {
            idGenerator = 0;
        }

        private string? name;
        public string? Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value.Length == 0)
                {
                    Console.WriteLine("No blank names allowed.");
                }
                else
                {
                    name = value;
                }
            }
        }

        private int empNo;
        public int EmpNo { get; }

        private decimal basic;
        public decimal Basic
        {
            get
            {
                return basic;
            }
            set
            {
                if (value < 10000)
                {
                    Console.WriteLine("Basic cant be less than 10000");
                }
                else
                {
                    basic = value;
                }
            }
        }


        private short deptNo;
        public short DeptNo
        {
            get
            {
                return deptNo;
            }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Dept no must be greater than 0.");
                }
                else
                {
                    deptNo = value;
                }
            }
        }

        public Employee(string name = "default", decimal basic = 10000, short deptNo = 1)
        {
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptNo;
            this.EmpNo = ++idGenerator;
        }

        public decimal CalcNetSalary()
        {
            return Basic + 1000;

        }

        //  public abstract string check();

        public override string ToString()
        {
            return "EmpNo = " + EmpNo + ", Name = " + Name + ",Basic = " + Basic + ", DeptNo = " + DeptNo;
        }


    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Enter How many Employee wants to store");
            int size = int.Parse(Console.ReadLine());

            Employee[] emps = new Employee[size];

            Accept(emps);
            Display(emps);
            DisplayHighestSalaryEmp(emps);

            Console.WriteLine("Enter employee id for searching");
            DisplayEmployeeById(emps, int.Parse(Console.ReadLine()));




        }


        static void Accept(Employee[] emps)
        {
            for (int i = 0; i < emps.Length; i++)
            {
                Console.WriteLine("Enter name ,basic department no");
                emps[i] = new Employee(Console.ReadLine(), decimal.Parse(Console.ReadLine()), short.Parse(Console.ReadLine()));

            }
        }

        static void Display(Employee[] emps)
        {
            Console.WriteLine("-----------Employee Details---------");
            for (int i = 0; i < emps.Length; i++)
            {

                Console.WriteLine(emps[i]);
            }
            Console.WriteLine("-----------End---------\n");

        }



        static void DisplayHighestSalaryEmp(Employee[] emps)
        {
            Console.WriteLine("-----------Employee with Highest Salary---------");

            decimal high = decimal.MinValue;
            Employee emp = null;
            for (int i = 0; i < emps.Length; i++)
            {

                if (emps[i].Basic > high)
                {
                    high = emps[i].Basic;
                    emp = emps[i];
                }
            }
            Console.WriteLine(emp);
            Console.WriteLine("-----------End---------\n");


        }


        static void DisplayEmployeeById(Employee[] emps, int id)
        {
            Employee emp = null;

            for (int i = 0; i < emps.Length; i++)
            {

                if (emps[i].EmpNo == id)
                {
                    emp = emps[i];
                    break;

                }
            }
            Console.WriteLine($"-----------Employee Details with {id}---------");
            if (emp == null)
            {
                Console.WriteLine("NOT FOUND");
            }
            else
            {
                Console.WriteLine(emp);
            }


            Console.WriteLine("-----------End---------\n");
        }


    }
}