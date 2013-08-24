using System;
using System.Linq;

class Guitar
{
    static void Main()
    {
        int[] songs = Console.ReadLine().Split(',').Select(ch => int.Parse(ch)).ToArray();

        int B = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());

        bool[,] values = new bool[songs.Length, M + 1];

        CanChangeVolume(songs[0], B, M, values, 0);

        for (int i = 1; i < values.GetLongLength(0); i++)
            for (int j = 0; j < values.GetLongLength(1); j++)
                if (values[i - 1, j]) CanChangeVolume(songs[i], j, M, values, i);

        Console.WriteLine(GetMaximumVolume(values));
    }

    static int GetMaximumVolume(bool[,] values)
    {
        for (int col = (int)values.GetLongLength(1) - 1; col >= 0; col--)
            if (values[values.GetLongLength(0) - 1, col]) return col;

        return -1;
    }

    static void CanChangeVolume(int songVolume, int B, int M, bool[,] values, int indexRow)
    {
        int addition = B + songVolume, subtraction = B - songVolume;

        if (addition >= 0 && addition <= M) values[indexRow, addition] = true;
        if (subtraction >= 0 && subtraction <= M) values[indexRow, subtraction] = true;
    }
}