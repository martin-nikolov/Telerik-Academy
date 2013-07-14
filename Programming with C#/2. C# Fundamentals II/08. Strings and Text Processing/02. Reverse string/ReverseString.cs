/*
* 2. Write a program that reads a string, reverses it and prints the result at the console.
* Example: "sample" -> "elpmas".
*/

using System;
using System.Linq;

class ReverseString
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string str = Reverse(Console.ReadLine());
        Console.WriteLine("\nReversed string -> {0}\n", str);
    }

    static string Reverse(string str)
    {
        string tmp = string.Empty;

        for (int i = 0; i < str.Length; i++)
            tmp = str[i] + tmp;

        return tmp;
    }
}