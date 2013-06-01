using System;
using System.Linq;

class ÅncryptedSMS
{
    static void Main()
    {
        string word = Console.ReadLine();

        string encryptedWord = string.Empty;

        if (word.Length > 1)
        {
            encryptedWord = "" + word[0] + word[1] + word[0];

            for (int i = 2; i < word.Length; i++)
            {
                encryptedWord += word[i] + encryptedWord;
            }
        }
        else
        {
            encryptedWord = word;
        }

        Console.WriteLine(encryptedWord);
    }
}