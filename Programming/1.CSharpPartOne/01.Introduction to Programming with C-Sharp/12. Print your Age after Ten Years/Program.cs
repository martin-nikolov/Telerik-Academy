using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Print_your_Age_after_Ten_Years
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your age: ");
            byte userAge = byte.Parse(Console.ReadLine());

            Console.WriteLine("Your age after 10 years is: {0}", userAge + 10);
        }
    }
}
