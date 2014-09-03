/*
 * 3. Write a program that finds a set of words (e.g. 1000 words)
 * in a large text (e.g. 100 MB text file). 
 * Print how many times each word occurs in the text.
 * Hint: you may find a C# trie in Internet.
 */

namespace AdvancedDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using rmandvikar.Trie;

    public class TrieTest
    {
        private static readonly Stopwatch sw = new Stopwatch();
        private static readonly Random rnd = new Random();

        public static void Main()
        {
            var trie = TrieFactory.GetTrie();

            var words = GenerateRandomWords(1000000);
            var uniqueWords = new HashSet<string>(words);

            AddWordsToTrie(words, trie);
            GetCountOfAllUniqueWords(uniqueWords, trie);
        }

        private static ICollection<string> GenerateRandomWords(int count)
        {
            Console.Write("Generation random words... ");
            sw.Start();

            var words = new List<string>(count);

            for (int i = 0; i < count; i++)
            {
                words.Add(GetRandomWord());
            }

            sw.Stop();
            Console.WriteLine("\rGeneration random words -> Total words: {0} | Elapsed time: {1}\n", words.Count, sw.Elapsed);
            sw.Reset();

            return words;
        }

        private static string GetRandomWord()
        {
            var newWord = new char[rnd.Next(3, 7)];

            for (int i = 0; i < newWord.Length; i++)
            {
                newWord[i] = ((char)rnd.Next(97, 122));
            }

            return new string(newWord);
        }

        private static void AddWordsToTrie(ICollection<string> words, ITrie trie)
        {
            Console.Write("Adding words to trie... ");
            sw.Start();

            foreach (var word in words)
            {
                trie.AddWord(word);
            }

            sw.Stop();
            Console.WriteLine("\rAdding words to trie -> Elapsed time: {1}\n", words.Count, sw.Elapsed);
            sw.Reset();
        }

        private static void GetCountOfAllUniqueWords(ICollection<string> wordsForSearcing, ITrie trie)
        {
            Console.Write("Searching words... ");
            sw.Start();

            foreach (var word in wordsForSearcing)
            {
                trie.WordCount(word); // return the number of words    
            }

            sw.Stop();
            Console.WriteLine("\rSearching words -> Unique words: {0} | Elapsed time: {1}\n", wordsForSearcing.Count, sw.Elapsed);
            sw.Reset();
        }
    }
}