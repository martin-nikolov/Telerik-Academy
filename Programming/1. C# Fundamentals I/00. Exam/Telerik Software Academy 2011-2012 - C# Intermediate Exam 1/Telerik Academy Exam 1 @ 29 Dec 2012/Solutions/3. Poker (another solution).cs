using System;

public class HandStrength
{
    static void Main()
    {
        byte c1 = 0; // Aces
        byte c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0, c9 = 0, c10 = 0; // 2 - 10
        byte c11 = 0; // Jacks
        byte c12 = 0; // Queens
        byte c13 = 0; // Kings
        for (int j = 1; j <= 5; j++)
        {
            string card = Console.ReadLine();
            if (card == "A") c1++;
            if (card == "2") c2++;
            if (card == "3") c3++;
            if (card == "4") c4++;
            if (card == "5") c5++;
            if (card == "6") c6++;
            if (card == "7") c7++;
            if (card == "8") c8++;
            if (card == "9") c9++;
            if (card == "10") c10++;
            if (card == "J") c11++;
            if (card == "Q") c12++;
            if (card == "K") c13++;
        }

        bool fiveOfAKind = c1 == 5 || c2 == 5 || c3 == 5 || c4 == 5 || c5 == 5 || c6 == 5 || c7 == 5 || c8 == 5 || c9 == 5 || c10 == 5 || c11 == 5 || c12 == 5 || c13 == 5;

        bool fourOfAKind = c1 == 4 || c2 == 4 || c3 == 4 || c4 == 4 || c5 == 4 || c6 == 4 || c7 == 4 || c8 == 4 || c9 == 4 || c10 == 4 || c11 == 4 || c12 == 4 || c13 == 4;

        bool threeOfAKind = c1 == 3 || c2 == 3 || c3 == 3 || c4 == 3 || c5 == 3 || c6 == 3 || c7 == 3 || c8 == 3 || c9 == 3 || c10 == 3 || c11 == 3 || c12 == 3 || c13 == 3;

        int twoOfAKindCount = 0;
        if (c1 == 2) twoOfAKindCount++;
        if (c2 == 2) twoOfAKindCount++;
        if (c3 == 2) twoOfAKindCount++;
        if (c4 == 2) twoOfAKindCount++;
        if (c5 == 2) twoOfAKindCount++;
        if (c6 == 2) twoOfAKindCount++;
        if (c7 == 2) twoOfAKindCount++;
        if (c8 == 2) twoOfAKindCount++;
        if (c9 == 2) twoOfAKindCount++;
        if (c10 == 2) twoOfAKindCount++;
        if (c11 == 2) twoOfAKindCount++;
        if (c12 == 2) twoOfAKindCount++;
        if (c13 == 2) twoOfAKindCount++;

        bool straight = false;
        if (c1 == 1 && c2 == 1 && c3 == 1 && c4 == 1 && c5 == 1) straight = true;
        if (c2 == 1 && c3 == 1 && c4 == 1 && c5 == 1 && c6 == 1) straight = true;
        if (c3 == 1 && c4 == 1 && c5 == 1 && c6 == 1 && c7 == 1) straight = true;
        if (c4 == 1 && c5 == 1 && c6 == 1 && c7 == 1 && c8 == 1) straight = true;
        if (c5 == 1 && c6 == 1 && c7 == 1 && c8 == 1 && c9 == 1) straight = true;
        if (c6 == 1 && c7 == 1 && c8 == 1 && c9 == 1 && c10 == 1) straight = true;
        if (c7 == 1 && c8 == 1 && c9 == 1 && c10 == 1 && c11 == 1) straight = true;
        if (c8 == 1 && c9 == 1 && c10 == 1 && c11 == 1 && c12 == 1) straight = true;
        if (c9 == 1 && c10 == 1 && c11 == 1 && c12 == 1 && c13 == 1) straight = true;
        if (c10 == 1 && c11 == 1 && c12 == 1 && c13 == 1 && c1 == 1) straight = true;

        if (fiveOfAKind)
        {
            Console.WriteLine("Impossible");
        }
        else if (fourOfAKind)
        {
            Console.WriteLine("Four of a Kind");
        }
        else if (threeOfAKind && twoOfAKindCount == 1)
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
        else if (twoOfAKindCount == 2)
        {
            Console.WriteLine("Two Pairs");
        }
        else if (twoOfAKindCount == 1)
        {
            Console.WriteLine("One Pair");
        }
        else
        {
            Console.WriteLine("Nothing");
        }
    }
}