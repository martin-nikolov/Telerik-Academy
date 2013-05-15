using System;
using System.Linq;

class SubsetSums
{
    static void Main(string[] args)
    {
        long searchedNumber = long.Parse(Console.ReadLine());
        long numbers = byte.Parse(Console.ReadLine());

        long[] allNumbers = new long[numbers];

        for (int i = 0; i < allNumbers.Length; i++)
        {
            allNumbers[i] = long.Parse(Console.ReadLine());
        }

        long totalSubSets = (long)Math.Pow(2, numbers) - 1;
        long searchedSubSets = 0;

        for (int i = 1; i <= totalSubSets; i++)
        {
            long currentSum = 0;

            for (int j = 0; j < allNumbers.Length; j++)
            {
                if ((i >> j & 1) == 1)
                    currentSum = currentSum + allNumbers[j];
            }

            if (currentSum == searchedNumber)
            {
                searchedSubSets++;
            }
        }

        Console.WriteLine(searchedSubSets);
    }
}