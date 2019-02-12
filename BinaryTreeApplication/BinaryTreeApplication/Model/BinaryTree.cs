using System;
using System.Collections.Generic;

namespace BinaryTreeApplication.Model
{
    [Serializable]
    public class BinaryTree<TValue> where TValue : IComparer<TValue>, IEquatable<TValue>
    {
        public TValue Value { get; set; }
        public BinaryTree<TValue> RightNode { get; set; }
        public BinaryTree<TValue> LeftNode { get; set; }

        private List<TValue> _list;

        public BinaryTree(TValue value) : this(value, null, null)
        {
        }

        public BinaryTree(TValue value, BinaryTree<TValue> rightNode, BinaryTree<TValue> leftNode)
        {
            Value = value;
            RightNode = rightNode;
            LeftNode = leftNode;
        }

        public BinaryTree(BinaryTree<TValue> binaryTree)
        {
            Value = binaryTree.Value;
            RightNode = binaryTree.RightNode;
            LeftNode = binaryTree.LeftNode;
        }

        public BinaryTree<TValue> Insert(TValue value)
        {
            if (value.Compare(value, Value) >= 0)
            {
                if (RightNode == null)
                {
                    RightNode = new BinaryTree<TValue>(value);
                    return this;
                }

                if (value.Compare(value, Value) == 0)
                {
                    var temp = new BinaryTree<TValue>(value)
                    {
                        RightNode = RightNode
                    };
                    RightNode = temp;
                    return this;
                }

                RightNode.Insert(value);
            }

            if (LeftNode == null)
            {
                LeftNode = new BinaryTree<TValue>(value);
                return this;
            }

            LeftNode.Insert(value);

            return this;
        }

        public List<TValue> ToList()
        {
            var tree = new BinaryTree<TValue>(this);
            _list = new List<TValue>();

            TreeTraversal(tree);

            var temp = _list;
            _list = null;
            return temp;
        }

        private void TreeTraversal(BinaryTree<TValue> tree)
        {
            while (true)
            {
                if (tree == null)
                {
                    return;
                }

                _list.Add(tree.Value);
                TreeTraversal(tree.LeftNode);
                tree = tree.RightNode;
            }
        }
    }
}