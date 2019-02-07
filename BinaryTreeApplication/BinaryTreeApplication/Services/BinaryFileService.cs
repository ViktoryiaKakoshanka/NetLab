using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BinaryTreeApplication.Model;

namespace BinaryTreeApplication.Services
{
    public class FileService<T> : IFileService<T>  where T: IComparer<T>, IEquatable<T>
    {
        public BinaryTree<T> Read(string filePath)
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                return (BinaryTree<T>) formatter.Deserialize(fileStream);
            }
        }

        public void Save(string filePath, BinaryTree<T> data)
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(fileStream, data);
            }
        }
    }
}
