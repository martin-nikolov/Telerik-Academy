using System;
using System.Collections.Generic;
using System.Linq;

class Example
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var indices = Console.ReadLine().Split(' ').Select(ch => int.Parse(ch)).ToArray();
        var visited = new bool[indices.Length];

        List<string> sequence = new List<string>();
        sequence.Add("0");
        visited[0] = true;

        int index = indices[0];

        while (true)
        {

            if (index < 0 || index >= indices.Length)
            {
                Console.WriteLine(string.Join(" ", sequence));
                break;
            }

            if (visited[index])
            {
                sequence.Insert(sequence.IndexOf(index.ToString()), "(");
                sequence.Add(")");

                Console.WriteLine(string.Join(" ", sequence).Replace(" ( ", "(").Replace(" )", ")").Replace("( ", "("));
                break;
            }

            visited[index] = true;
            sequence.Add(index.ToString());

            index = indices[index];
        }
    }
}