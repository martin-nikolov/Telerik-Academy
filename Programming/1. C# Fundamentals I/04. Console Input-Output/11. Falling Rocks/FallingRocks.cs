/*
* 11. *Implement the "Falling Rocks" game in the text console.
* A small dwarf stays at the bottom of the screen and can move
* left and right (by the arrows keys). A number of rocks of
* different sizes and forms constantly fall down and you need
* to avoid a crash.
* 
* Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, -
* distributed with appropriate density. The dwarf is (O). 
* Ensure a constant game speed by Thread.Sleep(150).
*
* Implement collision detection and scoring system.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class FallingRocks
{
    public static ConsoleColor[] RockColors = 
    {
        ConsoleColor.Cyan,
        ConsoleColor.Green,
        ConsoleColor.Red,
        ConsoleColor.White,
        ConsoleColor.Yellow,
        ConsoleColor.DarkYellow,
        ConsoleColor.DarkCyan
    };

    static readonly char[] symbols = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-', '>', '<', 'v', '=' };
    static readonly Random rnd = new Random();

    static List<Rocks> rocks = new List<Rocks>();
    static PlayerPosition player = new PlayerPosition();
    static uint score = 0;// default
    static byte rockFallSpeed = 200;// default
    static byte playerMoveSteps = 1;// default
    const int LevelNormal = 300;
    const int LevelDifficult = 200;

    static void Main()
    {
        ConsoleOptions(); // Console window's options
        int level = ChooseLevel(); // User can choose level

        rocks = new List<Rocks>();
        player = new PlayerPosition(Console.WindowHeight - 1, Console.WindowWidth / 2 - 3); // Set player's start position
        
        score = 0;
        rockFallSpeed = 200;
        playerMoveSteps = 2;

        InitiallyAddingRocks(); // Add a few rocks at the beginning
        
        do
        {
            Console.Clear();

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo userKey = Console.ReadKey(true);

                if (userKey.Key == ConsoleKey.LeftArrow && player.y > 1)
                {
                    player = new PlayerPosition(player.x, player.y - (playerMoveSteps == 2 && player.y >= 1 ? playerMoveSteps - 1 : playerMoveSteps));
                }
                else if (userKey.Key == ConsoleKey.RightArrow && player.y + 4 < Console.WindowWidth)
                {
                    player = new PlayerPosition(player.x, player.y + (playerMoveSteps == 2 && player.y + 6 < Console.WindowWidth ? playerMoveSteps - 1 : playerMoveSteps));
                }
                else if (userKey.Key == ConsoleKey.W) // CHEAT - Key 'W'
                {
                    rockFallSpeed--;
                    if (rockFallSpeed < 50)
                        rockFallSpeed = 50;
                }
                else if (userKey.Key == ConsoleKey.S) // CHEAT - Key 'S'
                {
                    rockFallSpeed++;
                    if (rockFallSpeed > 250)
                        rockFallSpeed = 250;
                }
                else if (userKey.Key == ConsoleKey.Q) // CHEAT - Key 'Q'
                {
                    playerMoveSteps = 2;
                }
                else if (userKey.Key == ConsoleKey.A) // CHEAT - Key 'A'
                {
                    playerMoveSteps = 1;
                }
            }
            
            // Printing all rocks
            for (int i = rocks.Count - 1; i >= 0; i--)
            {
                rocks[i].y++;

                if (rocks[i].y > Console.WindowHeight - 1)
                {
                    rocks[i] = new Rocks(rnd.Next(1, Console.WindowWidth - 1), 0);
                }

                if (rocks[i].x == player.y && rocks[i].y == player.x ||
                    rocks[i].x == player.y + 1 && rocks[i].y == player.x ||
                    rocks[i].x == player.y + 2 && rocks[i].y == player.x)
                {
                    Entrance();
                    return;
                }

                score++;
                rocks[i].PrintRock();

                // ADD NEW ROCK
                if (score % level == 0)
                    rocks.Add(new Rocks(rnd.Next(1, Console.WindowWidth - 1), 0));
            }

            Console.SetCursorPosition(player.y, player.x);
            Console.Write("(0)");

            Thread.Sleep(rockFallSpeed);
        }
        while (true);
    }

    static void ConsoleOptions()
    {
        Console.Title = "Falling rocks!!!";
        Console.SetWindowSize(43, 22);
        Console.SetBufferSize(43, 22);
    }
    
    static int ChooseLevel()
    {
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2 - 4);
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Choose level:");

        Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2 - 2);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1 - Normal");
        Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2 - 1);
        Console.WriteLine("2 - Difficult");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 1);
        Console.Write("Enter your choice: ");
        Console.ResetColor();

        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
        }
        while (key.KeyChar != '1' && key.KeyChar != '2');

        if (key.KeyChar == '2')
        {
            return LevelDifficult;
        }
        else
        {
            return LevelNormal;
        }
    }

    static void InitiallyAddingRocks()
    {
        // Add a few rocks
        for (int i = 0; i < rnd.Next(15, 30); i++)
        {
            Rocks newRock;
            do
            {
                newRock = new Rocks(rnd.Next(1, Console.WindowWidth - 1), rnd.Next(0, 5));
            }
            while (rocks.Contains(newRock));

            rocks.Add(newRock);
        }
    }

    static void Entrance()
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 - 1);
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("GAME OVER!");
        Console.ResetColor();

        Console.SetCursorPosition(Console.WindowWidth / 2 - 9, Console.WindowHeight / 2 + 1);
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Your points: {0,5}", score);
        Console.ResetColor();

        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.ReadKey();
        Console.ReadKey();
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(Console.WindowWidth - 34, Console.WindowHeight / 2 - 2);
        Console.Write("Do you want to play again?\n\n");
        Console.WriteLine("      Press [ENTER] to start new game");
        Console.WriteLine("     or press any other key to go out..");

        Console.ResetColor();
        Console.SetCursorPosition(0, Console.WindowHeight - 1);

        if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            Main();

        return;
    }

    struct PlayerPosition
    {
        public int x;
        public int y;

        public PlayerPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Rocks
    {
        public int x;
        public int y;

        private readonly ConsoleColor rockColor;
        private readonly char rockType;

        public Rocks(int x, int y)
        {
            this.x = x;
            this.y = y;

            this.rockType = symbols[rnd.Next(0, symbols.Length)];
            this.rockColor = RockColors[rnd.Next(0, RockColors.Length)];
        }

        public void PrintRock()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = rockColor;
            Console.Write(rockType);
            Console.ResetColor();
        }
    }
}