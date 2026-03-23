
//using System.Runtime.Intrinsics.X86;

//Level - 1 Problem 3:
//Scenario
//A financial application needs to process multiple reports simultaneously to reduce waiting time. Instead of executing tasks sequentially, the system should run them concurrently using C# Tasks so that reports are generated faster.
//Requirements
//1.Create three methods:
//a.GenerateSalesReport()
//b.GenerateInventoryReport()
//c.GenerateCustomerReport()
//2.Each method should simulate processing time using Thread.Sleep() or Task.Delay().
//3.Execute all three operations concurrently using Task.
//4.Display a message when each report starts and when it finishes.
//5.	Display a final message once all reports are completed.
//Technical Constraints
//•	Use Task class from System.Threading.Tasks.
//•	Use Task.Run() to execute methods.
//•	Use Task.WaitAll() or await Task.WhenAll() to wait for completion.
//•	The program must run in a Console Application.
//Expectations
//The program should start multiple report-generation tasks simultaneously and display completion messages for each report along with a final message once all tasks are completed.
//Learning Outcome
//Students will learn:
//•	How to create and run Tasks in C#
//•	How to execute multiple operations concurrently
//•	How to wait for multiple tasks to complete

using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
   

    static void GenerateSalesReport()
    {
        Console.WriteLine("Sales Report Started...");
        Thread.Sleep(3000);   
        Console.WriteLine("Sales Report Completed.");
    }

    static void GenerateInventoryReport()
    {
        Console.WriteLine("Inventory Report Starting........");
        Thread.Sleep(4000);
        Console.WriteLine("Inventory Report Completed.");
    }

    static void GenerateCustomerReport()
    {
        Console.WriteLine("Customer Report Starting.......");
        Thread.Sleep(2000);
        Console.WriteLine("Customer Report Completed.");
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Report Generation Starting......\n");

        // Creating Tasks
        Task t1 = Task.Run(() => GenerateSalesReport());
        Task t2 = Task.Run(() => GenerateInventoryReport());
        Task t3 = Task.Run(() => GenerateCustomerReport());

        // Waiting for all tasks
        Task.WaitAll(t1, t2, t3);

        Console.WriteLine("\nAll Reports Generated Successfully");

        Console.ReadLine();
    }
}