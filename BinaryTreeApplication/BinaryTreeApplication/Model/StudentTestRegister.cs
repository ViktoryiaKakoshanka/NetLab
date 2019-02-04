using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeApplication.Model
{
    [Serializable]
    public class StudentTestRegister : IComparer<StudentTestRegister>
    {
        public string TestName { get; }
        public string Student { get; }
        public DateTime Date { get; }
        public int Mark { get; }

        private readonly List<string> _namesStudents = new List<string>
        {
            "Tom",
            "Billy",
            "Alex",
            "Mila"
        };

        private readonly List<string> _namesTests = new List<string>
        {
            "Physics",
            "English",
            "Literature",
            "Maths" 
        };

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

        public StudentTestRegister CreateStudentTestRegisterRundom()
        {
            var randomMark = new Random();
            return new StudentTestRegister(CreateTestRandom(), CreateStudentRandom(), DateTime.Now, randomMark.Next(0, 10));
        }

        private string CreateStudentRandom()
        {
            var random = new Random();
            return _namesStudents.ElementAt(random.Next(0, _namesStudents.Count));
        }

        private string CreateTestRandom()
        {
            var random = new Random();
            return _namesTests.ElementAt(random.Next(0, _namesTests.Count));
        }
    }
}