using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class ThreeInOne
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        StringBuilder text = new StringBuilder();

        for (int i = 0; i < n; i++)
            text.Append(Console.ReadLine() + "\n");

        string result = RemoveTags(text.ToString());

        Console.Write(result);
    }

    static string RemoveTags(string line)
    {
        StringBuilder formatted = new StringBuilder(line);

        int startClosedTag = line.IndexOf("</");
        int endClosedTag = line.IndexOf(">", startClosedTag + 1);
        int closedTagLength = endClosedTag - startClosedTag + 1;

        int endOpenTag = line.LastIndexOf(">", startClosedTag);

        while (startClosedTag != -1)
        {
            //  string formatted[startClosedTag + 2].ToString() = line.Substring(startClosedTag, closedTagLength);

            int j = startClosedTag - 1;

            for (int i = endOpenTag + 1; i <= j; i++)
            {
                if (formatted[startClosedTag + 2] == 'd') break;

                if (formatted[startClosedTag + 2] == 'r')
                {
                    char swap = formatted[i];
                    formatted[i] = formatted[j];
                    formatted[j] = swap;
                    j--;
                }
                else if (formatted[startClosedTag + 2] == 't')
                {
                    if (char.IsLower(formatted[i])) formatted[i] = char.ToUpper(formatted[i]);
                    else formatted[i] = char.ToLower(formatted[i]);
                }
                else
                {
                    if (formatted[startClosedTag + 2] == 'u') formatted[i] = char.ToUpper(formatted[i]);
                    else formatted[i] = char.ToLower(formatted[i]);
                }
            }

            if (formatted[startClosedTag + 2] == 'd')
            {
                formatted.Remove(endOpenTag - (closedTagLength - 2), endClosedTag - endOpenTag + closedTagLength - 1);
            }
            else
            {
                formatted.Remove(startClosedTag, endClosedTag - startClosedTag + 1);
                formatted.Remove(endOpenTag - (closedTagLength - 2), closedTagLength - 1);
            }

            line = formatted.ToString();

            startClosedTag = line.IndexOf("</");
            endClosedTag = line.IndexOf(">", startClosedTag + 1);
            closedTagLength = endClosedTag - startClosedTag + 1;

            if (startClosedTag != -1) endOpenTag = line.LastIndexOf(">", startClosedTag);
        }

        return line;
    }
}