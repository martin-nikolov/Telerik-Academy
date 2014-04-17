/*
 * 8. Modify the above program to check whether a path exists
 * between two cells without finding all possible paths. 
 * Test it over an empty 100 x 100 matrix.
 */

using System;
using System.Linq;
using System.Text;

class ExistsPathInLabyrinth
{
    static readonly char[,] testLab =
    {
        { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
        { '*', '*', ' ', '*', ' ', '*', ' ' },
        { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
        { ' ', '*', '*', '*', '*', '*', ' ' },
        { ' ', ' ', ' ', ' ', ' ', ' ', 'e' },
    };

    static char[] path = new char[testLab.GetLongLength(0) * testLab.GetLongLength(1)];

    const char PassableCell = ' ';
    const char NonPassableCell = '*';
    const char FinalCell = 'e';

    static void Main()
    {
        bool existsPath = false;
        FindAllPaths(testLab, 0, 0, ref existsPath);
        Console.WriteLine(PrintResult(existsPath));

        TestWithEmptyMatrix100x100();
    }

    static void FindAllPaths(char[,] labyrinth, int row, int col, ref bool existsPath, int index = 1, char dir = ' ')
    {
        if (existsPath || !IsCellPassable(labyrinth, row, col))
        {
            return;
        }

        if (labyrinth[row, col] == FinalCell)
        {
            existsPath = true;
            return;
        }

        path[index - 1] = dir;
        labyrinth[row, col] = NonPassableCell;

        FindAllPaths(labyrinth, row - 1, col, ref existsPath, index + 1, 'U');  // Up
        FindAllPaths(labyrinth, row + 1, col, ref existsPath, index + 1, 'D');  // Down
        FindAllPaths(labyrinth, row, col - 1, ref existsPath, index + 1, 'L');  // Left
        FindAllPaths(labyrinth, row, col + 1, ref existsPath, index + 1, 'R');  // Right

        path[index - 1] = existsPath ? path[index - 1] : ' ';
        labyrinth[row, col] = PassableCell;
    }

    static bool IsCellPassable(char[,] labyrinth, int row, int col)
    {
        return row >= 0 && row < labyrinth.GetLongLength(0) &&
               col >= 0 && col < labyrinth.GetLongLength(1) &&
               labyrinth[row, col] != NonPassableCell;
    }

    static string PrintResult(bool existsPath)
    {
        if (!existsPath)
            return "Path does not exists!";

        var result = new StringBuilder();
        int pathLength = 1;

        for (int i = 1; i < path.Length && path[i] != '\0'; i++, pathLength++)
            result.Append(path[i] + " ");

        return string.Format("Path exists -> cells length: {0} -> Direction: {1}{2}\n",
            pathLength + 1, result.ToString().Substring(0, pathLength >= 250 ? 250 : pathLength),
            pathLength >= 250 ? "..." : "");
    }

    static void TestWithEmptyMatrix100x100()
    {
        const int N = 100;
        bool existsPath = false;

        char[,] matrix = new char[N, N];
        path = new char[N * N];

        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                matrix[i, j] = ' ';

        matrix[99, 99] = FinalCell;

        FindAllPaths(matrix, 0, 0, ref existsPath);
        Console.WriteLine(PrintResult(existsPath));
    }
}