/*
* 12. We are given integer number n, value v (v=0 or 1) and a
* position p. Write a sequence of operators that modifies
* n to hold the value v at the position p from the binary
* representation of n.
* Example: n = 5 (00000101), p=3, v=1 -> 13 (00001101)
* n = 5 (00000101), p=2, v=0 -> 1 (00000001)
*/

using System;
using System.Linq;

class ChangeBitAtSpecificPosition
{
    static int ChangeBitAtPosition(int number, byte bit, byte bitPosition)
    {
        // Extract the bit at 'bitPosition' position
        // if it is same as 'bit' -> takes value 0
        // else -> takes value 1
        byte firstBit = (byte)(((number >> bitPosition) & 1) ^ bit);

        // Move 'firstBit' (0 or 1) 'bitPosition' positions on left
        // then apply XOR ^ number
        return number ^ (firstBit << bitPosition);
        // Other way -> n = (v == 0) ? (n & ~(1 << p)) : (n | 1 << p);
    }

    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Enter bit's position: ");
        byte bitPosition = byte.Parse(Console.ReadLine());

        byte bit = 0;
        do
        {
            Console.Write("Enter bit (0 or 1): ");
        }
        while (!byte.TryParse(Console.ReadLine(), out bit) || (bit != 0 && bit != 1));

        Console.WriteLine("\nNew number -> {0}\n", ChangeBitAtPosition(number, bit, bitPosition));
    }
}