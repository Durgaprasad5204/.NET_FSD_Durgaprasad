
//Level - 2 Problem 2: Vehicle Rental System
//Scenario:
//A vehicle rental company wants a system where different vehicle types calculate rental charges differently.
//Requirements:
//1.Create a base class Vehicle with properties Brand and RentalRatePerDay.
//2. Create derived classes Car and Bike.
//3. Override CalculateRental(int days) method.
//4. Car adds insurance charge of 500 per rental.
//5. Bike offers 5% discount on total rental.
//Technical Constraints:
//• Use encapsulation with proper access modifiers.
//• Apply runtime polymorphism.
//• Validate number of rental days.
//Expectations:
//• Use base class reference to call overridden methods.
//• Implement clean class hierarchy.
//• Display final rental cost.
//Learning Outcome:
//• Master inheritance and polymorphism.
//• Implement real-world OOP scenarios.
//• Improve object-oriented design skills.
//Sample Input: 
//Car RentalRatePerDay = 2000, Days = 3
//Sample Output: 
//Total Rental = 6500



using System;

namespace ConsoleApp1
{
    class Vehicle
    {
        public string Brand { get; set; }

        private double rentalRatePerDay;

        // Encapsulation with validation
        public double RentalRatePerDay
        {
            get { return rentalRatePerDay; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Invalid Rental Rate");
                }
                else
                {
                    rentalRatePerDay = value;
                }
            }
        }

        // Virtual Method
        public virtual double CalculateRental(int days)
        {
            return rentalRatePerDay * days;
        }
    }

    // Derived Class - Car
    class Car : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = RentalRatePerDay * days;
            return total + 500;   // Insurance charge
        }
    }

    // Derived Class - Bike
    class Bike : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = RentalRatePerDay * days;
            double discount = total * 0.05;
            return total - discount;
        }
    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.Write("Enter Car Rental Rate Per Day: ");
//            double carRate;

//            if (!double.TryParse(Console.ReadLine(), out carRate) || carRate <= 0)
//            {
//                Console.WriteLine("Invalid Rate Input");
//                return;
//            }

//            Console.Write("Enter Number of Days: ");
//            int days;

//            if (!int.TryParse(Console.ReadLine(), out days) || days <= 0)
//            {
//                Console.WriteLine("Invalid Days Input");
//                return;
//            }

//            // Runtime Polymorphism
//            Vehicle v1 = new Car();
//            v1.Brand = "Honda";
//            v1.RentalRatePerDay = carRate;

//            Console.WriteLine("Total Rental = " + v1.CalculateRental(days));

//            Console.WriteLine();

//            Console.Write("Enter Bike Rental Rate Per Day: ");
//            double bikeRate;

//            if (!double.TryParse(Console.ReadLine(), out bikeRate) || bikeRate <= 0)
//            {
//                Console.WriteLine("Invalid Rate Input");
//                return;
//            }

//            Vehicle v2 = new Bike();
//            v2.Brand = "Yamaha";
//            v2.RentalRatePerDay = bikeRate;

//            Console.WriteLine("Total Rental = " + v2.CalculateRental(days));
//            Console.ReadLine();
//        }
//    }
//}