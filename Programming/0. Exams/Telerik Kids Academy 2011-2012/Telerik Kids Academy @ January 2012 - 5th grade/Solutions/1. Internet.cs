using System;
using System.Linq;

class Internet
{
    static void Main()
    {
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int montlyTax = int.Parse(tokens[0]);
        int packetMbs = int.Parse(tokens[1]);
        int pricePerMb = int.Parse(tokens[2]);
        int consumedMbs = int.Parse(tokens[3]);

        int totalSum = montlyTax;

        while (consumedMbs > packetMbs)
        {
            totalSum += pricePerMb;
            consumedMbs--;
        }

        Console.WriteLine(totalSum);
    }
}