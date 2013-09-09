using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class CSharpBrackets
{
    static List<string> cleanCode = new List<string>();

    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        string separator = Console.ReadLine();

        List<string> list = new List<string>();

        for (int i = 0; i < lines; i++)
            list.Add(Regex.Replace(Console.ReadLine(), @"\s+", " ").ToString().Trim());

        FormatCode(list, separator);

        foreach (var line in cleanCode)
            Console.WriteLine(line);
    }

    static void FormatCode(List<string> list, string separator)
    {
        int space = 0;
        string text = string.Empty;

        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list[i].Length; j++)
            {
                if (list[i][j] == '{')
                {
                    text = text.Trim();

                    if (!string.IsNullOrEmpty(text)) cleanCode.Add(Separator(separator, space) + text);

                    cleanCode.Add(Separator(separator, space++) + "{");

                    text = string.Empty;
                }
                else if (list[i][j] == '}')
                {
                    if (!string.IsNullOrEmpty(text)) cleanCode.Add(Separator(separator, space) + text.Trim());

                    cleanCode.Add(Separator(separator, --space) + "}");

                    text = string.Empty;
                }
                else
                {
                    text += list[i][j];
                }
            }

            if (!string.IsNullOrWhiteSpace(text))
            {
                cleanCode.Add(Separator(separator, space) + text.Trim());
                text = string.Empty;
            }
        }
    }

    static string Separator(string separator, int space)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < space; i++) result.Append(separator);

        return result.ToString();
    }
}