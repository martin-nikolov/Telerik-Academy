/*
* 3. Write a program that reads a text file and inserts line numbers in front of 
* each of its lines.The result should be written to another text file.
*/

using System;
using System.IO;
using System.Linq;

class InsertTheNumberOfLine
{
    static void Main()
    {
        string pathText = "../../text.txt";
        string pathResult = "../../result.txt";

        InsertLinesToResultFile(pathText, pathResult);
        PrintResultContent(pathResult);
    }

    static void InsertLinesToResultFile(string pathText, string pathResult)
    {
        int lineCount = 1;

        using (StreamWriter result = new StreamWriter(pathResult))
        {
            using (StreamReader reader = new StreamReader(pathText))
            {
                while (!reader.EndOfStream) result.WriteLine("Line {0}: {1}", lineCount++, reader.ReadLine());
            }
        }
    }
    
    static void PrintResultContent(string path)
    {
        Console.WriteLine("> Result:\n");

        using (StreamReader reader = new StreamReader(path))
        {
            while (!reader.EndOfStream) Console.WriteLine(reader.ReadLine());
        }

        Console.WriteLine("\n> End of file...\n");
    }
}