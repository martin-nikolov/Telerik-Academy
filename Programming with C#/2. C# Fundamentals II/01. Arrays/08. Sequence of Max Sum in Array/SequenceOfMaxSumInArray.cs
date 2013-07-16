/*
* 8. Write a program that finds the sequence of maximal sum in given array. 
* Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
* Can you do it with only one loop (with single scan through the elements of the array)? -> YES
*/

using System;
using System.Linq;

class SequenceOfMaxSumInArray
{
    // EASE OF USE: The program contains test method that show us how the program work on diffent inputs
    // The method that tests the program is called "TestRunner"

    static int bestStart = 0, bestEnd = 0, bestSum = 0;

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

        Console.WriteLine();

        FindBestSequence(numbers);
        PrintResult(numbers, bestStart, bestEnd, bestSum);

        //TestRunner(); // <- TEST METHOD
    }

    static void FindBestSequence(int[] numbers)
    {
        bestStart = 0; bestEnd = 0; bestSum = 0;

        int startIndex = 0, currentSum = 0;
        
        for (int i = 0; i < numbers.Length; i++)
        {
            if (currentSum <= 0)
            {
                startIndex = i;
                currentSum = 0;
            }

            currentSum += numbers[i];

            if (currentSum > bestSum)
            {
                bestSum = currentSum;
                bestStart = startIndex;
                bestEnd = i;
            }
        }
    }

    static void PrintResult(int[] numbers, int start, int end, int bestSum)
    {
        Console.WriteLine("Array's elements: {0} ", string.Join(" ", numbers));
        Console.WriteLine("Maximal sum: {0}", bestSum);

        Console.Write("Sequence of maximal sum: ");
        for (int i = start; i <= end; i++)
            Console.Write(numbers[i] + " ");

        Console.WriteLine("\n");
    }

    static void TestRunner()
    {
        Console.WriteLine(new string('-', 40) + "\n");

        int[] test0 = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        FindBestSequence(test0);
        PrintResult(test0, bestStart, bestEnd, bestSum);

        int[] test1 = { 1, 2, 3, 4, 5, 6 };
        FindBestSequence(test1);
        PrintResult(test1, bestStart, bestEnd, bestSum);

        int[] test2 = { 1, -1, 2, -2, 3, -3, 4, -4 };
        FindBestSequence(test2);
        PrintResult(test2, bestStart, bestEnd, bestSum);

        int[] test3 = { -4, 4, -3, 3, -2, 2, -1, 1 };
        FindBestSequence(test3);
        PrintResult(test3, bestStart, bestEnd, bestSum);

        int[] test4 = { 1, 2, -3, 4, -4, 1, 2, 3, 4 };
        FindBestSequence(test4);
        PrintResult(test4, bestStart, bestEnd, bestSum);

        int[] test5 = { 1, 2, -3, 1, 2, 3, 4, -4, 3 };
        FindBestSequence(test5);
        PrintResult(test5, bestStart, bestEnd, bestSum);

        int[] test6 = { 1, 2, 3, -5, 3, 4, 5, -10, 1, 1, 2, -5 };
        bestStart = 0; bestEnd = 0; bestSum = 0;
        FindBestSequence(test6);
        PrintResult(test6, bestStart, bestEnd, bestSum);

        int[] test7 = { 1, 2, 3, -10, 3, 4, 5, -10, 1, 1, 2, -5 };
        FindBestSequence(test7);
        PrintResult(test7, bestStart, bestEnd, bestSum);

        int[] test8 = { -6, 2, 6, -2, 1, -7, 5, 2, -1, 4, -5, -6, 2, -1 };
        FindBestSequence(test8);
        PrintResult(test8, bestStart, bestEnd, bestSum);

        Console.WriteLine(new string('-', 40));
    }
}