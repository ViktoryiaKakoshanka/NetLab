using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace BinaryTreeApplication.Model
{
    [Serializable]
    public class BinaryTree<TValue> : IEquatable<BinaryTree<TValue>>
        where TValue : IComparer<TValue>, IEquatable<TValue>
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

            if (value.Compare(value, Value) < 0)
            {
                if (LeftNode == null)
                {
                    LeftNode = new BinaryTree<TValue>(value);
                    return this;
                }

                LeftNode.Insert(value);
            }

            return this;
        }

        public BinaryTree<TValue> FindFirstNode(TValue value)
        {
            if (value.Equals(Value))
            {
                return this;
            }

            if (value.Compare(value, Value) >= 0 && RightNode != null)
            {
                return RightNode.FindFirstNode(value);
            }

            if (value.Compare(value, Value) < 0 && LeftNode != null)
            {
                return LeftNode.FindFirstNode(value);
            }

            throw new Exception("Value not found.");
        }
        
        public BinaryTree<TValue> Remove(TValue value)
        {
            var currentTree = new BinaryTree<TValue>(this);

            if (value.Compare(value, currentTree.Value) >= 0)
            {
                if (value.Equals(currentTree.Value))
                {
                   return ReplaceItem(currentTree);
                }
                currentTree.RightNode = currentTree.RightNode?.Remove(value);
            }

            if (value.Compare(value, currentTree.Value) < 0)
            {
                currentTree.LeftNode = currentTree.LeftNode?.Remove(value);
            }

            return new BinaryTree<TValue>(currentTree);
        }

        public bool Equals(BinaryTree<TValue> other)
        {
            return Value.Equals(other.Value) && RightNode.Equals(other.RightNode) && LeftNode.Equals(other.LeftNode);
        }

        public override int GetHashCode()
        {
            var rightCode = (RightNode == null) ? 0 : RightNode.Value.GetHashCode();
            var leftCode = (LeftNode == null) ? 0 : LeftNode.Value.GetHashCode();

            return checked(Value.GetHashCode() ^ rightCode * 397 * leftCode);
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
            if (tree == null)
            {
                return;
            }
            _list.Add(tree.Value);
            TreeTraversal(tree.LeftNode);
            TreeTraversal(tree.RightNode);
        }

        private static BinaryTree<TValue> ReplaceItem(BinaryTree<TValue> tree)
        {
            if (tree.LeftNode == null || tree.RightNode == null)
            {
                return RemoveItemWithSimpleDependency(tree);
            }

            return RemoveItemWithFullDependency(tree);
        }

        private static BinaryTree<TValue> RemoveItemWithSimpleDependency(BinaryTree<TValue> tree)
        {
            if (tree.RightNode == null && tree.LeftNode == null)
            {
                return null;
            }

            if (tree.RightNode != null && tree.LeftNode == null)
            {
                return new BinaryTree<TValue>(tree.RightNode);
            }

            if (tree.RightNode == null && tree.LeftNode != null)
            {
                return new BinaryTree<TValue>(tree.LeftNode);
            }

            return new BinaryTree<TValue>(tree);
        }

        private static BinaryTree<TValue> RemoveItemWithFullDependency(BinaryTree<TValue> tree)
        {
            if (tree.RightNode.LeftNode == null)
            {
                tree.Value = tree.RightNode.Value;
                tree.RightNode = tree.RightNode.RightNode;
                return new BinaryTree<TValue>(tree);
            }
            
            var temp = tree.RightNode;
            while (temp?.LeftNode != null)
            {
                temp = temp.LeftNode;
            }

            tree.Value = temp.Value;
            tree.RightNode = tree.RightNode?.Remove(temp.Value);

            return new BinaryTree<TValue>(tree);
        }
    }
}