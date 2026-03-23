

//Problem 5 Level-2: Application Tracing for Order Processing
//Scenario
//An e-commerce application processes customer orders. Sometimes the order processing fails, but developers are unable to identify where the failure occurs. The team decides to implement Tracing to monitor the execution flow and diagnose the issue.
//Requirements
//•	Create a console application that simulates order processing.
//•	The order processing should include the following steps:
//o Validate Order
//o	Process Payment
//o	Update Inventory
//o	Generate Invoice
//•	Use Trace class to log messages at each step of the process.
//•	Display trace messages showing the execution flow.
//Technical Constraints
//•	Use System.Diagnostics.Trace.
//•	Write trace messages using:
//o Trace.WriteLine()
//o Trace.TraceInformation()
//•	Configure a TextWriterTraceListener to store trace logs in a file.
//•	Implement the solution using .NET console application.
//Expectations
//•	The application should log messages for each stage of order processing.
//•	Trace logs should help developers identify where failures occur.
//•	The trace output should be stored in a log file.
//Learning Outcome
//Students will learn how to:
//•	Implement application tracing using System.Diagnostics.
//•	Monitor application flow using Trace listeners.
//•	Use trace logs to diagnose runtime issues in real-world applications.

using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Configure Trace to write to a file
        Trace.Listeners.Add(new TextWriterTraceListener("order_processing.log"));
        Trace.AutoFlush = true;
        try
        {
            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();
        }
        catch (Exception ex)
        {
            Trace.TraceError($"Error occurred: {ex.Message}");
        }
    }
    static void ValidateOrder()
    {
        Trace.TraceInformation("Validating order...");
        // Simulate validation logic
        if (new Random().Next(0, 2) == 0) // Randomly fail validation
        {
            throw new Exception("Order validation failed.");
        }
        Trace.TraceInformation("Order validated successfully.");
    }
    static void ProcessPayment()
    {
        Trace.TraceInformation("Processing payment...");
        // Simulate payment processing logic
        if (new Random().Next(0, 2) == 0) // Randomly fail payment processing
        {
            throw new Exception("Payment processing failed.");
        }
        Trace.TraceInformation("Payment processed successfully.");
    }
    static void UpdateInventory()
    {
        Trace.TraceInformation("Updating inventory...");
        // Simulate inventory update logic
        if (new Random().Next(0, 2) == 0) // Randomly fail inventory update
        {
            throw new Exception("Inventory update failed.");
        }
        Trace.TraceInformation("Inventory updated successfully.");
    }
    static void GenerateInvoice()
    {
        Trace.TraceInformation("Generating invoice...");
        // Simulate invoice generation logic
        if (new Random().Next(0, 2) == 0) // Randomly fail invoice generation
        {
            throw new Exception("Invoice generation failed.");
        }
        Trace.TraceInformation("Invoice generated successfully.");
    }
}
