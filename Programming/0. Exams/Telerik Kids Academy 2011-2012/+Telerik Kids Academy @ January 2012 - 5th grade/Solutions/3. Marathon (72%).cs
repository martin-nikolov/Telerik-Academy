using System;
using System.Linq;

class Marathon
{
    static void Main()
    {
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        decimal x = decimal.Parse(tokens[0]);
        decimal y = decimal.Parse(tokens[1]);

        int days = 0;

        while (x < y)
        {
            x += (x / 100m) * 10m;
            days++;
        }

        if (x > y)
            days++;

        Console.WriteLine(days);
    }
}