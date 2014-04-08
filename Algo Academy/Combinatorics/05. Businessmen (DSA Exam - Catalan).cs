using System;
using System.Linq;
using System.Numerics;

class Businessmen
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine()) / 2;

        Console.WriteLine(Factorial(2 * N) / (Factorial(N + 1) * Factorial(N))); // Slow
    }

    static BigInteger Factorial(int n)
    {
        if (n == 1) return 1;

        return n * Factorial(n - 1);
    }
}