/*
* 10. Write a boolean expression that returns if the bit at position
* p (counting from 0) in a given integer number v has value
* of 1. Example: v=5; p=1 -> false.
*/

using System;
using System.Linq;

class BitAtPosition
{
    static bool IsBitOne(int number, byte bitPosition)
    {
        byte bit = (byte)((number >> bitPosition) & 1);

        return bit == 1 ? true : false;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Enter bit's position: ");
        byte bitPosition = byte.Parse(Console.ReadLine());

        Console.WriteLine("\nBit at position {0} of number {1} is 1: {2}\n", bitPosition, number, IsBitOne(number, bitPosition));
    }
}