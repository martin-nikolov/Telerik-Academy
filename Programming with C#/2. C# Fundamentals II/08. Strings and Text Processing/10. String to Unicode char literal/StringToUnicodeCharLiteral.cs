/*
* 10. Write a program that converts a string to a sequence of C#
* Unicode character literals. Use format strings. 
* 
* Sample input:
* Hi!
* 
* Expected output:
* \u0048\u0069\u0021
*/

using System;
using System.Linq;

class StringToUnicodeCharLiteral
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string word = Console.ReadLine();

        Console.WriteLine("\nResult -> {0}\n", ConvertToUnicode(word));
    }
  
    static string ConvertToUnicode(string word)
    {
        string result = string.Empty;

        for (int i = 0; i < word.Length; i++)
            result += string.Format(@"\n{0:X4}", (int)word[i]);

        return result;
    }
}