/*
* 6. Write a program that reads from the console a string of maximum 20 characters.
* If the length of the string is less than 20, the rest of the characters 
* should be filled with '*'. Print the result string into the console.
*/

using System;
using System.Linq;

class StringFilledWithStars
{
    static void Main()
    {
        Console.Write("Enter a string (maximum 20 characters): ");
        string word = Console.ReadLine();

        Console.WriteLine("\nResult: {0}\n", word.PadRight(20, '*'));
    }
}