/*
 * 10. We are given N and M and the following operations:
 * N = N+1
 * N = N+2
 * N = N*2
 * 
 * Write a program, which finds the shortest subsequence from
 * the operations, which starts with N and ends with M. 
 * Use queue.
 * 
 * Example: N = 5, M = 16
 * Subsequence: 5 -> 7 -> 8 -> 16
 */

namespace PathFinder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AllPathsBetweenTwoPoints
    {
        static readonly Func<int, int>[] operations =
        {
            x => x * 2,
            x => x + 2,
            x => x + 1
        };

        static void Main(string[] args)
        {
            int n = 5;
            int m = 16;

            FindAllPaths(n, m);
        }

        /// <summary>
        /// Finds and prints all paths between two numbers.
        /// </summary>
        /// <param name="n">The startup number.</param>
        /// <param name="m">The final (max) number.</param>
        static void FindAllPaths(int n, int m)
        {
            // if n > m
            SwapValue(ref n, ref m);

            // parent node -> startup value
            var parentNode = new Node<int>(n);

            // leaf (last child) -> final (max) value
            var leaf = new Node<int>(m);

            FindAllPathsBFS(parentNode, leaf);
            PrintAllPaths(parentNode);
        }

        /// <summary>
        /// Finds all paths between two Node values using recursively BFS algorithm.
        /// </summary>
        /// <param name="parentNode">The startup Node value.</param>
        /// <param name="leaf">The final (max) Node value.</param>
        static void FindAllPathsBFS(Node<int> parentNode, Node<int> leaf)
        {
            // Adds childs with calculated values to parentNode
            foreach (var operation in operations)
            {
                var newNodeValue = operation(parentNode.Value);

                // Adds childs only if its value <= m
                if (newNodeValue <= leaf.Value)
                {
                    parentNode.AddChild(new Node<int>(newNodeValue));
                }
            }

            // Repeats recursively steps above for each childs of parentNode
            foreach (var child in parentNode.Childs)
            {
                FindAllPathsBFS(child, leaf);
            }
        }

        /// <summary>
        /// Prints all paths using appropriate format.
        /// </summary>
        /// <param name="parentNode">The startup Node value.</param>
        static void PrintAllPaths(Node<int> parentNode, string separator = " -> ")
        {
            var allPaths = new List<LinkedList<int>>();
            ConnectAllPathsDFS(parentNode, new LinkedList<int>(), ref allPaths);

            Console.WriteLine("All Paths Count: " + allPaths.Count + Environment.NewLine);

            // Finds all shortest paths
            var minPathLength = allPaths.Min(a => a.Count);
            var shortestPaths = allPaths.Where(a => a.Count == minPathLength).ToList();

            Console.WriteLine("-------------- SHORTEST PATHS --------------\n");

            PrintCurrentPath(shortestPaths, separator);

            Console.WriteLine("\n---------------- ALL PATHS -----------------\n");

            PrintCurrentPath(allPaths, separator);
        }

        /// <summary>
        /// Prints all paths from list of paths.
        /// </summary>
        /// <param name="pathCollection">The list containing lists of paths.</param>
        static void PrintCurrentPath(IList<LinkedList<int>> pathCollection, string separator)
        {
            for (int i = 0; i < pathCollection.Count; i++)
            {
                Console.WriteLine(string.Join(separator, pathCollection[i]));
            }
        }

        /// <summary>
        /// Connecting childs to form and store the full path.
        /// </summary>
        /// <param name="parentNode">The startup Node value.</param>
        /// <param name="currentResult">The list stores current paths in every moment.</param>
        /// <param name="allPaths">The collection stores all paths.</param>
        static void ConnectAllPathsDFS(Node<int> parentNode, LinkedList<int> currentResult, ref List<LinkedList<int>> allPaths)
        {
            currentResult.AddLast(parentNode.Value);

            // For each child go and visit its subtree
            foreach (var child in parentNode.Childs)
            {
                ConnectAllPathsDFS(child, currentResult, ref allPaths);
            }

            if (parentNode.Childs.Count == 0)
            {
                allPaths.Add(new LinkedList<int>(currentResult));
            }

            currentResult.RemoveLast();
        }

        static void SwapValue(ref int n, ref int m)
        {
            if (n > m)
            {
                int swap = n;
                n = m;
                m = swap;
            }
        }
    }
}