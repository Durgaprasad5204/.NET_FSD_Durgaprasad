
//Level - 1 Problem 2: Student Grade Calculator
//Scenario:
//A school wants to calculate the average marks of a student using a class-based approach.
//Requirements:
//1.Create a class Student.
//2.Create method CalculateAverage(int m1, int m2, int m3).
//3.Return the average marks.
//4. Display grade based on average.
//Technical Constraints:
//1.Use return type double for average.
//2. Avoid hard-coded values.
//Expectations:
//Clear separation of logic inside methods.
//Learning Outcome:
//Learn method creation, return values, and basic OOP concepts.
//Sample Input: 
//80 70 90
//Sample Output: 
//Average = 80, Grade = A


namespace ConsoleApp1
{
    class Student
    {
        public double CalAverage(int m1, int m2, int m3)
        {
            double average = (m1 + m2 + m3) / 3.0;
            return average;
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                int m1, m2, m3;

                Console.Write("Enter Marks 1: ");
                if (!int.TryParse(Console.ReadLine(), out m1))
                {
                    Console.WriteLine("Invalid Input");
                    return;
                }

                Console.Write("Enter Marks 2: ");
                if (!int.TryParse(Console.ReadLine(), out m2))
                {
                    Console.WriteLine("Invalid Input");
                    return;
                }

                Console.Write("Enter Marks 3: ");
                if (!int.TryParse(Console.ReadLine(), out m3))
                {
                    Console.WriteLine("Invalid Input");
                    return;
                }

                // Range Validation 
                if (m1 < 0 || m1 > 100 || m2 < 0 || m2 > 100 || m3 < 0 || m3 > 100)
                {
                    Console.WriteLine("Marks should be between 0 and 100");
                    return;
                }

                Student s = new Student();
                double avg = s.CalAverage(m1, m2, m3);

                string grade;

                if (avg >= 80)
                    grade = "A";
                else if (avg >= 60)
                    grade = "B";
                else if (avg >= 50)
                    grade = "C";
                else
                    grade = "Fail";

                Console.WriteLine("Average = " + avg.ToString("0.00"));
                Console.WriteLine("Grade = " + grade);

                Console.ReadLine();
            }



        }
    }
}
