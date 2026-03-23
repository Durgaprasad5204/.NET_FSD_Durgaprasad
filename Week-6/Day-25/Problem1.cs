//Week - 6(DAY - 1) Hands - On
//Level - 1 Problem 1: Asynchronous File Logger
//Scenario:
// An application writes logs to a file whenever an event occurs. Writing logs synchronously can slow down the application. Asynchronous file writing improves performance.

//Requirements:
// -Create an asynchronous method WriteLogAsync(string message).
// - The method should simulate file writing using Task.Delay().
// - Call this method multiple times to simulate logging different events.

//Technical Constraints:
// -Use async and await keywords.
// - Use Task.Delay() to simulate file I/O.
// - Use a console application.

//Expectations:
// -Logs should be written asynchronously.
// - The main thread should remain responsive while logging operations occur.

//Learning Outcome:
// Students will learn how asynchronous operations improve performance when dealing with I/O operations.


using System;
using System.Threading.Tasks;

class Program
{
    // Asynchronous Method
    static async Task WriteLogAsync(string message)
    {
        Console.WriteLine($"Start Writing Log: {message}");

        // Simulate file writing delay (I/O operation)
        await Task.Delay(2000);

        Console.WriteLine($"Log Written Successfully: {message}");
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Application Started...\n");

        // Calling async logging multiple times
        Task t1 = WriteLogAsync("User Login Event");
        Task t2 = WriteLogAsync("File Uploaded Event");
        Task t3 = WriteLogAsync("Payment Successful Event");

        Console.WriteLine("\nMain Thread is still running...");

        // Wait for all logs to complete
        await Task.WhenAll(t1, t2, t3);

        Console.WriteLine("\nAll Logs Completed.");
    }
}