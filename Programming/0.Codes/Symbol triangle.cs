using System;
using System.Text;

class Triangle
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;

        Console.WriteLine("Please enter the row count!");
        int rows = int.Parse(Console.ReadLine());

        int cells = (rows * 2) - 1;
        int symbolIncrement = 1; // Symbol magnifier
        int blankSpacesOnRow; // Blank spaces on row
        int symbolsOnRow; // Symbols on row

        for (int row = 0; row < rows; row++)
        {
            blankSpacesOnRow = cells - symbolIncrement; // Define total blank spaces on current row
            symbolsOnRow = cells - blankSpacesOnRow; // Define total symbols on current row

            string blankSpaces = new String(' ', blankSpacesOnRow / 2); // Black spaces on left
            string symbols = new String('©', symbolsOnRow);

            Console.Write("{0}{1}", blankSpaces, symbols);

            symbolIncrement = symbolIncrement + 2; // Increasing symbols on every row
            Console.WriteLine();
        }
    }
}