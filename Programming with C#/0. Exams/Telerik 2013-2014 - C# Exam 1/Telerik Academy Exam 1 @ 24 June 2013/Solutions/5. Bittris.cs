using System;
using System.Linq;

class Bittris
{
    static int[,] matrix = new int[4, 8];
    static bool hasTopRowFreeCells = true, canMoveDown = true;
    static int result = 0;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n / 4; i++)
        {
            int[] number = ReadNumber();

            if (!hasTopRowFreeCells) break;

            canMoveDown = true;

            for (int j = 0, row = 0; j < 3; j++, row++)
            {
                char direction = char.Parse(Console.ReadLine());

                if (!canMoveDown) continue;

                switch (direction)
                {
                    case 'L':
                    case 'R': MoveLeftRight(row, number, direction); break;
                    case 'D': MoveDown(row, number); break;
                }
            }
        }

        Console.WriteLine(result);
    }

    static int[] ReadNumber()
    {
        int number = int.Parse(Console.ReadLine());

        int[] binary = new int[8];
        for (int i = binary.Length - 1; i >= 0; i--)
            binary[i] = (number >> (7 - i)) & 1;

        if (number > 255)
            for (int i = 8; i < 32; i++) result += (number >> i) & 1;

        if (!IsTopRowFree(binary))
        {
            // The game ends
            hasTopRowFreeCells = false;
            return null;
        }

        // Fill the matrix's top row with current number's binary digits
        for (int col = (int)(matrix.GetLongLength(1) - 1); col >= 0; col--)
            matrix[0, col] = (number >> (7 - col)) & 1;

        return binary;
    }

    static bool CanMoveDown(int[] number, int row, int first, int last, int sum = 0)
    {
        for (int col = first; col <= last; col++)
            if (matrix[row + 1, col] == 1 && number[col] == 1)
            {
                // Cannot move down => calculate result
                result += sum;
                return canMoveDown = false;
            }

        return true;
    }

    static void MoveDown(int row, int[] number)
    {
        int first = Array.IndexOf(number, 1);
        int last = Array.LastIndexOf(number, 1);

        if (!CanMoveDown(number, row, first, last))
            if (IsRowFilledCompletely(row, ref number)) return;

        if (CanMoveDown(number, row, first, last, number.Sum()))
        {
            ClearNumberFromCurrentLine(row, number);

            // Move down number's digits
            for (int col = first; col <= last; col++)
                matrix[row + 1, col] = number[col] == 1 ? 1 : matrix[row + 1, col];

            if (!canMoveDown && IsRowFilledCompletely(row + 1, ref number)) return;
        }

        if (row == 2 && IsRowFilledCompletely(row + 1, ref number)) return;
    }

    static bool CanMoveLeft(int row, int[] number)
    {
        return number[0] == 1 ? false : matrix[row, Array.IndexOf(number, 1) - 1] == 0;
    }

    static bool CanMoveRight(int row, int[] number)
    {
        return number[number.Length - 1] == 1 ? false : matrix[row, Array.LastIndexOf(number, 1) + 1] == 0;
    }

    static void MoveLeftRight(int row, int[] number, char direction)
    {
        int first = Array.IndexOf(number, 1);
        int last = Array.LastIndexOf(number, 1);

        #region [Move Left and Move Right]          
        if (direction == 'L' && CanMoveLeft(row, number))
        {
            for (int i = first; i <= last; i++)
            {
                matrix[row, i] = 0;
                number[i - 1] = number[i];
            }
            
            number[last] = 0;
            
            for (int i = first - 1; i <= last - 1; i++)
                matrix[row, i] = number[i];
            
            if (CanMoveDown(number, row, first - 1, last - 1))
                ClearNumberFromCurrentLine(row, number);
        }
        else if (direction == 'R' && CanMoveRight(row, number))
        {
            for (int i = last + 1; i > first; i--)
                number[i] = number[i - 1];
            
            for (int i = first; i <= last; i++)
                matrix[row, i] = 0;
            
            number[first] = 0;
            
            for (int i = first + 1; i <= last + 1; i++)
                matrix[row, i] = number[i];
            
            if (CanMoveDown(number, row, first + 1, last + 1))
                ClearNumberFromCurrentLine(row, number);
        }
        #endregion
    
        MoveDown(row, number);
    }
    
    static bool IsTopRowFree(int[] number)
    {
        int first = Array.IndexOf(number, 1);
        int last = Array.LastIndexOf(number, 1);
    
        return CanMoveDown(number, -1, first, last);
    }
    
    static bool IsRowFilledCompletely(int row, ref int[] number)
    {
        // Check if row is filled completely
        for (int col = 0; col < matrix.GetLongLength(1); col++)
            if (matrix[row, col] == 0)
            {
                // Row is not filled completely
                if (canMoveDown) result += number.Sum();
                
                return false;
            }
        
        // Row is filled completely => clear current line
        for (int col = 0; col < matrix.GetLongLength(1); col++)
            matrix[row, col] = 0;
        
        // Move all blocks down with 1 row
        for (int i = row; i > 0; i--)
            for (int col = 0; col < matrix.GetLongLength(1); col++)
                matrix[i, col] = matrix[i - 1, col];

        result += number.Sum() * 10;
    
        return true;
    }
    
    static void ClearNumberFromCurrentLine(int row, int[] number)
    {
        for (int col = 0; col < matrix.GetLongLength(1); col++)
            matrix[row, col] = (number[col] == 1) ? 0 : matrix[row, col];
    }
}