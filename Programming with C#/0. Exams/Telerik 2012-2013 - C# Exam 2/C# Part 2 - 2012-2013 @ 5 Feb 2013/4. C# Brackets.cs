using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class CSharpBrackets
{
    static List<string> unformatted = new List<string>();
    static List<string> formatted = new List<string>();
    static int repeats = 0;
    static string separator;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        separator = Console.ReadLine();

        for (int i = 0; i < n; i++) unformatted.Add(Regex.Replace(Console.ReadLine(), @"\s+", " "));

        foreach (var line in unformatted)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '{')
                {
                    formatted.Add(AddLine("{", repeats++));
                }
                else if (line[i] == '}')
                {
                    formatted.Add(AddLine("}", --repeats));
                }
                else
                {
                    string remains = string.Empty;

                    while (i < line.Length && line[i] != '{' && line[i] != '}') remains += line[i++];
                    i--;

                    if (!string.IsNullOrWhiteSpace(remains))
                        formatted.Add(AddLine(remains.TrimStart().TrimEnd(), repeats));
                }
            }
        }

        Console.WriteLine(string.Join("\n", formatted));
    }

    static string AddLine(string text, int repeat)
    {
        StringBuilder line = new StringBuilder();

        for (int i = 0; i < repeat; i++) line.Append(separator);

        line.Append(text);

        return line.ToString();
    }
}