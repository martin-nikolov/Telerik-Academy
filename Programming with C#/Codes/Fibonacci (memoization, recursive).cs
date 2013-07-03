using System;

class Program
{
    const int MAX_FIBONACCI_SEQUENCE_MEMBER = 1000;
    static decimal[] fib = new decimal[MAX_FIBONACCI_SEQUENCE_MEMBER];

    static decimal recursiveCallsCounter = 0;

    static decimal Fibonacci(int num)
    {
        recursiveCallsCounter++;

        if (fib[num] == 0)
        {
            //The value of fib[n] is still not calculated ->
            if ((num == 1 || num == 2))
            {
                fib[num] = 1;
            }
            else
            {
                fib[num] = Fibonacci(num - 1) + Fibonacci(num - 2);
            }
        }
        return fib[num];
    }

    static void Main()
    {
        int num = 100;
        decimal fib = Fibonacci(num);
        Console.WriteLine("Fib({0}) = {1}", num, fib);
        Console.WriteLine("Recursive calls = {0}", recursiveCallsCounter);
    }
}