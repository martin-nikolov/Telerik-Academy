/*
 * 3. Write a program that counts how many times each word from 
 * given text file words.txt appears in it. The character casing 
 * differences should be ignored. The result words should be
 * ordered by their number of occurrences in the text. 
 * 
 * Example:
 * is -> 2
 * the -> 2
 * this -> 3
 * text -> 6
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class OccurrencesOfWordsInText
{
    static void Main()
    {
        var fileContent = GetFileTextContent("../../words.txt");
 
        var elements = ExtractWords(fileContent);

        var occurrences = FindElementsOccurrences(elements);

        PrintResult(occurrences);
    }

    static string GetFileTextContent(string fullPath)
    {
        if (!File.Exists(fullPath))
            throw new FileNotFoundException("File does not exist. File name: " + fullPath);

        string result = string.Empty;

        using (var reader = new StreamReader(fullPath))
        {
            result = reader.ReadToEnd();
        }

        return result;
    }

    static IList<string> ExtractWords(string text, string regex = "[a-zA-Z]+")
    {
        MatchCollection matches = Regex.Matches(text, regex);

        return matches.Cast<Match>().Select(m => m.Value).ToList();
    }

    static IDictionary<string, int> FindElementsOccurrences(IList<string> collection)
    {
        var dict = new SortedDictionary<string, int>(new CaseInsensitiveComparer());

        for (int i = 0; i < collection.Count; i++)
        {
            if (!dict.ContainsKey(collection[i]))
            {
                dict[collection[i]] = 0;
            }

            dict[collection[i]]++;
        }

        // Sorts by value and lowercase the keys in dictionary
        return dict.OrderBy(x => x.Value).ToDictionary(x => x.Key.ToLower(), x => x.Value);
    }

    static void PrintResult<T>(IDictionary<T, int> dict)
    {
        foreach (KeyValuePair<T, int> item in dict)
        {
            Console.WriteLine("{0} -> {1} time(s).", item.Key, item.Value);
        }
    }
}