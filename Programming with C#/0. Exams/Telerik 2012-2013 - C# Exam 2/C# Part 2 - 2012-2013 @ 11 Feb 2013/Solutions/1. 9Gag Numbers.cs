using System;
using System.Collections.Generic;
using System.Text;

class NineGagNumber
{
    static void Main()
    {        
        List<string> numbers = new List<string>();
        AddNumbersToList(numbers);

        string number = Console.ReadLine();

        ulong result = 0;

        while (number.Length > 0)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (number.StartsWith(numbers[i]))
                {
                    result = result * 9 + (ulong)i;
                    number = number.Remove(0, numbers[i].Length);
                }
            }
        }

        Console.WriteLine(result);
    }

    static void AddNumbersToList(List<string> numbers)
    {
        numbers.Add("-!");
        numbers.Add("**");
        numbers.Add("!!!");
        numbers.Add("&&");
        numbers.Add("&-");
        numbers.Add("!-");
        numbers.Add("*!!!");
        numbers.Add("&*!");
        numbers.Add("!!**!-");
    }
}