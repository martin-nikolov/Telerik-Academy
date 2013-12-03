using System;
using System.Collections.Generic;

class GenomeDecoder
{
    static List<Letters> letters = new List<Letters>();
    static List<string> result = new List<string>();

    static void Main()
    {
        string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int lettersPerLine = int.Parse(tokens[0]);
        int group = int.Parse(tokens[1]);

        string input = Console.ReadLine();

        SeparateLetters(input);
        Decode(lettersPerLine, group);
        AddLineIndicators();

        foreach (var item in result) Console.WriteLine(item);
    }

    static void AddLineIndicators()
    {
        int numberOfSpaces = (result.Count).ToString().Length - 1;

        for (int i = 0; i < result.Count; i++)
        {
            if (i == 9 || i == 99 || i == 999 || i == 9999 || i == 99999) numberOfSpaces--;

            result[i] = result[i].Insert(0, new string(' ', numberOfSpaces) + (i + 1) + " ");
        }
    }

    static void Decode(int lettersPerLine, int group)
    {
        string currentLine = string.Empty;
        int lettersCurrentLine = 0;

        for (int i = 0; i < letters.Count; i++)
        {
            while (true)
            {
                currentLine += letters[i].letter;
                letters[i] = new Letters(letters[i].letter, letters[i].count - 1);
                lettersCurrentLine++;

                if (lettersCurrentLine % group == 0)
                    currentLine += " ";

                if (lettersCurrentLine == lettersPerLine)
                {
                    result.Add(currentLine.Trim());
                    lettersCurrentLine = 0;
                    currentLine = string.Empty;
                }

                if (letters[i].count == 0) break;
            }
        }

        if (lettersCurrentLine > 0) result.Add(currentLine);
    }

    static void SeparateLetters(string input)
    {
        int count = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                count = count * 10 + (input[i] - '0');
            }
            else if (char.IsLetter(input[i]))
            {
                if (count == 0) count = 1;

                letters.Add(new Letters(input[i], count));
                count = 0;
            }
        }
    }

    struct Letters
    {
        public char letter;
        public int count;

        public Letters(char letter, int count)
        {
            this.letter = letter;
            this.count = count;
        }
    }
}