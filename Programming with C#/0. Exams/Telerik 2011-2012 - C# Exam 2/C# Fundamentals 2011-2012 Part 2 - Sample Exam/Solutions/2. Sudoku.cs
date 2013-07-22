using System;
using System.Linq;

class Sudoku
{
    static int[,] sudoku = new int[N, N];
    static int[,] temp = new int[N, N];
    static int row = 0, col = 0;
   
    const int N = 9, LittleN = 3;

    internal static void Initialize()
    {
        for (int ii = 0; ii < N; ii++)
        {
            string digits = Console.ReadLine();

            for (int jj = 0; jj < N; jj++)
                sudoku[ii, jj] = temp[ii, jj] = digits[jj] != '-' ? digits[jj] - 48 : 0;
        }
    }

    internal static void PrintSolution()
    {
        for (int ii = 0; ii < N; ii++)
        {
            for (int jj = 0; jj < N; jj++)
                Console.Write(temp[ii, jj]);
            Console.WriteLine();
        }
    }

    internal static bool HasSolution()
    {
        if (temp[0, 0] != 0) MoveForward(); // Moves until reach empty cell

        do
        {
            int digit = 0; // The number in current cell

            do
            {
                digit = temp[row, col] + 1; // Get number in [current cell] + 1

                while (digit <= N)
                {
                    if (IsPossible(digit)) // Check if is possible to put digit in current cell
                    {
                        temp[row, col] = digit; // Puts number in current cell 
                        break;                  // and loop is terminated
                    }

                    digit++; // Get next digit
                }

                if (digit > N)              // All digits are exhausted 
                    if (!MoveBackward())    // and cannot move backward 
                        return false;       // => no solution
            }
            while (digit > N); // We did backtracking => repets steps above
        }
        while (MoveForward()); // Sucessfully put number in cell => go to next cell

        return true;
    }

    private static bool IsPossible(int digit)
    {
        for (int ii = 0; ii < N; ii++) if (temp[ii, col] == digit) return false; // Check rows for same number

        for (int jj = 0; jj < N; jj++) if (temp[row, jj] == digit) return false; // Check columns for same number

        int shiftRow = LittleN * (row / LittleN);
        int shiftCol = LittleN * (col / LittleN);

        for (int ii = shiftRow; ii < shiftRow + LittleN; ii++)
            for (int jj = shiftCol; jj < shiftCol + LittleN; jj++)
                if (temp[ii, jj] == digit) return false;

        return true;
    }

    private static bool MoveForward()
    {
        do
        {
            if (row == N - 1 && col == N - 1) return false; // Solution found

            if (++col > N - 1)
            {
                col = 0;
                row++;
            }
        }
        while (sudoku[row, col] != 0); // Repeats until reach empty cell
       
        return true;
    }

    private static bool MoveBackward()
    {
        temp[row, col] = 0; // Clear current cell (remove current digit)

        do
        {
            if (row == 0 && col == 0) return false; // Cannot move backward -> out of bounds

            if (--col < 0)
            {
                col = N - 1;
                row--;
            }
        }
        while (sudoku[row, col] != 0); // Repeats until reach empty cell

        return true;
    }
}

class Program
{
    static void Main()
    {
        Sudoku.Initialize();
        if (Sudoku.HasSolution()) Sudoku.PrintSolution();
    }
}