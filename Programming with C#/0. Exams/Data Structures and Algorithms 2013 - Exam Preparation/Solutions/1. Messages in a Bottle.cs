using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class MessagesInBottle
{
    static Dictionary<string, string> values = new Dictionary<string, string>();
    static List<string> answers = new List<string>();
    
    static void Main()
    {
        string encodedCipher = Console.ReadLine();
        string cipher = Console.ReadLine();

        var letters = Regex.Matches(cipher, @"[A-Z]");
        var digits = Regex.Matches(cipher, @"\d+");

        for (int i = 0; i < letters.Count; i++) values[letters[i].Value] = digits[i].ToString();

        FindAllMessages(encodedCipher, string.Empty);

        answers.Sort();
        Console.WriteLine(answers.Count);

        foreach (var item in answers) Console.WriteLine(item);
    }

    static void FindAllMessages(string cipher, string str)
    {
        if (cipher.Length == 0)
        {
            answers.Add(str);
        }
        else
        {
            foreach (KeyValuePair<string, string> value in values)
                if (cipher.StartsWith(value.Value)) FindAllMessages(cipher.Substring(value.Value.Length), str + value.Key);
        }
    }
}