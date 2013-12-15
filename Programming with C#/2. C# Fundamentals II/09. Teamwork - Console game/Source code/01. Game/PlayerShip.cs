using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading;

namespace _01.Game
{
    public class PlayerShip : ObjectProperties
    {
        public static SoundPlayer DestroySound, ExplosionSound;
        public static List<Coordinates> PlayerCoords = new List<Coordinates>();
        public static char[,] Player = 
        {
            { ' ', ' ', '!', ' ', ' ', },
            { '<', '#', '#', '#', '>' }
        };
        public static int PlayerShootSpeed = 30;

        private static Coordinates barrelCoords;

        static PlayerShip()
        {
            if (System.IO.File.Exists("Sounds/destroy.wav")) DestroySound = new SoundPlayer("Sounds/destroy.wav");
            if (System.IO.File.Exists("Sounds/explosion.wav")) ExplosionSound = new SoundPlayer("Sounds/explosion.wav");

            PlayerShip.SetObjectCoords(Player, PlayerCoords, 46, 28);
            barrelCoords = new Coordinates(PlayerCoords[0].Row, PlayerCoords[0].Col);
        }

        public static void Shoot()
        {
            Program.IsPlayerShootNow = true;

            Coordinates currentBarrelCoords = new Coordinates(barrelCoords.Row - 1, barrelCoords.Col);

            for (int i = 0; i < 25; i++)
            {
                Thread.Sleep(PlayerShootSpeed);

                currentBarrelCoords.Row -= 1;

                #region [Check if some of the tower is hit]
                for (int j = 1; j <= 4; j++)
                {
                    int index = 0;

                    switch (j)
                    {
                        case 1: index = Towers.Tower1Coords.IndexOf(currentBarrelCoords); break;
                        case 2: index = Towers.Tower2Coords.IndexOf(currentBarrelCoords); break;
                        case 3: index = Towers.Tower3Coords.IndexOf(currentBarrelCoords); break;
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

                        Console.SetCursorPosition(currentBarrelCoords.Col, currentBarrelCoords.Row);
                        Console.Write(" ");
                        Console.SetCursorPosition(currentBarrelCoords.Col, currentBarrelCoords.Row + 1);
                        Console.Write(" ");

                        Program.IsPlayerShootNow = false;
                        Towers.IsHitTower = true;

                        return;
                    }
                }
                #endregion

                #region [Check if some of the invaders are hit]
                for (int j = 3; j >= 1; j--)
                {
                    List<Coordinates[]> currentInvaders;

                    switch (j)
                    {
                        case 3: currentInvaders = Invaders.InvaderCoords3; break;
                        case 2: currentInvaders = Invaders.InvaderCoords2; break;
                        case 1: currentInvaders = Invaders.InvaderCoords1; break;
                        default: return;
                    }

                    for (int k = 0; k < currentInvaders.Count; k++)
                    {
                        if (currentInvaders[k] != null && currentInvaders[k].Contains(currentBarrelCoords))
                        {
                            Field.Score += 10;
                            if (j == 2) Field.Score += 15;
                            else if (j == 1) Field.Score += 40;
                            Field.IsChangedScore = true;

                            currentInvaders.Remove(currentInvaders[k]);

                            if (DestroySound != null) DestroySound.Play();

                            Program.IsPlayerShootNow = false;

                            return;
                        }
                    }
                }

                #endregion

                #region [Check if flying saucer is hit]

                if (FlyingSaucer.AlienCoords.Contains(currentBarrelCoords))
                {
                    if (ExplosionSound != null) ExplosionSound.Play();
                    Field.Score += FlyingSaucer.Score;
                    FlyingSaucer.IsExits = false;
                    FlyingSaucer.AlienCoords = new List<ObjectProperties.Coordinates>();
                }

                #endregion

                #region [Check if boss is hit]

                if (Boss.BossTime && Boss.BossCoords.Contains(currentBarrelCoords))
                {
                    Program.IsPlayerShootNow = false;
                    Boss.Hitted--;
                    Field.Score += 50;
                    return;
                }

                #endregion

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(currentBarrelCoords.Col, currentBarrelCoords.Row);
                Console.Write("|");

                Console.SetCursorPosition(currentBarrelCoords.Col, currentBarrelCoords.Row + 1);
                Console.Write(" ");
            }

            Program.IsPlayerShootNow = false;
        }

        public static void MoveLeft(int step = -1)
        {
            for (int i = 0; i < PlayerCoords.Count; i++)
            {
                int nextColumn = PlayerCoords[i].Col + step;

                if (nextColumn < 0) nextColumn = Console.WindowWidth - 1;
                else if (nextColumn >= Console.WindowWidth) nextColumn = 0;

                PlayerCoords[i] = new Coordinates(PlayerCoords[i].Row, nextColumn);
            }

            #region [Removes, Draws and Moves weapon (barrel) of the ship]

            int next = barrelCoords.Col + step;

            if (next < 0) next = Console.WindowWidth - 1;
            else if (next >= Console.WindowWidth) next = 0;

            barrelCoords = PlayerCoords[0] = new Coordinates(barrelCoords.Row, next);

            #endregion
        }

        public static void MoveRight()
        {
            MoveLeft(1);
        }
    }
}