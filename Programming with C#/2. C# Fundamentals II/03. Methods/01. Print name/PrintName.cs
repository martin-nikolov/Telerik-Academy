/*
* 1. Write a method that asks the user for his name and prints
* “Hello, <name>” (for example, “Hello, Peter!”).
* Write a program to test this method.
*/

using System;
using System.Linq;

public class PrintName
{
    public static string RegardsUser(string userName)
    {
        return string.Format("Hello, {0}!", userName);
    }

    static void Main()
    {
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();

        Console.WriteLine(RegardsUser(userName));
    }
}