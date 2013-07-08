/*
* 5. Write a program to convert hexadecimal numbers to binary numbers (directly).
*/

using System;
using System.Linq;

class HexadecimalToBinary
{
    static void Main()
    {
        Console.Write("Enter a hexadecimal number: ");
        string hex = Console.ReadLine();

        Console.WriteLine("\n{0} to binary => {1}\n", hex, ConvertToBinary(hex.ToArray()));
    }

    static string ConvertToBinary(char[] hex)
    {
        // Makes all letters large
        for (int i = 0; i < hex.Length; i++)
            hex[i] = char.ToUpper(hex[i]);

        string binary = string.Empty;

        for (int i = hex.Length - 1; i >= 0; i--)
        {
            // Gets number
            int number = (hex[i] >= 'A') ? hex[i] - 'A' + 10 : hex[i] - '0';

            int digits = 0;

            // Convert to binary
            while (number > 0)
            {
                digits++;
                binary = number % 2 + binary;
                number /= 2;
            }

            binary = (i > 0 ? new string('0', 4 - digits) : "") + binary;
        }

        return binary;
    }
}