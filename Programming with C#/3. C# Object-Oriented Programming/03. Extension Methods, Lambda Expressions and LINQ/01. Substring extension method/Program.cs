/*
* 1. Implement an extension method Substring(int index, int length)
* for the class StringBuilder that returns new StringBuilder and
* has the same functionality as Substring in the class String.
*/

using System;
using System.Text;
using Extensions;

class Program
{
    static void Main()
    {
        StringBuilder text = new StringBuilder();
        text.Append("The StringBuilder class represents a mutable string of characters. ");
        text.Append("This class cannot be inherited.");

        Console.WriteLine("#1: {0}\n", text.Substring(0));

        Console.WriteLine("#2: {0}\n", text.Substring(0, 0));

        Console.WriteLine("#3: {0}\n", text.Substring(67));

        //Console.WriteLine("#4: {0}\n", text.Substring(-1)); // throws an exception

        //Console.WriteLine("#5: {0}\n", text.Substring(0, -5)); // throws an exception

        //Console.WriteLine("#6: {0}\n", text.Substring(-1, 5)); // throws an exception

        //Console.WriteLine("#7: {0}\n", text.Substring(-1, -5)); // throws an exception
    }
}