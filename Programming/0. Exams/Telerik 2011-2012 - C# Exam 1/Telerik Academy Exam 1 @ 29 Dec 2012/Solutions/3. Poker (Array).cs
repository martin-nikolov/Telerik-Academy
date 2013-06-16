using System;
using System.Linq;

class Poker
{
    static void Main()
    {
        int[] cards = new int[13]; // 2, 3, 4 ... J, Q, K, A

        for (int i = 0; i < 5; i++)
        {
            string card = Console.ReadLine();

            switch (card)
            {
                case "10": cards[8]++; break;
                case "J": cards[9]++; break;
                case "Q": cards[10]++; break;
                case "K": cards[11]++; break;
                case "A": cards[12]++; break;
                default: cards[int.Parse(card) - 2]++; break;
            }
        }

        int twoOfAKind = 0;
        bool threeOfAKind = false;
        bool fourOfAKind = false;
        bool fiveOfAKind = false;
        bool straight = false;

        for (int i = 0; i < cards.Length - 4; i++)
        {
            if (cards[i] == 1 && cards[i + 1] == 1 &&
                cards[i + 2] == 1 && cards[i + 3] == 1 && cards[i + 4] == 1)
            {
                straight = true;
                break;
            }

            if (cards[0] == 1 && cards[1] == 1 &&
                cards[2] == 1 && cards[3] == 1 && cards[12] == 1)
            {
                straight = true;
                break;
            }
        }

        for (int i = 0; i < cards.Length && !straight; i++)
        {
            if (cards[i] == 5)
            {
                fiveOfAKind = true;
                break;
            }
            else if (cards[i] == 4)
            {
                fourOfAKind = true;
                break;
            }
            else if (cards[i] == 3)
            {
                threeOfAKind = true;
            }
            else if (cards[i] == 2)
            {
                ++twoOfAKind;
            }
        }

        if (fiveOfAKind)
        {
            Console.WriteLine("Impossible");
        }
        else if (fourOfAKind)
        {
            Console.WriteLine("Four of a Kind");
        }
        else if (threeOfAKind && twoOfAKind == 1)
        {
            Console.WriteLine("Full House");
        }
        else if (straight)
        {
            Console.WriteLine("Straight");
        }
        else if (threeOfAKind)
        {
            Console.WriteLine("Three of a Kind");
        }
        else if (twoOfAKind == 2)
        {
            Console.WriteLine("Two Pairs");
        }
        else if (twoOfAKind == 1)
        {
            Console.WriteLine("One Pair");
        }
        else
        {
            Console.WriteLine("Nothing");
        }
    }
}