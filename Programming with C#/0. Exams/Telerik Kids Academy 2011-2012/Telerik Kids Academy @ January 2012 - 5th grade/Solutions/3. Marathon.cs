using System;
using System.Linq;

class Marathon
{
    static void Main()
    {
        // This program works on 100% but condition and tests are wrong...
        // I think if we start from 15 km and want to reach 16 km, it is needed to run only
        // one more day to increase distance with 10% (15km + 15km * 10% = 16,5km -> which is 
        // distance not smaller than 16 km)...

        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        decimal x = decimal.Parse(tokens[0]);
        decimal y = decimal.Parse(tokens[1]);

        int days = 1;

        while (x < y)
        {
            x += x / 10;
            days++;
        }

        Console.WriteLine(days);
    }
}