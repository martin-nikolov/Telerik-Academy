using System;
using System.Linq;

class ExcelColumns
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        char[] letters = new char[n];
        long columnIndex = 0;

        for (int i = 0; i < letters.Length; i++)
        {
            letters[i] = char.Parse(Console.ReadLine());

            columnIndex = columnIndex + (letters[i] - 64) * (long)Math.Pow(26, n - i - 1);
        }
        Console.WriteLine(columnIndex);
    }
}