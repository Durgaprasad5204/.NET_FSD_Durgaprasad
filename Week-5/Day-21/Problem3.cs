//Level - 2 Problem 1: Online Shopping Cart System
//Scenario:
//An e-commerce platform needs a flexible cart system where different product types calculate discounts differently.
//Requirements:
//1.Create a base class Product with properties Name and Price.
//2. Create derived classes Electronics and Clothing.
//3. Implement a virtual method CalculateDiscount().
//4. Electronics get 5% discount, Clothing gets 15% discount.
//5. Use encapsulation to protect price updates.
//Technical Constraints:
//• Use private fields with public properties.
//• Apply inheritance and method overriding.
//• Prevent negative price assignment.
//Expectations:
//• Demonstrate polymorphic behavior in cart processing.
//• Apply data validation inside properties.
//• Calculate and display final price after discount.
//Learning Outcome:
//• Combine encapsulation and polymorphism.
//• Design extensible product hierarchy.
//• Implement business logic in overridden methods.
//Sample Input: Electronics Price = 20000
//Sample Output: Final Price after 5% discount = 19000




using System;

namespace ConsoleApp1
{
    class Product
    {
        public string Name { get; set; }

        private double price;

        // Encapsulation with Validation
        public double Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Invalid Price. Price must be greater than zero.");
                }
                else
                {
                    price = value;
                }
            }
        }

        // Virtual Method
        public virtual double CalculateDiscount()
        {
            return price;
        }
    }

    // Derived Class - Electronics
    class Electronics : Product
    {
        public override double CalculateDiscount()
        {
            double discount = Price * 0.05;
            return Price - discount;
        }
    }

    // Derived Class - Clothing
    class Clothing : Product
    {
        public override double CalculateDiscount()
        {
            double discount = Price * 0.15;
            return Price - discount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Electronics Price: ");
            double ePrice;

            if (!double.TryParse(Console.ReadLine(), out ePrice) || ePrice <= 0)
            {
                Console.WriteLine("Invalid Price Input");
                return;
            }

            // Runtime Polymorphism
            Product p1 = new Electronics();
            p1.Name = "Laptop";
            p1.Price = ePrice;

            Console.WriteLine("Final Price after 5% discount = " + p1.CalculateDiscount());

            Console.WriteLine();

            Console.Write("Enter Clothing Price: ");
            double cPrice;

            if (!double.TryParse(Console.ReadLine(), out cPrice) || cPrice <= 0)
            {
                Console.WriteLine("Invalid Price Input");
                return;
            }

            Product p2 = new Clothing();
            p2.Name = "Shirt";
            p2.Price = cPrice;

            Console.WriteLine("Final Price after 15% discount = " + p2.CalculateDiscount());

            Console.ReadLine();
        }
    }
}