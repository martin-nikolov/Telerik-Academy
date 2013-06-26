using System;
using System.Linq;

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
            char[] opponentNumber = i.ToString().ToArray();
            char[] secret = secretNumber.ToString().ToArray();

            if (opponentNumber.Contains('0'))
                continue;

            int _bulls = 0, _cows = 0;

            // Finds bulls and cows
            for (int j = 0; j < 4; j++)
            {
                if (secret[j] == opponentNumber[j])
                {
                    _bulls++;
                    secret[j] = opponentNumber[j] = '-';
                }
                else
                {
                    int index = Array.IndexOf(opponentNumber, secret[j]);

                    while (index != -1 && secret[index] == opponentNumber[index])
                        index = Array.IndexOf(opponentNumber, secret[j], index + 1);

                    if (index != -1)
                    {
                        _cows++;
                        opponentNumber[index] = secret[j] = '-';
                    }
                }
            }

            // Check if the opponent number is answer
            if (_bulls == bulls && _cows == cows)
            {
                Console.Write(i + " ");
                oncePrinted = true;
            }
        }

        Console.WriteLine(oncePrinted ? "" : "No");
    }
}