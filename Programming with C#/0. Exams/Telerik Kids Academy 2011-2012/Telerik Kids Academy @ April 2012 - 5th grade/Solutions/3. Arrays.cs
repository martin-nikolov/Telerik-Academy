using System;
using System.Collections.Generic;
using System.Linq;

class Arrays
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string lineReader = Console.ReadLine();
        string[] firstArray = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();

        int m = int.Parse(Console.ReadLine());
        lineReader = Console.ReadLine();
        string[] secondArray = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();

        List<int> differentElements = new List<int>();

        bool isDifferent = false;
        for (int i = 0; i < firstArray.Length; i++)
        {
            if (!secondArray.Contains(firstArray[i]))
            {
                isDifferent = true;
                differentElements.Add(int.Parse(firstArray[i]));
            }
        }

        if (isDifferent)
        {
            differentElements.Sort();
            foreach (var element in differentElements)
            {
                Console.Write("{0} ", element);
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine(firstArray.Length);
        }
    }
}