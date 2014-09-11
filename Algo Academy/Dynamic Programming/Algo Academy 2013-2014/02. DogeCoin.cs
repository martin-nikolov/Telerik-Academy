namespace DynamicProgramming
{
    using System;
    using System.Linq;

    public class DogeCoin
    {
        private static int[,] matrix;

        public static void Main()
        {
            var matrixSizes = Console.ReadLine().Split(' ');
            int n = int.Parse(matrixSizes[0]);
            int m = int.Parse(matrixSizes[1]);
            matrix = new int[n, m];

            var coinsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < coinsCount; i++)
            {
                var coords = Console.ReadLine().Split(' ');
                int x = int.Parse(coords[0]);
                int y = int.Parse(coords[1]);
                matrix[x, y]++;
            }
    
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    int up = 0, left = 0;

                    if (row > 0)
                    {
                        up = matrix[row - 1, col];
                    }

                    if (col > 0)
                    {
                        left = matrix[row, col - 1];
                    }

                    var maxCoins = Math.Max(up, left);
                    matrix[row, col] += maxCoins;
                }
            }

            Console.WriteLine(matrix[n - 1, m - 1]);
        }
    }
}