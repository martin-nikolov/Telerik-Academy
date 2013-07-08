/*
* 3. Write a program to convert decimal numbers to their hexadecimal representation.
*/

using System;
using System.Linq;

class DecimalToHexadecimal
{
    static void Main()
    {
        Console.Write("Enter a non-negative number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("\n{0} to hexadecimal => {1}\n", number, ConvertToHexadecimal(number));
    }

    static string ConvertToHexadecimal(int number)
    {
        string hexadecimal = string.Empty;

        while (number > 0)
        {
            char remainder = (number % 16 >= 10) ? (char)('A' + number % 16 - 10) :
                             (char)(48 + number % 16);

            hexadecimal = remainder + hexadecimal;
            number /= 16;
        }

        return hexadecimal;
    }
}