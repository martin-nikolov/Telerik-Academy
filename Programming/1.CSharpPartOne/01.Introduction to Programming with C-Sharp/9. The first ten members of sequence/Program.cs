using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.The_first_ten_members_of_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 2; i <= 12; i++)
            {
                Console.WriteLine(i % 2 == 0 ? i : -i);
            }
        }
    }
}
