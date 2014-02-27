using System;

namespace CodingPractice
{
    public static class SearchSortedMatrix
    {
        public static int[,] matrix;

        public static void run()
        {
            matrix = new[,]
                         {
                             {10, 20, 30, 40},
                             {15, 25, 35, 45},
                             {27, 29, 37, 48},
                             {32, 33, 39, 50},
                         };

            searchMatrix(29);
        }

        private static void searchMatrix(int n)
        {
            var len = (int) matrix.GetLongLength(0);
            int row = 0;
            int column = len - 1;

            while (row < len && column >= 0)
            {
                if (matrix[row, column] == n)
                {
                    Console.WriteLine("Element {0} found at row {1} column {2}", n, row, column);
                    break;
                }

                if (matrix[row, column] > n) // if element in matrix is greater then decrease the column index
                    column--;
                else
                    row++;
            }
        }
    }
}