using System.Collections.Generic;

namespace _01.Game
{
    public class Towers : ObjectProperties
    {
        public static List<Coordinates> Tower1Coords = new List<Coordinates>();
        public static List<Coordinates> Tower2Coords = new List<Coordinates>();
        public static List<Coordinates> Tower3Coords = new List<Coordinates>();
        public static bool IsHitTower = true;

        private const int Rows = 4, Cols = 9;
        private static readonly char[,] tower1 = new char[Rows, Cols];

        static Towers()
        {
            string tower = @"|=======|
||=====||
||     ||
||     ||".Replace("\r\n", string.Empty);

            int count = 0;

            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Cols; col++, count++)
                    tower1[row, col] = tower[count];

            Towers.SetObjectCoords(tower1, Tower1Coords, 19, 23);
            Towers.SetObjectCoords(tower1, Tower2Coords, 44, 23);
            Towers.SetObjectCoords(tower1, Tower3Coords, 69, 23);
        }

        public static void PrintTowers()
        {
            Towers.IsHitTower = false;
            PrintObject(tower1, Tower1Coords);
            PrintObject(tower1, Tower2Coords);
            PrintObject(tower1, Tower3Coords);
        }
    }
}