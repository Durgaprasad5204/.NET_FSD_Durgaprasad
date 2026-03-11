//Level - 1 Problem 1: Student Grade Evaluator
//Scenario
//You are developing a console-based application in .NET 8 for a school. The application should evaluate a student’s marks and assign a grade based on predefined rules.
//Requirements
//• Accept student name and marks (0-100).
//• Use if-else statements to determine grade.
//• Display grade as A, B, C, D or Fail.
//• Handle invalid input using conditional checks.
//Technical Constraints
//• Use C# (.NET 8 Console Application).
//• Use appropriate data types (string, int).
//• Use if-else control flow.
//• Do not use advanced concepts like classes or LINQ.
//Sample Input
//Enter Name: Rahul
//Enter Marks: 78
//Sample Output
//Student: Rahul
//Grade: B
//Expectations
//Program should correctly evaluate grade and handle edge cases like marks below 0 or above 100.
//Learning Outcome
//Understand variables, data types, input/output handling and if-else control statements in C#.



namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string name;
            int marks;
            string grade;

            Console.Write("Enter your name: ");
            name = Console.ReadLine();


            Console.Write("Enter your marks: ");
            bool isValid = int.TryParse(Console.ReadLine(), out marks);
            if (isValid==false)
            {
                Console.WriteLine("Invalid input for marks");
            }

            else if (marks < 0 || marks > 100) {
                Console.WriteLine("Invalid Marks");

            }
            else
            {
                
                if (marks >= 85)
                {
                    grade = "A";
                }
                else if (marks >= 70)
                {
                    grade = "B";
                }
                else if (marks >= 50)
                {
                    grade = "C";
                }
                else if (marks >= 35)
                {
                    grade = "D";
                }
                else
                {
                    grade = "Fail";

                }

                Console.WriteLine("Student: " + name);
                Console.WriteLine("Grade: " + grade);
            }

                Console.ReadLine();
        }
    }
}
