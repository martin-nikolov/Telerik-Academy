using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class CardWars
{
    static readonly Dictionary<string, int> cards = new Dictionary<string, int>();

    static void Main()
    {
        for (int i = 2; i <= 10; i++)
            cards.Add(i.ToString(), 12 - i);
        cards.Add("A", 1);
        cards.Add("J", 11);
        cards.Add("Q", 12);
        cards.Add("K", 13);

        // The number of the game's rounds
        int n = int.Parse(Console.ReadLine()); 

        BigInteger firstTotalScore = 0;
        int firstWons = 0;
  
        BigInteger secondTotalScore = 0;
        int secondWons = 0;

        for (int i = 0; i < n; i++)
        {
            int firstCurrentScore = 0;
            bool hasFirstCardX = false;

            int secondCurrentScore = 0;
            bool hasSecondCardX = false;

            ReadThreeCards(ref firstTotalScore, ref firstCurrentScore, ref hasFirstCardX);
            ReadThreeCards(ref secondTotalScore, ref secondCurrentScore, ref hasSecondCardX);

            if (hasFirstCardX && hasSecondCardX)
            {
                firstTotalScore += 50;
                secondTotalScore += 50;
            }
            else if (hasFirstCardX)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
                return;
            }
            else if (hasSecondCardX)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
                return;
            }
            
            if (firstCurrentScore > secondCurrentScore)
            {
                firstTotalScore += firstCurrentScore;
                firstWons++;
            }
            else if (firstCurrentScore < secondCurrentScore)
            {
                secondTotalScore += secondCurrentScore;
                secondWons++;
            }
        }

        if (firstTotalScore > secondTotalScore)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", firstTotalScore);
            Console.WriteLine("Games won: {0}", firstWons);
        }
        else if (firstTotalScore < secondTotalScore)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", secondTotalScore);
            Console.WriteLine("Games won: {0}", secondWons);
        }
        else if (firstTotalScore == secondTotalScore)
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", firstTotalScore);
        }
    }

    /// <summary>
    /// Reads exactly 3 cards for each player every round, 
    /// changes the current player score and tell us if the player has card X.
    /// </summary>
    /// <param name="playerCurrentScore">The player current score</param>
    /// <param name="hasPlayesCardX">Return true if player has card X</param>
    static void ReadThreeCards(ref BigInteger playerTotalScore, ref int playerCurrentScore, ref bool hasPlayesCardX)
    {
        for (int i = 0; i < 3; i++)
        {
            string card = Console.ReadLine();

            switch (card)
            {
                case "Z": playerTotalScore *= 2; break;
                case "Y": playerTotalScore -= 200; break;
                case "X": hasPlayesCardX = true; break;
                default: playerCurrentScore += cards[card]; break;
            }
        }
    }
}