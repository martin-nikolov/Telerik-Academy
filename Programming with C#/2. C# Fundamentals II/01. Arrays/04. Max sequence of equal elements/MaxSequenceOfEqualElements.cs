/*
* 4. Write a program that finds the maximal sequence of equal elements in an array.
* Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.
*/

using System;
using System.Linq;

class MaxSequenceOfEqualElements
{
    // EASE OF USE: The program contains test method that show us how the program work on diffent inputs
    // The method that tests the program is called "TestRunner"

    static int bestLength = 0, bestElement = 0;

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

        FindBestSequence(numbers);
        PrintBestSequence(numbers, bestLength, bestElement);

        //TestRunner(); // <- TEST METHOD
    }
  
    static void FindBestSequence(int[] numbers)
    {
        int currentLength = 1, currentElement = numbers[0];

        bestElement = 0; bestLength = 0;

        if (numbers.Length == 1)
        {
            bestElement = currentElement;
            bestLength = 1;
            return;
        }

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == currentElement)
            {
                currentLength++;
            }
            else
            {
                currentElement = numbers[i];
                currentLength = 1;
            }

            if (currentLength >= bestLength)
            {
                bestLength = currentLength;
                bestElement = currentElement;
            }
        }
    }
  
    static void PrintBestSequence(int[] numbers, int bestLength, int bestElement)
    {
        Console.Write("\nArray's elements: {0}", string.Join(" ", numbers));

        Console.Write("-> Best sequence: ");
        for (int i = 0; i < bestLength; i++) Console.Write(bestElement + " ");
        Console.WriteLine("\n");
    }

    static void TestRunner()
    {
        Console.WriteLine(new string('-', 40));

        int[] test0 = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
        FindBestSequence(test0);
        PrintBestSequence(test0, bestLength, bestElement);

        int[] test1 = { 1 };
        FindBestSequence(test1);
        PrintBestSequence(test1, bestLength, bestElement);

        int[] test2 = { 1, 3, 3, 3 };
        FindBestSequence(test2);
        PrintBestSequence(test2, bestLength, bestElement);

        int[] test3 = { 2, 2, 1 };
        FindBestSequence(test3);
        PrintBestSequence(test3, bestLength, bestElement);

        int[] test4 = { 6, 6, 6, 6, 6, 6 };
        FindBestSequence(test4);
        PrintBestSequence(test4, bestLength, bestElement);

        int[] test5 = { 1, 2, 3, 4, 5 };
        FindBestSequence(test5);
        PrintBestSequence(test5, bestLength, bestElement);

        int[] test6 = { 1, 2, 2, 3, 3, 3 };
        FindBestSequence(test6);
        PrintBestSequence(test6, bestLength, bestElement);

        int[] test7 = { 4, 4, 4, 4, 3, 3, 3, 2, 2, 2, 1 };
        FindBestSequence(test7);
        PrintBestSequence(test7, bestLength, bestElement);

        int[] test8 = { 1, 3, 3, 3, 5, 5, 5, 5, 5, 2, 2 };
        FindBestSequence(test8);
        PrintBestSequence(test8, bestLength, bestElement);

        Console.WriteLine(new string('-', 40));
    }
}