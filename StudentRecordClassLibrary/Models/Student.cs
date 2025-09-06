using System;
using StudentManagement.DataStructures;

namespace StudentManagement.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        public int YearLevel { get; set; }
        public double GPA { get; set; }
        public GradeLinkedList Grades { get; set; } 

        public string FullName => $"{FirstName} {LastName}";

        public Student(int studentId, string firstName, string lastName, string course, int yearLevel, double gpa)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            Course = course;
            YearLevel = yearLevel;
            GPA = gpa;
            Grades = new GradeLinkedList();
        }

        public void DisplayGrades()
        {
            Grades.DisplayGrades();
        }

        public override string ToString()
        {
            return $"ID: {StudentId}, Name: {FullName}, Course: {Course}, Year: {YearLevel}, GPA: {GPA:F2}";
        }
    }
}