using System;
using System.Linq;

class BatGoikoTower
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int pointsOutside = n - 1;
        int pointsInside = 0;

        for (int i = 0, j = 2, line = 1; i < n; i++)
        {
            Console.Write(new string('.', pointsOutside) + "/");
            Console.Write(new string((i != line) ? '.' : '-', pointsInside));
            Console.WriteLine("\\" + new string('.', pointsOutside));

            pointsOutside--; pointsInside += 2;
            if (i == line) line += j++;
        }
    }
}