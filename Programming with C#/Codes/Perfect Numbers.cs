using System;
using System.Collections.Generic;
using System.Linq;

class CatalanFormula
{
    static readonly int[] mPrimes = { 2, 3, 5, 7, 13, 17, 19, 31, 61, 89, 107, 127, 521, 607 };

    static List<int> digits = new List<int>();

    static void Main()
    {
        Console.WriteLine("Program prints first 14 Perfect Numbers: ");

        for (int i = 0; i < mPrimes.Length; i++)
        {
            digits = new List<int>() { 1 };

            for (int j = 0; j < mPrimes[i]; j++)
                DoubleN();

            digits[0]--;

            for (int j = 0; j < mPrimes[i] - 1; j++)
                DoubleN();

            Console.Write((i + 1) + " -> ");
            for (int j = digits.Count - 1; j >= 0; j--)
                Console.Write(digits[j]);

            Console.WriteLine();
        }
    }
  
    private static void DoubleN()
    {
        int carry = 0;

        for (int k = 0; k < digits.Count; k++)
        {
            int temp = digits[k] * 2 + carry;
            digits[k] = temp % 10;
            carry = temp / 10;
        }

        if (carry > 0)
            digits.Add(carry);
    }
}