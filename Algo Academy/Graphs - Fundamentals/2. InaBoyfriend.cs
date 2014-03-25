using System;
using System.Collections.Generic;
using System.Linq;

class InaBoyfriend
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var mostLikedPerson = new KeyValuePair<string, int>();

        for (int i = 0; i < n; i++)
        {
            var currentPerson = Console.ReadLine().Split(' ').ToArray();
            var likes = currentPerson[1].Where(a => a == '1').Count();

            if (likes > mostLikedPerson.Value)
                mostLikedPerson = new KeyValuePair<string, int>(currentPerson[0], likes);
        }

        Console.WriteLine(mostLikedPerson.Key);
    }
}