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
    // This program finds between all subsets that subset which has maximal sum.

    // EASE OF USE: The program contains test method that show us how the program work on diffent inputs
    // The method that tests the program is called "TestRunner"

    static void Main()
    {
        Console.Write("Enter a number N (size of array): ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter a number K (elements in subset): ");
        int k = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        Console.WriteLine("\nEnter a {0} number(s) to array: ", n);
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("   {0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        List<int> subsetWithMaxSum = FindSubsetsWithMaxSum(numbers, k);
        PrintSubsetWithMaxSum(numbers, subsetWithMaxSum);
        Console.WriteLine();

        //TestRunner(); // <- TEST METHOD
    }
  
    // Find all subsets using BITWISE REPRESENTATION
    static List<int> FindSubsetsWithMaxSum(int[] numbers, int k)
    {
        // Total subsets = 2^n - 1
        int totalSubsets = (int)(Math.Pow(2, numbers.Length) - 1);
        int maximalSum = 0;

        List<int> subsetWithMaxSum = new List<int>();
       
        for (int i = 1; i <= totalSubsets; i++)
        {
            if (ElementsInSubset(i) == k)
            {
                List<int> currentSubsequence = new List<int>();

                for (int j = 0; j < numbers.Length; j++)
                    if (((i >> j) & 1) == 1)
                        currentSubsequence.Add(numbers[j]);

                if (currentSubsequence.Sum() > maximalSum)
                {
                    maximalSum = currentSubsequence.Sum();
                    subsetWithMaxSum = new List<int>(currentSubsequence);
                }
            }
        }

        return subsetWithMaxSum;
    }
  
    // Can be modified to find all subsets with maximal sum
    static int ElementsInSubset(int currentNumber)
    {
        int elementsInSubset = 0;

        while (currentNumber != 0)
        {
            elementsInSubset += currentNumber & 1;
            currentNumber >>= 1;
        }

        return elementsInSubset;
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