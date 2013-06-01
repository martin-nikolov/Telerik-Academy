using System;
using System.Linq;
using System.Text;

class Mutating
{
    static void Main()
    {
        int fatalMutatingCount = 0;

        int n = int.Parse(Console.ReadLine());
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < n; i++)
        {
            // Use StringBuilder (array - mutable) because it is faster than string (which is immutable)
            if (GCD(int.Parse(tokens[i]), MutateNumber(new StringBuilder(tokens[i]))) < 10)
                fatalMutatingCount++;
        }

        Console.WriteLine(fatalMutatingCount);
    }

    static int MutateNumber(StringBuilder num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            int currentDigit = num[i] - 48;

            if (currentDigit == 0)
            {
                num[i] = '9';
            }
            else if (currentDigit == 9)
            {
                num[i] = '0';
            }
            else if (currentDigit % 2 == 0)
            {
                num[i] = (char)(num[i] - 1);
            }
            else if (currentDigit % 2 != 0)
            {
                num[i] = (char)(num[i] + 1);
            }
        }

        return int.Parse(num.ToString());
    }

    static int GCD(int a, int b)
    {
        while (a != b)
        {
            if (a > b)
                a -= b;
            else
                b -= a;
        }

        return a;
    }
}