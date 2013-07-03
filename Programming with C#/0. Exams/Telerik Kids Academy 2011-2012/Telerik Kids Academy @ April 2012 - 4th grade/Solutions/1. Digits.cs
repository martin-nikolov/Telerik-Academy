using System;

class Digits
{
    static void Main()
    {
        string input = Console.ReadLine();
        int sumOfNumbers = 0;
        bool isFindNumber = false;

        for (int i = 0; i < input.Length; i++)
        {
            int digit = 0;

            if (int.TryParse(input[i].ToString(), out digit))
            {
                isFindNumber = true;
                sumOfNumbers += digit;
            }
        }

        Console.WriteLine(isFindNumber ? sumOfNumbers : -1);
    }
}