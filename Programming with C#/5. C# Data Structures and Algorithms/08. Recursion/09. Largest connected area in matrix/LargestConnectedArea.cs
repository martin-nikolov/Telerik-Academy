/*
 * 9. Write a recursive program to find the largest connected
 * area of adjacent empty cells in a matrix.
 */

using System;
using System.Linq;

class LargestConnectedArea
{
    // Passable cell is marked with "x"
    static readonly string[,] matrix =
    {
        { "1", "x", "2", "2", "2", "x" },
        { "x", "x", "x", "2", "4", "x" },
        { "4", "x", "1", "2", "x", "x" },
        { "4", "x", "1", "2", "x", "1" },
        { "4", "x", "1", "x", "x", "x" }
    };

    const string VisitedCell = "";
    const string PassableCell = "x";

    static void Main()
    {
        PrintMatrix();

        var bestLength = FindLargestConnectedArea();

        Console.WriteLine("\nBest area: {0}\n",
            bestLength != 0 ? string.Format("{0} -> {1} time(s).", PassableCell, bestLength) : "There is no best area.");
    }

    static int FindLargestConnectedArea()
    {
        int bestLength = int.MinValue;

        for (int i = 0; i < matrix.GetLongLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLongLength(1); j++)
            {
                var currentLength = 0;
              
                FindAreaDFS(i, j, ref currentLength);

                if (currentLength > bestLength)
                    bestLength = currentLength;
            }
        }

        return bestLength;
    }

    static void FindAreaDFS(int row, int col, ref int currentLength)
    {
        // Check for Non-passable cell
        if (row < 0 || row >= matrix.GetLongLength(0) ||
            col < 0 || col >= matrix.GetLongLength(1) || matrix[row, col] != PassableCell)
        {
            return;
        }

        currentLength++;
        matrix[row, col] = VisitedCell; // Marks as visited

        FindAreaDFS(row, col - 1, ref currentLength);
        FindAreaDFS(row, col + 1, ref currentLength);
        FindAreaDFS(row - 1, col, ref currentLength);
        FindAreaDFS(row + 1, col, ref currentLength);
    }

    static void PrintMatrix()
    {
        for (int i = 0; i < matrix.GetLongLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLongLength(1); j++)
                Console.Write("{0,-3}", matrix[i, j]);

            Console.WriteLine();
        }
    }
}