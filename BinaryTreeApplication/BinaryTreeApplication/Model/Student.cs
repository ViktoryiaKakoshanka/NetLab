using System;
using System.Collections.Generic;
using System.Globalization;

namespace BinaryTreeApplication.Model
{
    [Serializable]
    public class Student : IComparer<Student>
    {
        public Guid Id { get; }
        public string Name { get; }

        public Student(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Compare(Student x, Student y)
        {
           return CultureInfo.CurrentCulture.CompareInfo.Compare(x?.Name, y?.Name, CompareOptions.None);
        }
    }
}
