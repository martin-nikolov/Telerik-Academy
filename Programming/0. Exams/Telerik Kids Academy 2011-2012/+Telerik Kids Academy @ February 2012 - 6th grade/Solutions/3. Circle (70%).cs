using System;
using System.Collections.Generic;
using System.Linq;

class Circle
{
    static void Main()
    {
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int count = int.Parse(tokens[0]); // Students count
        byte steps = byte.Parse(tokens[1]); // Steps to next student
        int index = steps - 1; // TODO: Check for 'index' value if it is greater than count => IndexOutOfRangeException

        // Initialization
        List<byte> studentNumbers = new List<byte>(count);
        for (int i = 0; i < studentNumbers.Capacity; i++)
            studentNumbers.Add(byte.Parse(Console.ReadLine()));
        
        // Remove first student at the position choosen by teacher
        steps = studentNumbers[index];
        studentNumbers[index] = 0;
        count--;

        // HACK -> slow operation
        while (count > 1)
        {
            index++;

            if (index >= studentNumbers.Count)
                index = 0;

            if (studentNumbers[index] != 0)
            {
                steps--;

                if (steps == 0)
                {
                    steps = studentNumbers[index];
                    studentNumbers[index] = 0;
                    count--;
                }
            }
        }
        
        // Print winner's number
        for (int i = 1; i <= studentNumbers.Count - 1; i++)
        {
            if (studentNumbers[i - 1] != 0)
            {
                Console.WriteLine(i);
                return;
            }
        }
    }
}