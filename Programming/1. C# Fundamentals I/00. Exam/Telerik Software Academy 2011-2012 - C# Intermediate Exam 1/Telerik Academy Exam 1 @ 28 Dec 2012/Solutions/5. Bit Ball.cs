using System;
using System.Linq;

class BitBalls
{
    static void Main()
    {
        byte[,] top = new byte[8, 8];
        byte[,] bottom = new byte[8, 8];

        byte[,] matrix = new byte[8, 8];
        byte[] numbers = new byte[8];

        // Initialization - top
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = byte.Parse(Console.ReadLine());
        }
        PutBinNumbersInMatrix(top, numbers, 1);

        // Initialization - bottom
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = byte.Parse(Console.ReadLine());
        }
        PutBinNumbersInMatrix(bottom, numbers, 2);

        for (int row = 0; row < matrix.GetLongLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLongLength(1); col++)
            {
                if (matrix[row, col] == 0)
                {
                    if (top[row, col] != 0 && bottom[row, col] == 0)
                    {
                        matrix[row, col] = 1;
                    }
                    else if (top[row, col] == 0 && bottom[row, col] != 0)
                    {
                        matrix[row, col] = 2;
                    }
                }
            }
        }

        byte topGoals = 0, bottomGoals = 0;

        for (int row = 0; row < matrix.GetLongLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLongLength(1); col++)
            {
                int i = row;

                if (matrix[row, col] == 1)
                {
                    while (true)
                    {
                        if (i == 7)
                        {
                            topGoals++;
                            break;
                        }

                        if (matrix[i + 1, col] != 0)
                        {
                            break;
                        }

                        i++;
                    }
                }
                else if (matrix[row, col] == 2)
                {
                    while (true)
                    {
                        if (i == 0)
                        {
                            bottomGoals++;
                            break;
                        }

                        if (matrix[i - 1, col] != 0)
                        {
                            break;
                        }

                        i--;
                    }
                }
            }
        }

        Console.WriteLine("{0}:{1}", topGoals, bottomGoals);
    }
  
    private static void PutBinNumbersInMatrix(byte[,] matrix, byte[] numbers, byte type)
    {
        for (int row = 0; row < matrix.GetLongLength(0); row++)
        {
            for (int col = (int)(matrix.GetLongLength(1) - 1); col >= 0; col--)
            {
                matrix[row, col] = (byte)(numbers[row] % 2 == 1 ? type : 0);
                numbers[row] /= 2;
            }
        }
    }
}