/*
 * 3. Write a program that counts how many times each word from 
 * given text file words.txt appears in it. The character casing 
 * differences should be ignored. The result words should be
 * ordered by their number of occurrences in the text. 
 * 
 * Example:
 *  is -> 2
 *  the -> 2
 *  this -> 3
 *  text -> 6
 */

namespace AbstractDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Utility;

    public class OccurrencesOfWordsInText
    {
        public static void Main()
        {
            var fileContent = ConsoleUtility.GetFileTextContent("../../words.txt");
            var extractedWords = ExtractWords(fileContent);
            var occurrences = FindElementsOccurrences(extractedWords);

            ConsoleUtility.PrintDictionaryElements(occurrences);
        }

        public static IList<string> ExtractWords(string text, string regex = "[a-zA-Z]+")
        {
            var matches = Regex.Matches(text, regex);
            return matches.Cast<Match>().Select(m => m.Value).ToList();
        }

        public static IDictionary<string, int> FindElementsOccurrences(IList<string> collection)
        {
            var dict = new Dictionary<string, int>(new CaseInsensitiveComparer());

            for (int i = 0; i < collection.Count; i++)
            {
                if (!dict.ContainsKey(collection[i]))
                {
                    dict[collection[i]] = 0;
                }

                dict[collection[i]]++;
            }

            var sortedElements = dict.OrderBy(x => x.Value)
                                     .ToDictionary(x => x.Key.ToLower(), x => x.Value);
            return sortedElements;
        }
    }
}