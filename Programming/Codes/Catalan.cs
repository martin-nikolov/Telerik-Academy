using System;
using System.Linq;
using System.Numerics;

class CatalanFormula
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        uint n = uint.Parse(Console.ReadLine());

        Console.WriteLine("\nC({0}) = {1}\n", n, Fact(2 * n) / (Fact(n + 1) * Fact(n)));
    }

    // Calculate factorial
    static BigInteger Fact(uint n)
    {
        if (n < 1) return 1;

        return n * Fact(n - 1);
    }
}