using System;
using System.Collections.Generic;

class Accumulation
{
    static void Main()
    {
    }

    static List<int> AccumulateTwoNumbers(string a, string b)
    {
        string smaller = a.Length <= b.Length ? a : b;
        string bigger = a.Length > b.Length ? a : b;

        List<int> result = new List<int>();

        for (int i = bigger.Length - 1; i >= 0; i--)
            result.Add(bigger[i] - 48);

        for (int i = smaller.Length - 1, k = 0; i >= 0; i--, k++)
            result[k] += (smaller[i] - 48);

        int number, carry = 0;

        for (int i = 0; i < result.Count; i++)
        {
            number = result[i] + carry;
            result[i] = number % 10;
            carry = number / 10;
        }

        if (carry > 0)
            result.Add(carry);

        return result;
    }
}