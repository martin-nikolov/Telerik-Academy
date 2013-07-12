/*
* 1. Write a program that reads a text file and prints on the console its odd lines.
*/

using System;
using System.IO;
using System.Linq;

class PrintOddLines
{
    static void Main()
    {
        string path = "../../OddLines.txt";

        Console.WriteLine("> Prints odd lines of text file...\n");

        using (StreamReader reader = new StreamReader(path))
        {
            int lineCount = 1;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (lineCount++ % 2 != 0) Console.WriteLine(line);
            }
        }
    }
}