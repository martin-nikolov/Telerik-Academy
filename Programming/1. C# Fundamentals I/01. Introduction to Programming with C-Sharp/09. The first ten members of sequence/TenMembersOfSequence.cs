// 9. Write a program that prints the first 10 members
// of the sequence: 2, -3, 4, -5, 6, -7, ...

using System;

class TenMembersOfSequence
{
    static void Main(string[] args)
    {
        for (int i = 2; i < 12; i++)
        {
            Console.WriteLine(i % 2 == 0 ? i : -i);
        }
    }
}
