/*
* 2. Write a program that generates and prints to the console 10 random values in the range [100, 200].
*/

using System;
using System.Linq;

class RandomNumberGenerator
{
    static Random rnd = new Random();

    static void Main()
    {
        Console.WriteLine("Prints random numbers in interval [100; 200]: ");

        for (int i = 0; i < 100; i++)
            Console.WriteLine(rnd.Next(100, 201));
    }
}