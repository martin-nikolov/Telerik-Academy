using System;

class PrimeDividers
{
    static void Main()
    {
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int m = int.Parse(tokens[0]);
        int n = int.Parse(tokens[1]);

        bool isFoundDivider = false;

        for (int i = 2; i <= Math.Sqrt(Math.Max(m, n)); i++)
        {
            bool isPrime = true;
            for (int j = 2; j <= Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    continue;
                }
            }

            if (isPrime && m % i == 0 && n % i == 0)
            {
                isFoundDivider = true;
                Console.Write("{0} ", i);
            }
        }

        Console.WriteLine(isFoundDivider ? "" : "-1");
    }
}