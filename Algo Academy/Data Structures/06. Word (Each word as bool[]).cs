using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Words
{
    static List<bool[]> bitArrays = new List<bool[]>();

    static void Main()
    {
        GetWordsFromText();

        int K = int.Parse(Console.ReadLine());

        for (int i = 0; i < K; i++)
        {
            var word = Console.ReadLine();

            Console.WriteLine("{0} -> {1}", word, GetCount(ConvertToBitArray(word.ToLower())));
        }
    }

    static void GetWordsFromText()
    {
        var uniqueWords = new HashSet<string>();

        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            uniqueWords.UnionWith(Regex.Matches(Console.ReadLine().ToLower(), @"[a-z]+")
                                       .Cast<Match>()
                                       .Select(a => a.Value));
        }

        bitArrays = new List<bool[]>(uniqueWords.Select(a => ConvertToBitArray(a)));
    }

    static bool[] ConvertToBitArray(string word)
    {
        var bitArray = new bool[26];

        for (int i = 0; i < word.Length; i++)
            bitArray[(int)word[i] - 97] = true;

        return bitArray;
    }

    static int GetCount(bool[] bitArray)
    {
        int count = 0;

        for (int i = 0; i < bitArrays.Count; i++)
        {
            bool isCandidate = true;

            for (int j = 0; j < 26; j++)
            {
                if (bitArray[j] && !bitArrays[i][j])
                {
                    isCandidate = false;
                    break;
                }
            }

            if (isCandidate) count++;
        }

        return count;
    }
}