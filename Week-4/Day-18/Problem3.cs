

//Level-2 Problem 1: Employee Bonus Calculator
//Scenario
//Develop a console application that calculates employee bonus based on salary and years of experience.
//Requirements
//• Accept employee name, salary and years of experience.
//• Use if-else and conditional operator.
//• Bonus rules:
//   -Experience < 2 years: 5 % bonus
//   - 2 - 5 years: 10 % bonus
//   - > 5 years: 15 % bonus
//• Display final salary after bonus.
//Technical Constraints
//• Use double for salary.
//• Use if-else and ternary operator.
//• Use proper formatting for currency output.
//Sample Input
//Enter Name: Aisha
//Enter Salary: 50000
//Enter Experience: 4
//Sample Output
//Employee: Aisha
//Bonus: 5000
//Final Salary: 55000
//Expectations
//Accurate bonus calculation and correct usage of control statements.
//Learning Outcome
//Apply conditional logic and arithmetic operations in real-world scenarios.






namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Salary: ");
            double salary = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Experience in years: ");
            int experience = int.Parse(Console.ReadLine());

            double bonusPercentage;
            double bonusAmount;
            double finalSalary;

            if (experience<0)
            {
                Console.WriteLine("Experience cant be negative .");
            }
            else if(salary <=0)
            {
               Console.WriteLine("Salary cant be zero or negative .");
            }
            else
            {
                if (experience < 2)
                {
                    bonusPercentage = 0.05;

                }
                else if(experience <= 5){
                    bonusPercentage = 0.10;

                }
                else
                {
                    bonusPercentage = 0.15;

                }
                bonusAmount = salary>0 ? salary * bonusPercentage : 0; //Ternary Operator

                finalSalary = salary + bonusAmount;
                Console.WriteLine("Employee: " + name);
                Console.WriteLine("Bonus: " + bonusAmount);
                Console.WriteLine("Final Salary: " + finalSalary);
            }



            

            Console.ReadLine();
        }
    }
}
