/*
* 5. You are given an array of strings. Write a method that sorts
* the array by the length of its elements (the number of characters composing them).
*/

using System;
using System.Linq;

class SortStringByItsLength
{
    static void Main()
    {
        Console.Write("Enter a number N (size of array): ");
        int n = int.Parse(Console.ReadLine());

        string[] elements = new string[n];
        Console.WriteLine("\nEnter a {0} string(s) to array: ", n);

        for (int i = 0; i < elements.Length; i++)
        {
            Console.Write("   {0}: ", i + 1);
            elements[i] = Console.ReadLine();
        }

        Console.WriteLine("\nBefore sorting: {0}", string.Join(" ", elements));

        SelectionSortByLength(ref elements);

        Console.WriteLine("After sorting: {0}\n", string.Join(" ", elements));
    }

    static void SelectionSortByLength(ref string[] elements)
    {
        for (int i = 0; i < elements.Length - 1; i++)
        {
            int index = i;

            for (int j = i + 1; j < elements.Length; j++)
            {
                if (elements[j].Length < elements[index].Length)
                    index = j;
            }

            string swap = elements[i];
            elements[i] = elements[index];
            elements[index] = swap;
        }
    }
}