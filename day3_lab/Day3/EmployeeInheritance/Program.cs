﻿using System.Xml.Linq;



//Employee
//   Prop	
//	string Name -> no blanks
//	int EmpNo -> readonly, autogenerated
//	short DeptNo -> > 0

//    abstract decimal Basic
//   Methods
//    abstract decimal CalcNetSalary()


//Manager: Employee
//   Prop

//    string Designation -> cant be blank


//GeneralManager : Manager
//   Prop
// 	string Perks -> no validations

//CEO : Employee
//      Make CalNetSalary() a sealed method

//NOTE : Overloaded constructors in all classes calling their base class constructor
//All classes must implement IDbFunctions interface
//All classes to override the abstract members defined in the base class(Employee). Basic property to have different validation in different classes.
//CalcNetSalary() to have different validation in different classes.
namespace EmployeeInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            Employee employee = new Manager("abc", 10000, 10, "Manager");
            (employee as IDbFunctions).insert();
            Console.WriteLine("Salary of Manager");
            Console.WriteLine(employee.CalcNetSalary());
            (employee as IDbFunctions).delete();

            Console.WriteLine("-------------------------------------------");




            employee = new GeneralManager("xyz", 25000, 10, "General Manager", "chocalate");
            (employee as IDbFunctions).insert();
            Console.WriteLine("Salary of GeneralManager");
            Console.WriteLine(employee.CalcNetSalary());
            (employee as IDbFunctions).delete();


            Console.WriteLine("-------------------------------------------");
            employee = new CEO("cde", 25000, 10);
            ((IDbFunctions)employee).insert();
            Console.WriteLine("Salary of CEO");
            Console.WriteLine(employee.CalcNetSalary());
            (employee as IDbFunctions).delete();

        }
    }


    interface IDbFunctions
    {
        void insert();
        void update();
        void delete();
    }



    abstract class Employee : IDbFunctions
    {
        private static int idGenerator;

        static Employee()
        {
            idGenerator = 0;
        }

        protected string? name;
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

        protected int empNo;
        public int EmpNo { get; }

        protected decimal basic;
        abstract public decimal Basic { get; set; }


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

        public abstract decimal CalcNetSalary();

        //  public abstract string check();

        public override string ToString()
        {
            return "EmpNo = " + EmpNo + ", Name = " + Name + ",Basic = " + Basic + ", DeptNo = " + DeptNo;
        }

        void IDbFunctions.insert()
        {
            Console.WriteLine("Emp Inserted..");
        }

        void IDbFunctions.update()
        {
            Console.WriteLine("Emp Updated..");
        }


        void IDbFunctions.delete()
        {
            Console.WriteLine("Emp Deleted..");
        }

    }
    class Manager : Employee, IDbFunctions 
    {
        private string? designation;
        public string Designation
        {
            get
            {
                return designation;
            }
            set
            {
                if (value.Length == 0)
                {
                    Console.WriteLine("No blank designation allowed.");
                }
                else
                {
                    designation = value;
                }
            }
        }


        public Manager(string name = "default", decimal basic = 10000, short deptNo = 1, string designation = "default") : base(name, basic, deptNo)
        {
            Designation = designation;
        }


        public override decimal Basic
        {
            get
            {
                return basic;

            }
            set
            {
                if (value < 10000)
                {
                    Console.WriteLine("Basic less than not allowed");
                }
                else
                {
                    basic = value;
                }
            }
        }

        public override decimal CalcNetSalary()
        {
            return Basic + 1000;
        }




        void IDbFunctions.insert()
        {
            Console.WriteLine("Mgr Inserted..");
        }

        void IDbFunctions.update()
        {
            Console.WriteLine("Mgr Updated..");
        }


        void IDbFunctions.delete()
        {
            Console.WriteLine("Mgr Deleted..");
        }

    }


    class GeneralManager : Manager,IDbFunctions
    {
        private string? perks;
        public string? Perks { get; set; }


        public GeneralManager(string name = "default", decimal basic = 20000, short deptNo = 1, string designation = "default", string perks = "default") : base(name, basic, deptNo)
        {
            Perks = perks;

        }


        public override decimal Basic
        {
            get
            {
                return basic;

            }
            set
            {
                if (value < 20000)
                {
                    Console.WriteLine("Basic less than not allowed");
                }
                else
                {
                    basic = value;
                }
            }
        }

        public override decimal CalcNetSalary()
        {
            return Basic + 2000;
        }
        void IDbFunctions.insert()
        {
            Console.WriteLine("Gen.Mgr Inserted..");
        }

        void IDbFunctions.update()
        {
            Console.WriteLine("Gen.Mgr Updated..");
        }


        void IDbFunctions.delete()
        {
            Console.WriteLine("Gen.Mgr Deleted..");
        }

    }



    class CEO : Employee,IDbFunctions
    {

        public CEO(string name = "default", decimal basic = 25000, short deptNo = 1) : base(name, basic, deptNo)
        {


        }

        public override decimal Basic
        {
            get
            {
                return basic;

            }
            set
            {
                if (value < 25000)
                {
                    Console.WriteLine("Basic less than not allowed");
                }
                else
                {
                    basic = value;
                }
            }
        }

        public sealed override decimal CalcNetSalary()
        {
            return Basic + 3000;
        }

        void IDbFunctions.insert()
        {
            Console.WriteLine("CEO Inserted..");
        }

        void IDbFunctions.update()
        {
            Console.WriteLine("CEO Updated..");
        }


        void IDbFunctions.delete()
        {
            Console.WriteLine("CEO Deleted..");
        }


    }
}



