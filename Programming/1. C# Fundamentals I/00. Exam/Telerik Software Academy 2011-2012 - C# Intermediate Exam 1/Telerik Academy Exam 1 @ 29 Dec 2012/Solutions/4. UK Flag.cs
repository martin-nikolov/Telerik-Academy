using System;
using System.Linq;

class UkFlag
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
      
        int pointsOutside = 0;
        int pointsInside = (n - 3) / 2;

        for (int row = 0; row <= n; row++)
        {
            if (row < n / 2)
            {
                Console.Write(new string('.', pointsOutside) + "\\");
                Console.Write(new string('.', pointsInside) + "|" + new string('.', pointsInside));
                Console.Write("/" + new string('.', pointsOutside));
                Console.WriteLine();

                pointsInside--;
                pointsOutside++;
            }
            else if (row == n / 2 + 1)
            {
                pointsInside++;
                pointsOutside--;
                Console.WriteLine(new string('-',n / 2) + "*" + new string('-',n / 2));
            }
            else if (row > n / 2)
            {
                Console.Write(new string('.', pointsOutside) + "/");
                Console.Write(new string('.', pointsInside) + "|" + new string('.', pointsInside));
                Console.Write("\\" + new string('.', pointsOutside));
                Console.WriteLine();
                pointsInside++;
                pointsOutside--;
            }
        }
    }
}