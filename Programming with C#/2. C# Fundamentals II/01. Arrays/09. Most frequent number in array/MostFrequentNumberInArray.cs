/*
* 9. Write a program that finds the most frequent number in an array. 
* Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)
*/

using System;
using System.Collections.Generic;
using System.Linq;

class MostFrequentNumberInArray
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
        
        // Adds numbers to dictionary
        Dictionary<int, int> frequents = new Dictionary<int, int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            if (!frequents.ContainsKey(numbers[i])) frequents.Add(numbers[i], 1);
            else frequents[numbers[i]]++;
        }

        // Get the key of the highest value
        var max = frequents.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

        // Print all array elements
        Console.WriteLine("\nArray's elements: {0}", string.Join(" ", numbers));

        // Print all keys (numbers) with the highest value
        Console.WriteLine("\nMost frequent numbers: ");
        foreach (KeyValuePair<int, int> item in frequents)
            if (item.Value == frequents[max])
                Console.WriteLine("{0} -> {1} times", item.Key, frequents[item.Key]);

        Console.WriteLine();
    }
}