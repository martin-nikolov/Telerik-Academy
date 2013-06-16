using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class DancingBits
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        StringBuilder bin = new StringBuilder();
        int dancingCouples = 0;

        for (int i = 0; i < n; i++)
            bin.Append(Convert.ToString(int.Parse(Console.ReadLine()), 2));

        for (int i = 0; i < bin.Length - k + 1; i++)
        {
            List<char> sequence = new List<char>();

            for (int j = 0; j < k; j++)
                sequence.Add(bin[j + i]);

            // Remove all similar elements
            sequence = sequence.Distinct().ToList();

            // We have similar elements -> check neighbours
            if (sequence.Count == 1) 
            {
                // Check left neightbour for same value
                if (i > 0 && bin[i - 1] == sequence[0]) 
                    continue;

                // Check right neightbour for same value
                if (i + k < bin.Length && bin[i + k] == sequence[0]) 
                    continue;

                // Increasing 'dancingBitsCount' only if left and right
                // neightbours have different value than sequence value
                dancingCouples++;
            }
        }

        Console.WriteLine(dancingCouples);
    }
}