using System;
using System.Linq;

class Excursion
{
    static void Main()
    {
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        bool isCrash = false;
        int indexCrash = 0;

        int w = int.Parse(tokens[0]);
        int h = int.Parse(tokens[1]);

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            lineReader = Console.ReadLine();
            tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if ((int.Parse(tokens[0]) < w || int.Parse(tokens[1]) < h) && !isCrash)
            {
                isCrash = true;
                indexCrash = i + 1;
            }
        }

        if (isCrash)
        {
            Console.WriteLine(indexCrash);
        }
        else
        {
            Console.WriteLine("No crash");
        }
    }
}