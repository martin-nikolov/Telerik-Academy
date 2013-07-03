/*
* 1. Write a program that fills and prints a matrix of size (n, n) as shown below:
* (examples for n = 4)
* 
* 1 12 11 10
* 2 13 16  9
* 3 14 15  8
* 4  5  6  7
* 
*/

using System;
using System.Linq;

class MatrixD
{
    static int[,] matrix;

    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        matrix = new int[n, n];
        string direction = "down";
        int row = -1, col = 0;

        for (int count = 1; count <= n * n; count++)
        {
            if (direction == "down")
            {
                if (matrix[++row, col] == 0) matrix[row, col] = count;
                if (!IsTraversable(row + 1, col)) direction = "right";
            }
            else if (direction == "right")
            {
                if (matrix[row, ++col] == 0) matrix[row, col] = count;
                if (!IsTraversable(row, col + 1)) direction = "up";
            }
            else if (direction == "up")
            {
                if (matrix[--row, col] == 0) matrix[row, col] = count;
                if (!IsTraversable(row - 1, col)) direction = "left";
            }
            else if (direction == "left")
            {
                if (matrix[row, --col] == 0) matrix[row, col] = count;
                if (!IsTraversable(row, col - 1)) direction = "down";
            }
        }

        // Prints matrix
        Console.WriteLine();
        for (row = 0; row < n; row++)
        {
            for (col = 0; col < n; col++)
                Console.Write("{0,4} ", matrix[row, col]);
            Console.WriteLine("\n");
        }
    }

    static bool IsTraversable(int row, int col)
    {
        return row >= 0 && row < matrix.GetLongLength(0) &&
               col >= 0 && col < matrix.GetLongLength(1) && matrix[row, col] == 0;
    }
}