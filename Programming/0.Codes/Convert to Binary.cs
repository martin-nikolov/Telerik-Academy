using System;
using System.Collections.Generic;

class SubSetSum
{
    static void Main()
    {
        ConvertToBinary(4);
        ConvertToBinary(151);
        ConvertToBinary(35);
        ConvertToBinary(43);
        ConvertToBinary(2512);
    }

    private static void ConvertToBinary(int num)
    {
        List<int> result = new List<int>();

        while (num != 0)
        {
            result.Add(num % 2);
            num = num / 2;
        }

        Reverse(result);
    }

    private static void Reverse(List<int> bin)
    {
        for (int i = bin.Count - 1; i >= 0; i--)
        {
            Console.Write("{0}", bin[i]);
        }
        Console.WriteLine();
    }
}