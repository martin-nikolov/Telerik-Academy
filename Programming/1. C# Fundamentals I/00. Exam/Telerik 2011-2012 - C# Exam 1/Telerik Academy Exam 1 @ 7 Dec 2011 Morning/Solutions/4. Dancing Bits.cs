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

        int dancingBitsCount = 0;
        StringBuilder bin = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            bin.Append(Convert.ToString(number, 2)); // Convert numbers to Binary and Concate its values
        }

        for (int i = 0; i < bin.Length - k + 1; i++)
        {
            List<char> sequence = new List<char>();

            for (int j = i; j < (i + k) && j < bin.Length; j++)
                sequence.Add(bin[j]);

            sequence = sequence.Distinct().ToList(); // Remove all similar elements

            if (sequence.Count == 1) // We have similar elements -> check neighbours
            {
                if (i > 0 && bin[i - 1] == sequence[0]) // Check left neightbour for same value
                    continue;

                if (i + k < bin.Length && bin[i + k] == sequence[0]) // Check right neightbour for same value
                    continue;

                // Increasing 'dancingBitsCount' only if left and right
                // neightbours have different value than sequence value
                dancingBitsCount++; 
            }
        }

        Console.WriteLine(dancingBitsCount);
    }
}