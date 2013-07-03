using System;
using System.Linq;

class Digits
{
    static void Main()
    {
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int a = int.Parse(tokens[0]);
        int b = int.Parse(tokens[1]);
        int p1 = int.Parse(tokens[2]);
        int p2 = int.Parse(tokens[3]);

        int totalDigits = 0;

        for (int i = a; i <= b; i++)
        {
            string currentNumber = i.ToString();
            totalDigits += currentNumber.Length;

            for (int j = 0; j < currentNumber.Length; j++)
            {
                if ((currentNumber[j] - 48) % p1 == 0 || (currentNumber[j] - 48) % p2 == 0)
                {
                    totalDigits--;
                }
            }
        }

        Console.WriteLine(totalDigits);
    }
}