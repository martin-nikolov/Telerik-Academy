using System;
using System.Collections.Generic;
 
class VariableNumberOfMatrices
{
    static void Main()
    {
        List<int[,]> matrices = new List<int[,]>();
 
        for (int i = 0; i < 10; i++)
        {
            matrices.Add(new int[5,5]);
        }
 
        //Add values to matrices
        foreach (var matrix in matrices)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 1;
                }
            }            
        }
 
        //Print the matrices
        foreach (var matrix in matrices)
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
    }
}