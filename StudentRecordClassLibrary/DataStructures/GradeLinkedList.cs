using System;
using StudentManagement.Models;

namespace StudentManagement.DataStructures
{
    public class GradeLinkedList
    {
        private GradeNode head;
        private GradeNode tail;

        public GradeLinkedList()
        {
            head = null;
            tail = null;
        }


        public void AddGrade(Grade grade)
        {
            if (grade.GradeValue < 1.0 || grade.GradeValue > 5.0)
            {
                Console.WriteLine("Invalid grade! Only values from 1.0 to 5.0 are allowed.");
                return;
            }

            GradeNode newNode = new GradeNode(grade);

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
            Console.WriteLine($"Grade for {grade.SubjectCode} added successfully!");
        }

        // === Display All Grades ===
        public void DisplayGrades()
        {
            if (head == null)
            {
                Console.WriteLine("No grades recorded!");
                return;
            }

            Console.WriteLine("\n=======================================================================");
            Console.WriteLine("                        STUDENT GRADES                                 ");
            Console.WriteLine("=======================================================================");
            Console.WriteLine($"{"#",3} {"Subject ID",12} {"Code",10} {"Grade",7} {"Term",10}");
            Console.WriteLine(new string('-', 50));

            GradeNode current = head;
            int count = 1;
            while (current != null)
            {
                Console.WriteLine($"{count,3} {current.Data.SubjectID,12} {current.Data.SubjectCode,10} {current.Data.GradeValue,7:F2} {current.Data.Term,10}");
                current = current.Next;
                count++;
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Total grades: {count - 1}");
        }
    }
}