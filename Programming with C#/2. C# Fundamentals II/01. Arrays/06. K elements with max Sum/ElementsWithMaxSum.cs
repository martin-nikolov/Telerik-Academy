/*
* 6. Write a program that reads two integer numbers N and K 
* and an array of N elements from the console. Find in the 
* array those K elements that have maximal sum.
*/

using System;
using System.Collections.Generic;
using System.Linq;

class ElementsWithMaxSum
{
    // EASE OF USE: The program contains test method that show us how the program work on diffent inputs
    // The method that tests the program is called "TestRunner"

    static void Main()
    {
        Console.Write("Enter a size of array: ");
        int size = int.Parse(Console.ReadLine());

        Console.Write("Enter a number of elements in subset: ");
        int elements = int.Parse(Console.ReadLine());

        if (size < elements)
        {
            Console.WriteLine("\n-> Number of elements must be smaller or equal to Size of array...\n");
            return;
        }

        int[] numbers = new int[size];
        Console.WriteLine("\nEnter a {0} number(s) to array: ", size);
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("   {0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        PrintSubsetWithMaxSum(numbers, FindSubsetsWithMaxSum(numbers, elements));
        Console.WriteLine();

        //TestRunner(); // <- TEST METHOD
    }

    static List<int> FindSubsetsWithMaxSum(int[] numbers, int k)
    {
        List<int> subsetWithMaxSum = new List<int>();
        Array.Sort(numbers);

        for (int i = numbers.Length - 1; i >= 0 && k != 0; i--,k--)
            subsetWithMaxSum.Add(numbers[i]);

        return subsetWithMaxSum;
    }

    static void PrintSubsetWithMaxSum(int[] numbers, List<int> bestSubsequence)
    {
        Console.WriteLine("\nArray's elements: {0} ", string.Join(" ", numbers));
        Console.WriteLine("Subsequence with {0} element(s)", bestSubsequence.Count);
        Console.WriteLine("Maximal Sum = {0}", bestSubsequence.Sum());
        Console.WriteLine("Subset with Maximal Sum: {0}", string.Join(" ", bestSubsequence));
    }

    static void TestRunner()
    {
        Console.WriteLine(new string('-', 40));

        int[] test0 = { 2, 1, 2, 6, 7, 2, 1, 2, 9 };
        List<int> subsetWithMaxSum = FindSubsetsWithMaxSum(test0, 2);
        PrintSubsetWithMaxSum(test0, subsetWithMaxSum);

        subsetWithMaxSum = FindSubsetsWithMaxSum(test0, 3);
        PrintSubsetWithMaxSum(test0, subsetWithMaxSum);

        int[] test1 = { 1, -1, 2, -3, 4, -5 };
        subsetWithMaxSum = FindSubsetsWithMaxSum(test1, 2);
        PrintSubsetWithMaxSum(test1, subsetWithMaxSum);

        subsetWithMaxSum = FindSubsetsWithMaxSum(test1, 3);
        PrintSubsetWithMaxSum(test1, subsetWithMaxSum);

        int[] test2 = { 9, 1, 7, 5, -9, 3, 1, 9 };
        subsetWithMaxSum = FindSubsetsWithMaxSum(test2, 2);
        PrintSubsetWithMaxSum(test2, subsetWithMaxSum);

        subsetWithMaxSum = FindSubsetsWithMaxSum(test2, 7);
        PrintSubsetWithMaxSum(test2, subsetWithMaxSum);

        Console.WriteLine("\n" + new string('-', 40));
    }
}