using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public partial class BinarySearchTree<T> : ICloneable, IEnumerable<T>
    where T : IComparable<T>
{
    private TreeNode<T> root;

    public BinarySearchTree()
    {
        this.Root = root;
    }

    internal TreeNode<T> Root
    {
        get { return this.root; }
        private set { this.root = value; }
    }

    public void Insert(T value)
    {
        TreeNode<T> newNode = new TreeNode<T>(value);

        if (this.Root == null)
        {
            this.Root = newNode;
            return;
        }
        
        TreeNode<T> current = this.Root;
        TreeNode<T> parent;

        while (true)
        {
            parent = current; // by reference

            if (value.CompareTo(current.Value) < 0)
            {
                current = current.LeftChild;

                if (current == null)
                {
                    parent.LeftChild = newNode;
                    break;
                }
            }
            else if (value.CompareTo(current.Value) > 0)
            {
                current = current.RightChild;

                if (current == null)
                {
                    parent.RightChild = newNode;
                    break;
                }
            }
            else
            {
                break;
            }
        }
    }

    internal TreeNode<T> Search(T key)
    {
        TreeNode<T> current = this.root;

        while (current != null)
        {
            int compareTo = key.CompareTo(current.Value);

            if (compareTo < 0)
                current = current.LeftChild;
            else if (compareTo > 0)
                current = current.RightChild;
            else
                break;
        }

        return current;
    }
    
    public object Clone()
    {
        BinarySearchTree<T> tree = new BinarySearchTree<T>();
        TreeNode<T> theRoot = this.Root;

        // Preorder traversal
        if (theRoot != null)
        {
            tree.Insert(theRoot.Value);

            foreach (T node in this.InOrder(theRoot.LeftChild))
                tree.Insert(node);

            foreach (T node in this.InOrder(theRoot.RightChild))
                tree.Insert(node);
        }

        return tree;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.InOrder(this.Root).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private IEnumerable<T> InOrder(TreeNode<T> theRoot)
    {
        if (theRoot != null)
        {
            foreach (T node in this.InOrder(theRoot.LeftChild))
                yield return node;

            yield return theRoot.Value;

            foreach (T node in this.InOrder(theRoot.RightChild))
                yield return node;
        }
    }

    public override int GetHashCode()
    {
        int hashCode = 17;

        unchecked
        {
            if (Root != null)
                hashCode = hashCode * 23 + Root.Value.GetHashCode();

            foreach (T item in this)
                hashCode = hashCode * 23 + item.GetHashCode();
        }

        return hashCode;
    }

    public override bool Equals(object obj)
    {
        IEnumerator<T> tree1 = this.GetEnumerator();
        IEnumerator<T> tree2 = ((BinarySearchTree<T>)obj).GetEnumerator();

        while (tree1.MoveNext() && tree2.MoveNext())
            if (!tree1.Current.Equals(tree2.Current))
                return false;

        return !tree1.MoveNext() && !tree2.MoveNext();
    }

    public static bool operator ==(BinarySearchTree<T> tree1, BinarySearchTree<T> tree2)
    {
        return tree1.Equals(tree2);
    }

    public static bool operator !=(BinarySearchTree<T> tree1, BinarySearchTree<T> tree2)
    {
        return !tree1.Equals(tree2);
    }

    public override string ToString()
    {
        return string.Join(" ", this);
    }
}