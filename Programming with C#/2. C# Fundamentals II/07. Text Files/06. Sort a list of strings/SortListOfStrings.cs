/*
* 6. Write a program that reads a text file containing a list of strings,
* sorts them and saves them to another text file.
* 
*         _________________________
*         |         Example:      |
*         |                       |
*         | Ivan		   George |
*         | Peter		   Ivan   |
*         | Maria   ---->  Maria  |
*         | George	       Peter  |
*         |_______________________|
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class SortListOfStrings
{
    static List<string> strings = new List<string>();

    static void Main()
    {
        string pathText = "../../strings.txt";
        string pathResult = "../../result.txt";

        SeparateStringsFromTextFile(pathText);

        Console.WriteLine("Strings: {0}", string.Join(", ", strings));

        strings.Sort();
        SaveSortedStringsToTextFile(pathResult);

        Console.WriteLine("\nSorted strings: {0}\n", string.Join(", ", strings));
    }

    static void SeparateStringsFromTextFile(string pathText)
    {
        using (StreamReader reader = new StreamReader(pathText))
        {
            while (!reader.EndOfStream)
            {
                string[] tokens = reader.ReadLine().Split(new char[] { ' ', ',', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < tokens.Length; i++)
                    strings.Add(tokens[i]);
            }
        }
    }

    static void SaveSortedStringsToTextFile(string pathResult)
    {
        using (StreamWriter result = new StreamWriter(pathResult))
        {
            for (int i = 0; i < strings.Count; i++)
                result.WriteLine(strings[i]);
        }
    }
}