using System;
using System.Linq;

class Circle
{
    static void Main()
    {
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int count = int.Parse(tokens[0]); // Students count
        byte steps = byte.Parse(tokens[1]); // Steps to next student
        int index = steps - 1; // TODO (not necessary): Check for 'index' value if it is greater than count => IndexOutOfRangeException

        // Initialization
        // **Program uses byte[] is 2x faster than program uses List<byte>
        byte[] studentNumbers = new byte[count];
        for (int i = 0; i < studentNumbers.Length; i++)
            studentNumbers[i] = byte.Parse(Console.ReadLine());

        // Remove first student at the position choosen by teacher
        steps = studentNumbers[index];
        studentNumbers[index] = 0;
        count--;

        DateTime now = DateTime.Now;
        // HACK -> slow operation
        while (true)
        {
            if (++index >= studentNumbers.Length)
                index = 0;

            if (studentNumbers[index] != 0)
            {
                if (--steps == 0)
                {
                    steps = studentNumbers[index];
                    studentNumbers[index] = 0;

                    if (--count <= 1)
                    {
                        break;
                    }
                }
            }
        }
        Console.WriteLine(DateTime.Now - now);
       
        // Print winner's number
        for (int i = 1; i <= studentNumbers.Length - 1; i++)
        {
            if (studentNumbers[i - 1] != 0)
            {
                Console.WriteLine(i);
                return;
            }
        }
    }
}