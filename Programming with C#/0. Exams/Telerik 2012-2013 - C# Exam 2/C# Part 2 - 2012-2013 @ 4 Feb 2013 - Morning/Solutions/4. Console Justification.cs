using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ConsoleJustification
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        int limit = int.Parse(Console.ReadLine());
        string text = string.Empty;

        for (int i = 0; i < lines; i++)
            text += " " + Console.ReadLine();

        PrintLines(text, limit);
    }

    static void PrintLines(string content, int wordsLimit)
    {
        StringBuilder line = new StringBuilder();
        string[] topic = content.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int index = 0; index < topic.Length; index++)
        {
            if (line.Length + topic[index].Length > wordsLimit)
            {
                Console.WriteLine(AddSpaces(line, wordsLimit));
                line.Clear();
            }

            line.Append(topic[index] + " ");
        }

        Console.WriteLine(AddSpaces(line, wordsLimit)); // Prints last line
    }

    static StringBuilder AddSpaces(StringBuilder line, int wordsLimit)
    {
        line.Remove(line.Length - 1, 1); // Remove space at last position

        int spaceIndex = line.ToString().IndexOf(" ");
        int mostSpaces = 2;

        while (wordsLimit - line.Length > 0 && spaceIndex != -1)
        {
            line.Insert(spaceIndex, ' ');

            spaceIndex = line.ToString().IndexOf(new string(' ', mostSpaces - 1), spaceIndex + 2);

            if (spaceIndex == -1) spaceIndex = line.ToString().IndexOf(new string(' ', mostSpaces++), 0);
        }

        return line;
    }
}