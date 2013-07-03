using System;
using System.Linq;

class AngryBits
{
    static int[,] matrix = new int[8, 16];
    static int pigs = 0;
    static int totalSteps = 0;
    static int currentSteps = 0;
    static int totalPoints = 0;

    static void Main()
    {
        InitializationMatrix();

        if (pigs == 0)
        {
            Console.WriteLine("0 Yes"); return;
        }

        for (int col = 7; col >= 0; col--)
        {
            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                if (matrix[row, col] == 1)
                {
                    int _row = row, _col = col;
                    currentSteps = 0;

                    while (_col != 15)
                    {
                        // MOVE UP
                        while (InRange(_row - 1, _col + 1) && matrix[_row - 1, _col + 1] == 0) 
                        {
                            currentSteps++; totalSteps++;
                            _row--; _col++;
                        }
                        if (IsPiggy(_row, _col, ref col, ref row, -1)) break;

                        // MOVE DOWN
                        while (InRange(_row + 1, _col + 1) && matrix[_row + 1, _col + 1] == 0) 
                        {
                            currentSteps++; totalSteps++;
                            _row++; _col++;
                        }
                        if (IsPiggy(_row, _col, ref col, ref row, 1)) break;
     
                        // We reach the right or bottom side of the field
                        // so we didn't find some pig and remove current bit (bird)
                        if (_row == 7 || _col == 15)
                        {
                            matrix[row, col] = 0;

                            if (col > 0) // Go to next column
                            {
                                col--; 
                                row = -1;
                                // HACK: there the program makes unnecessary moves
                            }

                            break;
                        }
                    }
                }

                if (pigs == 0) break;   
            }
        }

        if (pigs == 0) Console.WriteLine("{0} Yes", totalPoints);

        if (pigs > 0) Console.WriteLine("{0} No", totalPoints);
    }
  
    static bool IsPiggy(int _row, int _col, ref int col, ref int row, int direction)
    {
        if (InRange(_row + direction, _col + 1))
        {
            if (matrix[_row + direction, _col + 1] == 1) // We found Pig!
            {
                currentSteps++;
                totalSteps++;
                FindAndRemoveAllPigs(_row + direction, _col + 1, currentSteps);

                matrix[row, col] = 0; // Remove current bit (bird)

                if (col > 0) // Go to next column
                {
                    col--; row = -1;
                }

                return true;
            }
        }

        return false;
    }

    static void FindAndRemoveAllPigs(int row, int col, int currentSteps)
    {
        int killedPigs = 1;

        matrix[row, col] = 0;
        pigs--;
       
        if (row > 0)
        {
            if (matrix[row - 1, col] == 1)
            {
                matrix[row - 1, col] = 0; killedPigs++; pigs--;
            }

            if (col != 8 && matrix[row - 1, col - 1] == 1)
            {
                matrix[row - 1, col - 1] = 0; killedPigs++; pigs--;
            }

            if (col < matrix.GetLongLength(1) - 1 && matrix[row - 1, col + 1] == 1)
            {
                matrix[row - 1, col + 1] = 0; killedPigs++; pigs--;
            }
        }

        if (row < matrix.GetLongLength(0) - 1)
        {
            if (matrix[row + 1, col] == 1)
            {
                matrix[row + 1, col] = 0; killedPigs++; pigs--;
            }

            if (col != 8 && matrix[row + 1, col - 1] == 1)
            {
                matrix[row + 1, col - 1] = 0; killedPigs++; pigs--;
            }

            if (col < matrix.GetLongLength(1) - 1 && matrix[row + 1, col + 1] == 1)
            {
                matrix[row + 1, col + 1] = 0; killedPigs++; pigs--;
            }
        }

        if (col < matrix.GetLongLength(1) - 1 && matrix[row, col + 1] == 1)
        {
            matrix[row, col + 1] = 0; killedPigs++; pigs--;
        }

        if (col != 8 && matrix[row, col - 1] == 1)
        {
            matrix[row, col - 1] = 0; killedPigs++; pigs--;
        }

        totalPoints += currentSteps * killedPigs;
    }
  
    static void InitializationMatrix()
    {
        for (int row = 0; row < matrix.GetLongLength(0); row++)
        {
            int number = int.Parse(Console.ReadLine());

            for (int col = (int)(matrix.GetLongLength(1) - 1); col >= 0; col--)
            {
                // Count how many pigs there are
                if (col >= 8 && number % 2 == 1) pigs++;

                matrix[row, col] = number % 2;
                number /= 2;
            }

            // Another way:
            //for (int iCol = 0; iCol < 16; iCol++)
            //{
            //   matrix[i, 15 - iCol] = (number >> iCol) & 1;
            //}
        }
    }

    static bool InRange(int row, int col)
    {
        return row >= 0 && row < matrix.GetLongLength(0) && col >= 0 && col < matrix.GetLongLength(1);
    }
}