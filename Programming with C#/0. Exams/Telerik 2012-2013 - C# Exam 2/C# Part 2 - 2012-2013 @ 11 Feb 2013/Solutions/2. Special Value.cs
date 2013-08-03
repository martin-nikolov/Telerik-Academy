using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class SpecialValue
{
    static List<int>[] numbers;
    static bool[][] visited;
    static long specialValue;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        numbers = new List<int>[n];
        visited = new bool[n][];

        for (int i = 0; i < n; i++)
            numbers[i] = new List<int>(Console.ReadLine().Split(',').Select(ch => Convert.ToInt32(ch)).ToList());

        for (int i = 0; i < n; i++)
            visited[i] = new bool[numbers[i].Count];

        for (int col = 0; col < numbers[0].Count; col++)
        {
            long value = GetValue(numbers[0][col], col);
            if (value > specialValue) specialValue = value;
        }

        Console.WriteLine(specialValue);
    }

    static long GetValue(int nextColumn, int col)
    {
        if (nextColumn < 0) return (int)Math.Abs(nextColumn) + 1;

        long step = 1, row = 0;

        for (int i = 0; i < numbers.GetLongLength(0); i++)
            visited[i] = new bool[numbers[i].Count];

        while (!visited[row][col])
        {
            step++;

            if (nextColumn >= 0)
            {
                visited[row][col] = true;
                col = nextColumn;
            }

            row = (row + 1) % numbers.GetLongLength(0);

            nextColumn = numbers[row][nextColumn];

            if (nextColumn < 0) return Math.Abs(nextColumn) + step;
        }

        return -1;
    }
}
