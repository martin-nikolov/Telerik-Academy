using System;

class Sandglass
{
    const char AsterikSymbol = '*';
    const char PointSymbol = '.';

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int asteriksCount = N, pointsCount = 0;

        for (int i = 0; i < N / 2 + 1; i++, asteriksCount -= 2, pointsCount++)
        {
            Console.Write(new string(PointSymbol, pointsCount));
            Console.Write(new string(AsterikSymbol, asteriksCount));
            Console.WriteLine(new string(PointSymbol, pointsCount));
        }

        asteriksCount += 4;
        pointsCount -= 2;

        for (int i = 0; i < N / 2; i++, asteriksCount += 2, pointsCount--)
        {
            Console.Write(new string(PointSymbol, pointsCount));
            Console.Write(new string(AsterikSymbol, asteriksCount));
            Console.WriteLine(new string(PointSymbol, pointsCount));
        }
    }
}