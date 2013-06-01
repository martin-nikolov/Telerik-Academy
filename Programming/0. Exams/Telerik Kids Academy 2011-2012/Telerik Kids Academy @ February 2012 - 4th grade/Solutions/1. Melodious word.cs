using System;
using System.Collections.Generic;
using System.Linq;

class MelodiousWord
{
    static void Main()
    {
        List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u', 'y' };
        int vowelsInWord = 0;

        string word = Console.ReadLine();

        for (int i = 0; i < word.Length; i++)
        {
            if (vowels.Contains(word[i]))
            {
                vowelsInWord++;
            }
        }

        if (vowelsInWord == 2)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("{0} {1}", vowelsInWord, word.Length - vowelsInWord);
        }
    }
}