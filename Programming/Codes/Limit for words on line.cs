using System;
using System.Text;

class Program
{
    static void PrintLines(string content)
    {
        int lineLimit = 60;

        StringBuilder wordLine = new StringBuilder("");
        string[] topic = content.Split(' ');

        for (int index = 0; index < topic.Length; index++)
        {
            wordLine.Append(topic[index]);
            wordLine.Append(" ");

            if ((wordLine.Length > lineLimit) || (index == topic.Length - 1))
            {
                Console.WriteLine(wordLine);
                wordLine.Clear();
            }
        }
    }
}