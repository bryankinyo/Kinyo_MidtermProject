using StudentManagement.Models;

namespace StudentManagement.DataStructures
{
    public class StudentNode
    {
        public Student Data { get; set; }
        public StudentNode Next { get; set; }
        public StudentNode Previous { get; set; }

        public StudentNode(Student student)
        {
            Data = student;
            Next = null;
            Previous = null;
        }
    }
}