using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Printing_current_Date_and_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime timeNow = DateTime.Now;

            Console.WriteLine("Current date and time: {0:F}", timeNow);
        }
    }
}
