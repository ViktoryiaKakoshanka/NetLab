using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BinaryTreeApplication.Model;

namespace BinaryTreeApplication
{
    public class FileService<TValue>
    {
        public BinaryTree<TValue> Open(string filePath)
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                return (BinaryTree<TValue>) formatter.Deserialize(fileStream);
            }
        }

        public void Save(string filePath, BinaryTree<TValue> data)
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(fileStream, data);
            }
        }
    }
}
