/*
* 1. Write a program that fills and prints a matrix of size (n, n) as shown below:
* (examples for n = 4)
* 
* 7  11  14  16
* 4   8  12  15
* 2   5   9  13
* 1   3   6  10
* 
*/

using System;
using System.Linq;

class MatrixC
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];
        int count = 1;

        for (int row = n - 1; count <= n * n; row--)
            for (int col = (row >= 0 ? 0 : -row), _row = (row >= 0 ? row : 0); col < (n - (row >= 0 ? row : 0));)
                matrix[_row++, col++] = count++;

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