using System;
using System.Collections.Generic;
using System.Linq;

public class ThreeDLabyrinth
{
    private static char[,,] labyrinth;

    private const char ImpassableCellSymbol = '#';
    private const char UpperLevelCellSymbol = 'U';// X + 1
    private const char LowerLevelCellSymbol = 'D';// X - 1

    internal static void Main()
    {
        var initialCoords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var matrixSizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int x = matrixSizes[0], y = matrixSizes[1], z = matrixSizes[2];

        labyrinth = new char[x, y, z];
        for (int xx = 0; xx < x; xx++)
        {
            for (int yy = 0; yy < y; yy++)
            {
                var line = Console.ReadLine();

                for (int zz = 0; zz < z; zz++)
                {
                    labyrinth[xx, yy, zz] = line[zz];
                }
            }
        }

        var shortestPath = FindShortestPath(initialCoords, z, y, x);
        Console.WriteLine(shortestPath);
    }
 
    private static int FindShortestPath(int[] initialCoords, int z, int y, int x)
    {
        var queue = new Queue<Cell>();
        queue.Enqueue(new Cell(initialCoords[0], initialCoords[1], initialCoords[2]));

        while (queue.Count > 0)
        {
            var cell = queue.Dequeue();

            // Left
            if (cell.Z - 1 >= 0 && labyrinth[cell.X, cell.Y, cell.Z - 1] != ImpassableCellSymbol)
            {
                var newCell = new Cell(cell.X, cell.Y, cell.Z - 1, cell.Level + 1);
                queue.Enqueue(newCell);
            }

            // Right
            if (cell.Z + 1 < z && labyrinth[cell.X, cell.Y, cell.Z + 1] != ImpassableCellSymbol)
            {
                var newCell = new Cell(cell.X, cell.Y, cell.Z + 1, cell.Level + 1);
                queue.Enqueue(newCell);
            }

            // Forward
            if (cell.Y - 1 >= 0 && labyrinth[cell.X, cell.Y - 1, cell.Z] != ImpassableCellSymbol)
            {
                var newCell = new Cell(cell.X, cell.Y - 1, cell.Z, cell.Level + 1);
                queue.Enqueue(newCell);
            }

            // Back
            if (cell.Y + 1 < y && labyrinth[cell.X, cell.Y + 1, cell.Z] != ImpassableCellSymbol)
            {
                var newCell = new Cell(cell.X, cell.Y + 1, cell.Z, cell.Level + 1);
                queue.Enqueue(newCell);
            }

            // Up
            if (labyrinth[cell.X, cell.Y, cell.Z] == UpperLevelCellSymbol)
            {
                var newCell = new Cell(cell.X + 1, cell.Y, cell.Z, cell.Level + 1);
                if (newCell.X >= x)
                {
                    return newCell.Level;
                }
                else if (newCell.X < x && labyrinth[newCell.X, newCell.Y, newCell.Z] != ImpassableCellSymbol)
                {
                    queue.Enqueue(newCell);
                }
            }

            // Down
            if (labyrinth[cell.X, cell.Y, cell.Z] == LowerLevelCellSymbol)
            {
                var newCell = new Cell(cell.X - 1, cell.Y, cell.Z, cell.Level + 1);
                if (newCell.X < 0)
                {
                    return newCell.Level;
                }
                else if (newCell.X >= 0 && labyrinth[newCell.X, newCell.Y, newCell.Z] != ImpassableCellSymbol)
                {
                    queue.Enqueue(newCell);
                }
            }

            MarkCellAsVisited(cell);
        }

        return 0;
    }
 
    private static void MarkCellAsVisited(Cell cellCoords)
    {
        labyrinth[cellCoords.X, cellCoords.Y, cellCoords.Z] = ImpassableCellSymbol;
    }

    public struct Cell
    {
        public Cell(int x, int y, int z, int level = 0)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Level = level;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public int Level { get; set; }
    }
}