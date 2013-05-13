// Quick sorting (sorting by partitions)
// The program below apply classical recursive implementation of the method QuickSort

using System;

class QuickSortAlgorithm
{
    static void Main()
    {
        TestRunner();
    }

    static void TestRunner()
    {
        int[] unsortedNumbers = { 1, -2, 3, -4, 5, -6, 7, -8, 9, -10 };

        PrintElements(unsortedNumbers); Console.Write(" -> ");
        QuickSort(unsortedNumbers, 0, unsortedNumbers.Length - 1);
        PrintElements(unsortedNumbers); Console.Write("\n");

        string[] unsortedSymbols = new string[] { "b", "d", "c", "a", "f", "w", "z" };

        PrintElements(unsortedSymbols); Console.Write(" -> ");
        QuickSort(unsortedSymbols, 0, unsortedSymbols.Length - 1);
        PrintElements(unsortedSymbols); Console.Write("\n");

        char[] unsortedLetters = { 'z', 'b', 'd', 'c', 'w', 'a', 'f' };
        
        PrintElements(unsortedLetters); Console.Write(" -> ");
        QuickSort(unsortedLetters, 0, unsortedLetters.Length - 1);
        PrintElements(unsortedLetters); Console.Write("\n");
    }
    
    static void QuickSort<T>(T[] sortArray, int leftIndex, int rightIndex) where T : IComparable<T>
    {
        /* QUICKSORT(A,p,r)
        1  if p < r
        2      then q  PARTITION(A,p,r)
        3           QUICKSORT(A,p,q)
        4           QUICKSORT(A,q + 1,r)*/
        if (leftIndex >= rightIndex)
            return;

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
            while (sortArray[leftPointer].CompareTo(frontier) < 0)
                leftPointer++;

            // 4. Find a smaller value to the left of the pivot.
            //    If there is non we end up at the pivot.
            while (sortArray[rightPointer].CompareTo(frontier) > 0)
                rightPointer--;

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
        if (rightPointer > leftIndex)
            QuickSort(sortArray, leftIndex, rightPointer);

        // 8. Recursively call the algorithm on the unsorted array
        //    to the right of the pivot (if exists).
        if (leftPointer < rightIndex)
            QuickSort(sortArray, leftPointer, rightIndex);
        // 9. The algorithm returns when all sub arrays are sorted.
    }

    static void PrintElements<T>(T[] unsortedArr)
    {
        foreach (var item in unsortedArr)
        {
            Console.Write(item + " ");
        }
    }
}