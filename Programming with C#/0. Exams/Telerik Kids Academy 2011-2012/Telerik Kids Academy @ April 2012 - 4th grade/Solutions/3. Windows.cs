using System;

class Windows
{
    static void Main()
    {
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int windowsCount = int.Parse(tokens[0]);
        int price = int.Parse(tokens[1]);
        int totalSum = 0;

        for (int i = 0; i < windowsCount; i++)
        {
            lineReader = Console.ReadLine();
            tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens[2] == "1")
            {
                totalSum += int.Parse(tokens[0]) * int.Parse(tokens[1]) * price;
            }
        }

        Console.WriteLine(totalSum);
    }
}