////Problem 4 – Level 2
////Scenario:
////A development team wants to analyze all folders inside a project directory to understand the project structure.
////Requirements:
////1.Accept a root directory path.
////2. Display all subdirectories inside the root folder.
////3. Show the number of files present in each directory.
////Technical Constraints:
////• Use DirectoryInfo class.
////• Use loops to iterate through directories.
////• Implement exception handling.
////Expectations:
////The application should display folder names and file counts for each directory.
////Learning Outcome:
////Students will learn how to navigate directories and retrieve folder information using DirectoryInfo.

//using System;
//using System.IO;

//namespace ConsoleApp1
//{


//    class Program
//    {
//        static void Main()
//        {
//            Console.Write("Enter Root Directory Path: ");
//            string rootPath = Console.ReadLine();

//            try
//            {
//                if (!Directory.Exists(rootPath))
//                {
//                    Console.WriteLine("Invalid Directory Path.");
//                    return;
//                }

//                DirectoryInfo rootDir = new DirectoryInfo(rootPath);

//                DirectoryInfo[] subDirs = rootDir.GetDirectories();

//                Console.WriteLine("\nFolder Analysis:\n");

//                foreach (DirectoryInfo dir in subDirs)
//                {
//                    try
//                    {
//                        FileInfo[] files = dir.GetFiles();

//                        Console.WriteLine("Folder Name : " + dir.Name);
//                        Console.WriteLine("File Count  : " + files.Length);
//                        Console.WriteLine("----------------------------------");
//                    }
//                    catch (UnauthorizedAccessException)
//                    {
//                        Console.WriteLine("Folder Name : " + dir.Name);
//                        Console.WriteLine("Access Denied.");
//                        Console.WriteLine("----------------------------------");
//                    }
//                }

//                Console.WriteLine("\nTotal Subdirectories: " + subDirs.Length);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }

//            Console.ReadLine();
//        }
//    }
//}