/*
* 7. Write a program that replaces all occurrences of the
* substring "start" with the substring "finish" in a text
* file. Ensure it will work with large files (e.g. 100 MB).
*/

using System;
using System.IO;
using System.Linq;

class ReplaceAllOccurrencesOfSubstring
{
    static void Main()
    {
        string pathText = "../../text.txt";
        string pathResult = "../../result.txt";

        ReplaceSubstrings(pathText, pathResult);
    }

    static void ReplaceSubstrings(string pathText, string pathResult)
    {
        using (StreamWriter result = new StreamWriter(pathResult))
        {
            using (StreamReader reader = new StreamReader(pathText))
            {
                while (!reader.EndOfStream)
                    result.WriteLine(reader.ReadLine().Replace("start", "finish"));
            }
        }
    }
}