using System;
using System.Collections.Generic;
using System.Linq;

class Exam
{
    static void Main()
    {
        int withoutPenCount = 0;

        string lineReader = Console.ReadLine(); // In this implementation of program, the first line of input doesn't matter
        //string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        lineReader = Console.ReadLine(); // Students without pen
        string[] withoutPen = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        lineReader = Console.ReadLine(); // Students with pen
        // Use List<string>, because it is easier to remove directly element by value
        List<string> withPen = new List<string>(lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

        for (int i = 0; i < withoutPen.Length; i++)
        {
            string left = (int.Parse(withoutPen[i]) - 1).ToString();
            string right = (int.Parse(withoutPen[i]) + 1).ToString();

            if (withPen.Contains(left))
            {
                withPen.Remove(left);
            }
            else if (withPen.Contains(right))
            {
                withPen.Remove(right);
            }
            else
            {
                withoutPenCount++;
            }
        }

        Console.WriteLine(withoutPenCount);
    }
}