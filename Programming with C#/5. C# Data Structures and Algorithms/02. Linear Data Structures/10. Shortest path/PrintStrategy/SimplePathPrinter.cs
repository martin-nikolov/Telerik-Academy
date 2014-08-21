namespace PathFinder.PrintStrategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DynamicList;
    using PathFinder;

    public class SimplePathPrinter : IPrinter
    {
        public void PrintResult(List<DoubleLinkedList<int>> allPaths, Node<int> parentNode, string separator = " -> ")
        {
            Console.WriteLine("---------------- ALL PATHS -----------------\n");

            this.PrintCurrentPath(allPaths, separator);

            Console.WriteLine("\n--------------------------------------------\n");

            Console.WriteLine("All Paths Count: " + allPaths.Count + Environment.NewLine);

            // Finds all shortest paths
            var minPathLength = allPaths.Min(a => a.Count);
            var shortestPaths = allPaths.Where(a => a.Count == minPathLength).ToList();

            Console.WriteLine("-------------- SHORTEST PATHS --------------\n");

            this.PrintCurrentPath(shortestPaths, separator);

            Console.WriteLine("\n--------------------------------------------\n");
        }

        /// <summary>
        /// Prints all paths from list of paths.
        /// </summary>
        /// <param name="pathCollection">The list containing lists of paths.</param>
        public void PrintCurrentPath(IList<DoubleLinkedList<int>> pathCollection, string separator)
        {
            for (int i = 0; i < pathCollection.Count; i++)
            {
                Console.WriteLine(string.Join(separator, pathCollection[i]));
            }
        }
    }
}