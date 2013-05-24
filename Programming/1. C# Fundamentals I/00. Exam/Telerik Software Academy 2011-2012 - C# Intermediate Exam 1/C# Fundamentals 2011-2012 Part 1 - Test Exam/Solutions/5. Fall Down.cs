// -> Other way with sorting columns

using System;

class FallDown
{
    static void Main()
    {
        byte[] numbers = new byte[8];
        byte[,] matrix = new byte[8, 8];

        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = byte.Parse(Console.ReadLine());

        for (int col = 0; col < matrix.GetLongLength(1); col++)
            matrix[7, col] = (byte)((numbers[7] >> 7 - col) & 1);

        for (int row = (int)matrix.GetLongLength(0) - 2; row >= 0; row--)
        {
            for (int col = 0; col < matrix.GetLongLength(1); col++)
            {
                if (((numbers[row] >> (7 - col)) & 1) == 1)
                {
                    int _row = row;

                    while (_row < matrix.GetLongLength(0) - 1)
                    {
                        if (matrix[_row + 1, col] != 1)
                        {
                            matrix[_row + 1, col] = 1;
                            _row++;
                        }
                        else
                        {
                            matrix[_row, col] = 1;
                            break;
                        }
                        for (int i = row; i < _row; i++)
                        {
                            matrix[i, col] = 0;
                        }
                    }
                }
            }
        }

        for (int row = 0; row < matrix.GetLongLength(0); row++)
        {
            numbers[row] = 0;

            for (int col = 0; col < matrix.GetLongLength(1); col++)
            {
                if (matrix[row, col] == 1)
                {
                    numbers[row] = (byte)(numbers[row] | (1 << 7 - col));
                }
            }
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
