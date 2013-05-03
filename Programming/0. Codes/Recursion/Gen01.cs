using System;

class Program
{
    static void Print(int[] vector)
    {
        for (int i = 0; i < vector.Length; i++)
        {
            Console.Write("{0}", vector[i]);
        }
        Console.WriteLine();
    }

    static void Gen01(int size, int[] vector)
    {
        if (size == -1)
        {
            Print(vector);
        }
        else
        {
            for (int i = 0; i <= 1; i++)
            {
                vector[size] = i;
                Gen01(size - 1, vector);
            }
        }
    }

    public static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        int[] vector = new int[size];

        Gen01(size - 1, vector);
    }
}