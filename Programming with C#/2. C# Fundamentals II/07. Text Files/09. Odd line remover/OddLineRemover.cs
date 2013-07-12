/*
* 9. Write a program that deletes from given text file all odd lines.
* The result should be in the same file.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class OddLineRemover
{
    static string pathText = "../../text.txt";

    static void Main()
    {
        WriteOddLines(ReadOddLines());
    }

    static List<string> ReadOddLines()
    {
        List<string> oddLines = new List<string>();
        int lineCount = 1;

        using (StreamReader reader = new StreamReader(pathText))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (lineCount++ % 2 == 0) oddLines.Add(line);
            }
        }

        return oddLines;
    }

    static void WriteOddLines(List<string> oddLines)
    {
        using (StreamWriter result = new StreamWriter(pathText))
        {
            for (int i = 0; i < oddLines.Count; i++)
                result.WriteLine(oddLines[i]);
        }
    }
}