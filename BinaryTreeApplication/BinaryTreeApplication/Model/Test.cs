using System;
using System.Collections.Generic;

namespace BinaryTreeApplication.Model
{
    [Serializable]
    public class Test : IComparer<Test>
    {
        public Guid Id { get; }
        public string Name { get; }

        public Test(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Compare(Test x, Test y)
        {
            return string.Compare(x.Name, y.Name);
        }
    }
}
