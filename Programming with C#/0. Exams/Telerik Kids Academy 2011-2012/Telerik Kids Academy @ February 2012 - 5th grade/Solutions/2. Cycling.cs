using System;
using System.Linq;

class Cycling
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int totalMinutes = 0;
        int bestAverageSpeed = 0;
        int bestIndex = 0; // Index of best average speed day

        for (int i = 0; i < n; i++)
        {
            string lineReader = Console.ReadLine();
            string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int minutes = int.Parse(tokens[0]) * 60 + int.Parse(tokens[1]); // All minutes = Hours * 60 + Minutes
            int distance = int.Parse(tokens[2]) * 1000; // Distance in metres = Distance in km * 1000;

            totalMinutes += minutes;

            if (distance / minutes > bestAverageSpeed)
            {
                bestAverageSpeed = distance / minutes;
                bestIndex = i + 1;
            }
        }

        Console.WriteLine("{0} {1} {2} {3}",
            totalMinutes / 24 / 60 % 24, totalMinutes / 60 % 24, totalMinutes % 60, bestIndex);
        //          DAYS                        HOURS                MINUTES        
    }
}