/*
* 10. Write a program that finds in given array of integers a 
* sequence of given sum S (if present). 
* Example: {4, 3, 1, 4, 2, 5, 8}, S = 11 -> {4, 2, 5}	
*/

using System;
using System.Collections.Generic;
using System.Linq;

class FindSequenceWithGivenSum
{
    // EASE OF USE: The program contains test method that show us how the program work on diffent inputs
    // The method that tests the program is called "TestRunner"

    static bool isFoundSequence = false;

    static void Main()
    {
        Console.Write("Enter a number N (size of array): ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter a searched Sum: ");
        int searchedSum = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        Console.WriteLine("\nEnter a {0} number(s) to array: ", n);
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("   {0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        FindAndPrintSequences(numbers, searchedSum);
       
        //TestRunner(); // <- TEST METHOD
    }
  
    static void FindAndPrintSequences(int[] numbers, int searchedSum)
    {
        Console.WriteLine("\nArray's elements: {0}", string.Join(" ", numbers));
        Console.WriteLine("Sequences with searched sum {0}: ", searchedSum);

        isFoundSequence = false;

        for (int i = 0; i < numbers.Length; i++)
        {
            List<int> sequence = new List<int>();

            for (int j = i; j < numbers.Length; j++)
            {
                sequence.Add(numbers[j]);

                if (sequence.Sum() == searchedSum)
                {
                    isFoundSequence = true;
                    Console.WriteLine(string.Join(" ", sequence));
                }
            }
        }

        Console.Write(!isFoundSequence ? "- There are no sequences with sum " + searchedSum + "\n" : "");
    }

    static void TestRunner()
    {
        Console.WriteLine("\n" + new string('-', 40));

        int[] test0 = { 4, 3, 1, 4, 2, 5, 8 };
        FindAndPrintSequences(test0, searchedSum: 11);

        int[] test1 = { 5, 2, 3, 4, 1, 3, 1, 2, -1, 6, };
        FindAndPrintSequences(test1, searchedSum: 5);

        int[] test2 = { 5, 5, 5, 5, 5 };
        FindAndPrintSequences(test2, searchedSum: 5);

        int[] test3 = { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5 };
        FindAndPrintSequences(test3, searchedSum: 0);

        int[] test4 = { 4, 5, 5 };
        FindAndPrintSequences(test4, searchedSum: 4);

        int[] test5 = { 4, 4, 5 };
        FindAndPrintSequences(test5, searchedSum: 5);

        Console.WriteLine("\n" + new string('-', 40));
    }
}