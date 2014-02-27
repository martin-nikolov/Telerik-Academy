using System;
using System.Collections.Generic;

namespace CodingPractice.BST
{
	public class BinarySearchTree
	{
		private Queue<IComparable> inOrderQueue;
		private BSTNode root;
		private IComparable[] nodeData;

		public BinarySearchTree()
		{
			root = null;
		}

		public void Insert(IComparable item)
		{
			root = recInsert(root, item);
		}

		public Queue<IComparable> GetIorderQueue()
		{
			inOrderQueue = new Queue<IComparable>();
			inOrder(root);
			return inOrderQueue;
		}

		public void PrintInOrder()
		{
			foreach (IComparable inOrder in GetIorderQueue())
			{
				Console.WriteLine(inOrder);
			}
		}

		public void Balance()
		{
			Queue<IComparable> treeData = GetIorderQueue();
			nodeData = treeData.ToArray();
			root = null; // delete old tree and then start all over again
			balanceInsert(0, nodeData.Length - 1);
		}

		public void Delete(IComparable item)
		{
			root = recDelete(item, root);
		}

		public int GetNodeLevel(IComparable item)
		{
			return find_NodeLevel(root, item);
		}

		public void PrintRootToLeavePath()
		{
			var nodes = new IComparable[1000];

			printPath(nodes, root, 0);
		}

		public bool IsBalanced()
		{
			return checkHeight(root) != -1;
		}

		public bool IsBinarySearchTree()
		{
			return recIsBst(root, int.MinValue, int.MaxValue);
		}

		private static bool recIsBst(BSTNode node, int min, int max)
		{
			//an empty tree is an BST
			if (node == null) return true;

			if (node.data.CompareTo(min) < 0 || node.data.CompareTo(max) > 0)
				return false;

			return recIsBst(node.left, min, (int) node.data) && recIsBst(node.right, (int) node.data + 1, max) ;
		}

		private static int checkHeight(BSTNode node)
		{
			if (node == null) return 0; //height of 0

			int leftHeight = checkHeight(node.left);
			if (leftHeight == -1) return -1; // not balanced

			int rightHeight = checkHeight(node.right);
			if (rightHeight == -1) return -1; // not balanced

			int heightDiff = leftHeight - rightHeight; // check if current node is balanced
			if (Math.Abs(heightDiff) > 1) 
				return -1;
			return Math.Max(leftHeight, rightHeight) + 1; //return height

		}

		private static BSTNode recInsert(BSTNode node, IComparable item)
		{
			if (node == null)  //base case
				return new BSTNode {data = item};

			if (item.CompareTo(node.data) < 0) //go to left 
				node.left = recInsert(node.left, item);

			if (item.CompareTo(node.data) > 0) // go to right
				node.right = recInsert(node.right, item);

			return node;
		}

		private void balanceInsert(int low, int high)
		{
			if (low == high) // when there is only one data to be inserted
				Insert(nodeData[low]);
			else if (low + 1 == high) // when there are only two data elements to be inserted.
			{
				Insert(nodeData[low]);
				Insert(nodeData[high]);
			}
			else
			{
				int mid = (low + high)/2;
				Insert(nodeData[mid]);
				balanceInsert(low, mid - 1);
				balanceInsert(mid + 1, high);
			}
		}

		private void inOrder(BSTNode tree)
		{
			if (tree == null) return;
			inOrder(tree.left);
			inOrderQueue.Enqueue(tree.data);
			inOrder(tree.right);
		}

		private BSTNode recDelete(IComparable item, BSTNode tree)
		{
			if (item.CompareTo(tree.data) < 0) // go left
				tree.left = recDelete(item, tree.left);
			else if (item.CompareTo(tree.data) > 0) // go right
				tree.right = recDelete(item, tree.right);
			else
				tree = deleteNode(tree); // found the node .. so go ahead and delete it

			return tree;
		}

		private BSTNode deleteNode(BSTNode tree)
		{
			if (tree.right == null && tree.left == null) // delete the leaf node
				return null;
			else if (tree.left == null) // node to be delete doesnt have left child so return right one
				return tree.right;
			else if (tree.right == null) // no right child so return left
				return tree.left;
			else
			{
				IComparable temp = getDescendentValue(tree.left); // get data to be replaced
				tree.data = temp; // copy that data 
				tree.left = recDelete(temp, tree.left);
				return tree;
			}
		}

		private static IComparable getDescendentValue(BSTNode tree)
		{
			while (tree.right != null)
			{
				tree = tree.right;
			}

			return tree.data;
		}

		private static int find_NodeLevel(BSTNode tree, IComparable item)
		{
			int level = 0;

			while (tree != null)
			{
				if (item.CompareTo(tree.data) == 0)
					return level++;
				if (item.CompareTo(tree.data) < 0) // if item less go left
				{
					tree = tree.left;
					level++;
				}
				else if (item.CompareTo(tree.data) > 0) // go right
				{
					tree = tree.right;
					level++;
				}
			}

			return level;
		}


		private static void printPath(IComparable[] toPrintNodes, BSTNode tree, int len)
		{
			if (tree == null) return;
			toPrintNodes[len] = tree.data;
			len++;
			if (tree.left == null && tree.right == null)
				printTree(toPrintNodes, len);
			else
			{
				printPath(toPrintNodes, tree.left, len);
				printPath(toPrintNodes, tree.right, len);
			}
		}

		private static void printTree(IComparable[] treeToPrint, int len)
		{
			for (int i = 0; i < len; i++)
			{
				Console.Write(treeToPrint[i]);
			}
			
			Console.WriteLine();
		}
	}

	internal class BSTNode
	{
		public IComparable data;
		public BSTNode left;
		public BSTNode right;
	}
}