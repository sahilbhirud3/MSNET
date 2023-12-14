using System.Runtime.Serialization.Json;

namespace EmployeeSerialization
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome....");
            Console.WriteLine("Single Writing..");

            SingleWrite();
            Console.WriteLine("Single Reading...");
            SingleRead();


            Console.WriteLine("Bulk Writing...");

            BulkWrite();
            Console.WriteLine("Bulk Reading...");
            BulkRead();



            Console.WriteLine("END");
        }

        static void SingleWrite()
        {

            Employee emp = new Employee("sahil",12000);
          
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Employee));
            Stream s = new FileStream("C:\\sahil_amar\\emp.json", FileMode.Create);
            js.WriteObject(s, emp);
            s.Close();
        }

        static void BulkWrite() {

            List<Employee> list = new List<Employee>();

            list.Add( new Employee("sahil", 12000));
            list.Add(new Employee("amar", 13000));
            list.Add(new Employee("aarti", 14000));
            list.Add(new Employee("arshraj", 15000));
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Employee>));
            Stream s = new FileStream("C:\\sahil_amar\\emps.json", FileMode.Create);
            js.WriteObject(s, list);
            s.Close();



        }


        static void BulkRead()
        {
            List<Employee> list = new List<Employee>(); 
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Employee>));
            Stream s = new FileStream("C:\\sahil_amar\\emps.json", FileMode.Open);
            list = (List<Employee>)js.ReadObject(s);
            s.Close();
            list.ForEach(e => Console.WriteLine(e));


        }

        static void SingleRead()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Employee));
            Stream s = new FileStream("C:\\sahil_amar\\emp.json", FileMode.Open);
            Employee emp = (Employee)js.ReadObject(s);
            s.Close();
            Console.WriteLine(emp);
        }




    }

    [Serializable]
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




}