namespace PathFinder.PrintStrategy
{
    using System.Collections.Generic;

    public interface IPrinter
    {
        void PrintResult(List<LinkedList<int>> allPaths, Node<int> parentNode, string separator = " -> ");

        void PrintCurrentPath(IList<LinkedList<int>> pathCollection, string separator);
    }
}