using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class TwoIsBetterThanOne
{
    static long happyNumbersCount = 0, start, end;

    static void Main()
    {
        SolveTask1();
        SolveTask2();
    }

    static void SolveTask1()
    {
        long[] interval = Console.ReadLine().Split(' ').Select(ch => long.Parse(ch)).ToArray();
        start = interval[0];
        end = interval[1];

        GenerateAllNumbers(0);
        Console.WriteLine(happyNumbersCount);
    }

    static void GenerateAllNumbers(long number)
    {
        if (number > end) return;

        if (number >= start && IsPalindrome(number))
            happyNumbersCount++;

        GenerateAllNumbers(number * 10 + 3);
        GenerateAllNumbers(number * 10 + 5);
    }

    static bool IsPalindrome(long number)
    {
        string num = number.ToString();

        for (int i = 0; i < num.Length / 2; i++)
            if (num[i] != num[num.Length - i - 1]) return false;

        return true;
    }

    static void SolveTask2()
    {
        List<int> numbers = Console.ReadLine().Split(',').Select(ch => int.Parse(ch)).ToList();
        int p = int.Parse(Console.ReadLine());

        numbers.Sort();
        Console.WriteLine(numbers[(int)(numbers.Count * (p / 100.01))]);
    }
}