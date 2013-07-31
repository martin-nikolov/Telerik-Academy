/*
* 8. Write a program that shows the binary representation of given 16-bit
* signed integer number (the C# type short).
*/

using System;
using System.Linq;
using System.Text;

class BinarySignedShortInteger
{
    // Program works for both positive and negative numbers.

    // Algorithm finds binary representation of negative numbers by "two's complement"
    // *This is number in reversed order to which is added (with addition) one.

    static void Main()
    {
        Console.Write("Enter a number in interval [{0}; {1}]: ", short.MinValue, short.MaxValue);
        short number = short.Parse(Console.ReadLine());

        Console.WriteLine("\n{0} to binary => {1}\n", number, ConvertToBinary(number));
    }

    static string ConvertToBinary(int number)
    {
        StringBuilder binary = new StringBuilder();

        bool negative = number < 0;

        if (negative) number = ~number;

        // Convert to binary
        while (number > 0)
        {
            binary.Append(number % 2);
            number /= 2;
        }

        if (negative) InverseBits(binary);

        Reverse(binary);

        return binary.Length == 0 ? "0" : binary.ToString(); 
    }

    static void InverseBits(StringBuilder binary)
    {
        binary.Append(new string('0', 16 - binary.Length));

        for (int i = 0; i < binary.Length; i++)
            binary[i] = (binary[i] == '0') ? '1' : '0';
    }

    static void Reverse(StringBuilder binary)
    {
        for (int i = 0; i < binary.Length / 2; i++)
        {
            char swap = binary[i];
            binary[i] = binary[binary.Length - i - 1];
            binary[binary.Length - i - 1] = swap;
        }
    }
}