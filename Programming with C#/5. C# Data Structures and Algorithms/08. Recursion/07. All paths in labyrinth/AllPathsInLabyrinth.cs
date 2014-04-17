/*
 * 7. We are given a matrix of passable and non-passable cells. 
 * Write a recursive program for finding all paths between two cells in the matrix.
 */

using System;
using System.Linq;

class AllPathsInLabyrinth
{
    static readonly char[,] labyrinth =
    {
        { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
        { '*', '*', ' ', '*', ' ', '*', ' ' },
        { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
        { ' ', '*', '*', '*', '*', '*', ' ' },
        { ' ', ' ', ' ', ' ', ' ', ' ', 'e' },
    };

    static readonly char[] directions = new char[labyrinth.GetLongLength(0) * labyrinth.GetLongLength(1)];

    static int pathsCount = 0;

    const char PassableCell = ' ';
    const char NonPassableCell = '*';
    const char FinalCell = 'e';

    static void Main()
    {
        FindAllPaths(0, 0);

        Console.WriteLine("\nTotal paths: {0}\n", pathsCount);
    }

    static void FindAllPaths(int row, int col, int currentLength = 1, char dir = ' ')
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

    static bool IsCellPassable(int row, int col)
    {
        return row >= 0 && row < labyrinth.GetLongLength(0) &&
               col >= 0 && col < labyrinth.GetLongLength(1) &&
               labyrinth[row, col] != NonPassableCell;
    }

    static void PrintPath(int currentLength)
    {
        Console.Write("Path #{0} -> cells length: {1} -> Direction: ", ++pathsCount, currentLength);

        for (int i = 1; i < currentLength; i++)
            Console.Write(directions[i] + " ");

        Console.WriteLine();
    }
}