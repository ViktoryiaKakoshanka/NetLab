using System;
using BinaryTreeApplication.Model;

namespace BinaryTreeApplication.Services
{
    public interface IFileService<T> where T : IMyComparable<T>
    {
        BinaryTree<T> Read(string filePath);
        void Save(string filePath, BinaryTree<T> data);
    }
}
