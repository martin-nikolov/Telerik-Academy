using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class JediMeditation
{
    static readonly StringBuilder output = new StringBuilder();

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        var jediKnights = Console.ReadLine().Split(' ').ToArray();

        var masters = new List<string>(N);
        var knights = new List<string>(N);
        var padawans = new List<string>(N);

        for (int i = 0; i < N; i++)
        {
            switch (jediKnights[i][0])
            {
                case 'm': masters.Add(jediKnights[i]); break;
                case 'k': knights.Add(jediKnights[i]); break;
                case 'p': padawans.Add(jediKnights[i]); break;
            }
        }

        AddOutputResult(masters);
        AddOutputResult(knights);
        AddOutputResult(padawans, true);

        Console.Write(output);
    }

    static void AddOutputResult(ICollection<string> collection, bool isLast = false)
    {
        output.AppendFormat("{0}{1}{2}", string.Join(" ", collection),
            collection.Count > 0 && !isLast ? " " : "", isLast ? "\n" : "");
    }
}