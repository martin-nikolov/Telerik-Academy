using System;
using System.Diagnostics;

public class QuickSortAlgorithm
{
    static Random randomGenerator = new Random();

    static void Main()
    {
        TestRunner();
        TestForPerformance(300000);
        TestForPerformance(600000);
        TestForPerformance(1200000);
    }

    public static void QuickSort<T>(T[] elements) where T : IComparable<T>
    {
        QuickSort(elements, 0, elements.Length - 1);
    }

    /// <summary>
    /// Quick sorting (sorting by partitions)
    /// The program below apply classical recursive implementation of the method QuickSort
    /// </summary>
    static void QuickSort<T>(T[] sortArray, int leftIndex, int rightIndex) where T : IComparable<T>
    {
        /* QUICKSORT(A,p,r)
        1  if p < r
        2      then q  PARTITION(A,p,r)
        3           QUICKSORT(A,p,q)
        4           QUICKSORT(A,q + 1,r)*/

        if (leftIndex >= rightIndex) return;

        T frontier;
        int leftPointer = leftIndex;
        int rightPointer = rightIndex;

        // 1. Pick a pivot value somewhere in the middle.
        frontier = sortArray[(leftIndex + rightIndex) / 2];

        // 2. Loop until pointers meet on the pivot.
        while (leftPointer <= rightPointer)
        {
            // 3. Find a larger value to the right of the pivot.
            //    If there is non we end up at the pivot.
            while (sortArray[leftPointer].CompareTo(frontier) < 0) leftPointer++;

            // 4. Find a smaller value to the left of the pivot.
            //    If there is non we end up at the pivot.
            while (sortArray[rightPointer].CompareTo(frontier) > 0) rightPointer--;

            // 5. Check if both pointers are not on the pivot.
            if (leftPointer <= rightPointer)
            {
                // 6. Swap both values to the right side.
                T swap = sortArray[leftPointer];
                sortArray[leftPointer] = sortArray[rightPointer];
                sortArray[rightPointer] = swap;

                leftPointer++;
                rightPointer--;
            }
        }

        // Here's where the pivot value is in the right spot

        // 7. Recursively call the algorithm on the unsorted array
        //    to the left of the pivot (if exists).
        if (rightPointer > leftIndex) QuickSort(sortArray, leftIndex, rightPointer);

        // 8. Recursively call the algorithm on the unsorted array
        //    to the right of the pivot (if exists).
        if (leftPointer < rightIndex) QuickSort(sortArray, leftPointer, rightIndex);

        // 9. The algorithm returns when all sub arrays are sorted.
    }

    static void TestRunner()
    {
        var unsortedNumbers = new int[] { 1, -2, 3, -4, 5, -6, 7, -8, 9, -10 };
        Console.Write(string.Join(" ", unsortedNumbers) + " -> ");
        QuickSort(unsortedNumbers);
        Console.WriteLine(string.Join(" ", unsortedNumbers));

        var unsortedSymbols = new string[] { "b", "d", "c", "a", "f", "w", "z" };
        Console.Write(string.Join(" ", unsortedSymbols) + " -> ");
        QuickSort(unsortedSymbols);
        Console.WriteLine(string.Join(" ", unsortedSymbols));

        var unsortedLetters = new char[] { 'z', 'b', 'd', 'c', 'w', 'a', 'f' };
        Console.Write(string.Join(" ", unsortedLetters) + " -> ");
        QuickSort(unsortedLetters);
        Console.WriteLine(string.Join(" ", unsortedLetters));
    }

    static void TestForPerformance(int capacity)
    {
        Stopwatch sw = new Stopwatch();
        var numbers = new int[capacity];

        for (int i = 0; i < capacity; i++)
            numbers[i] = randomGenerator.Next(int.MaxValue);

        sw.Start();
        QuickSort(numbers);
        sw.Stop();

        Console.WriteLine(sw.Elapsed + " -> " + capacity + " elements.");
    }
}
