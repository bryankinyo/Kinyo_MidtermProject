
using StudentManagement.Models;

namespace StudentManagement.DataStructures
{
    public class GradeNode
    {
        public Grade Data { get; set; }
        public GradeNode Next { get; set; }
        public GradeNode Previous { get; set; }

        public GradeNode(Grade grade)
        {
            Data = grade;
            Next = null;
            Previous = null;
        }
    }
}