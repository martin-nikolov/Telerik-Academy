using System;
using System.Text;

class FTML
{
    static string code = string.Empty;

    static string openUpperTag = "<upper>";
    static string openLowerTag = "<lower>";
    static string openRevTag = "<rev>";
    static string openToggleTag = "<toggle>";
    static string openDelTag = "<del>";

    static string closedUpperTag = "</upper>";
    static string closedLowerTag = "</lower>";
    static string closedRevTag = "</rev>";
    static string closedToggleTag = "</toggle>";
    static string closedDelTag = "</del>";

    static void Main()
    {
        code = Initialize();
        RemoveTags();
        Console.WriteLine(code);
    }

    static void RemoveTags()
    {
        StringBuilder formatted = new StringBuilder(code);
        formatted.Remove(formatted.Length - 1, 1);

        int indexClosedTag = code.IndexOf("</");
        int indexOpenTag = code.LastIndexOf("<", indexClosedTag - 1);

        while (indexClosedTag != -1)
        {
            string currentTag = GetTag(indexOpenTag);

            if (currentTag.StartsWith(openUpperTag))
            {
                for (int i = indexOpenTag + openUpperTag.Length; i < indexClosedTag; i++)
                    formatted[i] = char.ToUpper(formatted[i]);

                formatted.Remove(indexClosedTag, closedUpperTag.Length);
                formatted.Remove(indexOpenTag, openUpperTag.Length);
            }
            else if (currentTag.StartsWith(openLowerTag))
            {
                for (int i = indexOpenTag + openLowerTag.Length; i < indexClosedTag; i++)
                    formatted[i] = char.ToLower(formatted[i]);

                formatted.Remove(indexClosedTag, closedLowerTag.Length);
                formatted.Remove(indexOpenTag, openLowerTag.Length);
            }
            else if (currentTag.StartsWith(openToggleTag))
            {
                for (int i = indexOpenTag + openToggleTag.Length; i < indexClosedTag; i++)
                {
                    if (char.IsLower(formatted[i])) formatted[i] = char.ToUpper(formatted[i]);
                    else if (char.IsUpper(formatted[i])) formatted[i] = char.ToLower(formatted[i]);
                }

                formatted.Remove(indexClosedTag, closedToggleTag.Length);
                formatted.Remove(indexOpenTag, openToggleTag.Length);
            }
            else if (currentTag.StartsWith(openRevTag))
            {
                StringBuilder codeBetweenRevTags = new StringBuilder();

                for (int i = indexClosedTag - 1; i >= indexOpenTag + openRevTag.Length; i--)
                    codeBetweenRevTags.Append(formatted[i]);

                for (int i = indexOpenTag + openRevTag.Length, count = 0; i < indexClosedTag; i++)
                    formatted[i] = codeBetweenRevTags[count++];

                formatted.Remove(indexClosedTag, closedRevTag.Length);
                formatted.Remove(indexOpenTag, openRevTag.Length);
            }
            else if (currentTag.StartsWith(openDelTag))
            {
                formatted.Remove(indexOpenTag, indexClosedTag - indexOpenTag + closedDelTag.Length);
            }

            code = formatted.ToString();
            indexClosedTag = code.IndexOf("</");
            if (indexClosedTag != -1) indexOpenTag = code.LastIndexOf("<", indexClosedTag - 1);
        }
    }

    static string GetTag(int index)
    {
        return code.Substring(index, 8);
    }

    static string Initialize()
    {
        StringBuilder code = new StringBuilder();
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
            code.Append(Console.ReadLine() + "\n");

        return code.ToString();
    }
}