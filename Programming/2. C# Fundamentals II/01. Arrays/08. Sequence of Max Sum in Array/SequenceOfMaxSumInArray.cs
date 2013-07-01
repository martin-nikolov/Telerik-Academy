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

    static void Main()
    {
        int bestStart = 0, bestEnd = 0, bestSum = 0;

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

        FindBestSequence(numbers, ref bestStart, ref bestEnd, ref bestSum);
        PrintResult(numbers, bestStart, bestEnd, bestSum);

        //TestRunner(); // <- TEST METHOD
    }

    static void FindBestSequence(int[] numbers, ref int bestStart, ref int bestEnd, ref int bestSum)
    {
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

    static void PrintResult(int[] numbers, int startIndex, int endIndex, int bestSum)
    {
        Console.WriteLine("Array's elements: {0} ", string.Join(" ", numbers));
        Console.WriteLine("Maximal sum: {0}", bestSum);

        Console.Write("Sequence of maximal sum: ");
        for (int i = startIndex; i <= endIndex; i++)
            Console.Write(numbers[i] + " ");

        Console.WriteLine("\n");
    }

    static void TestRunner()
    {
        Console.WriteLine(new string('-', 40) + "\n");

        int[] test0 = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int bestStart = 0, bestEnd = 0, bestSum = 0;
        FindBestSequence(test0, ref bestStart, ref bestEnd, ref bestSum);
        PrintResult(test0, bestStart, bestEnd, bestSum);

        int[] test1 = { 1, 2, 3, 4, 5, 6 };
        bestStart = 0;
        bestEnd = 0;
        bestSum = 0;
        FindBestSequence(test1, ref bestStart, ref bestEnd, ref bestSum);
        PrintResult(test1, bestStart, bestEnd, bestSum);

        int[] test2 = { 1, -1, 2, -2, 3, -3, 4, -4 };
        bestStart = 0;
        bestEnd = 0;
        bestSum = 0;
        FindBestSequence(test2, ref bestStart, ref bestEnd, ref bestSum);
        PrintResult(test2, bestStart, bestEnd, bestSum);

        int[] test3 = { -4, 4, -3, 3, -2, 2, -1, 1 };
        bestStart = 0;
        bestEnd = 0;
        bestSum = 0;
        FindBestSequence(test3, ref bestStart, ref bestEnd, ref bestSum);
        PrintResult(test3, bestStart, bestEnd, bestSum);

        int[] test4 = { 1, 2, -3, 4, -4, 1, 2, 3, 4 };
        bestStart = 0;
        bestEnd = 0;
        bestSum = 0;
        FindBestSequence(test4, ref bestStart, ref bestEnd, ref bestSum);
        PrintResult(test4, bestStart, bestEnd, bestSum);

        int[] test5 = { 1, 2, -3, 1, 2, 3, 4, -4, 3 };
        bestStart = 0;
        bestEnd = 0;
        bestSum = 0;
        FindBestSequence(test5, ref bestStart, ref bestEnd, ref bestSum);
        PrintResult(test5, bestStart, bestEnd, bestSum);

        int[] test6 = { 1, 2, 3, -5, 3, 4, 5, -10, 1, 1, 2, -5 };
        bestStart = 0;
        bestEnd = 0;
        bestSum = 0;
        FindBestSequence(test6, ref bestStart, ref bestEnd, ref bestSum);
        PrintResult(test6, bestStart, bestEnd, bestSum);

        int[] test7 = { 1, 2, 3, -10, 3, 4, 5, -10, 1, 1, 2, -5 };
        bestStart = 0;
        bestEnd = 0;
        bestSum = 0;
        FindBestSequence(test7, ref bestStart, ref bestEnd, ref bestSum);
        PrintResult(test7, bestStart, bestEnd, bestSum);

        int[] test8 = { -6, 2, 6, -2, 1, -7, 5, 2, -1, 4, -5, -6, 2, -1 };
        bestStart = 0;
        bestEnd = 0;
        bestSum = 0;
        FindBestSequence(test8, ref bestStart, ref bestEnd, ref bestSum);
        PrintResult(test8, bestStart, bestEnd, bestSum);

        Console.WriteLine(new string('-', 40));
    }
}