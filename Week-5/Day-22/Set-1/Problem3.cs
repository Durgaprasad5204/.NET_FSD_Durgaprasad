//Level - 2 Problem 1: Bank Withdrawal System with Custom Exception Scenario: A bank wants to implement a withdrawal system that throws a custom exception when a customer attempts to withdraw more money than available in their account.
//Requirements: 1.Create a class BankAccount with a private field balance.
//2. Create a method Withdraw(double amount).
//3. Create a custom exception class InsufficientBalanceException.
//4.Throw the custom exception if the withdrawal amount exceeds the balance.
//5. Handle the exception in the main program using try-catch.
//6.Ensure proper cleanup using a finally block.Technical Constraints:
//• Use custom exception classes by inheriting from Exception. •
//Implement error propagation by throwing exceptions from methods.
//• Handle exceptions in the calling method.Expectations:
//• Demonstrate creation and usage of custom exceptions.
//• Implement proper exception handling in calling code.
//• Display user-friendly error messages. Learning Outcome:
//• Learn how to create custom exceptions. • Understand throw and error propagation.
//• Apply structured exception handling in real - world scenarios.
//Sample Input: Balance = 3000 Withdraw = 5000 Sample Output: Error: Withdrawal amount exceeds available balance


using System;

namespace ConsoleApp1
{
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    // BankAccount Class
    class BankAccount
    {
        private double balance;

        public BankAccount(double balance)
        {
            this.balance = balance;
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                // Throw custom exception (Error Propagation)
                throw new InsufficientBalanceException(
                    "Withdrawal amount exceeds available balance"
                );
            }

            balance = balance - amount;
            Console.WriteLine("Withdrawal Successful");
            Console.WriteLine("Remaining Balance: " + balance);
        }
    }




    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Enter Balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.Write("Enter Withdraw Amount: ");
            double withdraw = double.Parse(Console.ReadLine());

            BankAccount acc = new BankAccount(balance);

            try
            {
                acc.Withdraw(withdraw);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction Completed");
            }
            Console.ReadLine();
        }


    }
}