using System;
using System.Linq;

class HappyNumber
{
    static void Main()
    {
        string number = Console.ReadLine();

        int sumLetters = (number[0] + number[1] + number[6] + number[7]) / 10;
        int numProduct = 1;

        for (int i = 2; i < 6; i++)
        {
            numProduct *= number[i] - 48;
        }

        if (sumLetters == numProduct)
        {
            Console.WriteLine("Yes {0}", numProduct);
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}