/*
 * 7. We are given a matrix of passable and non-passable cells. 
 * Write a recursive program for finding all paths between two cells in the matrix.
 */

namespace Algorithms
{
    using System;

    public class AllPathsInLabyrinth
    {
        private static readonly char[,] labyrinth =
        {
            { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
            { '*', '*', ' ', '*', ' ', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', '*', '*', '*', '*', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', 'e' },
        };

        private static readonly char[] directions = new char[labyrinth.GetLongLength(0) * labyrinth.GetLongLength(1)];
        private static int pathsCount = 0;
        private const char PassableCell = ' ';
        private const char NonPassableCell = '*';
        private const char FinalCell = 'e';

        public static void Main()
        {
            FindAllPaths(0, 0);

            Console.WriteLine("\nTotal paths: {0}\n", pathsCount);
        }

        private static void FindAllPaths(int row, int col, int currentLength = 1, char dir = ' ')
        {
            if (!IsCellPassable(row, col))
            {
                return;
            }

            if (labyrinth[row, col] == FinalCell)
            {
                PrintPath(currentLength);
                return;
            }

            directions[currentLength - 1] = dir;
            labyrinth[row, col] = NonPassableCell;

            FindAllPaths(row - 1, col, currentLength + 1, 'U');  // Up
            FindAllPaths(row + 1, col, currentLength + 1, 'D');  // Down
            FindAllPaths(row, col - 1, currentLength + 1, 'L');  // Left
            FindAllPaths(row, col + 1, currentLength + 1, 'R');  // Right

            directions[currentLength - 1] = ' ';
            labyrinth[row, col] = PassableCell;
        }

        private static bool IsCellPassable(int row, int col)
        {
            return row >= 0 && row < labyrinth.GetLongLength(0) &&
                   col >= 0 && col < labyrinth.GetLongLength(1) &&
                   labyrinth[row, col] != NonPassableCell;
        }

        private static void PrintPath(int currentLength)
        {
            Console.Write("Path #{0} -> cells length: {1} -> Direction: ", ++pathsCount, currentLength);

            for (int i = 1; i < currentLength; i++)
            {
                Console.Write(directions[i] + " ");
            }

            Console.WriteLine();
        }
    }
}