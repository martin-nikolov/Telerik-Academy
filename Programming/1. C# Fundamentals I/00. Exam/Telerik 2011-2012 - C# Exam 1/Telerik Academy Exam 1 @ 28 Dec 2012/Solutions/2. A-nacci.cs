using System;
using System.Collections.Generic;
using System.Linq;

class Anacci
{
    static void Main()
    {
        Dictionary<char, byte> letters = new Dictionary<char, byte>();
        for (char i = 'A'; i <= 'Z'; i++) letters.Add(i, (byte)(i - 64));

        char[] userLetters = new char[2];
        userLetters[0] = char.Parse(Console.ReadLine());
        userLetters[1] = char.Parse(Console.ReadLine());
        byte position = byte.Parse(Console.ReadLine());
        byte intervals = 0;

        for (int i = 0; i < (position < 2 ? position : position * 2 - 1); i++)
        {
            if (i >= 2)
            {
                int nextIndex = letters[userLetters[0]] + letters[userLetters[1]];
                if (nextIndex > 26) nextIndex = nextIndex % 26;

                userLetters[0] = userLetters[1];
                userLetters[1] = letters.ElementAt(nextIndex - 1).Key;

                Console.Write(userLetters[1]);
                Console.Write(new string(' ',intervals));
            }
            else
            {
                Console.Write(userLetters[i]);
                if (i == 0) Console.WriteLine();
            }

            if (i > 0 && i % 2 == 0)
            {
                Console.WriteLine();
                intervals++;
            }
        }
    }
}