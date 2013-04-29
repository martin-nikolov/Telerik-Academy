using System;

namespace _6.Printing_First_and_Last_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Your name is: {0} {1}", firstName, lastName);
        }
    }
}
