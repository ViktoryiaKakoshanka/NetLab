using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeApplication.Model
{
    [Serializable]
    public class Register : IMyComparable<Register>
    {
        public string TestName { get; }
        public string Student { get; }
        public DateTime Date { get; }
        public int Mark { get; }

        private static readonly List<string> NamesStudents = new List<string>
        {
            "Tom",
            "Billy",
            "Alex",
            "Mila",
            "Vika",
            "Denis",
            "Mika"
        };

        private static readonly List<string> NamesTests = new List<string>
        {
            "Physics",
            "English",
            "Literature",
            "Maths",
            "DataBase",
            "Tests"
        };

        private static readonly Random Random = new Random();

        public Register(string testName, string student, DateTime date, int mark)
        {
            TestName = testName;
            Student = student;
            Date = date;
            Mark = mark;
        }
        
        public static Register GenerateNewRegister()
        {
            return new Register(CreateTestRandom(), CreateStudentRandom(), DateTime.Now, Random.Next(1, 11));
        }
        
        public override string ToString()
        {
            return $"{TestName} - {Student} - {Mark} - {Date.ToShortDateString()}";
        }

        public int CompareTo(Register other)
        {
            if (other == null)
            {
                throw new NullReferenceException();
            }

            if (Mark > other.Mark)
            {
                return 1;
            }

            if (Mark < other.Mark)
            {
                return -1;
            }

            return 0;
        }

        private static string CreateStudentRandom()
        {
            return NamesStudents.ElementAt(Random.Next(0, NamesStudents.Count));
        }

        private static string CreateTestRandom()
        {
            return NamesTests.ElementAt(Random.Next(0, NamesTests.Count));
        }

    }
}