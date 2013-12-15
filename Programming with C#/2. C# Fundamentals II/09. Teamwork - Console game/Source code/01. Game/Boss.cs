using System;
using System.Collections.Generic;
using System.Threading;

namespace _01.Game
{
    class Boss : ObjectProperties
    {

        public static List<Coordinates> BossCoords = new List<Coordinates>();
        public static char[,] BossMatrix = 
        {
            { ' ', ' ', ' ', ' ', ' ', ' ', '/', '-', '-', '-', '-', '\\', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', '/', ' ', ' ', ' ', ' ', ' ', ' ', '\\', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', '/', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '\\', ' ', ' ', ' ', ' ' },
            { '<', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '>' },
            { '<', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '>' },
            { ' ', ' ', ' ', ' ', '\\', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '/', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', '\\', ' ', ' ', ' ', ' ', ' ', ' ', '/', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', '\\', '-', '-', '-', '-', '/', ' ', ' ', ' ', ' ', ' ', ' ' }
        };
        public static bool BossTime = false;
        public static int Hitted = 30;

        private static string direction = "right";
        private static int row = 0, col = 0, iteration = 1;
        private static bool continueMove = true;

        static Boss()
        {
            Boss.SetObjectCoords(BossMatrix, BossCoords, 20, 15);
        }

        public static void MoveBoss()
        {
            int step = 2;

            if (direction == "right")
            {
                for (int i = 0; i < BossCoords.Count; i++)
                {
                    if (!continueMove && BossCoords[BossCoords.Count - 1].Col >= Console.WindowWidth / 2) step = 0;
                    BossCoords[i] = new Coordinates(BossCoords[i].Row + row, BossCoords[i].Col + step);
                }

                if (row == 1 && col == 1 && BossCoords[0].Row >= Console.BufferHeight - 15)
                {
                    row = -1; col = -1;
                    direction = "left";
                }

                if (BossCoords[0].Col >= Console.WindowWidth)
                {
                    col = 0; row = 0;

                    if (iteration++ == 1 && continueMove)
                        for (int i = 0; i < BossCoords.Count; i++)
                            BossCoords[i] = new Coordinates(BossCoords[i].Row - 5, BossCoords[i].Col);

                    if (iteration > 4 && iteration % 2 == 0 && continueMove)
                    {
                        row = -1; col = -1;
                    }

                    direction = "left";
                }
            }
            else if (direction == "left")
            {
                for (int i = 0; i < BossCoords.Count; i++)
                    BossCoords[i] = new Coordinates(BossCoords[i].Row + row, BossCoords[i].Col - step);

                if (row == -1 && col == -1)
                {
                    continueMove = false;
                }


                if (BossCoords[BossCoords.Count - 1].Col < 0)
                {
                    col = 0; row = 0;

                    if (iteration++ == 2 && continueMove)
                        for (int i = 0; i < BossCoords.Count; i++)
                            BossCoords[i] = new Coordinates(BossCoords[i].Row - 5, BossCoords[i].Col);

                    if (iteration > 3 && iteration % 2 != 0 && continueMove)
                    {
                        row = 1; col = 1;
                    }

                    direction = "right";
                }
            }
        }

        public static void Shoot()
        {
            if (Program.StopGame) return;

            int x = 0, y = 0;

            int randomIndex = new Random().Next(BossCoords.Count - 6, BossCoords.Count);

            x = BossCoords[randomIndex].Row;
            y = BossCoords[randomIndex].Col;

            while (x < Console.WindowHeight - 5)
            {
                if (Program.StopGame) return;

                if (x >= 0 && x < Console.WindowHeight && y >= 0 && y < Console.WindowWidth)
                {
                    Console.SetCursorPosition(y, x - 1);
                    Console.Write(" ");

                    if (Program.StopGame) return;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(y, x);
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Coordinates coords = new Coordinates { Row = x, Col = y };

                #region [Check if some of the tower is hit]
                for (int j = 1; j <= 4; j++)
                {
                    int index = 0;

                    switch (j)
                    {
                        case 1: index = Towers.Tower1Coords.IndexOf(coords); break;
                        case 2: index = Towers.Tower2Coords.IndexOf(coords); break;
                        case 3: index = Towers.Tower3Coords.IndexOf(coords); break;
                        default: index = -1; break;
                    }

                    if (index != -1)
                    {
                        switch (j)
                        {
                            case 1: Towers.Tower1Coords[index] = new Coordinates(); break;
                            case 2: Towers.Tower2Coords[index] = new Coordinates(); break;
                            case 3: Towers.Tower3Coords[index] = new Coordinates(); break;
                        }

                        Towers.IsHitTower = true;

                        return;
                    }
                }
                #endregion

                if (PlayerShip.PlayerCoords.Contains(coords) && Field.LivesCount == 1)
                {
                    Invaders.IsShooted = true; return;
                }
                else if (PlayerShip.PlayerCoords.Contains(coords) && Field.LivesCount > 1)
                {
                    Field.LivesCount--;
                }

                x++;
                Thread.Sleep(100);
            }
        }
    }
}
