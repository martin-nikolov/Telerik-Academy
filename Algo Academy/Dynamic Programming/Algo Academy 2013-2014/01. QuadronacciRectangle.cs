using System;
using System.Collections.Generic;
using System.Linq;

class QuadronacciRectangle
{
    static void Main()
    {
        long q1 = long.Parse(Console.ReadLine());
        long q2 = long.Parse(Console.ReadLine());
        long q3 = long.Parse(Console.ReadLine());
        long q4 = long.Parse(Console.ReadLine());

        int R = int.Parse(Console.ReadLine());
        int C = int.Parse(Console.ReadLine());
        int totalNumbers = R * C;

        var numbers = new List<long>(totalNumbers);
        numbers.AddRange(new long[] { q1, q2, q3, q4 });

        for (int i = 4; i < numbers.Capacity; i++)
        {
            var next = numbers[i - 1] + numbers[i - 2] + numbers[i - 3] + numbers[i - 4];
            numbers.Add(next);
        }

        for (int i = 1; i <= numbers.Count; i++)
            Console.Write(numbers[i - 1] + ((i % C == 0) ? Environment.NewLine : " "));
    }
}