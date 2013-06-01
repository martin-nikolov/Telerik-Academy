using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace _10_ShortestSequenceOfOperations
{
    class ShortestSequenceOfOperations
    {
        static void Main(string[] args)
        {
            int n = 5;
            int m = 16;
            int level = 0;
            bool isFoundLevel = false;
            Stack<TreeNode> shortestSequence = new Stack<TreeNode>();
            TreeNode root = new TreeNode(n, null);
            List<TreeNode> foundNodes = new List<TreeNode>();
            FillTree(root, m);
 
            if (n < m)//http://en.wikipedia.org/wiki/Breadth-first_search
            {
                TreeNode currentNode;
                Queue<TreeNode> treeNodes = new Queue<TreeNode>();
                treeNodes.Enqueue(root);
 
                while (treeNodes.Count > 0)
                {
                    currentNode = treeNodes.Dequeue();
                    if (currentNode.Value == m)
                    {
                        if (!isFoundLevel || (isFoundLevel && currentNode.Level == level))
                        {
                            foundNodes.Add(currentNode);
                            level = currentNode.Level;
                            isFoundLevel = true;
                        }
                    }
                    else if (currentNode.Value < m && isFoundLevel == false)
                    {
                        foreach (TreeNode node in currentNode.Children)
                        {
                            treeNodes.Enqueue(node);
                        }
                    }
                }
 
                string shortestPath = string.Empty;
                if (foundNodes.Count != 0)
                {
                    StringBuilder sb = new StringBuilder();
                   
                    foreach (TreeNode nodeItem in foundNodes)
                    {
                        shortestSequence.Clear();
                        shortestSequence.Push(nodeItem);
                        BuildPath(nodeItem, shortestSequence);
 
                        foreach (TreeNode node in shortestSequence)
                        {
                            sb.AppendFormat("{0} ", node.Value);
                        }
                        sb.AppendLine();
                    }
                   
                    shortestPath = sb.ToString();
                }
                else
                {
                    shortestPath = "Path not found!";
                }
 
                Console.WriteLine(shortestPath);
            }
        }
 
        private static void BuildPath(TreeNode currentNode, Stack<TreeNode> shortestSequence)
        {
            if (currentNode.Parent != null)
            {
                shortestSequence.Push(currentNode.Parent);
                BuildPath(currentNode.Parent, shortestSequence);
            }
        }
 
        private static void FillTree(TreeNode treeNode, int endValue)
        {
            int currentValue = treeNode.Value;
            int childValue;
            TreeNode childNode;
 
            if (currentValue < endValue)
            {
                foreach (var operation in operations)
                {
                    childValue = operation(currentValue);
                    childNode = new TreeNode(childValue, treeNode);
                    treeNode.Children.Add(childNode);
                    FillTree(childNode, endValue);
                }
            }
            else
            {
                return;
            }
        }
 
        static readonly Func<int, int>[] operations =
        {
            x => x + 1,
            x => x + 2,
            x => x * 2,
        };
    }
 
    public class TreeNode
    {
        private int value;
        private TreeNode parent;
        private List<TreeNode> children;
        private readonly int level;
 
        public TreeNode(int value, TreeNode parent)
        {
            this.value = value;
            this.parent = parent;
            this.children = new List<TreeNode>();
            if (parent == null)
            {
                this.level = 0;
            }
            else
            {
                this.level = this.Parent.Level + 1;
            }
        }
 
        public int Level
        {
            get
            {
                return this.level;
            }
        }
 
        public int Value
        {
            get
            {
                return this.value;
            }
            private set
            {
                this.value = value;
            }
        }
 
        public TreeNode Parent
        {
            get
            {
                return this.parent;
            }
            private set
            {
                this.parent = value;
            }
        }
 
        public List<TreeNode> Children
        {
            get
            {
                return this.children;
            }
            private set
            {
                this.children = value;
            }
        }
    }
}