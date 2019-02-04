using BinaryTreeApplication.Model;

namespace BinaryTreeApplication.Services
{
    public interface IFileService<T>
    {
        BinaryTree<T> Open(string filePath);
        void Save(string filePath, BinaryTree<T> data);
    }
}
