namespace PathFinders.PathFinderStrategies
{
    using System;
    using System.Linq;

    public class DfsPathFinder : IPathFinder
    {
        private const string StartupSign = "*";
        private const string EmptySign = "0";
        private const string UnreachableSign = "u";

        public string[,] FindAllPaths(string[,] matrix)
        {
            var startupCell = this.GetStartupCell(matrix);

            var visitedCells = new AbstractDataStructures.Stack<Cell>(); // My implementation of Stack
            visitedCells.Push(startupCell);

            while (visitedCells.Count > 0)
            {
                var currentCell = visitedCells.Pop();
                int x = currentCell.X, y = currentCell.Y, nextValue = currentCell.Value + 1;

                this.TryVisitCell(visitedCells, matrix, new Cell(x, y + 1, nextValue));
                this.TryVisitCell(visitedCells, matrix, new Cell(x, y - 1, nextValue));
                this.TryVisitCell(visitedCells, matrix, new Cell(x + 1, y, nextValue));
                this.TryVisitCell(visitedCells, matrix, new Cell(x - 1, y, nextValue));
            }

            this.MarkInaccessibleCells(matrix);

            return matrix;
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

        private void TryVisitCell(AbstractDataStructures.Stack<Cell> visitedCells, string[,] matrix, Cell cell)
        {
            if (this.IsCellAccessible(matrix, cell))
            {
                visitedCells.Push(cell);
                matrix[cell.X, cell.Y] = cell.Value.ToString();
            }
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