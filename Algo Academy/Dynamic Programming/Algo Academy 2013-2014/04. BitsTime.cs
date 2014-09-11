namespace DynamicProgramming
{
    using System;
    using System.Linq;

    /// <summary>
    /// There is no memory optimization -> Memory usage: ~ N * M
    /// </summary>
    public class BitsTime
    {
        private const double ReplaceCosts = 1;
        private const double AddOneCosts = 1.2;
        private const double AddZeroCosts = 1.1;
        private const double RemoveOneCosts = 0.8;
        private const double RemoveZeroCosts = 0.9;

        public static void Main()
        {
            string input = Console.ReadLine();
            string result = Console.ReadLine();
            double[,] matrix = new double[input.Length + 1, result.Length + 1];

            FillFirstRow(matrix, result);
            FillFirstColumn(matrix, input);
            FillMatrix(matrix, result, input);
            PrintAnswer(matrix);
        }
 
        private static void FillFirstRow(double[,] matrix, string result)
        {
            for (int col = 1; col < matrix.GetLongLength(1); col++)
            {
                matrix[0, col] = matrix[0, col - 1] + GetCostsForAdd(result[col - 1]);
            }
        }
 
        private static void FillFirstColumn(double[,] matrix, string input)
        {
            for (int row = 1; row < matrix.GetLongLength(0); row++)
            {
                matrix[row, 0] = matrix[row - 1, 0] + GetCostsForRemove(input[row - 1]);
            }
        }

        private static void FillMatrix(double[,] matrix, string output, string input)
        {
            for (int row = 1; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLongLength(1); col++)
                {
                    var replaceCosts = matrix[row - 1, col - 1];
                    if (output[col - 1] != input[row - 1])
                    {
                        replaceCosts += ReplaceCosts;
                    }

                    var addCosts = matrix[row, col - 1] + GetCostsForAdd(output[col - 1]);
                    var removeCosts = matrix[row - 1, col] + GetCostsForRemove(input[row - 1]);

                    var minCosts = GetMin(replaceCosts, removeCosts, addCosts);
                    matrix[row, col] = minCosts;
                }
            }
        }

        private static double GetCostsForAdd(char bit)
        {
            return bit == '0' ? AddZeroCosts : AddOneCosts;
        }

        private static double GetCostsForRemove(char bit)
        {
            return bit == '0' ? RemoveZeroCosts : RemoveOneCosts;
        }

        private static double GetMin(params double[] elements)
        {
            return elements.Min();
        }

        private static void PrintAnswer(double[,] matrix)
        {
            Console.WriteLine(matrix[matrix.GetLongLength(0) - 1, matrix.GetLongLength(1) - 1]);
        }
    }
}