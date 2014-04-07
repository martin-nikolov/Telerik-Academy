using System;
using System.Collections.Generic;
using System.Linq;

class ColoredRabbits
{
    static readonly Dictionary<int, int> rabbitsCount = new Dictionary<int, int>();

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            int rabbit = int.Parse(Console.ReadLine()) + 1;

            if (!rabbitsCount.ContainsKey(rabbit))
                rabbitsCount.Add(rabbit, 0);

            rabbitsCount[rabbit]++;
        }

        int totalRabits = 0;

        foreach (var rabbits in rabbitsCount)
            totalRabits += (int)Math.Ceiling((double)rabbits.Value / rabbits.Key) * rabbits.Key;

        Console.WriteLine(totalRabits);
    }
}