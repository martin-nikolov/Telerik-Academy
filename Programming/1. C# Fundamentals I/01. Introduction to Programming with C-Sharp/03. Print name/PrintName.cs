// 3. Modify the application to print your name.

using System;

class PrintName
{
    static void Main(string[] args)
    {
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();

        Console.WriteLine("Hello, {0}!", userName);
    }
}