using System;
using System.Linq;

class WearingIterative
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        var treasures = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int visitedRooms = 0;
        int collectedGold = 0;

        for (int i = 0; i < treasures.Length; i++)
        {
            if (collectedGold + treasures[i] > n)
                break;

            collectedGold += treasures[i];
            visitedRooms++;
        }

        Console.WriteLine(visitedRooms);
    }
}