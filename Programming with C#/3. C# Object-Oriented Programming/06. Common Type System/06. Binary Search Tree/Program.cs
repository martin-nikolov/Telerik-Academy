/*
* 5. *Define the data structure binary search tree with operations
* for "adding new element", "searching element" and "deleting elements".
* It is not necessary to keep the tree balanced. 
* 
* Implement the standard methods from System.Object – ToString(),
* Equals(…), GetHashCode() and the operators for comparison  == and !=. 
* 
* Add and implement the ICloneable interface for deep copy of the tree.
* Remark: Use two types – structure BinarySearchTree (for the tree) and
* class TreeNode (for the tree elements). 
* 
* Implement IEnumerable<T> to traverse the tree.
*/

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();

        tree.Insert(23);
        tree.Insert(45);
        tree.Insert(16);
        tree.Insert(37);
        tree.Insert(3);
        tree.Insert(99);
        tree.Insert(22);

        Console.Write("Inorder traversal: \nTree: ");
        foreach (var node in tree)
            Console.Write(node + " ");

        Console.WriteLine("-> Root: {0}", tree.Root);

        /* -------------- */

        Console.WriteLine("\nSearch [9]: {0}", tree.Search(9)); // does not exist
        Console.WriteLine("Search [Root]: {0}\n", tree.Search(tree.Root.Value));

        /* -------------- */

        BinarySearchTree<int> cloneTree = (BinarySearchTree<int>)tree.Clone();

        Console.WriteLine("\nClone tree: {0} -> Root: {1}", cloneTree, cloneTree.Root);

        /* -------------- */

        Console.WriteLine("\n\ntree.Equals(cloneTree): {0}", tree.Equals(cloneTree));
        Console.WriteLine("tree == cloneTree: {0}", tree == cloneTree);
        Console.WriteLine("tree != cloneTree: {0}", tree != cloneTree);

        /* -------------- */

        tree.Insert(1); // this will change hash code of the tree
        cloneTree.Insert(2); // this will change hash code of the tree

        Console.WriteLine("\n\ntree.GetHashCode(): {0}", tree.GetHashCode());
        Console.WriteLine("cloneTree.GetHashCode(): {0}\n", cloneTree.GetHashCode());

        /* -------------- */

        Console.WriteLine("\nTest TreeNode<T> internal class:");

        var treeNode = new BinarySearchTree<int>.TreeNode<int>(25);
        treeNode.LeftChild = new BinarySearchTree<int>.TreeNode<int>(23);
        treeNode.RightChild = new BinarySearchTree<int>.TreeNode<int>(28);

        Console.WriteLine("- Root value: {0}", treeNode.Value);
        Console.WriteLine("- LeftChild: {0}", treeNode.LeftChild);
        Console.WriteLine("- RightChild: {0}\n", treeNode.RightChild);
    }
}