/*
* 2. Write a program that concatenates two text files into another text file.
*/

using System;
using System.IO;
using System.Linq;

class ConcatTwoTextFiles
{
    static void Main()
    {
        string pathText1 = "../../text1.txt";
        string pathText2 = "../../text2.txt";
        string pathResult = "../../result.txt";

        ReadFileContent(pathText1, pathResult);
        ReadFileContent(pathText2, pathResult);

        PrintResultContent(pathResult);
    }

    static void ReadFileContent(string pathText, string pathResult)
    {
        using (StreamWriter result = new StreamWriter(pathResult, true))
        {
            using (StreamReader reader = new StreamReader(pathText))
            {
                while (!reader.EndOfStream) result.WriteLine(reader.ReadLine());
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