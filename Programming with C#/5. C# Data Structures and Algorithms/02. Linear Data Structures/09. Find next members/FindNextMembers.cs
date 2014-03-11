/*
 * 9.
 * We are given the following sequence:
 * S1 = N;
 * S2 = S1 + 1;
 * S3 = 2*S1 + 1;
 * S4 = S1 + 2;
 * S5 = S2 + 1;
 * S6 = 2*S2 + 1;
 * S7 = S2 + 2;
 * ...
 * 
 * Using the Queue<T> class write a program to print its first 50 members for given N.
 * Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
 */

using System;
using System.Collections.Generic;
using System.Linq;

class FindNextMembers
{
    static readonly Func<int, int>[] operations =
    {
        x => x + 1,
        x => 2 * x + 1,
        x => x + 2,
    };

    static void Main()
    {
        Console.Write("N: ");
        var n = int.Parse(Console.ReadLine());

        Console.Write("Count: ");
        var count = uint.Parse(Console.ReadLine());

        var result = CalculateNextMembers(n, count);

        Console.WriteLine(string.Join(", ", result));
    }

    static IEnumerable<int> CalculateNextMembers(int n, uint count)
    {
        var sequence = new Queue<int>();
        var result = new List<int>();

        sequence.Enqueue(n);
        result.Add(n);

        for (int i = 0; i < count; i++)
        {
            var member = sequence.Dequeue();
            var nextMembers = new List<int>();
            
            foreach (var operation in operations)
                nextMembers.Add(operation(member));

            sequence.Enqueue(nextMembers[0]);
            sequence.Enqueue(nextMembers[1]);
            sequence.Enqueue(nextMembers[2]);

            result.AddRange(nextMembers);
        }

        return result;
    }
}