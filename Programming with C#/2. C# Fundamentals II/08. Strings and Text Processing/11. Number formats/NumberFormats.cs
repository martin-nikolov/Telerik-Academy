/*
* 11. Write a program that reads a number and prints it as a decimal
* number, hexadecimal number, percentage and in scientific notation.
* Format the output aligned right in 15 symbols.
*/

using System;
using System.Linq;

class NumberFormats
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("\n{0,15} - Decimal", number); 
        Console.WriteLine("{0,15:X} - Hexadecimal", number);
        Console.WriteLine("{0,15:P} - Percentage", number); 
        Console.WriteLine("{0,15:E} - Scientific format\n", number); 
    }
}