/*
* 20. Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
*/

using System;
using System.Linq;
using System.Text.RegularExpressions;

class ExtractAllPalindromes
{
    static void Main()
    {
        string text = "ABBA, palindrome. LAMAL! EXE...bqlhlqb ,,! THIS IS NOT PALINDROME";

        MatchCollection words = Regex.Matches(text, @"\b\w+\b");

        Console.WriteLine("Extracted palindromes from the sample text: ");

        foreach (var word in words)
            if (IsPalindrome(word.ToString())) Console.WriteLine("- " + word);

        Console.WriteLine();
    }

    static bool IsPalindrome(string word)
    {
        return Enumerable.SequenceEqual(word.ToCharArray(), word.ToCharArray().Reverse());
    }
}