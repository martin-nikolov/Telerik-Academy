using System;
using System.Collections.Generic;
using System.Linq;

class Mark
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<decimal> marks = new List<decimal>();

        for (int i = 0; i < n; i++)
            marks.Add(int.Parse(tokens[i]));

        decimal min = marks.Min();
        decimal max = marks.Max();
        decimal averageSum = Math.Round((marks.Sum() - (min + max)) / (n - 2));

        Console.WriteLine("{0}", averageSum);
    }
}