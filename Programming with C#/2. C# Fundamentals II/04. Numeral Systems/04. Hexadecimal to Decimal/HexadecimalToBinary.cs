/*
* 4. Write a program to convert hexadecimal numbers to their decimal representation.
*/

using System;
using System.Linq;

class HexadecimalToDecimal
{
    static void Main()
    {
        Console.Write("Enter a hexadecimal number: ");
        string hex = Console.ReadLine();

        Console.WriteLine("\n{0} to decimal => {1}\n", hex, ConvertToDecimal(hex.ToArray()));
    }

    static long ConvertToDecimal(char[] hex)
    {
        for (int i = 0; i < hex.Length; i++)
            hex[i] = char.ToUpper(hex[i]);

        long decimalNumber = 0;

        for (int i = hex.Length - 1, pow = 1; i >= 0; i--, pow *= 16)
        {
            int remainder = (hex[i] >= 'A') ? hex[i] - 'A' + 10 : hex[i] - '0';

            decimalNumber += remainder * pow;
        }

        return decimalNumber;
    }
}