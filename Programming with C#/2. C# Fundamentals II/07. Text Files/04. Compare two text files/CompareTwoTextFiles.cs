/*
* 4. Write a program that compares two text files line by line
* and prints the number of lines that are the same and the number
* of lines that are different. Assume the files have equal number of lines.
*/

using System;
using System.IO;
using System.Linq;

class CompareTwoTextFiles
{
    static int sameLinesCount = 0, diffLinesCount = 0;

    static void Main()
    {
        string pathText1 = "../../text1.txt";
        string pathText2 = "../../text2.txt";

        CompareTextFiles(pathText1, pathText2);

        Console.WriteLine("Same lines: {0}", sameLinesCount);
        Console.WriteLine("Different lines: {0}\n", diffLinesCount);
    }

    static void CompareTextFiles(string pathText1, string pathText2)
    {
        using (StreamReader reader1 = new StreamReader(pathText1))
        {
            using (StreamReader reader2 = new StreamReader(pathText2))
            {
                // Text files have equal number of lines
                while (!reader1.EndOfStream || !reader2.EndOfStream)
                {
                    string line1 = reader1.ReadLine();
                    string line2 = reader2.ReadLine();

                    if (line1.CompareTo(line2) == 0) sameLinesCount++;
                    else diffLinesCount++;
                }
            }
        }
    }
}