using System;
using System.Collections.Generic;
using System.Linq;

class RiskWinsRiskLoses
{
    static readonly HashSet<string> visitedCombinations = new HashSet<string>();

    static readonly Func<int, char>[] operations =
    {
        x => (char)(--x >= 0 ? x + '0' : 57),
        x => (char)(++x <= 9 ? x + '0' : '0')
    };

    const int DigitsCount = 5;

    static void Main()
    {
        string startCombination = Console.ReadLine();
        string endCombination = Console.ReadLine();
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
            visitedCombinations.Add(Console.ReadLine());

        Console.WriteLine(FindShortestDistance(startCombination, endCombination));
    }

    static int FindShortestDistance(string startCombination, string endCombination)
    {
        char[] newCombinationDigits = new char[DigitsCount];
        int distance = 0;

        var queue = new Queue<string>();
        queue.Enqueue(startCombination);

        while (queue.Count > 0)
        {
            var tempQueue = new Queue<string>();
            distance++;

            while (queue.Count > 0)
            {
                var currentCombination = queue.Dequeue();

                currentCombination.CopyTo(0, newCombinationDigits, 0, DigitsCount);
               
                for (int i = 0; i < DigitsCount; i++)
                {
                    for (int j = 0; j < operations.Length; j++)
                    {
                        newCombinationDigits[i] = operations[j](newCombinationDigits[i] - '0');

                        string newCombination = new string(newCombinationDigits); // XXX

                        if (!visitedCombinations.Contains(newCombination))
                        {
                            // Combination found
                            if (newCombination == endCombination) return distance;

                            tempQueue.Enqueue(newCombination);
                            visitedCombinations.Add(newCombination);                       
                        }

                        newCombinationDigits[i] = currentCombination[i]; // backtracking
                    }
                }
            }

            queue = tempQueue;
        }

        return -1;
    }
}