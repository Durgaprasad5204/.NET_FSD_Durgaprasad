
//Level - 1 Problem 2: Employee Salary Calculator
//Scenario:
//A company wants to calculate employee salaries using inheritance.All employees have a base salary, but different roles calculate bonuses differently.
//Requirements:
//1.Create a base class Employee with Name and BaseSalary properties.
//2. Create derived classes Manager and Developer.
//3. Override a virtual method CalculateSalary().
//4. Manager gets 20% bonus, Developer gets 10% bonus.
//Technical Constraints:
//• Use inheritance and method overriding.
//• Apply polymorphism using base class reference.
//• Use properties for salary details.
//Expectations:
//• Demonstrate runtime polymorphism.
//• Avoid code duplication.
//• Display final calculated salary.
//Learning Outcome:
//• Understand inheritance hierarchy.
//• Implement polymorphism using virtual and override.
//• Write reusable and extensible code.
//Sample Input: 
//BaseSalary = 50000
//Sample Output: 
//Manager Salary = 60000, Developer Salary = 55000



using System;

namespace ConsoleApp1
{
    class Employee
    {
        // Properties
        public string Name { get; set; }

        private double baseSalary;
        public double BaseSalary
        { 
            get { return baseSalary; }
            set
            {
                               if (value < 0)
                {
                    Console.WriteLine("Salary must be greater than Zero.");
                    baseSalary = 0;
                }
                else
                {
                    baseSalary = value;
                }

            }
        }

        // Virtual Keyword for method overriding
        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }

    // Derived Class  Manager
    class Manager : Employee
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.20);
        }
    }

    // Derived Class - Developer
    class Developer : Employee
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.10);
        }
    }


//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.Write("Enter Base Salary: ");
//            double salary = double.Parse(Console.ReadLine());

//            // Runtime Polymorphism
//            Employee emp1 = new Manager();
//            emp1.BaseSalary = salary;

//            Employee emp2 = new Developer();
//            emp2.BaseSalary = salary;

//            Console.WriteLine("Manager Salary = " + emp1.CalculateSalary());
//            Console.WriteLine("Developer Salary = " + emp2.CalculateSalary());


//            Console.ReadLine();
//        }
//    }
//}