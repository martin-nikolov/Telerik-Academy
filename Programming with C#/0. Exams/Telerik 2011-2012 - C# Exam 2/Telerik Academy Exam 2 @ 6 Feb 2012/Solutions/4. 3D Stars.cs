using System;
using System.Linq;

class _3DStars
{
    static char[, ,] cuboid;
    static int[] stars = new int[26];

    static void Main()
    {
        var sizes = Console.ReadLine().Split(' ').Select(ch => int.Parse(ch)).ToArray();

        int w = sizes[0], h = sizes[1], d = sizes[2];

        cuboid = new char[w, h, d];

        InitializationCuboid(w, h, d);

        FindStars(w, h, d);

        if (stars != null)
        {
            Console.WriteLine(stars.Sum());
            for (int i = 0; i < stars.Length; i++)
                if (stars[i] != 0) Console.WriteLine("{0} {1}", (char)('A' + i), stars[i]);
        }
        else
        {
            Console.WriteLine(0);
        }
    }

    static void FindStars(int w, int h, int d)
    {
        if (d <= 2 || h <= 2 || w <= 2) stars = null;

        for (int i = 1; i < h - 1; i++)
        {
            for (int j = 1; j < d - 1; j++)
            {
                for (int k = 1; k < w - 1; k++)
                {
                    char star = cuboid[k, i, j];

                    if (cuboid[k - 1, i, j] == star && cuboid[k + 1, i, j] == star &&
                        cuboid[k, i - 1, j] == star && cuboid[k, i + 1, j] == star &&
                        cuboid[k, i, j - 1] == star && cuboid[k, i, j + 1] == star)
                    {
                        stars[star - 'A']++;
                    }
                }
            }
        }
    }

    static void InitializationCuboid(int w, int h, int d)
    {
        for (int i = 0; i < h; i++)
        {
            string elements = Console.ReadLine();

            for (int j = 0, count = 0; j < d; j++, count++)
                for (int k = 0; k < w; k++) cuboid[k, i, j] = elements[count++];
        }
    }
}