using System;
using System.Collections.Generic;
using System.Linq;

class Poker
{
    static void Main()
    {
        SortedDictionary<byte, byte> cards = new SortedDictionary<byte, byte>();
        bool hasStraightPotential = true;
        byte aceCount = 0;

        for (int i = 0; i < 5; i++)
        {
            byte number = 0;
            string card = Console.ReadLine();

            switch (card)
            {
                case "J": number = 11; break;
                case "Q": number = 12; break;
                case "K": number = 13; break;
                case "A": number = 14; break;
                default: number = byte.Parse(card); break;
            }

            if (!cards.ContainsKey(number))
            {
                cards.Add(number, 1);
            }
            else
            {
                cards[number]++;

                // Once discovered key with value 2, the bool variable takes value FALSE
                hasStraightPotential = false;
            }
        }

        // We have 5 different cards -> Potential for straingth
        if (hasStraightPotential) 
        {
            if (cards.ContainsKey(14) && cards.ContainsKey(2))
            {
                // Potential for straight starting with A...2...
                aceCount = cards[14];
                cards.Add(1, 1);
                cards.Remove(14);
            }

            // Check if elements are consecutive 
            for (int i = 0; i < cards.Count - 1; i++)
            {
                if (cards.ElementAt(i).Key != cards.ElementAt(i + 1).Key - 1)
                {
                    hasStraightPotential = false;
                    break;
                }
            }

            if (hasStraightPotential)
            {
                Console.WriteLine("Straight");
                return;
            }
            else if (cards.ContainsKey(1))
            {
                cards.Add(14, aceCount);
                cards.Remove(1);
            }
        }

        if (cards.ContainsValue(5))
        {
            Console.WriteLine("Impossible"); return;
        }
        else if (cards.ContainsValue(4))
        {
            Console.WriteLine("Four of a Kind"); return;
        }
        else if (cards.ContainsValue(3) && cards.ContainsValue(2))
        {
            Console.WriteLine("Full House"); return;
        }
        else if (cards.ContainsValue(3) && !cards.ContainsValue(2))
        {
            Console.WriteLine("Three of a Kind"); return;
        }

        var sortedDict = (from entry in cards
                          orderby entry.Value descending
                          select entry).ToDictionary(pair => pair.Key, pair => pair.Value);

        if (sortedDict.ElementAt(0).Value == 2 && sortedDict.ElementAt(1).Value == 2)
        {
            Console.WriteLine("Two Pairs");
        }
        else if (sortedDict.ElementAt(0).Value == 2 && sortedDict.ElementAt(1).Value == 1)
        {
            Console.WriteLine("One Pair");
        }
        else
        {
            Console.WriteLine("Nothing");
        }
    }
}