using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class WithoutAssignment
{
    static readonly Dictionary<char, int[]> ciphers = new Dictionary<char, int[]>(10);

    static void Main()
    {
        InitializeCipher();

        string number = Console.ReadLine();

        Console.WriteLine(GetAnswer(number));
    }

    static void InitializeCipher()
    {
        ciphers.Add('0', new int[] { });
        ciphers.Add('1', new int[] { 0 });
        ciphers.Add('2', new int[] { 0, 0 });
        ciphers.Add('3', new int[] { 0, 0, 0 });
        ciphers.Add('4', new int[] { 0, 1 });
        ciphers.Add('5', new int[] { 1 });
        ciphers.Add('6', new int[] { 1, 0 });
        ciphers.Add('7', new int[] { 1, 0, 0 });
        ciphers.Add('8', new int[] { 1, 0, 0, 0 });
        ciphers.Add('9', new int[] { 0, 2 });
    }
  
    static string GetAnswer(string number)
    {
        StringBuilder result = new StringBuilder();
        int increaseWith = 0;
        
        for (int i = number.Length - 1; i >= 0; i--)
        {
            int[] currentNumber = ciphers[number[i]].Clone() as int[];

            for (int j = 0; j < currentNumber.Length; j++)
            {
                currentNumber[j] += increaseWith;
            }

            result = new StringBuilder(string.Join("", currentNumber) + result);
            increaseWith += 2;
        }

        return result.ToString();
    }
}