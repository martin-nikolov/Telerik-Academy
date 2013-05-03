using System;
 
class LabyrinthGame
{
    static void Main()
    {
        // Declare and assign variables
        int labyrinthSizeY = 32; // This is size for Y of massive
        int labyrinthSizeX = 28; // This is size for X of massive
        int torchLight = 100;    // This is power of torch
        char w = '\u2588';       // This is wall char
        char heroChar = '@';     // This is hero char
        char e = 'O';            // This is exit char
        int x = 15;              // And this is
        int y = 17;              // coordinates of start point
        int xModifier = 0;
        int yModifier = 0;
        int moveCount = 0;
        bool checkInput = false;
 
        char[,] labyrinthMask = // This is massive mask of labyrinth: get more from : http://www.noah.org/cgi-bin/brainmaze.py - view source, and after litle edit with notepad++ you can create mask massive!
        {
            { w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w },
            { w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w },
            { w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ', w ,' ', w ,' ', w ,' ', w , w ,' ', w , w },
            { w ,' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ', w ,' ', w ,' ', w ,' ',' ',' ', w },
            { w , w , w ,' ', w ,' ', w , w , w ,' ', w , w , w , w , w ,' ', w , w , w , w , w ,' ', w , w , w , w , w ,' ', w },
            { w ,' ',' ',' ',' ',' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ', w ,' ',' ',' ',' ',' ', w ,' ',' ',' ', w },
            { w , w , w ,' ', w , w ,' ', w , w , w ,' ', w , w ,' ', w , w , w ,' ',' ',' ', w , w ,' ', w , w , w ,' ', w , w },
            { w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ', w },
            { w ,' ', w , w , w ,' ', w , w , w , w , w , w , w , w , w , w , w , w , w ,' ', w , w , w , w , w , w , w , w , w },
            { w ,' ', w ,' ', w ,' ',' ',' ',' ',' ',' ',' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ', w },
            { w ,' ',' ',' ', w , w , w ,' ', w , w , w ,' ', w ,' ', w ,' ', w ,' ',' ',' ', w , w , w ,' ', w , w ,' ', w , w },
            { w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ', w ,' ', w ,' ',' ',' ',' ',' ',' ',' ', w },
            { w ,' ', w , w , w ,' ', w , w , w , w , w ,' ',' ',' ', w , w , w , w , w , w , w , w , w , w , w ,' ', w , w , w },
            { w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w ,' ',' ',' ', w },
            { w ,' ', w ,' ', w ,' ', w ,' ', w , w , w ,' ', w ,' ', w , w , w , w ,' ', w , w ,' ', w ,' ', w , w ,' ', w , w },
            { w ,' ',' ',' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w ,' ', w ,' ',' ',' ',' ',' ', w },
            { w , w , w , w , w , w , w , w , w ,' ', w , w , w , w , w , w , w , w , w , w , w ,' ', w , w , w , w , w , w , w },
            { w ,' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w ,' ',' ',' ',' ',' ', w ,' ', w ,' ',' ',' ',' ',' ',' ',' ', w },
            { w , w ,' ', w , w , w ,' ', w , w , w ,' ', w , w , w ,' ', w , w ,' ',' ',' ', w , w ,' ', w , w ,' ', w , w , w },
            { w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ', w },
            { w , w , w ,' ', w , w , w , w , w ,' ', w , w , w , w , w ,' ', w , w , w , w , w , w ,' ', w , w , w , w , w , w },
            { w ,' ',' ',' ', w ,' ',' ',' ',' ',' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w ,' ',' ',' ', w },
            { w ,' ', w , w , w , w , w ,' ', w ,' ', w ,' ', w , w , w ,' ', w , w ,' ', w , w , w ,' ', w , w ,' ', w , w , w },
            { w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w },
            { w , w , w , w , w , w , w , w , w ,' ', w , w , w , w , w , w , w , w , w , w , w , w , w ,' ', w , w , w , w , w },
            { w ,' ', w ,' ', w ,' ', w ,' ',' ',' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ', w ,' ', w ,' ',' ',' ', w },
            { w ,' ', w ,' ',' ',' ', w ,' ', w , w ,' ', w , w , w ,' ', w , w , w ,' ', w , w ,' ', w ,' ', w , w ,' ', w , w },
            { w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ',' ',' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w },
            { w ,' ', w , w , w , w , w ,' ', w , w , w , w , w , w , w , w , w , w , w ,' ', w ,' ', w , w , w , w , w ,' ', w },
            { w ,' ',' ',' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ',' ',' ', w ,' ',' ',' ', w },
            { w ,' ', w , w , w ,' ', w ,' ',' ',' ', w ,' ', w ,' ',' ',' ',' ',' ',' ',' ', w , w , w ,' ', w ,' ', w ,' ', w },
            { w ,' ',' ',' ', w ,' ',' ',' ', w ,' ',' ',' ', w ,' ', w ,' ', w ,' ', w ,' ', w ,' ',' ',' ',' ',' ', w ,' ', w },
            { w , e , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w , w }
        };
 
        // Prepare console
        Console.SetWindowSize(labyrinthSizeX + 1, labyrinthSizeY + 10);
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
       
        // This is for my pleasure ;)
        Console.Clear();
        Console.SetCursorPosition(((labyrinthSizeX + 1) / 2 - 13) , (labyrinthSizeY + 10) / 2);
        Console.WriteLine("Stoyanov Games Present...");
        Console.ReadKey();
        Console.Clear();
        Console.SetCursorPosition(((labyrinthSizeX + 1) / 2 - 8), (labyrinthSizeY + 10) / 2);
        Console.WriteLine("The LaByRiNtH");
        Console.ReadKey();
 
 
        //Prepare game
        while (!checkInput)
        {
            Console.Clear();
            Console.SetCursorPosition(0, (labyrinthSizeY + 2) / 2);
            Console.Write("Select power of your  torch\n(level difficulty from\n1 hard to 5 easy): ");
            checkInput = int.TryParse(Console.ReadLine(), out torchLight) && torchLight > 0 && torchLight < 6;
        }
 
        Console.SetCursorPosition(x, y);
       
        // Game cycle
        while (true)
        {
            // Here make and print console output - every frame.
            Console.Clear();
            for (int a = -torchLight; a <= torchLight; a++)
            {
                for (int b = -torchLight; b <= torchLight; b++)
                {
                    if (x + a < 0 || y + b < 0 || x + a > labyrinthSizeX || y + b > labyrinthSizeY)
                    {
                        continue;
                    }
                    Console.SetCursorPosition(x + a, y + b);
                    Console.WriteLine((a == 0 && b == 0) ? heroChar : labyrinthMask[y + b, x + a]);
                }
            }
 
            // Here prepare control and take it from keyboard.
            xModifier = 0;
            yModifier = 0;
            Console.SetCursorPosition(0, labyrinthSizeX + 6);
            Console.WriteLine("x {0} - y {1}     moves: {2}", x, y, moveCount);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    xModifier = -1;
                    break;
                case ConsoleKey.RightArrow:
                    xModifier = 1;
                    break;
                case ConsoleKey.UpArrow:
                    yModifier = -1;
                    break;
                case ConsoleKey.DownArrow:
                    yModifier = 1;
                    break;
            }
 
            // Counting moves.
            moveCount++;
 
            // Modify position and check status.
            if (labyrinthMask[y + yModifier, x + xModifier] == 'O')
            {
                break; // Welldone you find exit..
            }
            if (labyrinthMask[y + yModifier, x + xModifier] == ' ' && labyrinthMask[y + yModifier, x + xModifier] != e)
            {
                x = x + xModifier;
                y = y + yModifier;
            }
            else
            {
                Console.Beep(); // Hit wall or... exit :)
            }
            // fixed bug with hold key for long time v1.2 - by Георги.Иванов
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
        }
        // Print result
        Console.WriteLine("\nWelldone,\n You went through the maze\n for {0} moves!", moveCount);
    }
}