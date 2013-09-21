using System;
using System.Collections.Generic;
using System.Text;

class PhpVariables
{
    static bool inOneLineComment, inMultiLineComment, inSingleQuotedString, inDoubleQuotedString, inVariable;
    static SortedSet<string> variables = new SortedSet<string>();

    static void Main()
    {
        ExtractVariables(ReadInput());
        PrintResult();
    }

    static void PrintResult()
    {
        Console.WriteLine(variables.Count);

        foreach (var variable in variables)
            Console.WriteLine(variable);
    }

    static void ExtractVariables(string input)
    {
        StringBuilder currentVariable = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            char currentSymbol = input[i];

            if (inOneLineComment)
            {
                if (currentSymbol == '\n') inOneLineComment = false;
                continue;
            }

            if (inMultiLineComment)
            {
                if (currentSymbol == '*' && i + 1 < input.Length && input[i + 1] == '/') inMultiLineComment = false;
                continue;
            }

            if (inSingleQuotedString)
            {
                if (currentSymbol == '\'')
                {
                    inSingleQuotedString = false;
                    continue;
                }
            }

            if (inDoubleQuotedString)
            {
                if (currentSymbol == '"')
                {
                    inDoubleQuotedString = false;
                    continue;
                }
            }

            if (inVariable)
            {
                if (char.IsLetterOrDigit(currentSymbol) || currentSymbol == '_')
                {
                    currentVariable.Append(currentSymbol);
                    continue;
                }
                else
                {
                    if (currentVariable.Length > 0) variables.Add(currentVariable.ToString());
                    currentVariable.Clear();
                    inVariable = false;
                }
            }

            if (!inSingleQuotedString && !inDoubleQuotedString)
            {
                if (currentSymbol == '#' || (currentSymbol == '/' && i + 1 < input.Length && input[i + 1] == '/'))
                {
                    inOneLineComment = true;
                    i++;
                    continue;
                }

                if (currentSymbol == '/' && i + 1 < input.Length && input[i + 1] == '*')
                {
                    inMultiLineComment = true;
                    i++;
                    continue;
                }
            }
            else if (inSingleQuotedString || inDoubleQuotedString)
            {
                if (currentSymbol == '\\')
                {
                    i++;
                    continue;
                }
            }

            if (currentSymbol == '\'') inSingleQuotedString = true;
            else if (currentSymbol == '"') inDoubleQuotedString = true;
            else if (currentSymbol == '$') inVariable = true;
        }
    }

    static string ReadInput()
    {
        StringBuilder input = new StringBuilder();

        string line = Console.ReadLine();

        while (line != "?>")
        {
            input.AppendLine(line);
            line = Console.ReadLine();
        }

        return input.ToString();
    }
}