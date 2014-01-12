using System;
using System.Linq;

class FeaturingWithGrisko
{
    static readonly long[] FirstEleventhFactorials = { 0, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800 };
    static readonly int[] LettersDictionary = new int[26];

    static long numberOfValidWords = 0;

    static void Main()
    {
        string input = Console.ReadLine();

        InitializeLetterOccurs(input, LettersDictionary);

        bool containsUniqueElements = !LettersDictionary.Any(key => key > 1); // or ... = LetterOccurs.All(key => key == 1 || key == 0);

        if (containsUniqueElements)
        {
            numberOfValidWords = FirstEleventhFactorials[input.Length];
        }
        else
        {
            var generatedWord = new char[input.Length];
            GeneratePermutations(generatedWord, 0);
        }

        Console.WriteLine(numberOfValidWords);
    }
  
    static void InitializeLetterOccurs(string input, int[] collection)
    {
        foreach (var letter in input)
        {
            collection[letter - 'a']++;
        }
    }

    static bool IsValidWord(char[] letters)
    {
        for (int i = 0; i < letters.Length - 1; i++)
            if (letters[i] == letters[i + 1])
                return false;

        return true;
    }

    static void GeneratePermutations(char[] generatedWord, int index)
    {
        if (index == generatedWord.Length)
        {
            if (IsValidWord(generatedWord))
                numberOfValidWords++;

            return;
        }

        for (int i = 0; i < LettersDictionary.Length; i++)
        {
            if (LettersDictionary[i] != 0)
            {
                generatedWord[index] = (char)(i + 'a');

                LettersDictionary[i]--;
                GeneratePermutations(generatedWord, index + 1); 
                LettersDictionary[i]++;
            }
        }
    }
}