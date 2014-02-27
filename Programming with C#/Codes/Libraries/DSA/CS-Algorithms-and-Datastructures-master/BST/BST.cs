using System;
using System.Collections.Generic;

namespace CodingPractice.BST
{
    public class BST : IBstInterface
    {
        protected BSTNode root;

        #region Implementation of IBstInterface

        public int NumberOfNodes()
        {
            return recNumberOfNodes(root);
        }

        public void Insert(IComparable item)
        {
            root = recInsert(item, root);
        }

        public bool IsThere(IComparable item)
        {
            return recIsThere(item, root);
        }

        public IComparable Retrive(IComparable item)
        {
            return recRetrive(item, root);
        }

        #endregion

        public BST()
        {
            root = null;
        }

        private static int recNumberOfNodes(BSTNode tree)
        {
            //return tree == null ? 0 : recNumberOfNodes(tree.left) + recNumberOfNodes(tree.right) + 1;

            if (tree == null)
                return 0;
            else if (tree.left == null && tree.right == null)
                return 1;
            else if (tree.left == null)
            {
                return recNumberOfNodes(tree.right) + 1; //search right of sub tree
            }
            else if (tree.right == null)
            {
                return recNumberOfNodes(tree.left) + 1; //search left of sub tree
            }
            else
            {   //both left and right are present 
                return recNumberOfNodes(tree.left) + recNumberOfNodes(tree.right) + 1;
            }
        }

        private static BSTNode recInsert(IComparable item, BSTNode tree)
        {
            if (tree == null)
            {
                tree = new BSTNode {left = null, right = null, info = item};
            }
            else if (item.CompareTo(tree.info) < 0)
            {
                tree.left = recInsert(item, tree.left); //insert at the left
            }
            else
            {
                tree.right = recInsert(item, tree.right); // insert at right
            }

            return tree;
        }

        public int NodeCount()
        {
            int count = 0;
            var nodes = new Stack<BSTNode>();
            nodes.Push(root);

            while (nodes.Count > 0)
            {
                BSTNode currNode = nodes.Peek();
                nodes.Pop();
                count++;

                if (currNode.left != null)
                    nodes.Push(currNode.left);
                if (currNode.right != null)
                    nodes.Push(currNode.right);
            }

            return count;
        }

        private bool recIsThere(IComparable item, BSTNode tree)
        {
            if (tree == null)
                return false;
            if (item.CompareTo(tree.info) < 0)
                return recIsThere(item, tree.left);
            else if (item.CompareTo(tree.info) > 0)
                return recIsThere(item, tree.right);
            else
                return true;
        }

        private IComparable recRetrive(IComparable item, BSTNode tree)
        {
            if (item.CompareTo(tree.info) < 0)
                return recRetrive(item, tree.left);
            else if (item.CompareTo(tree.info) > 0)
                return recRetrive(item, tree.right);
            else
                return tree.info;
        }

        #region Nested type: BSTNode

        protected class BSTNode
        {
            public IComparable info;
            public BSTNode left;
            public BSTNode right;
        }

        #endregion
    }
}