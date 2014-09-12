using System;
using System.Linq;
using System.Numerics;

/// <summary>
/// Formula: Factorial(2 * N) / [Factorial(N + 1) * Factorial(N)]
/// </summary>
class Businessmen
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine()) / 2;

        Console.WriteLine(Factorial(2 * N) / (Factorial(N + 1) * Factorial(N)));
    }

    static BigInteger Factorial(int n)
    {
        if (n == 1) return 1;

        return n * Factorial(n - 1);
    }
}