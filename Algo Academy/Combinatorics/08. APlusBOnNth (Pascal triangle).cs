using System;
using System.Collections.Generic;
using System.Linq;

class APlusBOnNth
{
    static long[,] pascalTriangle;

    static void Main()
    {
        var expression = Console.ReadLine();
        char x = expression[1], y = expression[3];

        Console.ReadLine(); // Skip empty line in tests

        int N = int.Parse(Console.ReadLine()) + 1;
        pascalTriangle = new long[N, N];

        MakePascalTriangle(N);

        Console.WriteLine(StringifyPolynomial(N, x, y));
    }
  
    static string StringifyPolynomial(int N, char x, char y)
    {
        var result = new List<string>(N + 1);
        int xPower = N - 1, yPower = 0;

        for (int col = 0; col < N; col++, xPower--, yPower++)
        {
            var argument = pascalTriangle[N - 1, col];

            if (argument == 1) result.Add(string.Format("({0}^{1})", col == 0 ? x : y, N - 1));
            else result.Add(string.Format("{0}({1}^{2})({3}^{4})", argument, x, xPower, y, yPower));
        }

        return string.Join("+", result);
    }

    static void MakePascalTriangle(int N)
    {
        pascalTriangle[0, 0] = 1; // N will be > 0

        for (int i = 1; i < N; i++)
            for (int j = 0; j < N; j++)
                pascalTriangle[i, j] = (j == 0 || j == N - 1) ? 1 : pascalTriangle[i - 1, j - 1] + pascalTriangle[i - 1, j];
    }
}