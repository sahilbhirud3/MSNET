
namespace Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee o1 = new Employee("Amol", 123465, 10);
            Console.WriteLine("Object o1 is created");
            Console.WriteLine("Calculated Net Salary: "+o1.GetNetSalary());
            Console.WriteLine();
            Console.WriteLine();

            Employee o2 = new Employee("Amol", 123465);
            Console.WriteLine("Object o2 is created");
            Employee o3 = new Employee("Amol");
            Console.WriteLine("Object o3 is created");
            Employee o4 = new Employee();
            Console.WriteLine("Object o4 is created");

            Console.WriteLine(o1);
            Console.WriteLine(o2);
            Console.WriteLine(o3);
            Console.WriteLine(o4);

            Console.WriteLine(o1.EmpNo);
            Console.WriteLine(o2.EmpNo);
            Console.WriteLine(o3.EmpNo);
            Console.WriteLine(o3.EmpNo);
            Console.WriteLine(o2.EmpNo);
            Console.WriteLine(o1.EmpNo);
        }
    }

     class Employee
    {
        private static int idGenerator;

        static Employee()
        {
            idGenerator = 0;
        }

        private string name;
        public string Name
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
                if (value < 10000 && value > 60000)
                {
                    Console.WriteLine("Invalid range for basic");
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

        public Employee(string name = "", decimal basic = 0, short deptNo = 0)
        {
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptNo;
            this.EmpNo = ++idGenerator;
        }

        public decimal GetNetSalary()
        {
            return Math.Class1.GetNetSalary(Basic);
        }

      //  public abstract string check();

        public override string ToString()
        {
            return "EmpNo = " + EmpNo + ", Name = " + Name + ",Basic = " + Basic + ", DeptNo = " + DeptNo;
        }


    }
   



}