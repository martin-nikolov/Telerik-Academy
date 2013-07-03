using System;

class Trapezoid
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        byte pointLeft = n;
        byte pointsRight = 0;

        Console.WriteLine(new string('.', pointLeft) + new string('*', n));

        for (int i = 0; i < n - 1; i++)
        {
            pointLeft--;
            pointsRight = (byte)(n * 2 - pointLeft - 2);

            Console.WriteLine(new string('.', pointLeft) + '*' + new string('.', pointsRight) + '*');
        }

        Console.WriteLine(new string('*', n * 2));
    }
}