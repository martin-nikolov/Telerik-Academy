using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class EasterMister
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int areaWidth = 3 * n + 1;

        var eggImage = new StringBuilder();
        var verticeImage = GetVerticeImage(n, areaWidth);
    
        eggImage.AppendLine(string.Join(Environment.NewLine, verticeImage));
        eggImage.Append(GetMiddleImage(n, areaWidth));
        eggImage.AppendLine(string.Join(Environment.NewLine, verticeImage.Reverse()));

        Console.Write(eggImage);
    }
  
    static IList<string> GetVerticeImage(int n, int areaWidth)
    {
        int dotsCount = n + 1;
        int starsCount = n - 1;

        var verticeImages = new List<string>();
        verticeImages.Add(new string('.', dotsCount) + new string('*', starsCount) + new string('.', dotsCount));

        for (int i = 0; i < n - 2; i++)
        {
            dotsCount -= 2;
            dotsCount += dotsCount < 0 ? 2 : 0;
            starsCount = areaWidth - (dotsCount * 2 + 2);

            verticeImages.Add(new string('.', dotsCount) + '*' +
                              new string('.', starsCount) + '*' + new string('.', dotsCount));
        }

        return verticeImages;
    }

    static string GetMiddleImage(int n, int areaWidth)
    {
        var middleImages = new StringBuilder();

        for (int i = 0; i < 2; i++)
        {
            middleImages.Append(".*");

            for (int j = 0; j < areaWidth - 4; j++)
            {
                middleImages.Append((i + j) % 2 != 0 ? "#" : ".");
            }

            middleImages.AppendLine("*.");
        }

        return middleImages.ToString();
    }
}
