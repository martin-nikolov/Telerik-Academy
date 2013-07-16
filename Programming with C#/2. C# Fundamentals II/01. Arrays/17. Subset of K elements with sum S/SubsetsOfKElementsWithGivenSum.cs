/*
* 17. *Write a program that reads three integer numbers 
* N, K and S and an array of N elements from the console.
* Find in the array a subset of K elements that have sum S
* or indicate about its absence
*/

using System;
using System.Collections.Generic;
using System.Linq;

class SubsetsOfKElementsWithGivenSum
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

        Console.Write("Enter a searcher Sum: ");
        int sum = int.Parse(Console.ReadLine());

        int[] numbers = new int[size];
        Console.WriteLine("\nEnter a {0} number(s) to array: ", size);
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("   {0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        PrintElementOfArray(numbers);
        FindAndPrintSubsetsWithMaxSum(numbers, elements, sum);

        //TestRunner(); // <- TEST METHOD
    }

    // Find all subsets using BITWISE REPRESENTATION
    static void FindAndPrintSubsetsWithMaxSum(int[] numbers, int elements, int sum)
    {
        Console.WriteLine("\nSubsets with {0} elements and Sum {1}: ", elements, sum);

        int totalSubsets = (int)(Math.Pow(2, numbers.Length) - 1); // Total subsets = 2^n - 1
        bool isFoundSubset = false;

        for (int i = 1; i <= totalSubsets; i++)
        {
            if (ElementsInSubset(i) == elements)
            {
                List<int> currentSubset = new List<int>();

                for (int j = 0; j < numbers.Length; j++)
                    if (((i >> j) & 1) == 1)
                        currentSubset.Add(numbers[j]);

                if (currentSubset.Sum() == sum)
                {
                    isFoundSubset = true;
                    PrintSubsetWithGivenSum(currentSubset);
                }
            }
        }

        if (!isFoundSubset)
            Console.WriteLine("- There are no subsets with {0} elements and Sum {1}...", elements, sum);
    }


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

    static void PrintElementOfArray(int[] numbers)
    {
        Console.WriteLine("\nArray's elements: {0}", string.Join(" ", numbers));
    }

    static void PrintSubsetWithGivenSum(List<int> subset)
    {
        Console.WriteLine(string.Join(" ", subset));
    }

    static void TestRunner()
    {
        Console.WriteLine("\n" + new string('-', 40));

        int[] test0 = { 2, 1, 2, 4, 3, 5, 2, 6 };
        PrintElementOfArray(test0);
        FindAndPrintSubsetsWithMaxSum(test0, 4, 14);
        FindAndPrintSubsetsWithMaxSum(test0, 3, 6);

        Console.WriteLine("\n" + new string('-', 40));

        int[] test1 = { 1, -1, 2, -3, 4, -5 };
        PrintElementOfArray(test1);
        FindAndPrintSubsetsWithMaxSum(test1, 2, 3);
        FindAndPrintSubsetsWithMaxSum(test1, 3, 2);

        Console.WriteLine("\n" + new string('-', 40));

        int[] test2 = { 9, 1, 7, 5, -9, 3, 1, 9, -8, -4, 2, 4 };
        PrintElementOfArray(test2);
        FindAndPrintSubsetsWithMaxSum(test2, 2, 2);
        FindAndPrintSubsetsWithMaxSum(test2, 3, 3);

        Console.WriteLine("\n" + new string('-', 40) + "\n");
    }
}