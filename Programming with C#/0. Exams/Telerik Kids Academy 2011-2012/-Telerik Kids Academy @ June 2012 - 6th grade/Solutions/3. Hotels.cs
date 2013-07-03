using System;
using System.Collections.Generic;
using System.Linq;

class Hotels
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Queue<int> toRight = new Queue<int>();
        Stack<int> toLeft = new Stack<int>();
        for (int i = 0; i < tokens.Length; i++)
        {
            toRight.Enqueue(int.Parse(tokens[i]));
            toLeft.Push(int.Parse(tokens[i]));
        }

        int smallerHotel = toRight.Dequeue();
        int viewedHotels = 1;

        while (toRight.Count > 0)
        {
            int currentHotel = toRight.Dequeue();

            if(smallerHotel < currentHotel)
            {
                smallerHotel = currentHotel;
                viewedHotels++;
            }
        }

        Console.Write(viewedHotels + " ");

        smallerHotel = toLeft.Pop();
        viewedHotels = 1;

        while (toLeft.Count > 0)
        {
            int currentHotel = toLeft.Pop();

            if (smallerHotel < currentHotel)
            {
                smallerHotel = currentHotel;
                viewedHotels++;
            }
        }

        Console.WriteLine(viewedHotels);
    }
}