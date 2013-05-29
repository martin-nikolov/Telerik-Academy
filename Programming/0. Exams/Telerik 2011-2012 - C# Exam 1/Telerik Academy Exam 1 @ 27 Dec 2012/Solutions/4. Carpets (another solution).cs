using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int middle = n / 2;

        for (int _row = 1, row = 1; row <= n; _row += row < middle ? 1 : row == middle ? 0 : -1, row++)
        {
            Console.Write(new String('.', middle - _row));

            for (int i = 1; i <= _row; i++) Console.Write(i % 2 == 0 ? " " : row > middle ? "\\" : "/");

            for (int i = _row; i >= 1; i--) Console.Write(i % 2 == 0 ? " " : row > middle ? "/" : "\\");

            Console.Write(new String('.', middle - _row));

            Console.WriteLine();
        }
    }
}