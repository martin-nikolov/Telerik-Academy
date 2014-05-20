namespace Refactoring
{
    using System;

    public class Labyrinth
    {
        const int MinX = 0;
        const int MaxX = int.MaxValue / 2;

        const int MinY = 0;
        const int MaxY = int.MaxValue / 4;

        static void Main()
        {
            // You can find first example in Project "01. Cooking" -> class "CookingTest.cs"

            int x = 10;
            int y = 15;

            if (IsCellPassable(x, y) && !IsCellVisited(x, y))
            {
                VisitCell(x, y);
            }
        }
 
        private static void VisitCell(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static bool IsCellVisited(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static bool IsCellPassable(int x, int y)
        {
            bool isCellPassable = x >= MinX && x <= MaxX &&
                                  MaxY >= y && MinY <= y;

            return isCellPassable;
        }
    }
}