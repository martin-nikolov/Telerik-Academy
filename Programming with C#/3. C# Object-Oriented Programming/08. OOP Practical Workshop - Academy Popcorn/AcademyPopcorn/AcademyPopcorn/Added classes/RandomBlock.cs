using System;
using System.Linq;
using AcademyPopcorn;

public static class RandomBlock
{
    static readonly Random rnd = new Random();

    public static Block GenerateRandomBlock(MatrixCoords coords)
    {
        int randomNumber = rnd.Next(12);

        switch (randomNumber)
        {
            case 1:
            case 2:
            case 3: return new Block(coords);
            case 4:
            case 5:
            case 6: return new ExplodingBlock(coords);
            case 7:
            case 8:
            case 9:
            case 10: return new GiftBlock(coords);
            case 11: return new UnpassableBlock(coords);
            default: return new Block(coords);
        }
    }
}