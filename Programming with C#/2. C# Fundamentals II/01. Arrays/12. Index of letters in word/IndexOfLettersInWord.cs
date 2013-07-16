/*
* 12. Write a program that creates an array containing all letters
* from the alphabet (A-Z). Read a word from the console and
* print the index of each of its letters in the array.
*/

using System;
using System.Linq;

class IndexOfLettersInWord
{
    static void Main()
    {
        int[] letters = new int[26];
        for (char i = 'A'; i <= 'Z'; i++) letters[i - 65] = i;

        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

        for (int i = 0; i < word.Length; i++)
            Console.WriteLine("Letter '{0}' -> index: {1} / ASCII Index: {2}", word[i],
                Array.IndexOf(letters, char.ToUpperInvariant(word[i])), (int)word[i]);
    }
}