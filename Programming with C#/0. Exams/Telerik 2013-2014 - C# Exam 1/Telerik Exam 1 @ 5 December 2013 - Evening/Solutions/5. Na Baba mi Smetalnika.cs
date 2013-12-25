using System;
using System.Collections.Generic;
using System.Linq;

class NaBabaMiSmetalnika
{
    const int Rows = 8;

    static void Main()
    {
        int width = int.Parse(Console.ReadLine());
        var matrix = InitializeMatrix(width);

        ExecuteCommands(matrix);

        Console.WriteLine(CalculateSum(matrix));
    }

    static List<int[]> InitializeMatrix(int width)
    {
        var matrix = new List<int[]>();

        for (int i = 0; i < Rows; i++)
        {
            var input = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(width, '0');
            matrix.Add(input.Select(ch => ch - '0').ToArray());
        }

        return matrix;
    }

    static void ExecuteCommands(List<int[]> matrix)
    {
        string command = Console.ReadLine();

        while (!command.Equals("stop"))
        {
            switch (command)
            {
                case "right": MoveDigits(matrix, true); break;
                case "left": MoveDigits(matrix, false); break;
                case "reset": ResetMatrix(matrix); break;
            }

            command = Console.ReadLine();
        }
    }
  
    static void MoveDigits(List<int[]> matrix, bool moveToRight)
    {
        int line = int.Parse(Console.ReadLine());
        int position = int.Parse(Console.ReadLine());

        position = position < 0 ? 0 : position;
        position = position >= matrix[line].Length ? matrix[line].Length - 1 : position;    

        if (moveToRight)
        {
            Array.Sort(matrix[line], position, matrix[line].Length - position);
        }
        else
        {
            Array.Reverse(matrix[line]);
            Array.Sort(matrix[line], matrix[line].Length - position - 1, position + 1);
            Array.Reverse(matrix[line]);
        }
    }
  
    static void ResetMatrix(List<int[]> matrix)
    {
        for (int i = 0; i < matrix.Count; i++)
            matrix[i] = matrix[i].OrderByDescending(a => a).ToArray();
    }

    static long CalculateSum(List<int[]> matrix)
    {
        long sum = 0;

        foreach (var array in matrix)
            sum += Convert.ToInt64(string.Join("", array), 2);

        return sum * GetNumberOfEmptyColumns(matrix);
    }

    static int GetNumberOfEmptyColumns(List<int[]> matrix)
    {
        int numberOfEmptyColumns = 0;

        for (int col = 0; col < matrix[0].Length; col++)
        {
            bool isEmpty = true;

            for (int row = 0; row < matrix.Count; row++)
            {
                if (matrix[row][col] != 0)
                {
                    isEmpty = false;
                    break;
                }
            }

            if (isEmpty)
            {
                numberOfEmptyColumns++;
            }
        }

        return numberOfEmptyColumns;
    }
}