/*
* 5. Write a program that finds the maximal increasing sequence in an array.
* Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.
*/

using System;
using System.Collections.Generic;
using System.Linq;

class MaxIncreasingSequence
{
    // EASE OF USE: The program contains test method that show us how the program work on diffent inputs
    // The method that tests the program is called "TestRunner"

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

        PrintMaxIncreasingSequence(numbers, FindMaxIncreasingSequence(numbers));
        Console.WriteLine();
        
        //TestRunner(); // <- TEST METHOD
    }

    static List<int> FindMaxIncreasingSequence(int[] numbers)
    {
        if (numbers.Length == 1) return new List<int>() { numbers[0] };

        List<int> maxIncreasingSequence = new List<int>() { numbers[0] };
        List<int> bestSequence = new List<int>();

        int currentElement = numbers[0];
  
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > currentElement)
            {
                maxIncreasingSequence.Add(numbers[i]);
                currentElement = numbers[i];
            }
            else
            {
                currentElement = numbers[i];
                maxIncreasingSequence = new List<int>() { currentElement };
            }

            if (maxIncreasingSequence.Count >= bestSequence.Count)
                bestSequence = new List<int>(maxIncreasingSequence);
        }

        if (bestSequence.Count == 1 && bestSequence[0] == numbers[numbers.Length - 1])
        {
            // Example: 6 5 4 3 2 1 -> return 6 instead any other element
            return new List<int>() { numbers[0] };
        }
        else
        {
            return bestSequence;
        }
    }

    static void PrintMaxIncreasingSequence(int[] numbers, List<int> bestSequence)
    {
        Console.WriteLine("\nArray's elements: {0}", string.Join(" ", numbers));      
        Console.WriteLine("-> Best sequence: {0}", string.Join(" ", bestSequence));
    }

    static void TestRunner()
    {
        Console.WriteLine(new string('-', 40));

        int[] test0 = { 8, 1, 3, 5, 7, 9, 8 };
        PrintMaxIncreasingSequence(test0, FindMaxIncreasingSequence(test0));

        int[] test1 = { 1 };
        PrintMaxIncreasingSequence(test1, FindMaxIncreasingSequence(test1));

        int[] test2 = { 1, 2, 3, 4, 1 };
        PrintMaxIncreasingSequence(test2, FindMaxIncreasingSequence(test2));

        int[] test3 = { 6, 1, 2, 3, 5 };
        PrintMaxIncreasingSequence(test3, FindMaxIncreasingSequence(test3));

        int[] test4 = { 6, 5, 4, 3, 2, 1 };
        PrintMaxIncreasingSequence(test4, FindMaxIncreasingSequence(test4));

        int[] test5 = { 1, 2, 3, 4, 9 };
        PrintMaxIncreasingSequence(test5, FindMaxIncreasingSequence(test5));

        int[] test6 = { 1, 2, 3, 7, 1, 2, 3, 4, 8 };
        PrintMaxIncreasingSequence(test6, FindMaxIncreasingSequence(test6));

        int[] test7 = { 2, 4, 6, 1, 2, 3, 4, 1, 3, 5, 7, 9 };
        PrintMaxIncreasingSequence(test7, FindMaxIncreasingSequence(test7));

        int[] test8 = { 1, 1, 2, 2, 2, 3, 4, 5 };
        PrintMaxIncreasingSequence(test8, FindMaxIncreasingSequence(test8));

        int[] test9 = { 8, 1, 3, 5, 7, 9, 8 };
        PrintMaxIncreasingSequence(test9, FindMaxIncreasingSequence(test9));

        Console.WriteLine("\n" + new string('-', 40));
    }
}