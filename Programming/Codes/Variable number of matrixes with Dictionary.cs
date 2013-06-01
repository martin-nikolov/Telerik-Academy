using System;
using System.Collections.Generic;
using System.Linq;
 
class VariableNumberOfMatrices
{
    public static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
 
    }
    public static void Main()
    {
        Dictionary<string, int[,]> matrices = new Dictionary<string, int[,]>();
 
        for (int i = 0; i < 10; i++)
        {
            matrices.Add("matrix"+i, new int[5,5]);
        }
 
        //Add values to matrices
        foreach (var matrix in matrices)
        {
            for (int row = 0; row < matrix.Value.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.Value.GetLength(1); col++)
                {
                    matrix.Value[row, col] = 1;
                }
            }
        }
 
        //Print the matrices
        string nameOfMatrixToPrint = "matrix1"; //can be matrix2, matrix3 etc. ... to matrix9, because we added 10 matrices(from 0 to 9)
        int[,] matrixToPrint = matrices.Where(x => x.Key == nameOfMatrixToPrint).FirstOrDefault().Value; //gets the matrix. See the link in the forum for Lambda expression.
 
        PrintMatrix(matrixToPrint);
    }
}