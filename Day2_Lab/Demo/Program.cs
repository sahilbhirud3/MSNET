namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.GetNetSalary();//emp
            Console.WriteLine();
            // employee = new Manager();
            //employee.GetNetSalary();//mgr
            Employee mgr = new Manager();
            mgr.GetNetSalary();
            


        }
    }

    class Employee {


       virtual public void GetNetSalary()
        {
            Console.WriteLine("In Employee getnetsal");
        }
    }
    class Manager: Employee
    {

        public new void GetNetSalary()
        {
            Console.WriteLine("In Manager getnetsal");
        }
    }





}