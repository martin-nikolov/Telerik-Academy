using System;
using System.Linq;

class Neurons
{
    static readonly string[,] matrix = new string[32, 32];
    static int rows = 0; // Total rows of matrix

    static void Main()
    {
        // Initialization
        for (long row = 0, number = 0; (number = long.Parse(Console.ReadLine())) != -1; row++, rows++)
        {
            for (int col = 31; col >= 0; col--)
                matrix[row, col] = (((number >> (31 - col)) & 1) == 1) ? "1" : ".";
        }

        for (int row = 0; row < rows; row++)
        {
            bool isFoundOnesOnRight = false;

            for (int col = 0; col < 32; col++)
            {
                if (matrix[row, col] == "1")
                {
                    while (col < 32 && matrix[row, col] != ".") 
                        matrix[row, col++] = ".";
                    
                    int _col = col;

                    while (_col < 32 && matrix[row, _col] != "1")
                    {
                        if (matrix[row, _col++] == "1")
                        {
                            isFoundOnesOnRight = false; 
                            break;
                        }

                        if (_col >= 32) isFoundOnesOnRight = true;
                    }

                    if (!isFoundOnesOnRight)
                    {
                        while (col < 32 && matrix[row, col] != "1") 
                            matrix[row, col++] = "1";
                        while (col < 32 && matrix[row, col] != ".") 
                            matrix[row, col++] = ".";
                    }
                }
            }
        }

        // Find and print numbers
        for (long row = 0, number = 0; row < rows; row++, number = 0)
        {
            for (long col = 31, pow = 0; col >= 0; col--, pow++)
                if (matrix[row, col] == "1") 
                    number += (long)Math.Pow(2, pow);

            Console.WriteLine(number);
        }
    }
}