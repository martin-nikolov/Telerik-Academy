// Quick sorting (sorting by partitions)
// The program below apply classical recursive implementation of the method QuickSort
 
using System;
 
class Program
{
    // QUICKSORT(A,p,r)
    // 1  if p < r
    // 2      then q  PARTITION(A,p,r)
    // 3           QUICKSORT(A,p,q)
    // 4           QUICKSORT(A,q + 1,r)
   
    static void QuickSort(int[] sortArray, int leftIndex, int rightIndex)
    {
        if (leftIndex >= rightIndex)
            return;
 
        int frontier;
        int leftPointer = leftIndex;
        int rightPointer = rightIndex;
 
        // 1. Pick a pivot value somewhere in the middle.
        frontier = sortArray[(leftIndex + rightIndex) / 2];
 
        // 2. Loop until pointers meet on the pivot.
        while (leftPointer <= rightPointer)
        {
            // 3. Find a larger value to the right of the pivot.
            //    If there is non we end up at the pivot.
            while (sortArray[leftPointer] < frontier)
                leftPointer++;
 
            // 4. Find a smaller value to the left of the pivot.
            //    If there is non we end up at the pivot.
            while (sortArray[rightPointer] > frontier)
                rightPointer--;
 
            // 5. Check if both pointers are not on the pivot.
            if (leftPointer <= rightPointer)
            {
                // 6. Swap both values to the right side.
                int swap = sortArray[leftPointer];
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
 
    static Random rnd = new Random();
 
    static void Main()
    {
        int[] unsorted_arr = { 5, -1, 2, -3, -5 };
 
        DateTime now = DateTime.Now;
        QuickSort(unsorted_arr, 0, unsorted_arr.Length - 1);
        Console.WriteLine("Test time: " + (DateTime.Now - now));
 
        foreach (var item in unsorted_arr)
        {
            Console.Write(item + " ");  
        }
    }
}