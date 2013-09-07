using System;

class NineGagNumber
{
    static string[] digits = { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };

    static void Main()
    {
        string number = Console.ReadLine();
        ulong result = 0;

        while (number.Length > 0)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if(number.StartsWith(digits[i]))
                {
                    number = number.Remove(0, digits[i].Length);
                    result = result * 9 + (ulong)i;
                }
            }
        }

        Console.WriteLine(result);
    }
}
