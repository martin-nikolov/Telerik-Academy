using System;
using System.Linq;

class KukataIsDancing
{
    static int[,] directions = 
    {
        { -1, 0 },
        { 0, 1 },
        { 1, 0 },
        { 0, -1 }
    };

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string path = Console.ReadLine();

            ShowColorAfterDancing(path);
        }
    }

    static void ShowColorAfterDancing(string path)
    {
        int dir = 0, row = 1, col = 1;

        for (int i = 0; i < path.Length; i++)
        {
            switch (path[i])
            {
                case 'R': dir = (dir + 1) % 4; break;
                case 'L': dir = (dir + 3) % 4; break;
                case 'W': row += directions[dir, 0];
                    col += directions[dir, 1]; break;
            }

            if (row < 0) row = 2;
            else if (row > 2) row = 0;

            if (col < 0) col = 2;
            else if (col > 2) col = 0;
        }

        if (row == 1 && col == 1)
        {
            Console.WriteLine("GREEN");
        }
        else if (row == col || (row == 2 && col == 0) || (row == 0 && col == 2))
        {
            Console.WriteLine("RED");
        }
        else
        {
            Console.WriteLine("BLUE");
        }
    }
}