/*
* 1. Write a program that fills and prints a matrix of size (n, n) as shown below:
* (examples for n = 4)
* 
* 1  5   9  13
* 2  6  10  14
* 3  7  11  15
* 4  8  12  16
* 
*/

using System;
using System.Linq;

class MatrixA
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        for (int row = 0, count = 1; row < n; row++)
            for (int col = 0; col < n; col++)
                matrix[col, row] = count++;

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