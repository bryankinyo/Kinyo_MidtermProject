
using System;

namespace StudentManagement.Utilities
{
    public static class InputValidator
    {
        public static int GetValidStudentId(Func<int, bool> studentIdExists)
        {
            while (true)
            {
                Console.Write("Enter student ID: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Student ID cannot be empty!");
                    continue;
                }

                if (int.TryParse(input, out int studentId))
                {
                    if (studentId <= 0)
                    {
                        Console.WriteLine("Student ID must be a positive number!");
                        continue;
                    }

                    if (studentIdExists(studentId))
                    {
                        Console.WriteLine($"Student ID {studentId} already exists! Please use a different ID.");
                        continue;
                    }

                    return studentId;
                }
                else
                {
                    Console.WriteLine("Invalid student ID! Please enter a valid number.");
                }
            }
        }

        public static string GetNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }

                Console.WriteLine("Input cannot be empty! Please try again.");
            }
        }

        public static int GetValidYearLevel()
        {
            while (true)
            {
                Console.Write("Enter year level (1-5): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int yearLevel))
                {
                    if (yearLevel >= 1 && yearLevel <= 5)
                    {
                        return yearLevel;
                    }
                    else
                    {
                        Console.WriteLine("Year level must be between 1 and 5!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid year level! Please enter a number between 1 and 5.");
                }
            }
        }

        public static double GetValidGPA()
        {
            while (true)
            {
                Console.Write("Enter GPA (0.0-4.0): ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out double gpa))
                {
                    if (gpa >= 0.0 && gpa <= 4.0)
                    {
                        return gpa;
                    }
                    else
                    {
                        Console.WriteLine("GPA must be between 0.0 and 4.0!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid GPA! Please enter a number between 0.0 and 4.0.");
                }
            }
        }
        public static double GetValidGradeValue()
        {
            while (true)
            {
                Console.Write("Enter Grade (1.0 - 5.0): ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out double grade))
                {
                    if (grade >= 1.0 && grade <= 5.0)
                    {
                        return grade;
                    }
                    else
                    {
                        Console.WriteLine("Grade must be between 1.0 and 5.0!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a number between 1.0 and 5.0.");
                }
            }
        }


    }
}