using System;

namespace _12.Print_your_Age_after_Ten_Years
{
    class Program
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
}
