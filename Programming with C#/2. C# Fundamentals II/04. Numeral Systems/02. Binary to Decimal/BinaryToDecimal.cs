/*
* 2. Write a program to convert binary numbers to their decimal representation.
*/

using System;
using System.Linq;

class BinaryToDecimal
{
    static void Main()
    {
        Console.Write("Enter a binary number: ");
        string binary = Console.ReadLine();

        Console.WriteLine("\n{0} to decimal => {1}\n", binary, ConvertToDecimal(binary));
    }

    static long ConvertToDecimal(string binary)
    {
        long decimalNumber = 0;

        for (int i = binary.Length - 1, pow = 1; i >= 0; i--, pow *= 2)
            decimalNumber += (binary[i] - '0') * pow;

        return decimalNumber;
    }
}