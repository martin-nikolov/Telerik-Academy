namespace Prototype
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static void Main(string[] args)
        {
            var darkTrooper = new Stormtrooper("Dark trooper", 180, 80);
            var anotherDarkTrooper = darkTrooper.Clone() as Stormtrooper;

            darkTrooper.Height = 200;

            Console.WriteLine(darkTrooper);
            Console.WriteLine(anotherDarkTrooper);
        }
    }
}
