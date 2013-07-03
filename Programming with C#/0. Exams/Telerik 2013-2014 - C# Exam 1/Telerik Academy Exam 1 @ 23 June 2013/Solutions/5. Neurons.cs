using System;
using System.Linq;
 
class Neurons
{
    static void Main()
    {
        while (true)
        {
            long n = long.Parse(Console.ReadLine());
            if (n == -1) break;
 
            char[] number = Convert.ToString(n, 2).ToArray();
 
            int leftOne = Array.IndexOf(number, '1');
            int rightOne = Array.LastIndexOf(number, '1');
 
            if (leftOne != -1)
                for (int j = leftOne; j <= rightOne; j++)
                    number[j] = (number[j] == '1') ? '0' : '1';
            
            Console.WriteLine(Convert.ToInt32(string.Join(string.Empty, number), 2));
        }
    }
}