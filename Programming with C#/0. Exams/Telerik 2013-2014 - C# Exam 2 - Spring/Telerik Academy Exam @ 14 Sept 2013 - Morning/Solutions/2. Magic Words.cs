using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
class MagicWords
{
    static List<string> words = new List<string>();
    static int bestLength = 0;
 
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
 
        for (int i = 0; i < n; i++)
        {
            words.Add(Console.ReadLine());
            if (words[i].Length > bestLength) bestLength = words[i].Length;
        }
 
        //for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int nextIndex = words[j].Length % (n + 1);
                //if (nextIndex > 0) nextIndex = nextIndex - 1;
                var swap = words[j];
 
                 
 
                if (nextIndex >= j)
                {
                    words.Insert(nextIndex, swap);
                    words.RemoveAt(j);
                }
                else
                {
                    words.RemoveAt(j);
                    words.Insert(nextIndex, swap);
 
                }
 
            }
        }
 
        int index = 0;
        StringBuilder result = new StringBuilder();
 
        while (index < bestLength)
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (index < words[i].Length)
                {
                    //Console.Write(words[i][index]);
                    result.Append(words[i][index]);
                }
            }
 
            index++;
        }
 
        Console.WriteLine(result);
    }
}