using System;
using System.Linq;
using System.Text;

class BullsAndCows
{
    static void Main()
    {
        int secretNumber = int.Parse(Console.ReadLine());
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());
        bool oncePrinted = false;

        for (int i = 1111; i <= 9999; i++)
        {
            if (i.ToString().Contains('0')) continue;

            StringBuilder num = new StringBuilder(secretNumber.ToString());
            StringBuilder iStr = new StringBuilder(i.ToString());

            int _bulls = 0;
            int _cows = 0;

            // Finds bulls
            for (int j = 0; j <= 3; j++)
            {
                if (num[j] == iStr[j])
                {
                    _bulls++;
                    iStr[j] = num[j] = '-';
                }
            }

            // Find cows
            for (int j = 0; j <= 3; j++)
            {
                if (iStr[j] == '-')
                    continue;

                int index = num.ToString().IndexOf(iStr[j]);

                if (index != -1)
                {
                    _cows++;
                    iStr[j] = num[index] = '-';
                }
            }

            // Check if the number is answer
            if (_bulls == bulls && _cows == cows)
            {
                Console.Write(i + " ");
                oncePrinted = true;
            }
        }

        Console.WriteLine(oncePrinted ? "" : "No");
    }
}