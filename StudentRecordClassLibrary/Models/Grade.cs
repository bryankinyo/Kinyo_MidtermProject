
using System;

namespace StudentManagement.Models
{
    public class Grade
    {
        public int SubjectID { get; set; }
        public string SubjectCode { get; set; }
        public double GradeValue { get; set; }
        public string Term { get; set; }

        public Grade(int subjectId, string subjectCode, double gradeValue, string term)
        {
            SubjectID = subjectId;
            SubjectCode = subjectCode;
            GradeValue = gradeValue;
            Term = term;
        }

        public override string ToString()
        {
            return $"Subject: {SubjectCode} (ID: {SubjectID}), Grade: {GradeValue:F2}, Term: {Term}";
        }
    }
}