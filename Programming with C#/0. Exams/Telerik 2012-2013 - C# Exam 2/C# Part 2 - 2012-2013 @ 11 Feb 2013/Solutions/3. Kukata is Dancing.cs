using System;

class KukataIsDancing
{
    static int[] dirRow = { -1, 0, 1, 0 };
    static int[] dirCol = { 0, -1, 0, 1 };

    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
            Console.WriteLine(EvaluateSteps(Console.ReadLine()));
    }

    static string EvaluateSteps(string directions)
    {
        string color = string.Empty;
        int row = 1, col = 1, nextIndex = 0;

        for (int i = 0; i < directions.Length; i++)
        {
            switch (directions[i])
            {
                case 'L': nextIndex = (nextIndex + 1) % dirRow.Length; break;
                case 'R': nextIndex = (nextIndex + 3) % dirRow.Length; break;
                case 'W':
                    row = row + dirRow[nextIndex];
                    col = col + dirCol[nextIndex];
                    break;
            }

            row = (row < 0) ? 2 : (row > 2) ? 0 : row;
            col = (col < 0) ? 2 : (col > 2) ? 0 : col;
        }

        if (row == 1 && col == 1) color = "GREEN";
        else if (row == col || (row == 2 && col == 0) || (row == 0 && col == 2)) color = "RED";
        else color = "BLUE";

        return color;
    }
}
