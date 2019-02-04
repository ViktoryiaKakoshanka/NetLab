using System.Collections.Generic;
using BinaryTreeApplication.Model;

namespace BinaryTreeApplication.Services
{
    public interface IFileService<T> where T : IComparer<T>
    {
        BinaryTree<T> Read(string filePath);
        void Save(string filePath, BinaryTree<T> data);
    }
}
