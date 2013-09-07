using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class BasicLanguage
{
    static List<string> commands = new List<string>();

    static void Main()
    {
        SeparateCommands();

        Console.WriteLine(EvaluateCommands());
    }

    static void SeparateCommands()
    {
        StringBuilder result = new StringBuilder();

        while (true)
        {
            string line = Console.ReadLine();

            for (int i = 0; i < line.Length; i++)
            {
                result.Append(line[i]);

                if (line[i] == ';')
                {
                    commands.Add(result.ToString());
                    result.Clear();
                    continue;
                }
            }

            result.AppendLine();

            if (line.Contains("EXIT;")) break;
        }
    }

    static StringBuilder EvaluateCommands()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < commands.Count; i++)
        {
            string[] subCommands = commands[i].Split(')');
            int repeat = 1;

            for (int j = 0; j < subCommands.Length; j++)
            {
                string sub = subCommands[j].TrimStart();

                if (sub.StartsWith("FOR"))
                {
                    int[] intervals = subCommands[j].Substring(subCommands[j].IndexOf('(') + 1).Split(',').Select(ch => int.Parse(ch)).ToArray();

                    if (intervals.Length == 1) repeat = repeat * intervals[0];
                    else repeat = repeat * (intervals[1] - intervals[0] + 1);
                }
                else if (sub.StartsWith("PRINT"))
                {
                    string message = subCommands[j].Substring(subCommands[j].IndexOf('(') + 1);

                    for (int k = 0; k < repeat && repeat > 0; k++) result.Append(message);
                }
            }
        }

        return result;
    }
}