namespace PathFinder.PrintStrategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PathFinder;

    public class SimplePathPrinter : IPrinter
    {
        public void PrintResult(List<LinkedList<int>> allPaths, Node<int> parentNode, string separator = " -> ")
        {
            this.PrintCurrentPath(allPaths, separator);

            Console.WriteLine("\n--------------------------------------------\n");

            Console.WriteLine("All Paths Count: " + allPaths.Count + Environment.NewLine);

            // Finds all shortest paths
            var minPathLength = allPaths.Min(a => a.Count);
            var shortestPaths = allPaths.Where(a => a.Count == minPathLength).ToList();

            Console.WriteLine("-------------- SHORTEST PATHS --------------\n");

            this.PrintCurrentPath(shortestPaths, separator);

            Console.WriteLine("\n---------------- ALL PATHS -----------------\n");
        }

        /// <summary>
        /// Prints all paths from list of paths.
        /// </summary>
        /// <param name="pathCollection">The list containing lists of paths.</param>
        public void PrintCurrentPath(IList<LinkedList<int>> pathCollection, string separator)
        {
            for (int i = 0; i < pathCollection.Count; i++)
            {
                Console.WriteLine(string.Join(separator, pathCollection[i]));
            }
        }
    }
}