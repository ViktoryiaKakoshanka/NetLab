using System;
using System.Collections.Generic;

namespace BinaryTreeApplication.Model
{
    [Serializable]
    public class BinaryTree<TValue> where TValue : IComparer<TValue>
    {
        public int Key { get; set; }
        public TValue Value { get; set; }
        public BinaryTree<TValue> RightNode { get; set; }
        public BinaryTree<TValue> LeftNode { get; set; }

        public BinaryTree()
        {
        }

        public BinaryTree(int key, TValue value) : this(key, value, null, null)
        {
        }

        public BinaryTree(int key, TValue value, BinaryTree<TValue> rightNode, BinaryTree<TValue> leftNode)
        {
            Key = key;
            Value = value;
            RightNode = rightNode;
            LeftNode = leftNode;
        }

        public BinaryTree(BinaryTree<TValue> binaryTree)
        {
            Key = binaryTree.Key;
            Value = binaryTree.Value;
            RightNode = binaryTree.RightNode;
            LeftNode = binaryTree.LeftNode;
        }

        public BinaryTree<TValue> Insert(int key, TValue value)
        {
            if (key > Key)
            {
                if (RightNode == null)
                {
                    RightNode = new BinaryTree<TValue>(key, value);
                }
                else
                {
                    RightNode.Insert(key, value);
                }
            }

            if (key < Key)
            {
                if (LeftNode == null)
                {
                    LeftNode = new BinaryTree<TValue>(key, value);
                }
                else
                {
                    LeftNode.Insert(key, value);
                }
            }

            if (key == Key)
            {
                throw new Exception("This key already exists.");
            }

            return new BinaryTree<TValue>(this);
        }

        public BinaryTree<TValue> Remove(int key)
        {
            var result = new BinaryTree<TValue>(this);

            if (key > result.Key)
            {
                result.RightNode = result.RightNode?.Remove(key);
            }

            if (key < result.Key)
            {
                result.LeftNode = result.LeftNode?.Remove(key);
            }

            if (key != result.Key)
            {
                return new BinaryTree<TValue>(result);
            }

            if (result.RightNode == null && result.LeftNode == null)
            {
                return null;
            }

            if (result.RightNode != null && result.LeftNode == null)
            {
                return new BinaryTree<TValue>(result.RightNode);
            }

            if (result.RightNode == null && result.LeftNode != null)
            {
                return new BinaryTree<TValue>(result.LeftNode);
            }

            ReplaceItem(result);

            return new BinaryTree<TValue>(result);
        }

        public BinaryTree<TValue> Find(int key)
        {
            if (key == Key)
            {
                return this;
            }

            if (key > Key && RightNode != null)
            {

                return RightNode.Find(key);
            }

            if (key < Key && LeftNode != null)
            {
                return LeftNode.Find(key);
            }

            throw new Exception("Key not found.");
        }

        private static void ReplaceItem(BinaryTree<TValue> result)
        {
            if (result.RightNode.LeftNode == null)
            {
                result.Key = result.RightNode.Key;
                result.Value = result.RightNode.Value;
                result.RightNode = result.RightNode.RightNode;
            }
            else
            {
                var temp = result.RightNode;
                while (temp?.LeftNode != null)
                {
                    temp = temp.LeftNode;
                }

                result.Value = temp.Value;
                result.Key = temp.Key;
                result.RightNode = result.RightNode?.Remove(temp.Key);
            }
        }
    }
}