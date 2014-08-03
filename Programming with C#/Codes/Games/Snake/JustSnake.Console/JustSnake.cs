using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Snake
{
    class Program
    {
        //Easy way to access element's coordinations
        struct Position
        {
            public int row;
            public int col;

            public Position(int row, int col)
            {
                this.row = row;
                this.col = col;
            }
        }

        static void Main(string[] args)
        {
            end:
            Console.Title = "SNAKE - MADE BY MARTIN NIKOLOV";

            //Set Console's Windows Sizes
            Console.WindowHeight = 25;
            Console.WindowWidth = 50;

            //Set Console's Buffer Sizes;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            //Random Generator
            Random randomNumberGenerator = new Random();

            //Variable increasing the speed
            double speedIncreaser = 100;

            //First elemets of our snake
            Queue<Position> snakeElements = new Queue<Position>();
            for (int i = 0; i <= 4; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }

            //Generating random coordinations of food
            Position food;
            int foodPushTime;
            do
            {
                food = new Position(
                    randomNumberGenerator.Next(1, Console.WindowHeight - 1),
                    randomNumberGenerator.Next(1, Console.WindowWidth - 1));
                foodPushTime = Environment.TickCount;
            }
            while (snakeElements.Contains(food));

            //Print food on the Console
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(food.col, food.row);
            Console.Write("@");
            Console.ResetColor();

            //Rock
            List<Position> rocks = new List<Position>();
            for (int i = 0; i < randomNumberGenerator.Next(1, 11); i++)
            {
                do
                {
                    rocks.Add(new Position(randomNumberGenerator.Next(1, Console.WindowHeight - 1),
                        randomNumberGenerator.Next(1, Console.WindowWidth - 1)));
                }
                while (snakeElements.Contains(rocks[i]) ||
                       (food.row == rocks[i].row && food.col == rocks[i].col));
            }

            //Print rocks
            foreach (Position rock in rocks)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(rock.col, rock.row);
                Console.Write("=");
                Console.ResetColor();
            }

            //Easy way to access every direction
            byte right = 0;
            byte left = 1;
            byte down = 2;
            byte up = 3;

            //Available directions
            Position[] directions = 
            {
                new Position(0,1), //Right
                new Position(0,-1), //Left
                new Position(1,0), //Down
                new Position(-1,0)//Up
            };

            //Set start direction - easiest right
            byte currentDirection = right;

            //Print snake with the default coordinations
            foreach (Position item in snakeElements)
            {
                Console.SetCursorPosition(item.col, item.row);
                Console.Write("*");
            }

            while (true)
            {
                //Check if we are typed specific key
                if (Console.KeyAvailable)
                {
                    //We are typed any key => we have to keep this key in variable
                    ConsoleKeyInfo userKeyInput = Console.ReadKey();

                    //Now we check which is this key
                    if (userKeyInput.Key == ConsoleKey.RightArrow)
                    {
                        //Change position if only old position is not opposite of new position
                        if (currentDirection != left)
                            currentDirection = right;
                    }
                    else if (userKeyInput.Key == ConsoleKey.LeftArrow)
                    {
                        if (currentDirection != right)
                            currentDirection = left;
                    }
                    else if (userKeyInput.Key == ConsoleKey.DownArrow)
                    {
                        if (currentDirection != up)
                            currentDirection = down;
                    }
                    else if (userKeyInput.Key == ConsoleKey.UpArrow)
                    {
                        if (currentDirection != down)
                            currentDirection = up;
                    }
                }

                //Get current coordinatios of snake head
                Position snakeCurrentHead = snakeElements.Last();

                //Calculation coordinatios of next direction
                Position nextDirection = directions[currentDirection];

                //Calculation coordinatios of the new snake head
                Position snakeNewHead = new Position(
                    snakeCurrentHead.row + nextDirection.row,
                    snakeCurrentHead.col + nextDirection.col);

                //Check if snake kill yourself
                if (snakeElements.Contains(snakeNewHead) || rocks.Contains(snakeNewHead))
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("GAME OVER!" + "\n" + "Your points are {0}!", (snakeElements.Count - 5) * 100);

                    Console.SetCursorPosition(10, 11);
                    Console.WriteLine("Press [SPACE] for new game...");

                    Console.SetCursorPosition(0, Console.WindowHeight - 1);
                    ConsoleKeyInfo userKeyInput = Console.ReadKey();

                    if (userKeyInput.Key == ConsoleKey.Spacebar)
                    {
                        Console.ResetColor();
                        Console.Clear();
                        goto end;
                    }
                    else
                    {
                        Console.ResetColor();

                        Console.SetCursorPosition(0, Console.WindowHeight - 1);
                        return;
                    }
                }

                //Check if snake is got the food, if not clear last element
                if (snakeNewHead.row == food.row && snakeNewHead.col == food.col)
                {
                    Console.SetCursorPosition(food.col, food.row);
                    Console.Write(" ");

                    Console.Beep(80, 50);

                    do
                    {
                        food = new Position(
                            randomNumberGenerator.Next(1, Console.WindowHeight - 1),
                            randomNumberGenerator.Next(1, Console.WindowWidth - 1));
                        foodPushTime = Environment.TickCount;
                    }
                    while (snakeElements.Contains(food) || rocks.Contains(food));

                    //Print food on the Console
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(food.col, food.row);
                    Console.Write("@");
                    Console.ResetColor();

                    int fiftyFifty = randomNumberGenerator.Next(1, 3);

                    if (fiftyFifty == 1)
                    {
                        //Adding new rock
                        Position rockElement;

                        do
                        {
                            rockElement = new Position(randomNumberGenerator.Next(1, Console.WindowHeight - 1),
                                randomNumberGenerator.Next(1, Console.WindowWidth - 1));
                        }
                        while (snakeElements.Contains(rockElement) ||
                               (food.row == rockElement.row && food.col == rockElement.col));

                        rocks.Add(new Position(rockElement.row, rockElement.col));

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(rockElement.col, rockElement.row);
                        Console.Write("=");
                        Console.ResetColor();
                    }
                }
                else
                {
                    //Get and clear last element of snake
                    Position lastElement = snakeElements.Dequeue();
                    Console.SetCursorPosition(lastElement.col, lastElement.row);
                    Console.Write(" ");
                }

                //Check if coordinatios of new head are available
                if (snakeNewHead.row < 0)
                    snakeNewHead.row = Console.WindowHeight - 2;
                else if (snakeNewHead.row >= Console.WindowHeight - 1)
                    snakeNewHead.row = 0;
                else if (snakeNewHead.col < 0)
                    snakeNewHead.col = Console.WindowWidth - 2;
                else if (snakeNewHead.col >= Console.WindowWidth - 1)
                    snakeNewHead.col = 0;

                //Convert old head as a body
                Console.SetCursorPosition(snakeCurrentHead.col, snakeCurrentHead.row);
                Console.WriteLine("*");

                //Print head with a individual symbol
                snakeElements.Enqueue(snakeNewHead);
                Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                if (currentDirection == right)
                    Console.Write(">");
                else if (currentDirection == left)
                    Console.Write("<");
                else if (currentDirection == down)
                    Console.Write("V");
                else if (currentDirection == up)
                    Console.Write("^");

                if (Environment.TickCount - foodPushTime >= 6000)
                {
                    Console.SetCursorPosition(food.col, food.row);
                    Console.Write(" ");

                    do
                    {
                        food = new Position(
                            randomNumberGenerator.Next(1, Console.WindowHeight - 1),
                            randomNumberGenerator.Next(1, Console.WindowWidth - 1));
                        foodPushTime = Environment.TickCount;
                    }
                    while (snakeElements.Contains(food) || rocks.Contains(food));

                    int fiftyFifty = randomNumberGenerator.Next(1, 3);

                    if (fiftyFifty == 1)
                    {
                        //Adding new rock
                        Position rockElement;

                        do
                        {
                            rockElement = new Position(randomNumberGenerator.Next(1, Console.WindowHeight - 1),
                                randomNumberGenerator.Next(1, Console.WindowWidth - 1));
                        }
                        while (snakeElements.Contains(rockElement) ||
                               (food.row == rockElement.row && food.col == rockElement.col));

                        rocks.Add(new Position(rockElement.row, rockElement.col));

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(rockElement.col, rockElement.row);
                        Console.Write("=");
                        Console.ResetColor();
                    }
                }

                //Always show the food
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(food.col, food.row);
                Console.Write("@");
                Console.ResetColor();

                speedIncreaser = speedIncreaser - 0.025;
                Thread.Sleep((int)speedIncreaser);
            }
        }
    }
}