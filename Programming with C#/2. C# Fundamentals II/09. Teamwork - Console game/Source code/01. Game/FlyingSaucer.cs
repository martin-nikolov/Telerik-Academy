using System;
using System.Collections.Generic;

namespace _01.Game
{
    class FlyingSaucer : ObjectProperties
    {
        public static List<Coordinates> AlienCoords = new List<Coordinates>();
        public static int Score = 150;
        public static bool IsExits = true;
        public static char[,] AlienMatrix = 
         {
            { ' ', ' ', '/', '-', '-', '\\', ' ', ' ' },
            { '<', '=', '=', '=', '=', '=', '=', '>' },
            { ' ', ' ', '\\', '-', '-', '/', ' ', ' ' },
        };

        private static string direction;

        public FlyingSaucer()
        {
            if (!Boss.BossTime)
            {
                if (!Invaders.Right)
                {
                    direction = "right";
                    AlienCoords = new List<Coordinates>();
                    FlyingSaucer.SetObjectCoords(AlienMatrix, AlienCoords, -8, 1);
                }
                else
                {
                    direction = "left";
                    AlienCoords = new List<Coordinates>();
                    FlyingSaucer.SetObjectCoords(AlienMatrix, AlienCoords, Console.WindowWidth, 1);
                }
            }
            else
            {
                if (direction == "left")
                {
                    direction = "right";
                    AlienCoords = new List<Coordinates>();
                    FlyingSaucer.SetObjectCoords(AlienMatrix, AlienCoords, -8, 1);
                }
                else
                {
                    direction = "left";
                    AlienCoords = new List<Coordinates>();
                    FlyingSaucer.SetObjectCoords(AlienMatrix, AlienCoords, Console.WindowWidth, 1);
                }
            }
        }

        public static void MoveAlien()
        {
            int step = 3;

            if (Field.Speed <= 200 && Field.Speed > 100) { step = 3; Score = 250; }
            else if (Field.Speed <= 100) { step = 1; Score = 500; }

            if (direction == "right")
            {
                for (int i = 0; i < AlienCoords.Count; i++)
                    AlienCoords[i] = new Coordinates(AlienCoords[i].Row, AlienCoords[i].Col + step);

                if (AlienCoords[0].Col >= Console.WindowWidth) IsExits = false;
            }
            else if (direction == "left")
            {
                for (int i = 0; i < AlienCoords.Count; i++)
                    AlienCoords[i] = new Coordinates(AlienCoords[i].Row, AlienCoords[i].Col - step);

                if (AlienCoords[AlienCoords.Count - 1].Col < 0) IsExits = false;
            }
        }
    }
}
