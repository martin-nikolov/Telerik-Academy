/*
* 8. Define a class Matrix<T> to hold a matrix of numbers 
* (e.g. integers, floats, decimals). 
* 
* 9. Implement an indexer this[row, col] to access the
* inner matrix cells.
* 
* 10. Implement the operators + and - (addition and subtraction
* of matrices of the same size) and * for matrix multiplication.
* Throw an exception when the operation cannot be performed.
* Implement the true operator (check for non-zero elements).
*/

using System;
using Multidimensional.Arrays;

class Program
{
    static readonly Random rnd = new Random();

    static void Main()
    {
        var matrix1 = new Matrix<int>(3, 3,
            1, 2, 0,
            0, 1, 1,
            2, 0, 1);

        var matrix2 = new Matrix<int>(3, 3);

        for (uint row = 0; row < matrix2.Rows; row++)
            for (uint col = 0; col < matrix2.Columns; col++)
                matrix2[row, col] = rnd.Next(10);

        Console.WriteLine("First Matrix ({0}x{1}) is:", matrix1.Rows, matrix1.Columns);
        Console.WriteLine(matrix1);

        Console.WriteLine("Second Matrix ({0}x{1}) is:", matrix2.Rows, matrix2.Columns);
        Console.WriteLine(matrix2);

        Console.WriteLine("Аccumulation of the Matrices:");
        Console.WriteLine(matrix1 + matrix2);

        Console.WriteLine("Subtraction of the Matrices:");
        Console.WriteLine(matrix1 - matrix2);

        Console.WriteLine("Multiplication of the Matrices:");
        Console.WriteLine(matrix1 * matrix2);

        Console.WriteLine("First matrix: {0}", matrix1 ? "Non-empty!" : "Empty!");
        Console.WriteLine("New matrix: {0}\n", new Matrix<double>(1, 1) ? "Non-empty!" : "Empty!");
    }
}