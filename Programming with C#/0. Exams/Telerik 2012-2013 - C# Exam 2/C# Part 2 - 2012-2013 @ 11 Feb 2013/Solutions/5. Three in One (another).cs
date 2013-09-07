using System;
using System.Linq;
using System.Collections.Generic;

class ThreeInOne
{
    static void Main()
    {
        Task1();
        Task2();
        Task3();
    }

    static void Task1()
    {
        int[] numbers = Console.ReadLine().Split(',').Select(ch => int.Parse(ch)).ToArray();
        int bestIndex = -1, bestValue = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] <= 21)
            {
                if (numbers[i] == bestValue)
                {
                    bestIndex = -1;
                }
                else if (numbers[i] > bestValue)
                {
                    bestValue = numbers[i];
                    bestIndex = i;
                }
            }
        }

        Console.WriteLine(bestIndex);
    }

    static void Task2()
    {
        int[] numbers = Console.ReadLine().Split(',').Select(ch => int.Parse(ch)).ToArray();
        int friendCount = int.Parse(Console.ReadLine());
        Array.Sort(numbers, (a, b) => b.CompareTo(a));

        int count = 0, index = 0;

        while (index < numbers.Length)
        {
            count += numbers[index];
            index += friendCount + 1;
        }

        Console.WriteLine(count);
    }

    static void Task3()
    {
        int[] tokens = Console.ReadLine().Split(' ').Select(ch => int.Parse(ch)).ToArray();
        long G1 = tokens[0], S1 = tokens[1], B1 = tokens[2];
        long G2 = tokens[3], S2 = tokens[4], B2 = tokens[5];
        long numberOfExchanges = 0;

        while (true)
        {
            if (B1 < B2)
            {
                if (S1 - 1 >= S2)
                {
                    B1 += 9;
                    S1--;
                }
                else if (G1 - 1 >= G2)
                {
                    S1 += 9;
                    G1--;
                }

                numberOfExchanges++;
            }
            else if (S1 < S2)
            {
                if (G1 - 1 >= G2)
                {
                    G1--;
                    S1 += 9;
                }
                else if (B1 - 11 >= B2)
                {
                    B1 -= 11;
                    S1++;
                }

                numberOfExchanges++;
            }
            else if (G1 < G2)
            {
                if (S1 - 11 >= S2)
                {
                    S1 -= 11;
                    G1++;
                }
                else if (B1 - 11 >= B2)
                {
                    S1++;
                    B1 -= 11;
                }
                else break;

                numberOfExchanges++;
            }
            else break;
        }

        Console.WriteLine((G1 < G2 || S1 < S2 || B1 < B2) ? -1 : numberOfExchanges);
    }
}