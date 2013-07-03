/*
* 5. Declare a character variable and assign it with the symbol that has
* Unicode code 72. Hint: first use the Windows Calculator to
* find the hexadecimal representation of 72.
*/

using System;

class CharacterWithCode48
{
    static void Main(string[] args)
    {
        char symbol = '\u0048'; // or (char)0x48
        Console.WriteLine("Symbol with Unicode code {0:X} is {1}.", (int)symbol, symbol);
    }
}