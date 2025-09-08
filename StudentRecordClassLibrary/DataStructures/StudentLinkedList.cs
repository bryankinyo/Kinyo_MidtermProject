using System;
using StudentManagement.Models;


namespace StudentManagement.DataStructures
{
    public class StudentLinkedList
    {
        private StudentNode head;
        private StudentNode tail;

        public StudentLinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddAtBeginning(Student student)
        {
            StudentNode newNode = new StudentNode(student);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            Console.WriteLine($"Student {student.FullName} added at the beginning successfully!");
        }

        public void AddAtEnd(Student student)
        {
            StudentNode newNode = new StudentNode(student);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            Console.WriteLine($"Student {student.FullName} added at the end successfully!");
        }

        public void AddAtPosition(Student student, int position)
        {
            if (position < 1)
            {
                Console.WriteLine("Position must be 1 or greater!");
                return;
            }

            if (position == 1)
            {
                AddAtBeginning(student);
                return;
            }

            StudentNode newNode = new StudentNode(student);
            StudentNode current = head;

            for (int i = 1; i < position && current != null; i++)
            {
                current = current.Next;
            }

            if (current == null)
            {
                Console.WriteLine("Position is beyond the list size. Adding at the end.");
                AddAtEnd(student);
            }
            else
            {
                newNode.Next = current;
                newNode.Previous = current.Previous;

                if (current.Previous != null)
                    current.Previous.Next = newNode;
                else
                    head = newNode;

                current.Previous = newNode;
                Console.WriteLine($"Student {student.FullName} added at position {position} successfully!");
            }
        }

        public bool DeleteStudent(int studentId)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty!");
                return false;
            }

            StudentNode current = head;

            while (current != null)
            {
                if (current.Data.StudentId == studentId)
                {
                    if (current.Previous != null)
                        current.Previous.Next = current.Next;
                    else
                        head = current.Next;

                    if (current.Next != null)
                        current.Next.Previous = current.Previous;
                    else
                        tail = current.Previous;

                    Console.WriteLine($"Student {current.Data.FullName} (ID: {studentId}) deleted successfully!");
                    return true;
                }
                current = current.Next;
            }

            Console.WriteLine($"Student with ID {studentId} not found!");
            return false;
        }

        public Student SearchById(int studentId)
        {
            StudentNode current = head;
            while (current != null)
            {
                if (current.Data.StudentId == studentId)
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return null;
        }

        public Student SearchByName(string name)
        {
            StudentNode current = head;
            while (current != null)
            {
                if (current.Data.FullName.ToLower().Contains(name.ToLower()) ||
                    current.Data.FirstName.ToLower().Contains(name.ToLower()) ||
                    current.Data.LastName.ToLower().Contains(name.ToLower()))
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return null;
        }

        public bool UpdateStudent(int studentId, string newFirstName = null, string newLastName = null,
                                 string newCourse = null, int? newYearLevel = null, double? newGPA = null)
        {
            Student student = SearchById(studentId);
            if (student != null)
            {
                if (newFirstName != null) student.FirstName = newFirstName;
                if (newLastName != null) student.LastName = newLastName;
                if (newCourse != null) student.Course = newCourse;
                if (newYearLevel.HasValue) student.YearLevel = newYearLevel.Value;
                if (newGPA.HasValue) student.GPA = newGPA.Value;

                Console.WriteLine("Student details updated successfully!");
                Console.WriteLine(student);
                return true;
            }
            Console.WriteLine($"Student with ID {studentId} not found!");
            return false;
        }

        public void DisplayAllStudents()
        {
            if (head == null)
            {
                Console.WriteLine("No students in the system!");
                return;
            }
            StudentNode current = head;
            bool viewing = true;

            // Count students
            int totalStudents = 0;
            StudentNode counter = head;
            while (counter != null)
            {
                totalStudents++;
                counter = counter.Next;
            }
            int index = 1;
            while (viewing && current != null)
            {
                Console.Clear();
                Console.WriteLine($"\n===================================================");
                Console.WriteLine($"    STUDENT RECORD ({index} of {totalStudents})    ");
                Console.WriteLine($"===================================================");
                Console.WriteLine(current.Data);
                current.Data.Grades.DisplayGrades();

                Console.WriteLine("\nOptions: ");
                Console.WriteLine("[N] Next | [P] Previous | [E] Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine().Trim().ToUpper();

                switch (choice)
                {
                    case "N":
                        if (current.Next != null)
                        {
                            current = current.Next;
                            index++;
                        }
                        else
                        {
                            Console.WriteLine("This is the last record!");
                            Console.ReadKey();
                        }
                        break;
                    case "P":
                        if (current.Previous != null)
                        {
                            current = current.Previous;
                            index--;
                        }
                        else
                        {
                            Console.WriteLine("This is the first record!");
                            Console.ReadKey();
                        }
                        break;
                    case "E":
                        viewing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option! Try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public bool StudentIdExists(int studentId)
        {
            return SearchById(studentId) != null;
        }
    }
}