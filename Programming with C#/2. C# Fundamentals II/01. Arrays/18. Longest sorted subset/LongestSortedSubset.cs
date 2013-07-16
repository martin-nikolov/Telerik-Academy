/*
* 18. * Write a program that reads an array of integers and removes
* from it a minimal number of elements in such way that the remaining
* array is sorted in increasing order. Print the remaining sorted array.
* 
* Example: { 6, 6, 5, 4, 3, 2, 1, 3, 1, 2, 3, 4, 5, 6, 3, 2, 1, 2, 1, 2, 3 } -> { 1, 1, 2, 3, 4, 5, 6 }
* Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}
*/

using System;
using System.Collections.Generic;
using System.Linq;

class LongestSortedSubset
{
    // EASE OF USE: The program contains test method that show us how the program work on diffent inputs
    // The method that tests the program is called "TestRunner"

    static List<int>[] allBestSubsets = new List<int>[40];
    static int index = 0;

    static void Main()
    {
        Console.Write("Enter a number N (size of array): ");
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        Console.WriteLine("\nEnter a {0} number(s) to array: ", n);
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("   {0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        FindAllSubsetsWithGivenSum(numbers);
        PrintLongestSubsets(numbers);
        Console.WriteLine();

        //TestRunner(); // <- TEST METHOD
    }
  
    static void PrintLongestSubsets(int[] numbers)
    {
        Console.WriteLine("\nArray's elements: {0}", string.Join(" ", numbers));

        Console.WriteLine("Longest subset(s) with increasing elements: ");
        for (int i = 0; i < index; i++) Console.WriteLine(string.Join(" ", allBestSubsets[i]));
    }

    // Find all subsets using BITWISE REPRESENTATION
    static void FindAllSubsetsWithGivenSum(int[] numbers)
    {
        allBestSubsets = new List<int>[40]; // this line is necessary only for TestRunner

        List<int> subset = new List<int>();
        long bestLength = 0;
        long totalSubsets = (long)(Math.Pow(2, numbers.Length) - 1); // Number of subsets

        //for (int i = 1; i <= totalSubsets; i++)
        for (long i = totalSubsets; i >= 1; i--)
        {
            long elementInSubset = ElementsInSubset(i);

            if (elementInSubset < bestLength) continue;

            subset.Clear();

            for (int j = 0; j < numbers.Length; j++)
                if (((i >> j) & 1) == 1)
                    subset.Add(numbers[j]);

            if (IsIncreasingElements(subset))
            {
                if (bestLength < elementInSubset)
                {
                    allBestSubsets = new List<int>[40];
                    index = 0;
                }

                bestLength = elementInSubset;

                allBestSubsets[index++] = new List<int>(subset);
            }
        }
    }

    // Optimization method
    static long ElementsInSubset(long currentNumber)
    {
        long elementsInSubset = 0;

        while (currentNumber != 0)
        {
            elementsInSubset += currentNumber & 1;
            currentNumber >>= 1;
        }

        return elementsInSubset;
    }

    static bool IsIncreasingElements(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count - 1; i++)
            if (numbers[i] > numbers[i + 1])
                return false;

        return true;
    }

    static void TestRunner()
    {
        Console.WriteLine(new string('-', 40));

        int[] test0 = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        FindAllSubsetsWithGivenSum(test0);
        PrintLongestSubsets(test0);

        int[] test1 = { 1, 2, 3, 1, 2, 3 };
        FindAllSubsetsWithGivenSum(test1);
        PrintLongestSubsets(test1);

        int[] test2 = { 8, 7, 6, 5, 4, 3 };
        FindAllSubsetsWithGivenSum(test2);
        PrintLongestSubsets(test2);

        int[] test3 = { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5 };
        FindAllSubsetsWithGivenSum(test3);
        PrintLongestSubsets(test3);

        int[] test4 = { 1, -5, 2, -4, 3, -3, 4, -2, 5, -1 };
        FindAllSubsetsWithGivenSum(test4);
        PrintLongestSubsets(test4);

        int[] test5 = { 6, 6, 5, 4, 3, 2, 1, 3, 1, 2, 3, 4, 5, 6, 3, 2, 1, 2, 1, 2, 3 };
        FindAllSubsetsWithGivenSum(test5);
        PrintLongestSubsets(test5);

        Console.WriteLine("\n" + new string('-', 40));
    }
}