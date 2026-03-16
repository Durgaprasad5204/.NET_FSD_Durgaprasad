using System;

namespace ConsoleApp1
{
    public class Employee
    {
        //  Private Fields (Strong Encapsulation)
        private string _fullName;
        private int _age;
        private decimal _salary;

        //  Readonly Property
        public string EmployeeId { get; }

        //  FullName Property (Validation + Trim)
        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Full name cannot be empty.");

                _fullName = value.Trim();
            }
        }

        //  Age Property (18–80)
        public int Age
        {
            get => _age;
            set
            {
                if (value < 18 || value > 80)
                    throw new ArgumentException("Age must be between 18 and 80.");

                _age = value;
            }
        }

        //  Salary Property (Public Get, Private Set)
        public decimal Salary
        {
            get => _salary;
            private set
            {
                if (value < 1000)
                    throw new ArgumentException("Salary cannot be below 1000.");

                _salary = value;
            }
        }

        //  Constructor (Safe Initialization)
        public Employee(string name, decimal salary, int age, string empId = null)
        {
            EmployeeId = string.IsNullOrWhiteSpace(empId)
                ? "E" + Guid.NewGuid().ToString("N").Substring(0, 5)
                : empId;

            FullName = name;   // Using property → validation reused
            Age = age;
            Salary = salary;
        }

        //  Give Raise Method
        public void GiveRaise(decimal percentage)
        {
            if (percentage <= 0 || percentage > 30)
                throw new ArgumentException("Raise must be between 0 and 30 percent.");

            decimal increase = Salary * percentage / 100;
            Salary = Salary + increase;

            Console.WriteLine("Raise Applied. New Salary: " + Salary);
        }

        //  Deduct Penalty Method
        public bool DeductPenalty(decimal amount)
        {
            if (amount <= 0)
                return false;

            if (Salary - amount < 1000)
                return false;

            Salary = Salary - amount;
            Console.WriteLine("Penalty Deducted. New Salary: " + Salary);
            return true;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("Marko Horvat", 4500m, 35);

            Console.WriteLine("Employee ID: " + emp.EmployeeId);
            Console.WriteLine("Salary: " + emp.Salary);

            emp.GiveRaise(15);

            bool ok = emp.DeductPenalty(500);
            Console.WriteLine("Penalty Status: " + ok);

            emp.FullName = "Marko Horvat Jr.";

            Console.WriteLine("Updated Name: " + emp.FullName);
            Console.WriteLine("Age: " + emp.Age);

            Console.ReadLine();
        }
    }
}