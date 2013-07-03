/*
* 14. Write a program that sorts an array of strings using
* the quick sort algorithm.
*/

using System;
using System.Linq;

class QuickSortAlgorithm
{
    // EASE OF USE: The program contains test method that show us how the program work on diffent inputs
    // The method that tests the program is called "TestRunner"

    static void Main()
    {
        Console.Write("Enter a number N (size of array): ");
        int n = int.Parse(Console.ReadLine());

        string[] words = new string[n];
        Console.WriteLine("\nEnter a {0} strings to array: ", n);
        for (int i = 0; i < words.Length; i++)
        {
            Console.Write("   {0}: ", i + 1);
            words[i] = Console.ReadLine();
        }

        Console.WriteLine("\nBefore sorting: {0}", string.Join(" ", words));

        QuickSort(words, 0, words.Length - 1);

        Console.WriteLine("After sorting: {0}\n", string.Join(" ", words));

        //TestRunner(); // <- TEST METHOD
    }

    static void QuickSort(string[] elements, int left, int right)
    {
        if (left >= right) return; // Array with 1 element

        int leftPointer = left, rightPointer = right;

        // 1. Pick a pivot value somewhere in the middle.
        string frontier = elements[(left + right) / 2];

        // 2. Loop until pointers meet on the pivot.
        while (leftPointer <= rightPointer)
        {
            // 3. Find a larger value to the right of the pivot.
            //    If there is non we end up at the pivot.
            while (elements[leftPointer].CompareTo(frontier) < 0) 
                leftPointer++;

            // 4. Find a smaller value to the left of the pivot.
            //    If there is non we end up at the pivot.
            while (elements[rightPointer].CompareTo(frontier) > 0) 
                rightPointer--;

            // 5. Check if both pointers are not on the pivot.
            if (leftPointer <= rightPointer)
            {
                // 6. Swap both values to the right side.
                string swap = elements[leftPointer];
                elements[leftPointer] = elements[rightPointer];
                elements[rightPointer] = swap;

                leftPointer++; rightPointer--;
            }
        }

        // Here's where the pivot value is in the right spot

        // 7. Recursively call the algorithm on the unsorted array
        //    to the left of the pivot (if exists).
        if (left < rightPointer) QuickSort(elements, left, rightPointer);

        // 8. Recursively call the algorithm on the unsorted array
        //    to the right of the pivot (if exists).
        if (leftPointer < right) QuickSort(elements, leftPointer, right);
        // 9. The algorithm returns when all sub arrays are sorted.
    }

    static void TestRunner()
    {
        Console.WriteLine(new string('-', 40) + "\n");

        string[] test0 = { "c", "cc", "cb", "bb", "ba", "ab", "aa", "a", "b", "d" };
        Console.WriteLine("Before sorting: {0}", string.Join(" ", test0));
        QuickSort(test0, 0, test0.Length - 1);
        Console.WriteLine("After sorting: {0}", string.Join(" ", test0));

        string[] test1 = { "g", "f", "e", "d", "c", "b", "a" };
        Console.WriteLine("\nBefore sorting: {0}", string.Join(" ", test1));
        QuickSort(test1, 0, test1.Length - 1);
        Console.WriteLine("After sorting: {0}", string.Join(" ", test1));

        Console.WriteLine("\n" + new string('-', 40));
    }
}