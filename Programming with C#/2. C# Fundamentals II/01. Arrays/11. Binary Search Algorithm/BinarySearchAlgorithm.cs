/*
* 11. Write a program that finds the index of given element in
* a sorted array of integers by using the binary search algorithm.
* Example: { 1, -1, 2, -3, 5, 4 } => { -3, -1, 1, 2, 3, 4, 5 }, given element = -3 -> index = 0
*/

using System;
using System.Linq;

class BinarySearchAlgorithm
{
    static void Main()
    {
        Console.Write("Enter a number N (size of array): ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter a searched number: ");
        int searchedNumber = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        Console.WriteLine("\nEnter a {0} number(s) to array: ", n);
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("   {0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(numbers);

        int index = BinarySearch(numbers, searchedNumber, 0, numbers.Length);

        if (index != -1) Console.WriteLine("\nNumber {0} found at index: {1}\n", searchedNumber, index);
        else Console.WriteLine("\nNumber {0} not found!\n", searchedNumber);
    }

    // Searches for the specified object and returns the index of the first
    // occurrence within the range of elements in the one-dimensional System.Array
    // that starts at the specified index and contains the specified number of elements.
    static int BinarySearch(int[] numbers, int value, int startIndex, int endIndex)
    {
        if (!numbers.Contains(value)) return -1; // Not found

        int middleIndex = (startIndex + endIndex) / 2;

        if (numbers[middleIndex] == value)
        {
            return middleIndex;
        }
        else if (numbers[middleIndex] > value)
        {
            return BinarySearch(numbers, value, 0, middleIndex - 1);
        }
        else
        {
            return BinarySearch(numbers, value, middleIndex + 1, numbers.Length - 1);
        }
    }
}