

//Level - 1 Problem 2: Simple Calculator Using Switch
//Scenario
//Create a simple calculator application that performs basic arithmetic operations.
//Requirements
//• Accept two numbers from user.
//• Accept operator (+, -, *, /).
//• Use switch statement to perform operation.
//• Display result.
//Technical Constraints
//• Use int or double data types.
//• Use switch-case statement.
//• Handle division by zero.
//Sample Input
//Enter First Number: 10
//Enter Second Number: 5
//Enter Operator: *
//Sample Output
//Result: 50
//Expectations
//Correct operator selection and proper validation of inputs.
//Learning Outcome
//Understand switch statements, arithmetic operators and control flow in C#.




namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number: ");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Operator (+,-,*,/):");

            char op = char.Parse(Console.ReadLine());

            int result = 0;

            switch(op)
            {
                case '+':
                    result = x + y;
                    Console.WriteLine("Result: " + result);
                    break;
                case '-':
                    result = x - y;
                    Console.WriteLine("Result: " + result);
                    break;
                case '*':
                    result = x * y;
                    Console.WriteLine("Result: " + result);
                    break;
                case '/':
                    if (y == 0)
                    {
                        Console.WriteLine("Cannot Divide by Zero");
                    }
                    else
                    {
                        result = x / y;
                        Console.WriteLine("Result: " + result);
                    }
                    
                    break;
                default:
                    Console.WriteLine("Invalid Operator");
                    break;



            }

            Console.ReadLine();
        }
    }
}
