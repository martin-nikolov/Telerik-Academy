using System;
using System.Collections.Generic;
using System.Threading;

namespace _01.Game
{
    class Invaders : ObjectProperties
    {
        public static List<Coordinates[]> InvaderCoords1 = new List<Coordinates[]>();
        public static List<Coordinates[]> InvaderCoords2 = new List<Coordinates[]>();
        public static List<Coordinates[]> InvaderCoords3 = new List<Coordinates[]>();
        public static string[] Ship1, Ship2, Ship3;
        public static bool Right = true, ShootNow = false, IsShooted = false;
        public static int ShootRow = 1;

        private static readonly Random rnd = new Random();
        private static readonly char[,] invader1 = new char[3, 3];
        private static readonly char[,] invader2 = new char[3, 5];
        private static readonly char[,] invader3 = new char[3, 3];

        public Invaders()
        {
            string invaderVariant1 = @" ! 
[*]
<'>";
            string invaderVariant2 = @" {X} 
=+=+=
<\'/>";
            string invaderVariant3 = @" | 
[=]
\'/";
            int count = 0;

            Ship1 = invaderVariant1.Split('\n');
            Ship2 = invaderVariant2.Split('\n');
            Ship3 = invaderVariant3.Split('\n');

            for (int row = 0; row < invader1.GetLongLength(0); row++)
                for (int col = 0; col < invader1.GetLongLength(1); col++, count++)
                {
                    invader1[row, col] = invaderVariant1[count];
                    invader3[row, col] = invaderVariant3[count];
                }

            count = 0;

            for (int row = 0; row < invader2.GetLongLength(0); row++)
                for (int col = 0; col < invader2.GetLongLength(1); col++, count++)
                    invader2[row, col] = invaderVariant2[count];

            SetInvadersCoords(ref InvaderCoords1, top: 7, left: 4, count: 10, space: 6);
            SetInvadersCoords(ref InvaderCoords2, top: 11, left: 5, count: 8, space: 7, size: 5);
            SetInvadersCoords(ref InvaderCoords3, top: 15, left: 10, count: 8, space: 6);
        }

        public static void MoveInvaders()
        {
            if (Invaders.Right)
            {
                Invaders.MoveRight(ref Invaders.InvaderCoords1, 1);
                Invaders.MoveRight(ref Invaders.InvaderCoords2, 2);
                Invaders.MoveRight(ref Invaders.InvaderCoords3, 3);
            }
            else if (!Invaders.Right)
            {
                Invaders.MoveLeft(ref Invaders.InvaderCoords1, 1);
                Invaders.MoveLeft(ref Invaders.InvaderCoords2, 2);
                Invaders.MoveLeft(ref Invaders.InvaderCoords3, 3);
            }
        }

        public static void PrintInvaders()
        {
            Invaders.PrintInvaders(1);
            Invaders.PrintInvaders(2);
            Invaders.PrintInvaders(3);
        }

        private static void SetInvadersCoords(ref List<Coordinates[]> invadersCoords, int top, int left, int count, int space, int size = 3)
        {
            for (int i = 0; i < count; i++, left += space)
            {
                if (size == 3)
                {
                    invadersCoords.Add(new Coordinates[] { new Coordinates(top, left), 
                    new Coordinates(top, left + 1), new Coordinates(top, left + 2) });
                }
                else if (size == 5)
                {
                    invadersCoords.Add(new Coordinates[] { new Coordinates(top, left), 
                    new Coordinates(top, left + 1), new Coordinates(top, left + 2), new Coordinates(top, left + 3),
                    new Coordinates(top, left + 4) });
                }
            }
        }

        private static void MoveRight(ref List<Coordinates[]> invadersCoords, int type)
        {
            for (int i = 0; i < invadersCoords.Count; i++)
            {
                if (invadersCoords[i] != null)
                {
                    if (invadersCoords[i][2].Col + 5 > Console.WindowWidth)
                    {
                        ChangeColumn(ref invadersCoords, i, 1);
                        MoveDown();
                        Right = false;
                        break;
                    }

                    ChangeColumn(ref invadersCoords, i, 1);
                }
            }
        }
        private static void MoveLeft(ref List<Coordinates[]> invadersCoords, int type)
        {
            for (int i = 0; i < invadersCoords.Count; i++)
            {
                if (invadersCoords[i] != null)
                {
                    if (invadersCoords[i][0].Col - 2 <= 0)
                    {
                        MoveDown();
                        Right = true;
                        break;
                    }

                    ChangeColumn(ref invadersCoords, i, -1);
                }
            }
        }

