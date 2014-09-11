/*
 * 01. Write a program based on dynamic programming to solve the "Knapsack Problem": 
 * you are given N products, each has weight Wi and costs Ci and a knapsack of capacity 
 * M and you want to put inside a subset of the products with highest cost and weight ≤ M.
 * The numbers N, M, Wi and Ci are integers in the range [1..500].
 * 
 * Example: M=10 kg, N=6, products:
 *   beer – weight=3, cost=2
 *   vodka – weight=8, cost=12
 *   cheese – weight=4, cost=5
 *   nuts – weight=1, cost=4
 *   ham – weight=2, cost=3
 *   whiskey – weight=8, cost=13
 *
 * Optimal solution:
 *   nuts + whiskey
 *   weight = 9
 *   cost = 17
 */

namespace DynamicProgramming
{
    using System;
    using System.Linq;

    public class KnapsackProblem
    {
        private static Product[] products;
        private static int[,] matrix;

        internal static void Main()
        {
            #if DEBUG
                Console.SetIn(new System.IO.StreamReader("../../input_1.txt"));
            #endif

            int maximalWeight;
            Utility.ParseInput(out products, out maximalWeight);
            matrix = new int[products.Length + 1, maximalWeight + 1];

            FillMatrix();

            int maxValueColIndex = FindMaxValueIndexInLastRow();
            var maxValueInLastRow = matrix[products.Length, maxValueColIndex];

            Console.WriteLine("Optimal solution: {0}\n", maxValueInLastRow);
            PrintChosenFoods(maxValueInLastRow, maxValueColIndex);
            Console.WriteLine();
        }

        private static void FillMatrix()
        {
            for (int row = 1; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLongLength(1); col++)
                {
                    int upperValue = matrix[row - 1, col], leftValue = 0;
                    int colIndex = col - products[row - 1].Weight;
                    if (colIndex >= 0)
                    {
                        leftValue = matrix[row - 1, colIndex] + products[row - 1].Cost;
                    }

                    matrix[row, col] = Math.Max(upperValue, leftValue);
                }
            }
        }

        private static int FindMaxValueIndexInLastRow()
        {
            int maxValue = int.MinValue, indexOfMaxValue = 0;
            for (int col = 0; col < matrix.GetLongLength(1); col++)
            {
                var cellValue = matrix[matrix.GetLongLength(0) - 1, col];
                if (cellValue > maxValue)
                {
                    maxValue = cellValue;
                    indexOfMaxValue = col;
                }
            }

            return indexOfMaxValue;
        }

        private static void PrintChosenFoods(int maxValue, int maxValueColIndex)
        {
            int currentRow = (int)(matrix.GetLongLength(0) - 1), currentCol = maxValueColIndex;
            int currentValue = maxValue, upperValue = 0;

            while (currentRow > 0 && currentCol > 0)
            {
                upperValue = matrix[currentRow - 1, currentCol];

                if (upperValue != currentValue)
                {
                    Console.WriteLine(products[currentRow - 1]); // The chosen food
                    currentCol -= products[currentRow - 1].Weight;
                }

                currentValue = matrix[--currentRow, currentCol];
            }
        }
    }
}