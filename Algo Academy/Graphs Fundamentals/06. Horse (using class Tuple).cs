using System;
using System.Collections.Generic;
using System.Linq;

class Horse
{
    static readonly int[] dirsX = { -1, 1, -2, -2, 2, 2, -1, 1 };
    static readonly int[] dirsY = { -2, -2, -1, 1, -1, 1, 2, 2 };

    static char[,] matrix;
    static Tuple<int, int, int> startPosition; // using more memory

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        matrix = new char[N, N];

        for (int i = 0; i < N; i++)
        {
            var input = Console.ReadLine();

            for (int j = 0, jj = 0; j < N; j++, jj += 2)
            {
                matrix[i, j] = input[jj];

                if (input[jj] == 's')
                    startPosition = new Tuple<int, int, int>(i, j, 0);
            }
        }

        var distance = FindMinimalDistanceBFS();

        Console.WriteLine(distance != -1 ? distance.ToString() : "-1"); // or No
    }

    static int FindMinimalDistanceBFS()
    {
        var queue = new Queue<Tuple<int, int, int>>();
        queue.Enqueue(startPosition);

        while (queue.Count > 0)
        {
            var currentCell = queue.Dequeue();

            for (int i = 0; i < dirsX.Length; i++)
            {
                var nextX = dirsX[i] + currentCell.Item1;
                var nextY = dirsY[i] + currentCell.Item2;

                if (nextX >= 0 && nextX < matrix.GetLongLength(0) &&
                    nextY >= 0 && nextY < matrix.GetLongLength(1))
                {
                    if (matrix[nextX, nextY] == 'e')
                        return currentCell.Item3 + 1;

                    if (matrix[nextX, nextY] == '-')
                    {
                        queue.Enqueue(new Tuple<int, int, int>(nextX, nextY, currentCell.Item3 + 1));

                        matrix[nextX, nextY] = 'x'; // Marked as visited
                    }
                }
            }
        }

        return -1;
    }
}