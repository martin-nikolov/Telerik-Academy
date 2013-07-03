using System;

class Lines
{
    static int[,] matrix = new int[8, 8];
    static int bestLength = 0;
    static int bestLengthCount = 0;

    static void Main()
    {
        for (int row = 0; row < matrix.GetLongLength(0); row++)
        {
            int number = int.Parse(Console.ReadLine());

            for (int col = (int)(matrix.GetLongLength(0) - 1); col >= 0; col--)
            {
                matrix[row, col] = number % 2;
                number /= 2;
            }
        }

        for (int index = 0; index < matrix.GetLongLength(0); index++)
        {
            int currentLength = 0;

            for (int col = 0; col < matrix.GetLongLength(1); col++) // horizontal
            {
                if (matrix[index, col] == 1)
                {
                    currentLength++;

                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                        bestLengthCount = 1;
                    }
                    else if (currentLength == bestLength)
                    {
                        bestLengthCount++;
                    }
                }
                else 
                {
                    currentLength = 0;
                }
            }

            currentLength = 0;

            for (int row = 0; row < matrix.GetLongLength(0); row++) // vertical
            {
                if (matrix[row, index] == 1)
                {
                    currentLength++;

                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                        bestLengthCount = 1;
                    }
                    else if (currentLength == bestLength && bestLength != 0)
                    {
                        bestLengthCount++;
                    }
                }
                else
                {
                    currentLength = 0;
                }
            }
        }

        if (bestLength == 1)
            bestLengthCount /= 2;

        Console.WriteLine(bestLength);
        Console.WriteLine(bestLengthCount);
    }
}