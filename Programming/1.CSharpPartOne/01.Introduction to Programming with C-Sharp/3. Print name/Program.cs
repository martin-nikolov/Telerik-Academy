using System;

namespace _3.Print_name
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            Console.WriteLine("Your name is: {0}", userName);
        }
    }
}
