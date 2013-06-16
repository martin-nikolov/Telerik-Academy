using System;

class FormulaBit1
{
    static readonly int[,] directions = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, 1 } };
    static readonly int[] numbers = new int[8];
    static int dir = 0, steps = 0, turns = 0;

    static void Main()
    {
        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = int.Parse(Console.ReadLine());

        DFS(0, 0);
    }

    static bool IsTraversable(int row, int col)
    {
        return row >= 0 && row <= 7 && col >= 0 && col <= 7 &&
               ((numbers[row] >> col) & 1) == 0;
    }

    static void DFS(int row, int col)
    {
        steps++;

        if (!IsTraversable(row, col))
        {
            Console.WriteLine("No {0}", steps - 1);
            return;
        }

        if (row == 7 && col == 7)
        {
            Console.WriteLine("{0} {1}", steps, turns);
            return;
        }

        int _row = row + directions[dir, 0];
        int _col = col + directions[dir, 1];

        // If only the new coords are not traversable -> change directions
        if (!IsTraversable(_row, _col))
        {
            dir = ++dir % 4;
            ++turns;

            _row = row + directions[dir, 0];
            _col = col + directions[dir, 1];
        }

        DFS(_row, _col);
    }
}