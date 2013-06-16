using System;
using System.Linq;

class FallDown
{
    static void Main()
    {
        int[,] matrix = new int[8, 8];
        int[] numbers = new int[8];

        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = int.Parse(Console.ReadLine());

        for (int col = 0; col < 8; col++)
        {
            int[] sorted = new int[8];

            for (int row = 0; row < 8; row++)
                sorted[row] = (numbers[row] >> col) & 1;

            Array.Sort(sorted);

            for (int i = 0; i < 8; i++)
                matrix[i, col] = sorted[i];
        }

        for (int row = 0; row < 8; row++)
        {
            numbers[row] = 0;

            for (int col = 0; col < 8; col++)
                numbers[row] += matrix[row, col] * (int)Math.Pow(2, col);

            Console.WriteLine(numbers[row]);
        }
    }
}