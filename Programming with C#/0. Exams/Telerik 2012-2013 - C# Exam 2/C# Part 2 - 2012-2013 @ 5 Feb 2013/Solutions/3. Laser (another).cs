using System;
using System.Linq;
using System.Collections.Generic;

class Laser
{
    static bool[, ,] visited;

    static void Main()
    {
        int[] cuboidSizes = Console.ReadLine().Split(' ').Select(ch => int.Parse(ch)).ToArray();
        int[] laserCoords = Console.ReadLine().Split(' ').Select(ch => int.Parse(ch)).ToArray();
        int[] directions = Console.ReadLine().Split(' ').Select(ch => int.Parse(ch)).ToArray();

        visited = new bool[cuboidSizes[0] + 1, cuboidSizes[1] + 1, cuboidSizes[2] + 1];
        visited[laserCoords[0], laserCoords[1], laserCoords[2]] = true;

        for (int W = 1; W <= cuboidSizes[0]; W++)
            for (int H = 1; H <= cuboidSizes[1]; H++)
                for (int D = 1; D <= cuboidSizes[2]; D++)
                    if ((W == 1 || W == cuboidSizes[0]) && (H == 1 || H == cuboidSizes[1] || D == 1 || D == cuboidSizes[2])) visited[W, H, D] = true;

        while (true)
        {
            for (int i = 0; i < laserCoords.Length; i++) laserCoords[i] += directions[i];

            if (visited[laserCoords[0], laserCoords[1], laserCoords[2]])
            {
                Console.WriteLine("{0} {1} {2}", laserCoords[0] - directions[0], laserCoords[1] - directions[1], laserCoords[2] - directions[2]);
                break;
            }

            if (laserCoords[0] <= 1) directions[0] = 1;
            else if (laserCoords[0] >= cuboidSizes[0]) directions[0] = -1;

            if (laserCoords[1] <= 1) directions[1] = 1;
            else if (laserCoords[1] >= cuboidSizes[1]) directions[1] = -1;

            if (laserCoords[2] <= 1) directions[2] = 1;
            else if (laserCoords[2] >= cuboidSizes[2]) directions[2] = -1;

            visited[laserCoords[0], laserCoords[1], laserCoords[2]] = true;
        }
    }
}