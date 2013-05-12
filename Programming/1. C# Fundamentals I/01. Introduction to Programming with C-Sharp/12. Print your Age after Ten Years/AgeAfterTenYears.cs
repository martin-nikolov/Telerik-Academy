// *12. Write a program to read your age from the console 
// and print how old you will be after 10 years.

using System;

class AgeAfterTenYears
{
    static void Main(string[] args)
    {
        Console.Write("Enter your age: ");
        byte userAge = byte.Parse(Console.ReadLine());

        DateTime age = new DateTime(userAge, 1, 1);
        Console.WriteLine("Your age after 10 years is: {0}", age.AddYears(10).Year);
        //Console.WriteLine("Your age after 10 years is: {0}", userAge + 10);
    }
}
