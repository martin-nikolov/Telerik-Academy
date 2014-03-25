using System;
using System.Linq;

class WearingRecursively
{
    static int visitedRooms = 0, collectedGold = 0, bagCapacity = 0;
    static int[] rooms;

    static void Main()
    {
        bagCapacity = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        rooms = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        VisitRoom(0);

        Console.WriteLine(visitedRooms);
    }

    static void VisitRoom(int index)
    {
        if (index >= rooms.Length)
            return;

        if (collectedGold + rooms[index] > bagCapacity)
            return;

        collectedGold += rooms[index];
        visitedRooms++;

        VisitRoom(index + 1);
    }
}