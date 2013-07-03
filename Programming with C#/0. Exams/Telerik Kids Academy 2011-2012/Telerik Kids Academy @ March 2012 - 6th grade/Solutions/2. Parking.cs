using System;
using System.Linq;

class Parking
{
    static readonly string[][,] engagedPlaces = new string[5][,]
    {
        // 4 free places
        new string[1, 4]
        {
            { ".", ".", ".", "." },
        },

        // Places for one car
        new string[4, 4]
        {
            { "X", ".", ".", "." },
            { ".", "X", ".", "." },
            { ".", ".", "X", "." },
            { ".", ".", ".", "X" }
        },

        // Places for two cars
        new string[6, 4]
        {
            { "X", "X", ".", "." },
            { ".", ".", "X", "X" },
            { "X", ".", "X", "." },
            { ".", "X", ".", "X" },
            { ".", "X", "X", "." },
            { "X", ".", ".", "X" },
        },

        // Places for three cars
        new string[4, 4]
        {
            { ".", "X", "X", "X" },
            { "X", ".", "X", "X" },
            { "X", "X", ".", "X" },
            { "X", "X", "X", "." }
        },

        // Places for four cars
        new string[1, 4]
        {
            { "X", "X", "X", "X" },
        }
    };

    // Places for X cars
    static int[] placesForCars = new int[5];

    static void Main()
    {
        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int rows = int.Parse(tokens[0]);
        int cols = int.Parse(tokens[1]);
        string[,] parking = new string[rows, cols];

        // Initialization
        for (int row = 0; row < rows; row++)
        {
            lineReader = Console.ReadLine();

            for (int col = 0; col < cols; col++)
            {
                parking[row, col] = lineReader[col].ToString();
            }
        }

        for (int row = 0; row < rows - 1; row++)
        {
            for (int col = 0; col < cols - 1; col++)
            {
                CalculateCarsPlaces(parking, row, col);
            }
        }

        for (int i = 0; i < placesForCars.Length; i++)
        {
            Console.WriteLine(placesForCars[i]);
        }
    }

    static void CalculateCarsPlaces(string[,] parking, int row, int col)
    {
        for (int i = 0; i < engagedPlaces.GetLongLength(0); i++)
        {
            for (int j = 0; j < engagedPlaces[i].GetLongLength(0); j++)
            {
                if (parking[row, col] == engagedPlaces[i][j, 0] && parking[row, col + 1] == engagedPlaces[i][j, 1] &&
                    parking[row + 1, col] == engagedPlaces[i][j, 2] && parking[row + 1, col + 1] == engagedPlaces[i][j, 3])
                {
                    placesForCars[i]++;
                    return;
                }
            }
        }
    }
}