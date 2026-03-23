
//Problem 5 – Level 2
//Scenario:
//An IT administrator wants to monitor disk storage and identify drives that are running out of space.
//Requirements:
//1.Retrieve all system drives.
//2. Display drive name, drive type, total size, and available free space.
//3. Display a warning if free space is below 15%.
//Technical Constraints:
//• Use DriveInfo class.
//• Ensure the drive is ready before accessing properties.
//• Use loops to process multiple drives.
//Expectations:
//The program should display drive health information and warn the user about low disk space.
//Learning Outcome:
//Students will learn how to retrieve and analyze system storage information using DriveInfo.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            Console.WriteLine("System Drive Information:\n");

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Drive Name : " + drive.Name);
                Console.WriteLine("Drive Type : " + drive.DriveType);

                if (drive.IsReady)
                {
                    long total = drive.TotalSize;
                    long free = drive.AvailableFreeSpace;

                    double freePercent = (double)free / total * 100;

                    Console.WriteLine("Total Size : " + (total / (1024 * 1024 * 1024)) + " GB");
                    Console.WriteLine("Free Space : " + (free / (1024 * 1024 * 1024)) + " GB");
                    Console.WriteLine("Free %     : " + freePercent.ToString("F2") + "%");

                    if (freePercent < 15)
                    {
                        Console.WriteLine("WARNING: Low Disk Space!");
                    }
                }
                else
                {
                    Console.WriteLine("Drive not ready.");
                }

                Console.WriteLine("----------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}