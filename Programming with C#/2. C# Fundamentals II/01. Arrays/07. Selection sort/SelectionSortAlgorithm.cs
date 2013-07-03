/*
* 7. Sorting an array means to arrange its elements in increasing order.
* Write a program to sort an array. Use the "selection sort" algorithm:
* Find the smallest element, move it at the first position, find the
* smallest from the rest, move it at the second position, etc.
*/

using System;
using System.Linq;

class SelectionSortAlgorithm
{
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

        Console.Write("\nBefore sorting: ");
        Console.WriteLine(string.Join(" ", numbers));

        numbers = SelectionSort(numbers);

        Console.Write("\nAfter sorting: ");
        Console.WriteLine(string.Join(" ", numbers) + "\n");
    }

    // Classical implementation of Selection Sort Algorithm
    static int[] SelectionSort(int[] numbers)
    {
        int index, swap;

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            index = i;

            for (int j = i + 1; j < numbers.Length; j++)
                if (numbers[j] < numbers[index])
                    index = j;

            swap = numbers[i];
            numbers[i] = numbers[index];
            numbers[index] = swap;
        }

        return numbers;
    }
}