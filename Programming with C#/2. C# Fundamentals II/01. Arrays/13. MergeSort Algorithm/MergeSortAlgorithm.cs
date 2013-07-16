/*
* 13. *Write a program that sorts an array of integers using
* the merge sort algorithm.
* Example: { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5 } -> { -5, -4, -3, -2, -1, 1, 2, 3, 4, 5}
*/

using System;
using System.Linq;

class MergeSortAlgorithm
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

        int[] tmp = new int[n];

        Console.WriteLine("\nBefore sorting: {0}", string.Join(" ", numbers)); 

        MergeSort(numbers, tmp, 0, numbers.Length - 1);

        Console.WriteLine("After sorting: {0}\n", string.Join(" ", numbers)); 
    }

    static void MergeSort(int[] elements, int[] temp, int start, int end)
    {
        if (start >= end) return;  // Array with 1 element

        int middle = start + (end - start) / 2; // Define a middle of the array

        MergeSort(elements, temp, start, middle);
        MergeSort(elements, temp, middle + 1, end);

        CompareAndSort(elements, temp, start, middle, end);
    }

    static void CompareAndSort(int[] elements, int[] temp, int start, int middle, int end)
    {
        int i = start; // 'temp' index
        int l = start, m = middle + 1; // 'elements' indexes

        while (l <= middle && m <= end)
            temp[i++] = (elements[l] > elements[m]) ? elements[m++] : elements[l++];

        while (l <= middle) temp[i++] = elements[l++];

        while (m <= end) temp[i++] = elements[m++];

        for (int j = start; j <= end; j++) elements[j] = temp[j];
    }
}