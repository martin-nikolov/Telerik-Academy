/*
* 9. Write a program that prints an isosceles triangle of 9 copyright symbols ©.
* Use Windows Character Map to find the Unicode code of the © symbol.
* Note: the © symbol may be displayed incorrectly.
*/

using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        int thighLength = 3;
        char specialSymbol = '©';
        //Console.Write("Enter length of triangle's thigh: ");
        //thighLength = int.Parse(Console.ReadLine());

        int cols = thighLength * 2 - 1; // length of hypotenuse
        int symbolOnRow = 1; // increasing with 2 on every row

        Console.WriteLine("Isosceles triangle built with the symbol " + specialSymbol + ":\n");

        for (int col = 1; col <= thighLength; col++)
        {
            int blankSpaces = cols - symbolOnRow / 2;

            Console.Write(new string(' ',blankSpaces));
            Console.WriteLine(new string(specialSymbol,symbolOnRow));

            symbolOnRow = symbolOnRow + 2;
        }

        Console.WriteLine();
    }
}