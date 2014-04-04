using System;
using System.Collections.Generic;
using System.Linq;

class Horse
{
    static readonly int[] dirsX = { -1, 1, -2, -2, 2, 2, -1, 1 };
    static readonly int[] dirsY = { -2, -2, -1, 1, -1, 1, 2, 2 };

    static char[,] matrix;
    static Cell startPosition;

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
                    startPosition = new Cell(i, j, 0);
            }
        }

        var distance = FindMinimalDistanceBFS();

        Console.WriteLine(distance != -1 ? distance.ToString() : "-1"); // or No
    }

    static int FindMinimalDistanceBFS()
    {
        var queue = new Queue<Cell>();
        queue.Enqueue(startPosition);

        while (queue.Count > 0)
        {
            var currentCell = queue.Dequeue();

            for (int i = 0; i < dirsX.Length; i++)
            {
                var nextX = dirsX[i] + currentCell.X;
                var nextY = dirsY[i] + currentCell.Y;

                if (nextX >= 0 && nextX < matrix.GetLongLength(0) &&
                    nextY >= 0 && nextY < matrix.GetLongLength(1))
                {
                    if (matrix[nextX, nextY] == 'e')
                        return currentCell.Distance + 1;

                    if (matrix[nextX, nextY] == '-')
                    {
                        queue.Enqueue(new Cell(nextX, nextY, currentCell.Distance + 1));

                        matrix[nextX, nextY] = 'x'; // Marked as visited
                    }
                }
            }
        }

        return -1;
    }

    struct Cell
    {
        public Cell(int x, int y, int distance)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Distance = distance;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Distance { get; set; }
    }
}