using System;
using System.Linq;

class GreedyDwarf
{
    static bool[] visited;
    static long bestCollection = long.MinValue;

    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(',').Select(n => int.Parse(n)).ToArray();
        visited = new bool[numbers.Length];

        int m = int.Parse(Console.ReadLine());

        int[][] patters = new int[m][];
        for (int i = 0; i < m; i++)
        {
            patters[i] = Console.ReadLine().Split(',').Select(n => int.Parse(n)).ToArray();

            GetCollectionCoint(numbers, patters[i]);
        }

        Console.WriteLine(bestCollection);
    }

    static void GetCollectionCoint(int[] numbers, int[] patters)
    {
        visited = Enumerable.Repeat(false, visited.Length).ToArray();

        int currentCollection = 0, index = 0;

        for (int i = 0; i < patters.Length; i++)
        {
            if (index < 0 || index >= numbers.Length || visited[index] == true) break;

            currentCollection += numbers[index];
            visited[index] = true;

            index += patters[i];
            
            if (i == patters.Length - 1) i = -1; // Starts from the beginning of pattern numbers
        }

        if (currentCollection > bestCollection) bestCollection = currentCollection;
    }
}