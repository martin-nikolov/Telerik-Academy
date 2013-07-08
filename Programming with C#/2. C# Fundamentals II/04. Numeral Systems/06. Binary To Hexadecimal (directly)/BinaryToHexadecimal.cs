/*
* 6. Write a program to convert binary numbers to hexadecimal numbers (directly).
*/

using System;
using System.Linq;

class BinaryToHexadecimal
{
    static void Main()
    {
        Console.Write("Enter a binary number: ");
        string binary = Console.ReadLine();

        Console.WriteLine("\n{0} to hexadecimal => {1}\n", binary, ConvertToHexadecimal(binary));
    }

    static string ConvertToHexadecimal(string binary)
    {
        string hex = string.Empty;

        for (int i = binary.Length - 1; i >= 0;)
        {
            int number = 0, j = 0;

            for (int pow = 1; j < 4 && i - j >= 0; j++, pow *= 2)
                number += (binary[i - j] - 48) * pow;

            i -= j;

            hex = number >= 10 ? (char)('A' + number - 10) + hex : number + hex;
        }

        return hex;
    }
}