////Problem 2 – Level 1:
////Scenario:
////An administrator wants to check file properties stored in a particular folder for auditing purposes.
////Requirements:
////1.Accept a folder path from the user.
////2. Display file name, file size, and creation date.
////3. Count and display the total number of files.
////Technical Constraints:
////• Use FileInfo class.
////• Handle invalid directory paths.
////Expectations:
////The program should list file details clearly in the console.
////Learning Outcome:
////Students will understand how to retrieve file metadata using FileInfo.

//using System;
//using System.IO;

//namespace ConsoleApp1
//{


//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.Write("Enter Folder Path: ");
//            string folderPath = Console.ReadLine();

//            try
//            {
//                if (!Directory.Exists(folderPath))
//                {
//                    Console.WriteLine("Invalid Directory Path.");
//                    return;
//                }

//                DirectoryInfo dir = new DirectoryInfo(folderPath);
//                FileInfo[] files = dir.GetFiles();

//                int count = 0;

//                Console.WriteLine("\nFile Details:\n");

//                foreach (FileInfo file in files)
//                {
//                    Console.WriteLine("File Name      : " + file.Name);
//                    Console.WriteLine("File Size (KB) : " + (file.Length / 1024.0).ToString("F2"));
//                    Console.WriteLine("Creation Date  : " + file.CreationTime);
//                    Console.WriteLine("-----------------------------------");
//                    count++;
//                }

//                Console.WriteLine("\nTotal Files: " + count);
//            }
//            catch (UnauthorizedAccessException)
//            {
//                Console.WriteLine("No permission to access this folder.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }

//            Console.ReadLine();
//        }
//    }
//}