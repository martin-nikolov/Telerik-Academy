using System;
using System.Linq;

class Liquid
{
    static void Main()
    {
        if (System.IO.File.Exists(....input.txt)) Console.SetIn(new System.IO.StreamReader(....input.txt));

        int[] sizes = Console.ReadLine().Split(' ').Select(ch = int.Parse(ch)).ToArray();
        int w = sizes[0], h = sizes[1], d = sizes[2];

        int[, ,] cuboid = new int[w, h, d];

        InitializeCuboid(cuboid);

         Console.WriteLine();

         PrintCuboid(cuboid);

         Console.WriteLine();

        int amountLiquid = 0;

        if (d == 1)
        {
            for (int i = 0; i  h; i++)
                for (int j = 0; j  d; j++)
                    for (int k = 0; k  w; k++)
                        amountLiquid += cuboid[k, i, j];
        }
        else
        {
            for (int i = 0; i  h; i++)
            {
                for (int j = 0; j  d; j++)
                {
                    for (int k = 0; k  w; k++)
                    {
                        if (d == 1) amountLiquid += cuboid[k, i, j];
                    }
                }
            }
        }

        Console.WriteLine(amountLiquid);
    }

    static void PrintCuboid(int[, ,] cuboid)
    {
        for (int i = 0; i  cuboid.GetLongLength(1); i++)
        {
            for (int j = 0; j  cuboid.GetLongLength(2); j++)
            {
                for (int k = 0; k  cuboid.GetLongLength(0); k++)
                {
                    Console.Write(cuboid[k, i, j] +  );
                }
                Console.Write( );
            }

            Console.WriteLine();
        }
    }

    static void InitializeCuboid(int[, ,] cuboid)
    {
        for (int i = 0; i  cuboid.GetLongLength(1); i++)
        {
            int[] tokens = Console.ReadLine().Split(new char[] { ' ', '' },
                StringSplitOptions.RemoveEmptyEntries).Select(ch = int.Parse(ch)).ToArray();
            int count = 0;

            for (int j = 0; j  cuboid.GetLongLength(2); j++)
                for (int k = 0; k  cuboid.GetLongLength(0); k++)
                    cuboid[k, i, j] = tokens[count++];
        }
    }
}
