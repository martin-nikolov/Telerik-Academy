using System;
using System.Linq;

class Sudoku
{
    static readonly int n = 9, littleN = 3;

    static int[,] sudoku = new int[9, 9];
    static int[,] temp = new int[9, 9];
    static int row = 0, col = 0;

    static void Main()
    {
        for (int ii = 0; ii < 9; ii++)
        {
            string digits = Console.ReadLine();

            for (int jj = 0; jj < 9; jj++)
                sudoku[ii, jj] = temp[ii, jj] = digits[jj] != '-' ? digits[jj] - 48 : 0;
        }

        Solve();

        PrintSudoku(temp);
    }
  
    static bool Solve()
    {
        if (temp[0, 0] != 0) MoveForward();

        do
        {
            int digit = 0;

            do
            {
                digit = temp[row, col] + 1;

                while (digit <= n)
                {
                    if (IsPossible(digit))
                    {
                        temp[row, col] = digit;
                        break;
                    }

                    digit++;
                }

                if (digit > n && !MoveBackward()) return false;
            }
            while (digit > n);
        }
        while (MoveForward());

       return true;
    }

    static bool IsPossible(int number)
    {
        for (int jj = 0; jj < n; jj++)
            if (temp[row, jj] == number) return false;

        for (int ii = 0; ii < n; ii++)
            if (temp[ii, col] == number) return false;

        int shiftRow = littleN * (row / littleN);
        int shiftCol = littleN * (col / littleN);

        for (int ii = shiftRow; ii < shiftRow + littleN; ii++)
            for (int jj = shiftCol; jj < shiftCol + littleN; jj++)
                if (temp[ii, jj] == number) return false;

        return true;
    }

    static bool MoveForward()
    {
        do
        {
            if (row == n - 1 && col == n - 1) return false;

            if (col < n - 1) 
            {
                col++;
            }
            else
            {
                col = 0;
                row++;
            }
        } 
        while (sudoku[row, col] != 0);

        return true;
    }

    static bool MoveBackward()
    {
        temp[row, col] = 0;

        do
        {
            if (row == 0 && col == 0) return false;

            if (col > 0)
            {
                col--;
            }
            else
            {
                col = n - 1;
                row--;
            }
        }
        while (sudoku[row, col] != 0);

        return true;
    }

    static void PrintSudoku(int[,] matrix)
    {
        for (int ii = 0; ii < 9; ii++)
        {
            for (int jj = 0; jj < 9; jj++)
                Console.Write(matrix[ii, jj]);
            Console.WriteLine();
        }
    }
}