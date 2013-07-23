using System;
using System.Collections.Generic;
using System.Linq;

class KaspichanNumber
{
    static void Main()
    {
        List<string> numbers = new List<string>();

        ulong number = ulong.Parse(Console.ReadLine());

        for (char i = 'A'; i <= 'Z'; i++)
            numbers.Add(i.ToString());

        for (char i = 'a'; i <= 'i'; i++)
            for (char j = 'A'; j <= 'Z'; j++)
                numbers.Add(i.ToString() + j.ToString());

        string result = string.Empty;

        if (number == 0)
        {
            Console.WriteLine("A");
            return;
        }

        while (number != 0)
        {
            result = numbers[(int)(number % 256)] + "" + result;
            number /= 256;
        }

        Console.WriteLine(result);
    }
}