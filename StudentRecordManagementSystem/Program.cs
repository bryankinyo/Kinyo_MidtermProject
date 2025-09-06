using StudentManagement.Models;
using StudentManagement.DataStructures;
using StudentManagement.Utilities;

namespace StudentManagement
{
    class Program
    {
        private static StudentLinkedList studentList = new StudentLinkedList();

        public static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewStudent();
                        break;
                    case "2":
                        DeleteStudent();
                        break;
                    case "3":
                        SearchStudent();
                        break;
                    case "4":
                        UpdateStudent();
                        break;
                    case "5":
                        DisplayAllStudents();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Thank you for using Student Record Management System!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("    STUDENT RECORD MANAGEMENT SYSTEM    ");
            Console.WriteLine("========================================");
            Console.WriteLine("| [1] Add New Student                  |");
            Console.WriteLine("| [2] Delete Student                   |");
            Console.WriteLine("| [3] Search Student                   |");
            Console.WriteLine("| [4] Update Student Details           |");
            Console.WriteLine("| [5] Display All Students             |");
            Console.WriteLine("| [6] Exit                             |");
            Console.WriteLine("========================================");
            Console.Write("Enter your choice (1-6): ");
        }

        private static void AddNewStudent()
        {
            Console.WriteLine("\n=========================");
            Console.WriteLine("     ADD NEW STUDENT    ");
            Console.WriteLine("=========================");

            int studentId = InputValidator.GetValidStudentId(studentList.StudentIdExists);
            if (studentId == -1) return;

            string firstName = InputValidator.GetNonEmptyString("Enter First Name: ");
            string lastName = InputValidator.GetNonEmptyString("Enter Last Name: ");
            string course = InputValidator.GetNonEmptyString("Enter Course: ");
            int yearLevel = InputValidator.GetValidYearLevel();
            if (yearLevel == -1) return;
            double gpa = InputValidator.GetValidGPA();
            if (gpa == -1) return;

            Student newStudent = new Student(studentId, firstName, lastName, course, yearLevel, gpa);

            Console.WriteLine("\n=================================");
            Console.WriteLine("     ENTER GRADES FOR STUDENT    ");
            Console.WriteLine("=================================");
            while (true)
            {
                int subjectId;
                while (true)
                {
                    Console.Write("Enter Subject ID: ");
                    if (int.TryParse(Console.ReadLine(), out subjectId) && subjectId > 0)
                        break;
                    Console.WriteLine("Invalid Subject ID!");
                }

                string subjectCode = InputValidator.GetNonEmptyString("Enter Subject Code: ");


                double gradeValue = InputValidator.GetValidGradeValue();

                string term = InputValidator.GetNonEmptyString("Enter Term (1st Sem / 2nd Sem): ");

                newStudent.Grades.AddGrade(new Grade(subjectId, subjectCode, gradeValue, term));

                string choice;
                while (true)
                {
                    Console.Write("Add another grade? (Y/N): ");
                    choice = Console.ReadLine().Trim().ToUpper();

                    if (choice == "Y" || choice == "y" || choice == "n" || choice == "N")
                        break;

                    Console.WriteLine("Invalid choice!");
                }
                if (choice == "n" || choice == "N") break;
            }
            Console.WriteLine("\nWhere to insert student?");
            Console.WriteLine("1. At Beginning");
            Console.WriteLine("2. At End");
            Console.WriteLine("3. At Position");
            Console.Write("Choice: ");
            string insertChoice = Console.ReadLine();

            switch (insertChoice)
            {
                case "1": studentList.AddAtBeginning(newStudent); break;
                case "2": studentList.AddAtEnd(newStudent); break;
                case "3":
                    Console.Write("Enter position: ");
                    if (int.TryParse(Console.ReadLine(), out int pos))
                        studentList.AddAtPosition(newStudent, pos);
                    else
                        Console.WriteLine("Invalid position!");
                    break;
                default:
                    Console.WriteLine("Invalid choice! Adding at end by default.");
                    studentList.AddAtEnd(newStudent);
                    break;
            }
        }

        private static void DeleteStudent()
        {
            Console.WriteLine("\n======================");
            Console.WriteLine("    DELETE STUDENT    ");
            Console.WriteLine("======================");
            Console.Write("Enter student ID to delete: ");

            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                studentList.DeleteStudent(studentId);
            }
            else
            {
                Console.WriteLine("Invalid student ID!");
            }
        }

        private static void SearchStudent()
        {
            Console.WriteLine("\n======================");
            Console.WriteLine("    SEARCH STUDENT    ");
            Console.WriteLine("======================");
            Console.WriteLine("1. Search by ID");
            Console.WriteLine("2. Search by Name");
            Console.Write("Enter choice (1-2): ");

            string choice = Console.ReadLine();
            Student foundStudent = null;

            switch (choice)
            {
                case "1":
                    Console.Write("Enter student ID: ");
                    if (int.TryParse(Console.ReadLine(), out int studentId))
                    {
                        foundStudent = studentList.SearchById(studentId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid student ID!");
                        return;
                    }
                    break;
                case "2":
                    string name = InputValidator.GetNonEmptyString("Enter student name (first, last, or full name): ");
                    foundStudent = studentList.SearchByName(name);
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    return;
            }

            if (foundStudent != null)
            {
                Console.WriteLine("\nStudent found:");
                Console.WriteLine(foundStudent);
                foundStudent.DisplayGrades();
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        private static void UpdateStudent()
        {
            Console.WriteLine("\n===============================");
            Console.WriteLine("    UPDATE STUDENT DETAILS     ");
            Console.WriteLine("===============================");
            Console.Write("Enter student ID to update: ");

            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Invalid student ID!");
                return;
            }

            Student student = studentList.SearchById(studentId);
            if (student == null)
            {
                Console.WriteLine($"Student with ID {studentId} not found!");
                return;
            }

            Console.WriteLine("\nCurrent details:");
            Console.WriteLine(student);
            Console.WriteLine("\nEnter new details (press Enter to keep current value):");

            Console.Write($"First Name ({student.FirstName}): ");
            string newFirstName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newFirstName)) newFirstName = null;

            Console.Write($"Last Name ({student.LastName}): ");
            string newLastName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newLastName)) newLastName = null;

            Console.Write($"Course ({student.Course}): ");
            string newCourse = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newCourse)) newCourse = null;

            Console.Write($"Year Level ({student.YearLevel}): ");
            string yearInput = Console.ReadLine();
            int? newYearLevel = null;
            if (!string.IsNullOrWhiteSpace(yearInput) && int.TryParse(yearInput, out int year))
            {
                if (year >= 1 && year <= 5)
                    newYearLevel = year;
                else
                    Console.WriteLine("Invalid year level! Keeping current value.");
            }

            Console.Write($"GPA ({student.GPA:F2}): ");
            string gpaInput = Console.ReadLine();
            double? newGPA = null;
            if (!string.IsNullOrWhiteSpace(gpaInput) && double.TryParse(gpaInput, out double gpa))
            {
                if (gpa >= 0.0 && gpa <= 4.0)
                    newGPA = gpa;
                else
                    Console.WriteLine("Invalid GPA! Keeping current value.");
            }

            studentList.UpdateStudent(studentId, newFirstName, newLastName, newCourse, newYearLevel, newGPA);
        }

        private static void DisplayAllStudents()
        {
            studentList.DisplayAllStudents();
        }
    }
}