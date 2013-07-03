using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class EqualNumbers
{
    static BigInteger Factorial(int n)
    {
        if (n <= 0)
            return 1;

        return n * Factorial(n - 1);
    }

    static BigInteger CalculateCombinations(int n)
    {
        // Classical implementation of finding combinations of n element k-th class
        return Factorial(n) / (2 * Factorial(n - 2));
    }

    static void Main()
    { 
        Dictionary<byte, byte> studentHeight = new Dictionary<byte, byte>();
        int n = int.Parse(Console.ReadLine());

        string numbers = Console.ReadLine(); // We have sequence of numbers on one line
        string[] tokens = numbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < n; i++)
        {
            byte height = byte.Parse(tokens[i]);

            if (!studentHeight.ContainsKey(height))
                studentHeight.Add(height, 1);
            else
                studentHeight[height]++;
        }

        int combinations = 0;
        for (int i = 0; i < studentHeight.Count; i++)
        {
            if (studentHeight.ElementAt(i).Value > 1)
            {
                combinations += (int)CalculateCombinations(studentHeight.ElementAt(i).Value);
            }
        }
        Console.WriteLine(combinations);
    }
}