using System;
using System.Linq;

class Lines
{
    static int bestLength = -1, bestCount = -1;
    static int width, height, depth;
    static char[, ,] cuboid;

    static int[] dirWidth = { -1, -1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1 };
    static int[] dirHeight = { 0, 1, 1, 0, 1, 1, 0, 0, 1, 1, -1, 1, -1 };
    static int[] dirDepth = { 1, 0, 0, 1, 1, -1, 0, 1, 1, 0, 1, -1, -1 };

    static void Main()
    {
        string[] tokens = Console.ReadLine().Split(' ');
        width = int.Parse(tokens[0]);
        height = int.Parse(tokens[1]);
        depth = int.Parse(tokens[2]);
        cuboid = new char[width, height, depth];

        InitializeCuboid();

        for (int h = 0; h < height; h++)
        {
            for (int d = 0; d < depth; d++)
            {
                for (int w = 0; w < width; w++)
                {
                    for (int dir = 0; dir < dirWidth.Length; dir++)
                    {
                        int _w = w, _h = h, _d = d;
                        char letter = cuboid[w, h, d];
                        int length = 1;

                        while (true)
                        {
                            _w += dirWidth[dir]; _h += dirHeight[dir]; _d += dirDepth[dir];

                            if (_w < 0 || _w >= width || _h < 0 || _h >= height || _d < 0 || _d >= depth) break;

                            if (cuboid[_w, _h, _d] != letter) break;

                            length++;
                        }

                        if (length > bestLength)
                        {
                            bestLength = length;
                            bestCount = 1;
                        }
                        else if (length == bestLength)
                        {
                            bestCount++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(bestLength > 1 ? string.Format("{0} {1}", bestLength, bestCount) : "-1");
    }

    static void InitializeCuboid()
    {
        for (int h = 0; h < height; h++)
        {
            string line = Console.ReadLine();
            int count = 0;

            for (int d = 0; d < depth; d++)
            {
                for (int w = 0; w < width; w++) cuboid[w, h, d] = line[count++];
                count++;
            }
        }
    }
}