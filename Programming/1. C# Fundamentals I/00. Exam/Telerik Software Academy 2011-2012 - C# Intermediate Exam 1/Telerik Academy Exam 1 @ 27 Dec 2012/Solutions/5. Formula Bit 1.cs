using System;
using System.Linq;

class FormulaBitOne
{
    static byte[,] matrix = new byte[8, 8];
    static int direction = 0, length = 0, turns = 0;
    static int[,] directions = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, 1 } };
    static byte[] numbers = new byte[8];

    static void Main()
    {
        for (int row = 0; row < 8; row++) numbers[row] = byte.Parse(Console.ReadLine());

        DFS(0, 0);
    }

    private static bool IsTraversable(int row, int col)
    {
        return 0 <= row && row < numbers.Length && 0 <= col && col < numbers.Length && ((numbers[row] >> col) & 1) == 0;
    }

    static void DFS(int row, int col)
    {
        length++;

        if (row == 7 && col == 7) Console.WriteLine("{0} {1}", length, turns); // Final
        else if (!IsTraversable(row, col)) Console.WriteLine("No {0}", length - 1); // Out of range
        else
        {
            // Next coords
            int _row = row + directions[direction, 0];
            int _col = col + directions[direction, 1];

            if (!IsTraversable(_row, _col)) // if next coords are not traversable -> change direction
            {
                turns++;
                direction = (int)(++direction % directions.GetLongLength(0)); // Always we will be in the interval

                // Next coords with new direction
                _row = row + directions[direction, 0];
                _col = col + directions[direction, 1];
            }

            DFS(_row, _col);
        }
    }
}