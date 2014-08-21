namespace PathFinder
{
    using System;
    using System.Collections.Generic;
    using DynamicList;
    using PathFinder.PrintStrategy;

    public class AllPathsBetweenTwoPointsFinder
    {
        private readonly Func<int, int>[] operations =
        {
            x => x * 2,
            x => x + 2,
            x => x + 1
        };

        private Node<int> parentNode = null;

        /// <summary>
        /// Finds and prints all paths between two numbers.
        /// </summary>
        /// <param name="startValue">The startup number.</param>
        /// <param name="endValue">The final (max) number.</param>
        public void FindAllPaths(int startValue, int endValue)
        {
            // if startValue > endValue
            this.SwapValue(ref startValue, ref endValue);

            // parent node -> startup value
            this.parentNode = new Node<int>(startValue);

            // leaf (last child) -> final (max) value
            var leaf = new Node<int>(endValue);

            this.FindAllPathsBFS(this.parentNode, leaf);
        }

        /// <summary>
        /// Connects and prints all paths + shortest paths using appropriate format.
        /// </summary>
        /// <param name="printerStrategy">The result printer strategy</param>
        public void PrintResult(IPrinter printerStrategy)
        {
            var allPaths = new List<DoubleLinkedList<int>>();
            this.ConnectAllPathsDFS(this.parentNode, new DoubleLinkedList<int>(), ref allPaths);

            printerStrategy.PrintResult(allPaths, this.parentNode);
        }

        /// <summary>
        /// Finds all paths between two Node values using recursively BFS algorithm.
        /// </summary>
        /// <param name="parentNode">The startup Node value.</param>
        /// <param name="leaf">The final (max) Node value.</param>
        private void FindAllPathsBFS(Node<int> parentNode, Node<int> leaf)
        {
            // Adds childs with calculated values to parentNode
            foreach (var operation in this.operations)
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
                this.FindAllPathsBFS(child, leaf);
            }
        }

        /// <summary>
        /// Connecting childs to form and store the full path.
        /// </summary>
        /// <param name="parentNode">The startup Node value.</param>
        /// <param name="currentResult">The list stores current paths in every moment.</param>
        /// <param name="allPaths">The collection stores all paths.</param>
        private void ConnectAllPathsDFS(Node<int> parentNode, DoubleLinkedList<int> currentResult, ref List<DoubleLinkedList<int>> allPaths)
        {
            currentResult.AddLast(parentNode.Value);

            // For each child go and visit its subtree
            foreach (var child in parentNode.Childs)
            {
                this.ConnectAllPathsDFS(child, currentResult, ref allPaths);
            }

            if (parentNode.Childs.Count == 0)
            {
                allPaths.Add(new DoubleLinkedList<int>(currentResult));
            }

            currentResult.RemoveLast();
        }

        private void SwapValue(ref int n, ref int m)
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