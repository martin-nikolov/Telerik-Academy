/*
* 4. Declare an integer variable and assign it with the value 254
* in hexadecimal format. Use Windows Calculator to find its
* hexadecimal representation.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        int hex = 0x254; // 596 in decimal
        Console.WriteLine("Hexadecimal number {0:X} in decimal format {0}.", hex);
    }
}