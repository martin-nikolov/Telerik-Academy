using System;
using System.Linq;

public partial class BinarySearchTree<T>
{
    internal class TreeNode<T> : IComparable<TreeNode<T>>
        where T : IComparable<T>
    {
        public TreeNode(T value)
        {
            if (value == null)
                throw new ArgumentException("Cannot insert null value");

            this.Value = value;
        }

        public T Value { get; set; }
        
        public TreeNode<T> LeftChild { get; set; }

        public TreeNode<T> RightChild { get; set; }

        public int CompareTo(TreeNode<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.CompareTo((TreeNode<T>)obj) == 0;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}