/*
* 11. Write a program that deletes from a text file all words that
* start with the prefix "test".
* Words contain only the symbols 0...9, a...z, A…Z, _.
*/

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class DeleteWordsWithPrefixTest
{
    static void Main()
    {
        string pathText = "../../text.txt";
        string pathResult = "../../result.txt";

        ExtractTextWithoutTags(pathText, pathResult);
    }

    static void ExtractTextWithoutTags(string pathText, string pathResult)
    {
        using (StreamWriter result = new StreamWriter(pathResult))
        {
            using (StreamReader reader = new StreamReader(pathText))
            {
                while (!reader.EndOfStream)
                {
                    string line = Regex.Replace(reader.ReadLine(), @"\btest\S*", String.Empty).Trim();
                    result.Write(line);
                }
            }
        }
    }
}