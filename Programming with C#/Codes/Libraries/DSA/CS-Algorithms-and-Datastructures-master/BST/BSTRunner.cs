using System;
using System.Threading;

namespace CodingPractice.BST
{
    public static class BSTRunner
    {
        public static void run()
        {
            //var bst = new BST();
            //bst.Insert(5);
            //bst.Insert(8);
            //bst.Insert(3);
            //bst.Insert(1);
            //bst.Insert(10);
            //bst.Insert(12);

            //Console.WriteLine(bst.NumberOfNodes());
            //Console.WriteLine(bst.NodeCount());
            //Console.WriteLine(bst.IsThere(156));
            //Console.WriteLine(bst.Retrive(12));

            var node = new BinarySearchTree();
            /*node.insert(10);
            node.insert(7);
            node.insert(15);
            node.insert(5);
            node.insert(12);
            node.insert(18);
            node.insert(1);*/
            
            //node.balance();
			  node.Insert(5);
			  node.Insert(4);
			  node.Insert(7);
			  node.Insert(3);
			  node.Insert(6);
			  node.Insert(2);
			  node.Insert(9);

            node.PrintRootToLeavePath();
		  //  Console.WriteLine(node.IsBalanced());

		  //node.Balance();

		  //  Console.WriteLine(node.IsBalanced());
		    Console.WriteLine(node.IsBinarySearchTree());
			Thread.Sleep(10000);
        	//Console.WriteLine(node.getNodeLevel(10));
        }
    }
}