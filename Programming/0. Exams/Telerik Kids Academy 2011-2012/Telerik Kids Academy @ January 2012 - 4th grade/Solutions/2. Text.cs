using System;
using System.Linq;

class Text
{
    static void Main()
    {
        string symbols = Console.ReadLine();

        int numbers = 0;
        int lowerLetters = 0;
        int upperLetters = 0;
        int signs = 0;

        for (int i = 0; i < symbols.Length; i++)
        {
            if (symbols[i] >= '0' && symbols[i] <= '9')
            {
                numbers++;
            }
            else if (symbols[i] >= 'a' && symbols[i] <= 'z')
            {
                lowerLetters++;
            }
            else if (symbols[i] >= 'A' && symbols[i] <= 'Z')
            {
                upperLetters++;
            }
            else
            {
                signs++;
            }
        }

        Console.WriteLine("{0} {1} {2} {3}", numbers, lowerLetters, upperLetters, signs);
    }
}