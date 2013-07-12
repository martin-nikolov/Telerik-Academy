/*
* 8. Modify the solution of the previous problem to replace only whole words (not substrings).
*/

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class ReplaceWholeWords
{
    static void Main()
    {
        string pathText = "../../text.txt";
        string pathResult = "../../result.txt";

        ReplaceAllWholeWords(pathText, pathResult);
    }

    static void ReplaceAllWholeWords(string pathText, string pathResult)
    {
        using (StreamWriter result = new StreamWriter(pathResult))
        {
            using (StreamReader reader = new StreamReader(pathText))
            {
                while (!reader.EndOfStream)
                    result.WriteLine(Regex.Replace(reader.ReadLine(), @"\bstart\b", "finish"));
            }
        }
    }
}