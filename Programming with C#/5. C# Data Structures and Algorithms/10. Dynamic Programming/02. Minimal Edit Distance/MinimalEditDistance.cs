/*
 * 2. Write a program to calculate the "Minimum Edit Distance" (MED) between
 * two words. MED(x, y) is the minimal sum of costs of edit operations 
 * used to transform x to y. Sample costs are given below:
 * 
 *   cost (replace a letter) = 1
 *   cost (delete a letter) = 0.9
 *   cost (insert a letter) = 0.8
 *   
 * Example: x = "developer", y = "enveloped" -> cost = 2.7 
 *   delete ‘d’:  "developer" -> "eveloper", cost = 0.9
 *   insert ‘n’:  "eveloper" -> "enveloper", cost = 0.8
 *   replace ‘r’ -> ‘d’:  "enveloper" -> "enveloped", cost = 1
 */

namespace DynamicProgramming
{
    using System;
    using System.Linq;

    /// <summary>
    /// There is no memory optimization -> Memory usage: ~ N * M
    /// </summary>
    public class MinimalEditDistance
    {
        private static double[,] matrix;

        private const double ReplaceLetterCosts = 1;
        private const double DeleteLetterCosts = 0.9;
        private const double InsertLetterCosts = 0.8;

        internal static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            #endif

            string input = Console.ReadLine();
            string output = Console.ReadLine();

            matrix = new double[input.Length + 1, output.Length + 1];

            FillFirstRow();
            FillFirstColumn();
            FillMatrix(output, input);
            PrintAnswer();
        }

        private static void FillFirstRow()
        {
            for (int col = 1; col < matrix.GetLongLength(1); col++)
            {
                matrix[0, col] = matrix[0, col - 1] + DeleteLetterCosts;
            }
        }
 
        private static void FillFirstColumn()
        {
            for (int row = 1; row < matrix.GetLongLength(0); row++)
            {
                matrix[row, 0] = matrix[row - 1, 0] + DeleteLetterCosts;
            }
        }

        private static void FillMatrix(string output, string input)
        {
            for (int row = 1; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLongLength(1); col++)
                {
                    var replaceCosts = matrix[row - 1, col - 1];
                    if (output[col - 1] != input[row - 1])
                    {
                        replaceCosts += ReplaceLetterCosts;
                    }

                    var addCosts = matrix[row, col - 1] + InsertLetterCosts;
                    var removeCosts = matrix[row - 1, col] + DeleteLetterCosts;

                    var minCosts = GetMin(replaceCosts, removeCosts, addCosts);
                    matrix[row, col] = minCosts;
                }
            }
        }

        private static double GetMin(params double[] elements)
        {
            return elements.Min();
        }

        private static void PrintAnswer()
        {
            Console.WriteLine("Minimal Edit Distance Costs: {0}",
                matrix[matrix.GetLongLength(0) - 1, matrix.GetLongLength(1) - 1]);
        }
    }
}