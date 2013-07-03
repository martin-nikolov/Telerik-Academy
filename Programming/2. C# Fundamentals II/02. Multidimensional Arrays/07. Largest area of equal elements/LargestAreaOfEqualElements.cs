/*
* 7. *Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size. 
* 
*    ------------------------------------
*    |    Example:                      |
*    |                                  |
*    |  1 3 2 2 2 4                     |
*    |  3 3 3 2 4 4                     |
*    |  4 3 1 2 3 3    -> Output: 13    |
*    |  4 3 1 3 3 1                     |
*    |  4 3 3 3 1 1                     |
*    ------------------------------------
*/

using System;
using System.Linq;

class LargestAreaOfEqualElements
{
    // EASE OF USE: The program contains test method that show us how the program work on diffent inputs
    // The method that tests the program is called "TestRunner"

    static int[,] matrix;
    static int bestLength = 0, bestNumber = 0;
    static int currentLength = 0, currentNumber = 0;

    static void Main()
    {
        // The cells which contains 0 are empty.

        matrix = new int[,]
        {
            { 1, 3, 2, 2, 2, 4 },
            { 3, 3, 3, 2, 4, 4 },
            { 4, 3, 1, 2, 3, 3 },
            { 4, 3, 1, 3, 3, 1 },
            { 4, 3, 3, 3, 1, 1 }
        };

        PrintMatrix(matrix);
        FindBestAreaLength(matrix);

        //TestRunner(); // <- TEST METHOD
    }

    static void FindBestAreaLength(int[,] matrix)
    {
        bestLength = bestNumber = 0;

        for (int row = 0; row < matrix.GetLongLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLongLength(1); col++)
            {
                currentNumber = matrix[row, col];
                currentLength = 0;

                GetAreaLength(row, col);

                if (currentLength > bestLength)
                {
                    bestLength = currentLength;
                    bestNumber = currentNumber;
                }
            }
        }

        Console.WriteLine("Best Area of number {0} -> {1} times\n", bestNumber, bestLength);
    }

    static void GetAreaLength(int row, int col)
    {
        if (row < 0 || row >= matrix.GetLongLength(0) ||
            col < 0 || col >= matrix.GetLongLength(1) || matrix[row, col] == 0)
            return;
            
        if (matrix[row, col] == currentNumber)
        {
            matrix[row, col] = 0;
            currentLength++;

            GetAreaLength(row - 1, col);
            GetAreaLength(row + 1, col);
            GetAreaLength(row, col - 1);
            GetAreaLength(row, col + 1);
        }
    }

    static void PrintMatrix(int[,] matrix)
    {
        Console.WriteLine("Matrix ({0}x{1}):\n", matrix.GetLongLength(0), matrix.GetLongLength(1));
        for (int row = 0; row < matrix.GetLongLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLongLength(1); col++)
                Console.Write("{0,3}", matrix[row, col]);
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void TestRunner()
    {
        Console.WriteLine(new string('-', 40) + "\n");

        matrix = new int[,]
        {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 }
        };

        PrintMatrix(matrix);
        FindBestAreaLength(matrix);

        Console.WriteLine(new string('-', 40));

        matrix = new int[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        PrintMatrix(matrix);
        FindBestAreaLength(matrix);

        Console.WriteLine(new string('-', 40));

        matrix = new int[,]
        {
            { 8, 8, 8, 8, 8 },
            { 8, 1, 1, 1, 1 },
            { 8, 8, 8, 8, 8 },
            { 1, 1, 1, 1, 8 },
            { 8, 8, 8, 8, 8 }
        };

        PrintMatrix(matrix);
        FindBestAreaLength(matrix);

        Console.WriteLine(new string('-', 40));

        matrix = new int[,]
        {
            { 9, 9, 9, 9, 9, 9, 9 },
            { 9, 1, 1, 1, 1, 1, 1 },
            { 9, 1, 9, 9, 9, 9, 9 },
            { 9, 1, 9, 1, 1, 1, 9 },
            { 9, 1, 9, 1, 9, 1, 9 },
            { 9, 1, 9, 9, 9, 1, 9 },
            { 9, 1, 1, 1, 1, 1, 9 },
            { 9, 9, 9, 9, 9, 9, 9 }
        };

        PrintMatrix(matrix);
        FindBestAreaLength(matrix);

        Console.WriteLine(new string('-', 40));

        matrix = new int[,]
        {
            { 5, 5, 5, 5, 5, 5, 5, 5, 5 },
            { 4, 4, 4, 4, 4, 4, 4, 4, 5 },
            { 3, 3, 3, 3, 3, 3, 3, 4, 5 },
            { 2, 2, 2, 2, 2, 2, 3, 4, 5 },
            { 1, 1, 1, 1, 1, 2, 3, 4, 5 }
        };

        PrintMatrix(matrix);
        FindBestAreaLength(matrix);

        Console.WriteLine(new string('-', 40));
    }
}