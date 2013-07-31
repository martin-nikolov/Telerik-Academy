using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class DurankulakNumbers
{
    static void Main()
    {
        string number = Console.ReadLine();

        List<string> digits = new List<string>();

        for (char i = 'A'; i <= 'Z'; i++)
            digits.Add(i.ToString());

        for (char i = 'a'; i <= 'f'; i++)
            for (char j = 'A'; j <= 'Z'; j++)
                digits.Add(i.ToString() + j.ToString());

        if (number.Length == 1)
        {
            Console.WriteLine(digits.IndexOf(number[0].ToString()));
            return;
        }

        long result = 0, pow = 0;

        for (int i = number.Length - 1; i >= 0; i--)
        {
            // Example with number aFG...

            string left = number[i - 1].ToString(); // Found: F
            string right = number[i].ToString(); // Found: G

            if (i - 2 >= 0 && char.IsLower(number[i - 2])) // Check: aFG
            {
                left = number[i - 2] + "" + number[i - 1]; // Correct numbers: aF and G
                i--;
            }

            int index = digits.IndexOf(left + right); // Finds only numbers from type aF, bG, pL, etc...

            if (index != -1)
            {
                // Found one number
                result += index * (long)Math.Pow(168, pow++);
            }
            else
            {
                // There are two numbers, example: FG => calculates its values
                result += digits.IndexOf(right) * (long)Math.Pow(168, pow++) +
                          digits.IndexOf(left) * (long)Math.Pow(168, pow++);
            }

            i--;

            if (i - 1 == 0)
            {
                // Only one number left
                result += digits.IndexOf(number[0].ToString()) * (long)Math.Pow(168, pow);
                break;
            }
        }

        Console.WriteLine(result);
    }
}