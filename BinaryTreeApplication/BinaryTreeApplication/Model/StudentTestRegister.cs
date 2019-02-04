using System;
using System.Collections.Generic;

namespace BinaryTreeApplication.Model
{
    [Serializable]
    public class StudentTestRegister : IComparer<StudentTestRegister>
    {
        public string TestName { get; }
        public string Student { get; }
        public DateTime Date { get; }
        public int Mark { get; }

        public StudentTestRegister(string testName, string student, DateTime date, int mark)
        {
            TestName = testName;
            Student = student;
            Date = date;
            Mark = mark;
        }

        public int Compare(StudentTestRegister x, StudentTestRegister y)
        {
            if (x == null || y == null)
            {
                throw new NullReferenceException();
            }
            return DateTime.Compare(x.Date, y.Date);
        }
    }
}