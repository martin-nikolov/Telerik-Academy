using System;
using System.Linq;

class Monster
{
    static int steps = 0;

    static void Main()
    {
        string nm = Console.ReadLine();
        string[] tokens = nm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int m = int.Parse(tokens[0]); // cols
        int n = int.Parse(tokens[1]); // rows

        int monsters = int.Parse(Console.ReadLine());
        int[,] coords = new int[monsters, 3];

        for (int i = 0; i < monsters; i++)
        {
            nm = Console.ReadLine();
            tokens = nm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            CalculateMoves(m, n, n - int.Parse(tokens[1]) + 1, int.Parse(tokens[0]), tokens[2]);
        }

        Console.WriteLine(steps);
    }

    static void CalculateMoves(int m, int n, int x, int y, string direction)
    {
        int currentDirection = 0;
        int[,] directions = 
        {
            { 0, 1 }, // East
            { 0, -1 }, // West
            { -1, 0 }, // North
            { 1, 0 }, // South
        };  

        switch (direction)
        {
            case "E": currentDirection = 0; break;
            case "W": currentDirection = 1; break;
            case "N": currentDirection = 2; break;
            case "S": currentDirection = 3; break;
        }

        while (true)
        {
            if (x == 0 || x == n + 1 || y == 0 || y == m + 1)
            {
                steps--;
                return;
            }

            steps++;
            x += directions[currentDirection, 0];
            y += directions[currentDirection, 1];
        }
    }
}
