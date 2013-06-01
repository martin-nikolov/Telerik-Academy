using System;
using System.Collections.Generic;
using System.Linq;

class Prize
{
    static void Main()
    {
        Dictionary<byte, byte> marks = new Dictionary<byte, byte>();
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (byte i = 0; i < 7; i++)
        {
            byte currentMark = byte.Parse(tokens[i]);

            if (!marks.ContainsKey(currentMark))
            {
                marks.Add(currentMark, 1);
            }
            else
            {
                marks[currentMark]++;
            }
        }

        if (marks.ContainsKey(2) || !marks.ContainsKey(6))
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine(new string('*', marks[6]));
        }
    }
}