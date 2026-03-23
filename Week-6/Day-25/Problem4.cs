

//Level - 2 Problem 4: Asynchronous Order Processing System
//Scenario:
// An e-commerce system processes customer orders. Each order requires multiple steps such as payment verification, inventory check, and order confirmation. These steps involve delays and should be handled asynchronously.

//Requirements:
// -Create asynchronous methods:
//   -VerifyPaymentAsync()
//   - CheckInventoryAsync()
//   - ConfirmOrderAsync()
// - Simulate processing delays using Task.Delay().
// - Execute steps asynchronously while maintaining the logical order of operations.
//Technical Constraints:
// -Use async and await.
// - Use Task-based asynchronous methods.
// - Implement using a console application.

//Expectations:
// -Each processing step should run asynchronously.
// - The program should display messages indicating the progress of order processing.

//Learning Outcome:
// Students will understand how to design real-world workflows using asynchronous methods with async/await.

using System;
using System.Threading.Tasks;

class Program

{
    static async Task ProcessOrderAsync()
    {
        Console.WriteLine("Starting order processing...");
        
        await VerifyPaymentAsync();
        await CheckInventoryAsync();
        await ConfirmOrderAsync();
        
        Console.WriteLine("Order processing completed.");

    }

    static async Task VerifyPaymentAsync()
    {
        Console.WriteLine("Verifying payment...");
        await Task.Delay(2000);
        Console.WriteLine("Payment verified.");
    }

    static async Task CheckInventoryAsync()
    {
        Console.WriteLine("Checking inventory...");
        await Task.Delay(3000);
        Console.WriteLine("Inventory checked.");
    }

    static async Task ConfirmOrderAsync() {
        Console.WriteLine("Confirming order...");
        await Task.Delay(1000);
        Console.WriteLine("Order confirmed.");
    }


    static async Task Main(string[] args) { 
        Console.WriteLine("Welcome to the E-commerce Order Processing System");
        await ProcessOrderAsync();
        Console.WriteLine("Press any key to exit...");

        Console.ReadLine();
    
    }
}