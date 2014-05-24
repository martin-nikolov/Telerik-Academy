namespace Algorithms.Test
{
    using System;
    using System.Linq;

    internal class AssertionsTest
    {
        static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SortingAlgorithms.SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            //int[] nullArray = null;
            //SortingAlgorithms.SelectionSort(nullArray); // Test sorting null array
            //SortingAlgorithms.SelectionSort(new int[0]); // Test sorting empty array
            SortingAlgorithms.SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(SearchingAlgorithms.BinarySearch(arr, -1000));
            Console.WriteLine(SearchingAlgorithms.BinarySearch(arr, 0));
            Console.WriteLine(SearchingAlgorithms.BinarySearch(arr, 17));
            Console.WriteLine(SearchingAlgorithms.BinarySearch(arr, 10));
            Console.WriteLine(SearchingAlgorithms.BinarySearch(arr, 1000));
        }
    }
}