using System.Collections.Generic;
using System.Linq;
using BinaryTreeApplication.Model;

namespace BinaryTreeApplication.Helpers
{
    public static class ListExtensions
    {
        public static BinaryTree<StudentTestRegister> ToTree(this List<StudentTestRegister> registers)
        {
            var tree = new BinaryTree<StudentTestRegister>(registers.First());
            registers.Skip(1).Select(register => tree.Insert(register));
            return tree;
        }
    }
}
