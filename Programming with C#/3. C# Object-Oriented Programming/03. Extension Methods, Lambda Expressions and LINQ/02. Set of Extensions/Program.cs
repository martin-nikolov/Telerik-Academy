/*
* 2. Implement a set of extension methods for IEnumerable<T>
* that implement the following group functions:
* sum, product, min, max, average.
*/
using System;
using System.Collections.Generic;
using Extensions;

class Program
{
    static void Main()
    {
        var integers = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        Print(integers);

        var bytes = new List<byte>(new byte[] { 250, 25, 15, 5 });
        Print(bytes);

        var doubles = new double[] { 1.1, 2.2, 3.3, 4.4 };
        Print(doubles);

        var decimals = new Queue<decimal>(new decimal[] { -1.1m, 2m, -3m, 4.3m });
        Print(decimals);
    }

    static void Print<T>(IEnumerable<T> elements)
    {
        Console.WriteLine(string.Join(", ", elements));
        Console.WriteLine("Count: {0}", elements.Count());
        Console.WriteLine("Sum: {0}", elements.Sum());
        Console.WriteLine("Product: {0}", elements.Product());
        Console.WriteLine("Min: {0}", elements.Min());
        Console.WriteLine("Max: {0}", elements.Max());
        Console.WriteLine("Average: {0}\n", elements.Average());
    }
}