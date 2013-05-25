using System;

class ShipDamage
{
    static int[,] shipCoords = new int[4, 2];
    static int[,] catapultsCoords = new int[3, 2];
    static int percent = 0;

    static void Main()
    {
        ShipCoordsInitialization();
        int h = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < catapultsCoords.GetLongLength(0); i++)
        {
            catapultsCoords[i, 0] = int.Parse(Console.ReadLine());
            catapultsCoords[i, 1] = int.Parse(Console.ReadLine()); 

            // Coords of projectile
            catapultsCoords[i, 1] = 2 * h - catapultsCoords[i, 1]; // THIS SOLVED THE PROBLEM
        }

        CalculateDamage(catapultsCoords, shipCoords);
    }
  
    private static void ShipCoordsInitialization()
    {
        for (int i = 0; i < 2; i++)
        {
            shipCoords[i, 0] = int.Parse(Console.ReadLine());
            shipCoords[i, 1] = int.Parse(Console.ReadLine());
        }

        if (shipCoords[0, 0] > shipCoords[1, 0])
        {
            int swap = shipCoords[0, 0];
            shipCoords[0, 0] = shipCoords[1, 0];
            shipCoords[1, 0] = swap;

            swap = shipCoords[0, 1];
            shipCoords[0, 1] = shipCoords[1, 1];
            shipCoords[1, 1] = swap;
        }

        shipCoords[2, 0] = shipCoords[0, 0]; // Bottom left
        shipCoords[2, 1] = shipCoords[1, 1];
        shipCoords[3, 0] = shipCoords[1, 0]; // Top right
        shipCoords[3, 1] = shipCoords[0, 1];
    }

    static void CalculateDamage(int[,] catapult, int[,] ship)
    {
        for (int i = 0; i < catapult.GetLongLength(0); i++)
        {
            // Check every angle
            for (int j = 0; j < ship.GetLongLength(0); j++)
                if (catapult[i, 0] == ship[j, 0] && catapult[i, 1] == ship[j, 1])
                {
                    percent += 25; break;
                }

            // If projectile is on some side
            if ((catapult[i, 0] > ship[0, 0] && catapult[i, 0] < ship[1, 0] && catapult[i, 1] == ship[0, 1]) ||
                (catapult[i, 0] > ship[0, 0] && catapult[i, 0] < ship[1, 0] && catapult[i, 1] == ship[1, 1]) ||
                (catapult[i, 1] < ship[0, 1] && catapult[i, 0] > ship[1, 1] && catapult[i, 0] == ship[0, 0]) ||
                (catapult[i, 1] < ship[0, 1] && catapult[i, 0] > ship[1, 1] && catapult[i, 0] == ship[1, 0]))
            {
                percent += 50;
            }

            // If projectile is inside a rectangle
            if (catapult[i, 0] > ship[0, 0] && catapult[i, 0] < ship[1, 0] &&
                catapult[i, 1] < ship[0, 1] && catapult[i, 1] > ship[1, 1])
            {
                percent += 100;
            }

            if (catapult[i, 0] > ship[0, 0] && catapult[i, 0] < ship[1, 0] &&
                catapult[i, 1] > ship[0, 1] && catapult[i, 1] < ship[1, 1])
            {
                percent += 100;
            }
        }

        Console.WriteLine("{0}%", percent);
    }
}