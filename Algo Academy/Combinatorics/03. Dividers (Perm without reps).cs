using System;
using System.Linq;
using System.Text;

class Dividers
{
    static int[] elements, permutations;
    static bool[] used;
    static int bestNumber = MaximalNumber, bestDividersCount = MaximalNumber;

    const int MaximalNumber = 100000;

    static void Main()
    {
        ParseInput();

        Permutations(0);

        Console.WriteLine(bestNumber);
    }
  
    static void ParseInput()
    {
        int N = int.Parse(Console.ReadLine());
        elements = new int[N];
        permutations = new int[N];
        used = new bool[N];

        for (int i = 0; i < N; i++)
            elements[i] = int.Parse(Console.ReadLine());
    }

    static void Permutations(int index)
    {
        if (index >= permutations.Length)
        {
            var number = int.Parse(GetNumber());
            var dividers = FindDividersCount(number);

            if (bestDividersCount > dividers || bestDividersCount == dividers && number < bestNumber)
            {
                bestNumber = number;
                bestDividersCount = dividers;
            }

            return;
        }

        for (int i = 0; i < permutations.Length; i++)
        {
            if (used[i]) continue;

            used[i] = true;

            permutations[index] = i;
            Permutations(index + 1);

            used[i] = false;
        }
    }

    static int FindDividersCount(int number)
    {
        var dividersCount = 0;

        for (int i = 1; i <= number; i++)
            if (number % i == 0)
                dividersCount++;

        return dividersCount;
    }

    static string GetNumber()
    {
        var number = new StringBuilder();

        for (int i = 0; i < permutations.Length; i++)
            number.Append(elements[permutations[i]]);

        return number.ToString();
    }
}