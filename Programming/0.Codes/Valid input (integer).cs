using System;

class Program
{
    static void Main(string[] args)
    {
        int number;
        bool ValidNumber;

        do
        {
            Console.WriteLine("Enter Integer:");
            ValidNumber = int.TryParse(Console.ReadLine(), out number);
        }
        while (ValidNumber != true);
    }
}