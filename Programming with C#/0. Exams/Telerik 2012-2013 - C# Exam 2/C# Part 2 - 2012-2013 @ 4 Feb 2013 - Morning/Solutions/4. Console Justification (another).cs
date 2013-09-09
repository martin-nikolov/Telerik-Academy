using System;
using System.Collections.Generic;
using System.Text;

class ConsoleJustification
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        int letterLimit = int.Parse(Console.ReadLine());
        List<string> formatted = new List<string>();

        StringBuilder text = new StringBuilder();

        for (int i = 0; i < lines; i++) text.AppendFormat("{0} ", Console.ReadLine());

        string[] words = text.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        AddWordsToList(letterLimit, ref formatted, ref words);

        AddSpacesBetweenWords(letterLimit, ref formatted);

        Console.WriteLine(string.Join("\n", formatted));
    }

    static void AddSpacesBetweenWords(int letterLimit, ref List<string> formatted)
    {
        for (int i = 0; i < formatted.Count; i++)
        {
            int space = 1, index = 0;

            while (formatted[i].Length < letterLimit && index != -1)
            {
                index = formatted[i].IndexOf(new string(' ', space));

                while (index != -1 && formatted[i].Length < letterLimit && index != formatted[i].Length - 1)
                {
                    formatted[i] = formatted[i].Insert(index, " ");
                    index = formatted[i].IndexOf(new string(' ', space), index + space + 1);
                }

                space++;

                index = formatted[i].IndexOf(new string(' ', space));
            }
        }
    }

    static void AddWordsToList(int letterLimit, ref List<string> formatted, ref string[] words)
    {
        StringBuilder text = new StringBuilder();

        for (int i = 0; i < words.Length; i++)
        {
            text.Append(words[i]);

            if (text.Length + (i + 1 < words.Length ? words[i + 1].Length : 0) >= letterLimit)
            {
                formatted.Add(text.ToString());
                text = new StringBuilder();
            }
            else
            {
                text.Append(" ");
            }
        }

        formatted.Add(text.ToString().Trim());
    }
}