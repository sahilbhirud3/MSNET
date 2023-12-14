namespace Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Main Started");
                Employee o1 = new Employee("Amol", 60000, 1);
              //  throw new Exception("my exception");
                Console.WriteLine("Object o1 is created");
                Console.WriteLine("Emp No:");
                Console.WriteLine(o1.EmpNo);

                Console.WriteLine(o1);


               
            }

           catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
         
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
                    //Console.WriteLine("No blank names allowed.");
                    throw new Exception("No blank names allowed.");
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
                Console.WriteLine("in basic prop set");
                if (value < 10000 || value > 60000)
                {
                   // Console.WriteLine("in set Invalid range for basic");
                    throw new Exception("Invalid range for basic");
                    
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
                    //Console.WriteLine("Dept no must be greater than 0.");
                    throw new Exception("Dept no must be greater than 0.");
                }
                else
                {
                    deptNo = value;
                }
            }
        }

        public Employee(string name = "", decimal basic = 0, short deptNo = 0)
        {
            Console.WriteLine("In constr");
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptNo;
            this.EmpNo = ++idGenerator;
        }

        public decimal GetNetSalary()
        {
            return Basic * (decimal)0.10;
        }

        public override string ToString()
        {
            return "EmpNo = " + EmpNo + ", Name = " + Name + ",Basic = " + Basic + ", DeptNo = " + DeptNo;
        }


    }
}