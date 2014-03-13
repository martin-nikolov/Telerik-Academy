namespace Algorithms
{
    using System;
    using System.Linq;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            Console.WriteLine("All items before sorting:");
            collection.PrintAllItemsOnConsole();

            Console.WriteLine("SelectionSorter result:");
            collection.Sort(new SelectionSorter<int>());
            collection.PrintAllItemsOnConsole();

            collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            Console.WriteLine("Quicksorter result:");
            collection.Sort(new QuickSorter<int>());
            collection.PrintAllItemsOnConsole();

            collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            Console.WriteLine("MergeSorter result:");
            collection.Sort(new MergeSorter<int>());
            collection.PrintAllItemsOnConsole();

            Console.WriteLine("Linear search 101:");
            Console.WriteLine(collection.LinearSearch(101) + Environment.NewLine);

            Console.WriteLine("Binary search 101:");
            Console.WriteLine(collection.BinarySearch(101) + Environment.NewLine);

            Console.WriteLine("Shuffle:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();

            Console.WriteLine("Shuffle again:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
        }
    }
}