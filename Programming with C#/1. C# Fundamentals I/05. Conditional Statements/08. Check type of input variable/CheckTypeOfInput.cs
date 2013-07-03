/*
* 8. Write a program that, depending on the user's choice inputs int,
* double or string variable. If the variable is integer or double,
* increases it with 1. If the variable is string, appends "*"
* at its end. The program must show the value of that variable as
* a console output. Use switch statement.
*/

using System;
using System.Linq;

class CheckTypeOfInput
{
    static void Main()
    {
        double number = 0;
        string text = string.Empty;

        Console.WriteLine("Choose type of variable: ");
        Console.WriteLine("   1: int");
        Console.WriteLine("   2: double");
        Console.WriteLine("   3: string");
        Console.Write("-> Enter your choice: ");

        switch (Console.ReadLine())
        {
            case "1":
                Console.Write("\nEnter integer number: ");
                number = int.Parse(Console.ReadLine());
                Console.WriteLine("New value -> {0}\n", number + 1);
                break;
            case "2":
                Console.Write("\nEnter real number: ");
                number = double.Parse(Console.ReadLine());
                Console.WriteLine("New value -> {0}\n", number + 1);
                break;
            case "3":
                Console.Write("\nEnter a text: ");
                text = Console.ReadLine();
                Console.WriteLine("New value -> {0}*\n", text);
                break;
            default:
                Console.WriteLine("\nError! Wrong input data!\n");
                break;
        }
    }
}