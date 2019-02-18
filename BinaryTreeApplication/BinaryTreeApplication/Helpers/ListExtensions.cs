using System.Collections.Generic;
using System.Linq;
using BinaryTreeApplication.Model;

namespace BinaryTreeApplication.Helpers
{
    public static class ListExtensions
    {
        public static BinaryTree<Register> ToTree(this List<Register> registers)
        {
            var tree = new BinaryTree<Register>(registers.First());
            foreach (var register in registers.Skip(1))
            {
                tree.Insert(register);
            }
            return tree;
        }
    }
}
