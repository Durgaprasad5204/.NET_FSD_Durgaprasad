

//DAY - 4 Hands - On
//Level - 1 Problem 1: Simple Calculator Using Methods
//Scenario:
//A small retail shop wants a simple calculator application to perform addition and subtraction operations using reusable methods.
//Requirements:
//1.Create a class named Calculator.
//2.Create methods Add(int a, int b) and Subtract(int a, int b).
//3.Each method should return the result.
//4. In Main(), create an object and call the methods.
//5. Display the output.
//Technical Constraints:
//1.Use method parameters and return types properly.
//2. Use appropriate access modifiers.
//3. No global variables allowed.
//Expectations:
//Proper method definition, object creation, and method invocation.
//Learning Outcome:
//Understand functions, parameters, return types, classes, and objects.
//Sample Input: 10 5
//Sample Output: Addition = 15, Subtraction = 5

namespace ConsoleApp1
{
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
            }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            Console.WriteLine("Enter First Number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Second Number: ");
            int num2=int.Parse(Console.ReadLine());

            int addResult = calc.Add(num1, num2);
            int subResult = calc.Subtract(num1, num2);

            Console.WriteLine("Addition = " + addResult);
            Console.WriteLine("Subtraction = " + subResult);
                


            Console.ReadLine();
        }

       
        
    }
}
