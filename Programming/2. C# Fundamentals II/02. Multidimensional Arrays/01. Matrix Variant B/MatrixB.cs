/*
* 1. Write a program that fills and prints a matrix of size (n, n) as shown below:
* (examples for n = 4)
* 
* 1  8   9  16
* 2  7  10  15
* 3  6  11  14
* 4  5  12  13
* 
*/

using System;
using System.Linq;

class MatrixB
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];
        bool isDirsDown = true;

        for (int col = 0, row = 0, count = 1; col < n; col++)
        {
            while (row >= 0 && row < n)
            {
                matrix[row, col] = count++;
                row += isDirsDown ? +1 : -1; // Change 'row' value
            }

            // Change direction and change 'row' value
            row += (isDirsDown = !isDirsDown) ? +1 : -1;
        }

        // Prints matrix
        Console.WriteLine();
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
                Console.Write("{0,4} ", matrix[row, col]);
            Console.WriteLine("\n");
        }
    }
}