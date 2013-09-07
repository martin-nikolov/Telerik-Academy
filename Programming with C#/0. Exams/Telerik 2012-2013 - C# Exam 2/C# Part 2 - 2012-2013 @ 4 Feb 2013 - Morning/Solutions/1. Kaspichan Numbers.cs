using System;
using System.Collections.Generic;

class KaspichanNumbers
{
    static void Main()
    {
        List<string> numbers = new List<string>();

        for (char i = 'A'; i <= 'Z'; i++) numbers.Add(i.ToString());

        for (char i = 'a'; i <= 'z'; i++)
            for (char j = 'A'; j <= 'Z'; j++)
                numbers.Add(string.Format("{0}{1}", i.ToString(), j.ToString()));

        ulong number = ulong.Parse(Console.ReadLine());
        string result = string.Empty;

        if (number == 0) Console.WriteLine("A");

        while (number > 0)
        {
            result = numbers[(int)(number % 256)] + result;
            number /= 256;
        }

        Console.WriteLine(result);
    }
}