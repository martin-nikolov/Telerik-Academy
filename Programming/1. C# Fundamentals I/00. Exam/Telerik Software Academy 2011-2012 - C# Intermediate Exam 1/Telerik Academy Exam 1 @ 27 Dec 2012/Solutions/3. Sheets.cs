using System;
using System.Collections.Generic;
using System.Linq;

class Sheets
{
    static void Main(string[] args)
    {
        int[] sheets = new int[11];
        for (int i = 0; i < sheets.Length; i++)
        {
            sheets[i] = (int)Math.Pow(2, i);
        }

        int n = int.Parse(Console.ReadLine());
        int subsets = (int)(Math.Pow(2, sheets.Length) - 1);
        List<int> usedSheets = new List<int>();

        for (int j = 1; j <= subsets; j++)
        {
            int currentSum = 0;

            for (int i = 0; i < sheets.Length; i++)
            {
                if (((j >> i) & 1) == 1)
                {
                    currentSum = currentSum + sheets[i];
                    usedSheets.Add(i);
                }
            }

            if (currentSum == n)
                break;

            usedSheets.Clear();
        }

        for (int i = 0; i < sheets.Length; i++)
        {
            if (!usedSheets.Contains(i))
            {
                Console.WriteLine("A{0}",sheets.Length- i-1);
            }
        }
    }
}