using System;
using System.Collections.Generic;
using System.Linq;

class Sorting : IComparer<uint>
{
    static uint Remainder = 0;

    public static void Main()
    {
        var input = Console.ReadLine().Split(' ').Select(uint.Parse).ToArray();
        Remainder = input[1];

        var numbers = Console.ReadLine().Split(' ').Select(uint.Parse).ToArray();

        Array.Sort(numbers, new Sorting());

        Console.WriteLine(string.Join(" ", numbers));
    }

    public int Compare(uint x, uint y)
    {
        uint a = x % Remainder, b = y % Remainder;

        return a == b ? x.CompareTo(y) : a.CompareTo(b);
    }
}