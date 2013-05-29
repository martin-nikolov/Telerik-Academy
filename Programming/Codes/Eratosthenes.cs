using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        bool[] prime = new bool[n];

        for (int i = 2; i < Math.Sqrt(prime.Length); i++) //i < prime.Lenght || i < prime.Lenght / 2 
        {
            if (prime[i] == false) //Propuskame tezi koito sa true, t.e. chislata koito ne sa prosti
            {
                for (int j = i * i; j < n; j = j + i) //j = i + i
                {
                    prime[j] = true;
                }
            }
        }

        for (int i = 2; i < prime.Length; i++)
        {
            if (prime[i] == false)
            {
                Console.Write("{0} ", i);
            }
        }

        Console.WriteLine();
    }
}