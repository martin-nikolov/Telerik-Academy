/*
* 12. Find online more information about ASCII (American Standard Code for Information Interchange)
* and write a program that prints the entire ASCII table of characters on the console.
*/

using System;
using System.Text;

class ASCII
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        string ASCII = @"ASCII includes definitions for 128 characters: 33 are non-printing control characters
that affect how text and space are processed and 95 printable characters, including the space.";
        Console.WriteLine(ASCII);
        Console.WriteLine("\nList of all visible ASCII symbols: ");

        StringBuilder tableASCII = new StringBuilder();

        for (byte symbol = 33; symbol <= 126; symbol++)
        {
            if ((symbol + 3) % 6 == 0)
                tableASCII.AppendLine();
                
            tableASCII.AppendFormat("{0:000}: {1,-8}", symbol, (char)symbol);
        }

        Console.WriteLine(tableASCII + Environment.NewLine);
    }
}