using System;
using System.Linq;

class NightmareOnCodeStreet
{
    static void Main()
    {
        string digits = Console.ReadLine();
        int sum = 0, count = 0;

        for (int i = 1; i < digits.Length; i += 2)
        {
            if (char.IsDigit(digits[i]))
            {
                sum += digits[i] - '0';
                count++;
            }
        }
        
        Console.WriteLine("{0} {1}", count, sum);
    }
}