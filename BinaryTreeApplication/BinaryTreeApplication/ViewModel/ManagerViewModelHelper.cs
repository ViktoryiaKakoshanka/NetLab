using BinaryTreeApplication.Model;
using System.Collections.ObjectModel;

namespace BinaryTreeApplication.ViewModel
{
    public static class ManagerViewModelHelper
    {
        public static BinaryTree<Register> GenerateDataTree()
        {
            var tree = new BinaryTree<Register>(Register.GenerateNewRegister());

            for (var i = 0; i < 15; i++)
            {
                tree.Insert(Register.GenerateNewRegister());
            }

            return tree;
        }

        public static ObservableCollection<string> GenerateNamesOfFields()
        {
            return new ObservableCollection<string>
            {
                nameof(Register.TestName),
                nameof(Register.Student),
                nameof(Register.Date),
                nameof(Register.Mark)
            };
        }
    }
}