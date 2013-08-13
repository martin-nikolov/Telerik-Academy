using System;
using System.Linq;

class _3DMaxWalk
{
    static void Main()
    {
        int[] sizes = Console.ReadLine().Split(' ').Select(ch => int.Parse(ch)).ToArray();
        int w = sizes[0], h = sizes[1], d = sizes[2];

        int[, ,] cuboid = new int[w, h, d];
        bool[, ,] visited = new bool[w, h, d];

        InitializeCuboid(cuboid);

        int _w = (w - 1) / 2;
        int _h = (h - 1) / 2;
        int _d = (d - 1) / 2;

        visited[_w, _h, _d] = true;

        int sum = cuboid[_w, _h, _d];
        bool single = true;

        while (true)
        {
            int nextNumber = -1001;
            int w1 = 0, h1 = 0, d1 = 0;

            // Check horizontal (width)
            for (int i = 0; i < w; i++)
            {
                if (i == _w) continue;

                if (cuboid[i, _h, _d] > nextNumber)
                {
                    w1 = i; h1 = _h; d1 = _d; // new (next) coords
                    nextNumber = cuboid[i, _h, _d];
                    single = true;
                }
                else if (cuboid[i, _h, _d] == nextNumber) single = false;
            }

            // Check vertical (height)
            for (int i = 0; i < h; i++)
            {
                if (i == _h) continue;

                if (cuboid[_w, i, _d] > nextNumber)
                {
                    w1 = _w; h1 = i; d1 = _d; // new (next) coords
                    nextNumber = cuboid[_w, i, _d];
                    single = true;
                }
                else if (cuboid[_w, i, _d] == nextNumber) single = false;
            }

            // Check depth
            for (int i = 0; i < d; i++)
            {
                if (i == _d) continue;

                if (cuboid[_w, _h, i] > nextNumber)
                {
                    w1 = _w; h1 = _h; d1 = i; // new (next) coords
                    nextNumber = cuboid[_w, _h, i];
                    single = true;
                }
                else if (cuboid[_w, _h, i] == nextNumber) single = false;
            }

            if (!single || visited[w1, h1, d1]) break;

            sum += nextNumber;
            _w = w1; _h = h1; _d = d1;
            visited[w1, h1, d1] = true;
        }

        Console.WriteLine(sum);
    }

    static void InitializeCuboid(int[, ,] cuboid)
    {
        for (int i = 0; i < cuboid.GetLongLength(1); i++)
        {
            int[] tokens = Console.ReadLine().Split(new char[] { ' ', '|' },
                StringSplitOptions.RemoveEmptyEntries).Select(ch => int.Parse(ch)).ToArray();
            int count = 0;

            for (int j = 0; j < cuboid.GetLongLength(2); j++)
                for (int k = 0; k < cuboid.GetLongLength(0); k++)
                    cuboid[k, i, j] = tokens[count++];
        }
    }
}
