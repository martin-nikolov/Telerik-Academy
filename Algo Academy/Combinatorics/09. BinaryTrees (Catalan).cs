using System;
using System.Linq;
using System.Numerics;

class BinaryTrees
{
    static readonly int[] lettersCount = new int[26];

    static void Main()
    {
        var input = Console.ReadLine().ToCharArray();

        for (int i = 0; i < input.Length; i++)
            lettersCount[input[i] - 'A']++;

        Console.WriteLine(CalculateResult(input.Length));
    }

    // Formula:
    //
    // Input: YBB
    // N = 3 => F(3) = 6
    // 'B' occurs 2 time(s) => F(2) = 2
    // 'Y' occurs 1 time(s) => F(1) = 1
    //
    // x => F(3) / ( F(2) * F(1) ) = 6 / (2 * 1) = 6 / 2 = 3
    // y => Catalan(N) = Catalan(3) = 5
    // 
    // Result = x * y = 15
 
    static BigInteger CalculateResult(int n)
    {
        var result = Factorial(n);

        for (int i = 0; i < lettersCount.Length; i++)
            result /= Factorial(lettersCount[i]);

        return result * CalculateCatalan(n);
    }

    static BigInteger CalculateCatalan(int n)
    {
        return Factorial(2 * n) / (Factorial(n + 1) * Factorial(n));
    }

    static BigInteger Factorial(int n)
    {
        if (n <= 1) return 1;

        return n * Factorial(n - 1);
    }
}