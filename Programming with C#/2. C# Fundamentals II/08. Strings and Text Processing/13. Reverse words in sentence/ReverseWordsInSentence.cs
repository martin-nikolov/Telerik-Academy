/*
* 13. Write a program that reverses the words in given sentence.
* Example: 
* "C# is not C++ not PHP and not Delphi!" -> "Delphi not and PHP not C++ not is C#!".
*/

using System;
using System.Linq;

class ReverseWordsInSentence
{
    static void Main()
    {
        string text = "C# is not C++ not PHP and not Delphi!";

        // Text must contains sigh in the end('.', '!', '?' etc)
        char sigh = text[text.Length - 1];
        text = text.Remove(text.Length - 1, 1);

        string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Array.Reverse(words);

        Console.WriteLine("Result: {0}{1}\n", string.Join(" ", words), sigh);
    }
}