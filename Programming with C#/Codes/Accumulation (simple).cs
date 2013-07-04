using System;
using System.Collections.Generic;
using System.Linq;

class Accumulation
{
    static void Main()
    {
        Console.Write("Enter first number:  ");
        string first = Console.ReadLine();

        Console.Write("Enter second number: ");
        string second = Console.ReadLine();

        List<int> result = AccumulateTwoNumbers(first, second);

        Console.Write("\nResult: {0} + {1} = ", first, second);
        PrintResult(result);
    }

    static List<int> AccumulateTwoNumbers(string first, string second)
    {
        var a = first.Select(ch => ch - '0').ToArray();
        var b = second.Select(ch => ch - '0').ToArray();

        Array.Reverse(a);
        Array.Reverse(b);

        List<int> result = new List<int>(Math.Max(a.Length, b.Length));

        int carry = 0;

        for (int i = 0; i < result.Capacity; i++)
        {
            int num = (i < a.Length ? a[i] : 0) + (i < b.Length ? b[i] : 0) + carry;
            carry = num / 10;
            result.Add(num % 10);
        }

        if (carry > 0)
            result.Add(carry);

        return result;
    }

    static void PrintResult(List<int> result)
    {
        for (int i = result.Count - 1; i >= 0; i--)
            Console.Write(result[i]);

        Console.WriteLine("\n");
    }
}