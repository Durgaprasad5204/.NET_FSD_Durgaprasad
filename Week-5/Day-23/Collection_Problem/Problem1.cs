using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    // Added 'class Program' to wrap the methods
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tasks = new List<string>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nTo-Do List Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask(tasks);
                        break;
                    case "2":
                        ViewTasks(tasks);
                        break;
                    case "3":
                        RemoveTask(tasks);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose 1-4.");
                        break;
                }
            }
        }

        static void AddTask(List<string> tasks)
        {
            Console.Write("Enter task: ");
            string description = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(description))
            {
                tasks.Add(description);
                Console.WriteLine("Task added!");
            }
            else
            {
                Console.WriteLine("Error: Task description cannot be empty.");
            }
        }

        static void ViewTasks(List<string> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("The list is empty.");
            }
            else
            {
                Console.WriteLine("\nTasks:");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
        }

        static void RemoveTask(List<string> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Nothing to remove. The list is empty.");
                return;
            }

            Console.Write("Enter task number to remove: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int taskNumber))
            {
                int index = taskNumber - 1;

                if (index >= 0 && index < tasks.Count)
                {
                    string removedTask = tasks[index];
                    tasks.RemoveAt(index);
                    Console.WriteLine($"Removed: {removedTask}");
                }
                else
                {
                    Console.WriteLine("Invalid task number.");
                }
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
        }
    } 
} 