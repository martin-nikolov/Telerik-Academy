using System;
using System.Linq;

class MostPopularFriend
{
    static bool[,] adjancencyMatrix;

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        adjancencyMatrix = new bool[N, N];

        ParseInput();
  
        Console.WriteLine(FindMaxFriends());
    }
  
    static int FindMaxFriends()
    {
        int maxFriendsCount = 0;

        for (int i = 0; i < adjancencyMatrix.GetLongLength(0); i++)
        {
            int currentFriendsCount = 0;

            for (int j = 0; j < adjancencyMatrix.GetLongLength(1); j++)
            {
                bool areFriends = false;

                if (adjancencyMatrix[i, j])
                {
                    areFriends = true;
                }
                else if (i != j)
                {
                    for (int k = 0; k < adjancencyMatrix.GetLongLength(0); k++)
                    {
                        if (adjancencyMatrix[i, k] && adjancencyMatrix[j, k])
                        {
                            areFriends = true;
                            break;
                        }
                    }
                }

                if (areFriends)
                {
                    currentFriendsCount++;
                }
            }

            maxFriendsCount = Math.Max(currentFriendsCount, maxFriendsCount);
        }

        return maxFriendsCount;
    }
  
    static void ParseInput()
    {
        for (int i = 0; i < adjancencyMatrix.GetLongLength(0); i++)
        {
            var input = Console.ReadLine();

            for (int j = 0; j < adjancencyMatrix.GetLongLength(1); j++)
                adjancencyMatrix[i, j] = input[j] == 'Y';
        }
    }
}