        private static void ChangeColumn(ref List<Coordinates[]> invadersCoords, int i, int step)
        {
            for (int j = 0; j < invadersCoords[i].Length; j++)
                invadersCoords[i][j].Col = invadersCoords[i][j].Col + step;
        }

        private static void MoveDown()
        {
            if (Field.Speed - 115 > 0) Field.Speed -= 35;

            for (int i = 1; i <= 3; i++)
            {
                List<Coordinates[]> currentInvaders;
                int currentRow = 0;

                switch (i)
                {
                    case 1: currentInvaders = InvaderCoords1; break;
                    case 2: currentInvaders = InvaderCoords2; break;
                    case 3: currentInvaders = InvaderCoords3; break;
                    default: return;
                }

                for (int j = 0; j < currentInvaders.Count; j++)
                {
                    if (currentInvaders[j] != null)
                    {
                        currentRow = currentInvaders[j][0].Row;

                        if (currentRow == 22)
                        {
                            Invaders.IsShooted = true;
                            return;
                        }

                        for (int k = 0; k < currentInvaders[j].Length; k++) currentInvaders[j][k].Row++;
                    }
                }
            }
        }

        private static void PrintInvaders(int type)
        {
            List<Coordinates[]> currentInvaders;
            string[] currentShipType;

            switch (type)
            {
                case 1: currentInvaders = InvaderCoords1; currentShipType = Ship1; Console.ForegroundColor = ConsoleColor.Cyan; break;
                case 2: currentInvaders = InvaderCoords2; currentShipType = Ship2; Console.ForegroundColor = ConsoleColor.Yellow; break;
                case 3: currentInvaders = InvaderCoords3; currentShipType = Ship3; Console.ForegroundColor = ConsoleColor.DarkCyan; break;
                default: return;
            }

            for (int i = 0; i < currentInvaders.Count; i++)
            {
                if (currentInvaders[i] != null)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.SetCursorPosition(currentInvaders[i][0].Col, currentInvaders[i][0].Row - 2 + j);
                        Console.Write(string.Join("", currentShipType[j]));
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Shoot()
        {
            ShootNow = false;
            int x = 0, y = 0;

            List<Coordinates[]> invadersCoords = new List<Coordinates[]>();

            if (ShootRow == 1 && InvaderCoords3.Count == 0) ShootRow = 2;

            if (ShootRow == 2 && InvaderCoords2.Count == 0) ShootRow = 3;

            if (ShootRow == 3 && InvaderCoords1.Count == 0)
            {
                ShootRow = -1;
                return;
            }

            if (ShootRow < 0) return;

            int count = 0;

            switch (ShootRow)
            {
                case 3: count = InvaderCoords1.Count; invadersCoords = InvaderCoords1; break;
                case 2: count = InvaderCoords2.Count; invadersCoords = InvaderCoords2; break;
                case 1: count = InvaderCoords3.Count; invadersCoords = InvaderCoords3; break;
                default: return;
            }

            if (count == 0) return;

            int index1 = rnd.Next(0, count);
            x = invadersCoords[index1][1].Row;
            y = invadersCoords[index1][1].Col;

            while (x < Console.WindowHeight - 5)
            {
                if (IsShooted) return;

                Console.SetCursorPosition(y, x - 1);
                Console.Write(" ");

                Console.SetCursorPosition(y, x);
                Console.Write("|");

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

                        ShootNow = false;
                        Towers.IsHitTower = true;

                        return;
                    }
                }
                #endregion

                if (PlayerShip.PlayerCoords.Contains(coords) && Field.LivesCount == 1)
                {
                    IsShooted = true; return;
                }
                else if (PlayerShip.PlayerCoords.Contains(coords) && Field.LivesCount > 1)
                {
                    Field.LivesCount--;
                }

                x++;
                Thread.Sleep(100);
            }

            ShootNow = false;
        }
    }
}
