using System;
using System.Linq;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 2;
            int startCol = 2;
            int endCol = WorldCols - 2;
            int endRow = WorldRows - 15;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            //engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            #region

            /* Exercise: 1 */

            for (int row = 1; row < WorldRows - 1; row++)
            {
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(row, 0)));
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(row, WorldCols - 1)));
            }

            for (int col = 1; col < WorldCols - 1; col++)
            {
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(1, col)));
            }

            /* Exercise: 5 */

            engine.AddObject(new TrailObject(new MatrixCoords(5, 5), 20));
            engine.AddObject(new TrailObject(new MatrixCoords(5, 10), 30));
            engine.AddObject(new TrailObject(new MatrixCoords(5, 15), 40));

            /* Exercise: 6 and 7 */

            //engine.AddObject(new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1)));

            /* Exercise: 8 and 9 */

            // for (int i = startCol + 5; i < endCol; i += 2)
            //  engine.AddObject(new UnpassableBlock(new MatrixCoords(startRow + 4, i)));

            engine.AddObject(new UnstoppableBall(new MatrixCoords(WorldRows / 2 + 5, 0), new MatrixCoords(-1, 1)));
            
            /* Exercise: 10 */

            for (int j = startRow + 1; j < endRow; j++)
                for (int i = startCol; i < endCol; i++)
                    engine.AddObject(RandomBlock.GenerateRandomBlock(new MatrixCoords(j, i)));
            
            #endregion
        }
        
        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();
            
            EngineForShootingRacket gameEngine = new EngineForShootingRacket(renderer, keyboard, 100);
            
            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };
            
            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };
            
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };
            
            Initialize(gameEngine);
            
            //
            
            gameEngine.Run();
        }
    }
}