/*
* 11. Write an expression that extracts from a given integer
* i the value of a given bit number b. Example: i=5; b=2 -> value=1.
*/

using System;
using System.Linq;

class ExtractBitAtPosition
{
    static byte BitAtPosition(int number, byte bitPosition)
    {
        byte bit = (byte)((number >> bitPosition) & 1);

        return bit;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Enter bit's position: ");
        byte bitPosition = byte.Parse(Console.ReadLine());

        Console.WriteLine("\nBit at position {0} of number {1} is {2}\n",
            bitPosition, number, BitAtPosition(number, bitPosition));
    }
}