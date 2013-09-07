using System;
using System.Collections.Generic;

class DurankulakNumbers
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
                    result = result * 168 + (ulong)i;
                    number = number.Remove(0, numbers[i].Length);
                }
            }
        }

        Console.WriteLine(result);
    }

    static void AddNumbersToList(List<string> digits)
    {
        for (char i = 'A'; i <= 'Z'; i++)
            digits.Add(i.ToString());

        for (char i = 'a'; i <= 'f'; i++)
            for (char j = 'A'; j <= 'Z'; j++)
                digits.Add(i.ToString() + j.ToString());
    }
}