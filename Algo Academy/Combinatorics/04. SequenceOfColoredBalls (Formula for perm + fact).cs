using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class SequenceOfColoredBalls
{
    static readonly Dictionary<char, int> lettersCount = new Dictionary<char, int>();

    // Formula:
    //
    // Input: BYYBB
    // N = 5 => F(5) = 120
    // 'B' occurs 3 times => F(3) = 6
    // 'Y' occurs 2 times => F(2) = 2
    //
    // Result => F(5) / ( F(3) * F(2) ) = 120 / (6 * 2) = 120 / 12 = 10

    static void Main()
    {
        var input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            if (!lettersCount.ContainsKey(input[i]))
                lettersCount.Add(input[i], 0);

            lettersCount[input[i]]++;
        }

        BigInteger result = Factorial(input.Length);
     
        foreach (var letter in lettersCount)
            result /= Factorial(letter.Value);

        Console.WriteLine(result);
    }

    static BigInteger Factorial(BigInteger n)
    {
        if (n <= 1) return 1;

        return n * Factorial(n - 1);
    }
}