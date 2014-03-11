namespace PathFinders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    static class BfsPathFinder
    {
        private const string StartupSign = "*";
        private const string EmptySign = "0";
        private const string UnreachableSign = "u";

        public static string[,] FindAllPaths(string[,] matrix)
        {
            var startupCell = GetStartupCell(matrix);

            var visitedCells = new Queue<Cell>();
            visitedCells.Enqueue(startupCell);

            while (visitedCells.Count > 0)
            {
                var currentCell = visitedCells.Dequeue();
                int x = currentCell.X, y = currentCell.Y, nextValue = currentCell.Value + 1;

                TryVisitCell(visitedCells, matrix, new Cell(x, y + 1, nextValue));
                TryVisitCell(visitedCells, matrix, new Cell(x, y - 1, nextValue));
                TryVisitCell(visitedCells, matrix, new Cell(x + 1, y, nextValue));
                TryVisitCell(visitedCells, matrix, new Cell(x - 1, y, nextValue));
            }

            MarkInaccessibleCells(matrix);

            return matrix;
        }

        private static Cell GetStartupCell(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    if (matrix[i, j].CompareTo(StartupSign) == 0)
                    {
                        return new Cell(i, j, 0);
                    }
                }
            }

            throw new ArgumentOutOfRangeException("There is no startup cell...");
        }

        private static void TryVisitCell(Queue<Cell> visitedCells, string[,] matrix, Cell cell)
        {
            if (IsCellAccessible(matrix, cell))
            {
                visitedCells.Enqueue(cell);
                matrix[cell.X, cell.Y] = cell.Value.ToString();
            }
        }

        private static bool IsCellAccessible(string[,] matrix, Cell cell)
        { 
            long rows = matrix.GetLongLength(0), cols = matrix.GetLongLength(1);
            int row = cell.X, col = cell.Y;

            if (row < 0 || row >= rows ||
                col < 0 || col >= cols ||
                matrix[row, col] != EmptySign)
            {
                return false;
            }

            return true;
        }

        private static void MarkInaccessibleCells(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    if (matrix[i, j].CompareTo(EmptySign) == 0)
                    {
                        matrix[i, j] = UnreachableSign;
                    }
                }
            }
        }
    }
}