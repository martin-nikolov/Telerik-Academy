/*
* 13. Write a program that exchanges bits 3, 4 and 5
* with bits 24, 25 and 26 of given 32-bit unsigned integer.
*/

using System;
using System.Linq;

class BitExchange
{
    static uint ExchangeBits(uint number)
    {
        // 3, 4 and 5 bits
        byte first = (byte)((number >> 3) & 7); // ... & 111 (7 in dec) => gets 3 signs anytime

        // 24, 25, 26 bits
        byte second = (byte)((number >> 24) & 7); // ... & 111 (7 in dec) => gets 3 signs anytime

        // Example: 111 ^ 001 = 110
        // Intermediate point of comparison
        byte firstXORsecond = (byte)(first ^ second);

        number = (uint)(number ^ (firstXORsecond << 24));
        number = (uint)(number ^ (firstXORsecond << 3));

        return number;
    }
    
    static void Main(string[] args)
    {
        uint number = 1073709056;

        Console.WriteLine("Old number {0,-10} to binary -> {1}", number, Convert.ToString(number, 2).PadLeft(32, '0'));
        number = ExchangeBits(number);
        Console.WriteLine("New number {0,-10} to binary -> {1}", number, Convert.ToString(number, 2).PadLeft(32, '0'));
    }
}