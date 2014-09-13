using System;
using System.Linq;
using System.Numerics;

public class RoboticZombieCamel
{
    private static readonly BigInteger module = new BigInteger(ulong.MaxValue) + 1;
    private static int[] values;

    internal static void Main()
    {
        var count = int.Parse(Console.ReadLine());
        values = new int[count];

        for (int i = 0; i < count; i++)
        {
            Console.ReadLine(); // Bgcoder input problem
            var coords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            values[i] = Math.Abs(coords[0]) + Math.Abs(coords[1]);
        }

        var pow = ((BigInteger)1 << count - 1);
        var result = (values.Sum() * pow) % module;

        Console.WriteLine(result);
    }
}