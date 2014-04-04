using System;
using System.Collections.Generic;
using System.Linq;

class Algograms
{
    static void Main()
    {
        string input = Console.ReadLine();

        var uniqueAlgograms = new HashSet<string>();

        while (input != "-1")
        {
            var charArray = input.ToCharArray();
            Array.Sort(charArray);

            uniqueAlgograms.Add(new string(charArray));

            input = Console.ReadLine();
        }

        Console.WriteLine(uniqueAlgograms.Count);
    }
}