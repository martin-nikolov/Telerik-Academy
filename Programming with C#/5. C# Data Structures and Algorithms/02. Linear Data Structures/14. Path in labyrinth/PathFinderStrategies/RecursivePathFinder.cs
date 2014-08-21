namespace PathFinders.PathFinderStrategies
{
    using System;
    using System.Linq;
    using PathFinders;

    public class RecursivePathFinder : IPathFinder
    {
        private const string StartupSign = "*";
        private const string EmptySign = "0";
        private const string UnreachableSign = "u";

        public string[,] FindAllPaths(string[,] matrix)
        {
            var startupCell = this.GetStartupCell(matrix);

            this.FindPathsRecursively(matrix, startupCell);
            this.MarkInaccessibleCells(matrix);

            return matrix;
        }

        private void FindPathsRecursively(string[,] matrix, Cell cell)
        {
            var currentCell = cell;
            int x = currentCell.X, y = currentCell.Y, nextValue = currentCell.Value + 1;

            // Bottom of recursion
            if (!this.TryVisitCell(matrix, currentCell) && currentCell.Value != 0)
            {
                return;
            }

            this.FindPathsRecursively(matrix, new Cell(x + 1, y, nextValue));
            this.FindPathsRecursively(matrix, new Cell(x - 1, y, nextValue));
            this.FindPathsRecursively(matrix, new Cell(x, y + 1, nextValue));
            this.FindPathsRecursively(matrix, new Cell(x, y - 1, nextValue));
        }

        private Cell GetStartupCell(string[,] matrix)
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

        private bool TryVisitCell(string[,] matrix, Cell cell)
        {
            if (this.IsCellAccessible(matrix, cell))
            {
                matrix[cell.X, cell.Y] = cell.Value.ToString();
                return true;
            }

            return false;
        }

        private bool IsCellAccessible(string[,] matrix, Cell cell)
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

        private void MarkInaccessibleCells(string[,] matrix)
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