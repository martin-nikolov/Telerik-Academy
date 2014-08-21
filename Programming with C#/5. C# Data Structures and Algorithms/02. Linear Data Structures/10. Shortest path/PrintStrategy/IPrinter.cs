namespace PathFinder.PrintStrategy
{
    using System.Collections.Generic;
    using DynamicList;

    public interface IPrinter
    {
        void PrintResult(List<DoubleLinkedList<int>> allPaths, Node<int> parentNode, string separator = " -> ");

        void PrintCurrentPath(IList<DoubleLinkedList<int>> pathCollection, string separator);
    }
}