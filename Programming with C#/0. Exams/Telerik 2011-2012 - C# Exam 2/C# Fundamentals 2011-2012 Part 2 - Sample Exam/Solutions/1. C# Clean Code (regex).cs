using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class CleanCode
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        StringBuilder code = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();

            if (line != null && line != string.Empty) code.AppendLine(line);
        }

        var blockComments = @"/\*(.*?)\*/";
        var lineComments = @"//(.*?)\r?\n";
        var strings = @"""((\\[^\n]|[^""\n])*)""";
        var verbatimStrings = @"@(""[^""]*"")+";

        string noComments = Regex.Replace(code.ToString(),
            blockComments + "|" + lineComments + "|" + strings + "|" + verbatimStrings,
            me =>
            {
                if (me.Value.StartsWith("/*") || me.Value.StartsWith("//") && !me.Value.StartsWith("///"))
                    return me.Value.StartsWith("//") ? Environment.NewLine : "";
                // Keep the literal strings
                return me.Value;
            },
            RegexOptions.Singleline);

        // Remove empty lines
        string result = Regex.Replace(noComments, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);

        Console.Write(result);
    }
}