using System;
using System.Linq;

class AngryBits
{
    static int[,] matrix = new int[8, 16];
    static int result = 0;

    static void Main()
    {
        Initialization();

        // Start from the middle
        for (int col = 7; col >= 0; col--)
        {
            for (int row = 0; row < 8; row++)
            {
                if (matrix[row, col] == 1)
                {
                    int _row = row;
                    int _col = col;
                    int flightLength = 0;

                    // Move up
                    while (_row > 0)
                    {
                        _row--; _col++; ++flightLength;

                        if (matrix[_row, _col] == 1)
                        {
                            FindAndDestroyAllPigsAround(_row, _col, flightLength);
                            matrix[row, col] = 0;
                            break;
                        }
                    }

                    // Move down
                    while (_row < 7 && _col < 15 && matrix[row, col] == 1)
                    {
                        ++_row; ++_col; ++flightLength;

                        if (matrix[_row, _col] == 1)
                        {
                            FindAndDestroyAllPigsAround(_row, _col, flightLength);
                            matrix[row, col] = 0;
                            break; 
                        }
                        else if (_row == 7 || _col == 15)
                        {
                            matrix[row, col] = 0;
                            break;
                        }
                    }
                }
            }
        }

        Console.WriteLine("{0} {1}", result, ExistAlivePigs() ? "No" : "Yes");
    }

    private static bool ExistAlivePigs()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 8; col < 16; col++)
            {
                if (matrix[row, col] == 1)
                    return true;
            }
        }

        return false;
    }

    private static void FindAndDestroyAllPigsAround(int _row, int _col, int flightLength)
    {
        int destroyedPigs = 0;

        for (int row = _row - 1; row <= _row + 1; row++)
        {
            for (int col = _col - 1; col <= _col + 1; col++)
            {
                if (col > 7 && col < 16 && row >= 0 && row < 8)
                {
                    if (matrix[row, col] == 1)
                    {
                        matrix[row, col] = 0;
                        destroyedPigs++;
                    }
                }
            }
        }

        result += flightLength * destroyedPigs;
    }
  
    private static void Initialization()
    {
        for (int row = 0; row < 8; row++)
        {
            int number = int.Parse(Console.ReadLine());

            for (int col = 0; col < 16; col++)
                matrix[row, col] = (number >> 15 - col) & 1;
        }
    }
}