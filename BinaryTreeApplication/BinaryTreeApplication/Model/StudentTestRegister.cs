using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeApplication.Model
{
    [Serializable]
    public class StudentTestRegister : IComparer<StudentTestRegister>, IEquatable<StudentTestRegister>
    {
        public string TestName { get; }
        public string Student { get; }
        public DateTime Date { get; }
        public int Mark { get; }

        private static List<string> _namesStudents = new List<string>
        {
            "Tom",
            "Billy",
            "Alex",
            "Mila"
        };

        private static List<string> _namesTests = new List<string>
        {
            "Physics",
            "English",
            "Literature",
            "Maths" 
        };

        private static Random random = new Random();

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

            if (x.Mark > y.Mark)
            {
                return 1;
            }

            if (x.Mark < y.Mark)
            {
                return -1;
            }

            return 0;
        }

        public static StudentTestRegister GenerateNewRegister()
        {
            return new StudentTestRegister(CreateTestRandom(), CreateStudentRandom(), DateTime.Now, random.Next(1, 11));
        }

        public override int GetHashCode()
        {
            return unchecked(Mark ^ Date.GetHashCode() ^ Student.GetHashCode() * 397) ^ TestName.GetHashCode();
        }

        public bool Equals(StudentTestRegister other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Mark == other.Mark &&
                   Date == other.Date &&
                   Student == other.Student &&
                   TestName == other.TestName;
        }
        
        private static string CreateStudentRandom()
        {
            return _namesStudents.ElementAt(random.Next(0, _namesStudents.Count));
        }

        private static string CreateTestRandom()
        {
            return _namesTests.ElementAt(random.Next(0, _namesTests.Count));
        }
    }
}