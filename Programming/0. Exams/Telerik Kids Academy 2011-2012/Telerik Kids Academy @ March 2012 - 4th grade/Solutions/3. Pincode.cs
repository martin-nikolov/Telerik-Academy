using System;
using System.Linq;

class PinCode
{
    static void Main()
    {
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int a = ReverseNumber(int.Parse(tokens[0]));
        int b = ReverseNumber(int.Parse(tokens[1]));

        if (a > b)
        {
            Console.WriteLine(a);
        }
        else
        {
            Console.WriteLine(b);
        }
    }

    static int ReverseNumber(int number)
    {
        int reversedNumber = 0;

        while (number != 0)
        {
            reversedNumber *= 10;
            reversedNumber += number % 10;
            number /= 10;
        }

        return reversedNumber;
    }
}