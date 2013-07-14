/*
* 24. Write a program that reads a list of words, separated by
* spaces and prints the list in an alphabetical order.
*/

using System;
using System.Linq;

class SortAlphabetical
{
    static void Main()
    {
        Console.Write("Enter a few words (separated by spaces): ");
        string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
       
        Array.Sort(words);

        Console.WriteLine("\nWords sorted in alphabetical order:\n{0}\n", 
            string.Join("\n", words.Select(x => string.Format("- {0}", x))));
    }
}