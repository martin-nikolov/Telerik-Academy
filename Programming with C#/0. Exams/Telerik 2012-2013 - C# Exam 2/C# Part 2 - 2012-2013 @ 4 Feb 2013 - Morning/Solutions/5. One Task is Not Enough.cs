using System;
using System.Linq;

class OneTaskIsNotEnough
{
    static void Main()
    {
        Console.WriteLine(FindNumberOfLastLamp(int.Parse(Console.ReadLine())));
        Console.WriteLine(WillLeaveCircle(Console.ReadLine()));
        Console.WriteLine(WillLeaveCircle(Console.ReadLine()));
    }

    // First task
    static int FindNumberOfLastLamp(int lampCount)
    {
        int[] turnedOn = new int[lampCount];

        for (int i = 0; i < lampCount; i++) turnedOn[i] = i + 1;

        int jump = 2;

        while (lampCount > 1)
        {
            for (int i = 0; i < lampCount; i += jump) turnedOn[i] = 0;

            int index = 0;

            for (int i = 0; i < lampCount; i++)
                if (turnedOn[i] != 0) turnedOn[index++] = turnedOn[i];

            lampCount = index;

            jump++;
        }

        return turnedOn[0];
    }

    // Second task
    static string WillLeaveCircle(string path)
    {
        int[,] directions = 
        {
            { 0, 1 },
            { 1, 0 },
            { 0, -1 },
            { -1, 0 },
        };

        int dir = 0, row = 0, col = 0;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < path.Length; j++)
            {
                switch (path[j])
                {
                    case 'S':
                        row += directions[dir, 0];
                        col += directions[dir, 1];
                        break;
                    case 'L': dir = (dir + 3) % 4; break;
                    case 'R': dir = (dir + 1) % 4; break;
                    default: break;
                }
            }
        }

        if (row == 0 && col == 0) return "bounded";
        else return "unbounded";
    }
}