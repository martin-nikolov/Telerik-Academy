using System;
using System.Linq;

class Digits
{
    static void Main()
    {
        var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int from = input[0], to = input[1], divider = input[2], residue = input[3];
        int count = 0;

        while (from % divider != residue)
            from++;

        while (from <= to)
        {
            count++;
            from += divider;
        }

        Console.WriteLine(count);
    }
}