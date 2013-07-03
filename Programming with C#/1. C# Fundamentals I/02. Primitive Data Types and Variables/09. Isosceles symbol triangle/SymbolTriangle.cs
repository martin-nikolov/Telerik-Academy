/*
* 9. Write a program that prints an isosceles triangle of 9 copyright symbols ©.
* Use Windows Character Map to find the Unicode code of the © symbol.
* Note: the © symbol may be displayed incorrectly.
*/

using System;
using System.Text;

class SymbolTriangle
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        int thighLength = 5;
        char specialSymbol = '©';

        int cols = thighLength * 2 - 1; // length of hypotenuse
        int symbolOnRow = 1; // increasing with 2 on every row

        Console.WriteLine("Isosceles triangle built with the symbol " + specialSymbol + ":\n");

        for (int col = 1; col <= thighLength; col++)
        {
            int blankSpaces = cols - symbolOnRow / 2;

            Console.Write(new string(' ', blankSpaces));
            Console.WriteLine(new string(specialSymbol, symbolOnRow));

            symbolOnRow = symbolOnRow + 2;
        }

        Console.WriteLine();

        // Another way to display triangle
        for (int i = 1; i <= thighLength; i++)
        {
            Console.Write(new string(' ', thighLength + 5 - i)); // add white spaces
            
            for (int j = 1; j <= i; j++)
            {
                Console.Write("{0} ", specialSymbol);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
