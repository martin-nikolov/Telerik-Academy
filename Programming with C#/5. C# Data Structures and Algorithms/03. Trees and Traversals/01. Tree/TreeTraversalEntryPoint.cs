/*
 * 1. You are given a tree of N nodes represented as a set of N-1 pairs of 
 * nodes (parent node, child node), each in the range (0..N-1). 
 * 
 * Write a program to read the tree and find:
 *   a) the root node
 *   b) all leaf nodes
 *   c) all middle nodes
 *   d) the longest path in the tree
 *   e) all paths in the tree with given sum S of their nodes
 *   f) all subtrees with given sum S of their nodes
 */

namespace TreesTraversals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeTraversalEntryPoint
    {
        private static readonly Tree<int> tree = new Tree<int>();

        public static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input_4.txt"));
            #endif

            // YOU CAN SEE TREE DIAGRAM -> Tree-Diagram.jpg

            ProcessInput();

            Console.WriteLine("----------------- PARENT NODE: ----------------");
            {
                PrintParentNode();
            }

            Console.WriteLine("------------------ ALL NODES: -----------------");
            {
                PrintNodes(tree.Nodes);
            }

            Console.WriteLine("---------------- MIDDLE NODES: ----------------");
            {
                PrintNodes(tree.MiddleNodes);
            }

            Console.WriteLine("----------------- LEAF NODES: -----------------");
            {
                PrintNodes(tree.LeafNodes);
            }

            Console.WriteLine("------------ LONGEST PATH IN TREE: ------------");
            {
                var treeTraversal = new TreeTraversalStrategy();

                Console.WriteLine("\nStarting from Root Node:");
                {
                    var longestPaths = treeTraversal.GetLongestPathInTree(tree.ParentNode);
                    PrintPaths(longestPaths, null);
                }

                Console.WriteLine("\nStarting from Middle Nodes (Longest paths in subtrees):");
                {
                    var longestPaths = treeTraversal.GetLongestPathInTree(tree.Nodes.First(n => n.Value == 2));
                    PrintPaths(longestPaths, null);

                    longestPaths = treeTraversal.GetLongestPathInTree(tree.Nodes.First(n => n.Value == 5));
                    PrintPaths(longestPaths, null);
                }
            }

            Console.WriteLine("\n---------- ALL PATHS WITH GIVEN SUM: ----------");
            {
                var treeTraversal = new TreeTraversalStrategy();

                Console.WriteLine("\nStarting from Root Node:");
                {
                    int sumFromRoot = 9;
                    var allPathsWithGivenSum = treeTraversal.GetAllPathsInTreeWithGivenSum(tree.ParentNode, sumFromRoot);
                    PrintPaths(allPathsWithGivenSum, sumFromRoot);                    
                }

                Console.WriteLine("\nStarting from Middle Nodes (Paths with given sum in subtrees):");
                {
                    int sumFromMiddleNode = 6;
                    var allPathsWithGivenSum = treeTraversal.GetAllPathsInTreeWithGivenSum(tree.Nodes.First(n => n.Value == 2), sumFromMiddleNode);
                    PrintPaths(allPathsWithGivenSum, sumFromMiddleNode);

                    allPathsWithGivenSum = treeTraversal.GetAllPathsInTreeWithGivenSum(tree.Nodes.First(n => n.Value == 5), sumFromMiddleNode);
                    PrintPaths(allPathsWithGivenSum, sumFromMiddleNode);
                }
            }

            Console.WriteLine("\n-------- ALL SUBTREES WITH GIVEN SUM: ---------");
            {
                var treeTraversal = new TreeTraversalStrategy();

                var sum = 16;
                var allSubtreesPaths = treeTraversal.GetAllSubtreesWithGivenSum(tree, sum);
                PrintPaths(allSubtreesPaths, sum);
            }
        }
 
        private static void PrintNodes<T>(IReadOnlyCollection<Node<T>> nodes)
        {
            foreach (var node in nodes)
            {
                Console.WriteLine(node);
            }

            Console.WriteLine();
        }

        private static void PrintParentNode()
        {
            Console.WriteLine("Parent node: {0}\n", tree.ParentNode);
        }

        private static void PrintPaths(List<List<int>> paths, int? sum, string separator = " -> ")
        {
            foreach (var path in paths.OrderBy(p => p.Count))
            {
                Console.WriteLine("{0} {1}",
                    string.Join(separator, path), sum.HasValue ? "(Sum: " + sum.Value + ")" : string.Empty);
            }
        }

        private static void ProcessInput()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                ParseInput(input);
                input = Console.ReadLine();
            }
        }

        private static void ParseInput(string inputLine)
        {
            var inputValues = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(v => int.Parse(v))
                                       .ToArray();

            var parentNodeValue = inputValues[0];
            var childNodeValue = inputValues[1];

            tree.ConnectNodes(parentNodeValue, childNodeValue);
        }
    }
}