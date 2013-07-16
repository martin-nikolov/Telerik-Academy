/*
* 14. *Write a program that sorts an array of strings using
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

        string pivot = elements[(left + right) / 2];

        while (leftPointer <= rightPointer)
        {
            while (elements[leftPointer].CompareTo(pivot) < 0) leftPointer++;

            while (elements[rightPointer].CompareTo(pivot) > 0) rightPointer--;

            if (leftPointer <= rightPointer)
            {                
                string swap = elements[leftPointer];
                elements[leftPointer] = elements[rightPointer];
                elements[rightPointer] = swap;

                leftPointer++; rightPointer--;
            }
        }

        if (left < rightPointer) QuickSort(elements, left, rightPointer);

        if (leftPointer < right) QuickSort(elements, leftPointer, right);
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