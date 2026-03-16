using System;

namespace ConsoleApp1
{
    public class BankAccount
    {
        // Private Fields (Data Hiding)
        private decimal _balance;
        private string _accountHolder;

        // Readonly Property
        public string AccountNumber { get; }

        // Read Only Balance Property
        public decimal Balance
        {
            get { return _balance; }
        }

        // Read Write Property with Validation
        public string AccountHolder
        {
            get { return _accountHolder; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");

                _accountHolder = value;
            }
        }

        // Constructor
        public BankAccount(string accNo, string holder, decimal initialBalance = 0)
        {
            if (string.IsNullOrWhiteSpace(accNo))
                throw new ArgumentException("Invalid Account Number");

            if (string.IsNullOrWhiteSpace(holder))
                throw new ArgumentException("Invalid Name");

            if (initialBalance < 0)
                throw new ArgumentException("Balance cannot be negative");

            AccountNumber = accNo;
            _accountHolder = holder;
            _balance = initialBalance;
        }

        // Deposit Method
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit must be positive");

            _balance += amount;
            Console.WriteLine("Deposit Success. Balance: " + _balance);
        }

        // Withdraw Method
        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid Withdraw Amount");
                return false;
            }

            if (amount > _balance)
            {
                Console.WriteLine("Insufficient Balance");
                return false;
            }

            _balance -= amount;
            Console.WriteLine("Withdraw Success. Balance: " + _balance);
            return true;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc = new BankAccount("LT987654", "Jonas", 1200);

            acc.Deposit(300);

            bool success = acc.Withdraw(2000);
            Console.WriteLine("Withdraw Status: " + success);

            acc.Withdraw(800);

            Console.WriteLine("Final Balance: " + acc.Balance);

            acc.AccountHolder = "Jonas Jonaitis";

            Console.ReadLine();
        }
    }
}