using System;
using System.Linq;
using System.Text.RegularExpressions;

class MaxEven
{
    static void Main()
    {
        int maxEven = -1;

        string lineReader = Console.ReadLine();
        string[] tokens = Regex.Split(lineReader, @"\D+"); // 23text == 23 text == 23

        for (int i = 0; i < tokens.Length; i++)
        {
            int number = 0;
            if (int.TryParse(tokens[i], out number)) // We found number
            {
                if (number % 2 == 0 && number > maxEven) // maxEven is -1 because we would have 0 as max even number
                    maxEven = number;
            }
        }

        Console.WriteLine(maxEven); // if there is no max even number return -1, else return the max even number
    }
}