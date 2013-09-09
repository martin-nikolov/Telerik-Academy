using System;
using System.Collections.Generic;
using System.Linq;

class GreedyDwarf
{
    static int bestCollection = Int32.MinValue;

    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ch => int.Parse(ch)).ToArray();

        int pattersCount = int.Parse(Console.ReadLine());
        List<int[]> patterns = new List<int[]>();

        for (int i = 0; i < pattersCount; i++)
            patterns.Add(Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ch => int.Parse(ch)).ToArray());

        for (int i = 0; i < pattersCount; i++)
        {
            bool[] visited = new bool[numbers.Length];
            visited[0] = true;

            int indexPattern = 0, indexNumbers = 0, currentCollection = numbers[0];

            while (true)
            {
                indexNumbers += patterns[i][indexPattern];
                indexPattern = (indexPattern + 1) % patterns[i].Length;

                if (indexNumbers < 0 || indexNumbers >= numbers.Length) break;

                if (visited[indexNumbers]) break;

                visited[indexNumbers] = true;

                currentCollection += numbers[indexNumbers];
            }

            if (currentCollection > bestCollection) bestCollection = currentCollection;
        }

        Console.WriteLine(bestCollection);
    }
}