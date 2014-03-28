using System;
using System.Linq;

class SuperSumDP
{
    static int K, N;

    static void Main()
    {
        var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        K = numbers[0];
        N = numbers[1];

        Console.WriteLine(SuperSum(K, N));
    }

    static long SuperSum(int K, int N)
    {
        if (K == 1)
        {
            int sum = 0;

            for (int i = 1; i <= N; i++)
                sum += i;

            return sum;
        }

        long currentSum = 0;

        for (int i = 1; i <= N; i++)
            currentSum += SuperSum(K - 1, i);

        return currentSum;
    }
}