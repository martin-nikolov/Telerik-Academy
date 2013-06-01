using System;
using System.Linq;

class Sort
{
    static void Main()
    {
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        bool isAscending = true;
        bool isDescenting = true;
        bool isMixed = false;

        for (int i = 0; i < tokens.Length - 1; i++)
        {
            // Check for ascending order
            if (int.Parse(tokens[i]) < int.Parse(tokens[i + 1]))
            {
                isDescenting = false;
            }
            else if (int.Parse(tokens[i]) > int.Parse(tokens[i + 1]))
            {
                isAscending = false;
            }
            else
            {
                Console.WriteLine("Mixed");
                return;
            }
        }

        if (isAscending)
        {
            Console.WriteLine("Ascending");
        }
        else if (isDescenting)
        {
            Console.WriteLine("Descending");   
        }
        else
        {
            Console.WriteLine("Mixed");
        }
    }
}