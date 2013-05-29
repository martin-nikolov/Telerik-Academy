using System;

class ReadingNumbersUntilPressEscape
{
    static void Main()
    {
        int number = 0;
        int sumOfNumbers = 0;
        
        while (true)
        { 
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Escape)
            {
                Console.Write(key.KeyChar);
                var input = key.KeyChar + Console.ReadLine();
                number = int.Parse(input);
                sumOfNumbers = sumOfNumbers + number;
            }
            else
            {
                Console.WriteLine(sumOfNumbers);
                break;
            }
        }
    }
}