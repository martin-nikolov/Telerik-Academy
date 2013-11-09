using System;
using System.Collections.Generic;
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
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;
            int endRow = WorldRows - 15;

            for (int i = startCol; i < endCol; i++)
                engine.AddObject(new Block(new MatrixCoords(startRow, i)));

            //AddTrailObjects(engine); /* Task 5 */

            /*** BLOCKS ***/
            AddWalls(engine); /* Task 1 */
            //AddUnpassableBlocks(engine, startCol, endCol, startRow); /* Task 9 */
            //AddExplodingBlocks(engine, startCol, endCol, startRow); /* Task 10 */
            //AddGiftBlocks(engine, startCol, endCol, startRow); /* Task 12 */
            AddRandomBlocks(engine, startCol, endCol, startRow, endRow);

            /*** BALLS ***/
            //AddMeteoriteBall(engine); /* Task 6 and 7 */
            AddUnstoppableBall(engine); /* Task 9 */
            //engine.AddObject(new Ball(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1)));

            /*** RACKETS ***/
            engine.AddObject(new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength));
            //engine.AddObject(new ShootingRacket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength));
        }

        /// <summary>
        /// Task 1
        /// </summary>
        static void AddWalls(Engine engine)
        {
            for (int row = 1; row < WorldRows - 1; row++)
            {
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(row, 0)));
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(row, WorldCols - 1)));
            }

            for (int col = 1; col < WorldCols - 1; col++)
            {
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(1, col)));
            }
        }

        /// <summary>
        /// Task 5
        /// </summary>
        static void AddTrailObjects(Engine engine)
        {
            engine.AddObject(new TrailObject(new MatrixCoords(5, 5), 20));
            engine.AddObject(new TrailObject(new MatrixCoords(5, 10), 30));
            engine.AddObject(new TrailObject(new MatrixCoords(5, 15), 40));
        }

        /// <summary>
        /// Task 6 and 7
        /// </summary>
        /// <param name="engine"></param>
        static void AddMeteoriteBall(Engine engine)
        {
            engine.AddObject(new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1)));
        }

        /// <summary>
        /// Task 9
        /// </summary>
        static void AddUnpassableBlocks(Engine engine, int startCol, int endCol, int startRow)
        {
            for (int i = startCol + 5; i < endCol; i += 2)
                engine.AddObject(new UnpassableBlock(new MatrixCoords(startRow + 4, i)));
        }

        /// <summary>
        /// Task 9
        /// </summary>
        static void AddUnstoppableBall(Engine engine)
        {
            engine.AddObject(new UnstoppableBall(new MatrixCoords(WorldRows / 2 + 5, 0), new MatrixCoords(-1, 1)));
        }

        /// <summary>
        /// Task 10
        /// </summary>
        static void AddExplodingBlocks(Engine engine, int startCol, int endCol, int startRow)
        {
            for (int i = startCol + 5; i < endCol; i += 2)
                engine.AddObject(new ExplodingBlock(new MatrixCoords(startRow + 4, i)));
        }

        /// <summary>
        /// Task 12
        /// </summary>
        static void AddGiftBlocks(Engine engine, int startCol, int endCol, int startRow)
        {
            for (int i = startCol + 5; i < endCol; i += 2)
                engine.AddObject(new GiftBlock(new MatrixCoords(startRow + 4, i)));
        }

        /// <summary>
        /// Adding random blocks
        /// </summary>
        static void AddRandomBlocks(Engine engine, int startCol, int endCol, int startRow, int endRow)
        {
            for (int j = startRow + 1; j < endRow; j++)
                for (int i = startCol; i < endCol; i++)
                    engine.AddObject(RandomBlock.GenerateRandomBlock(new MatrixCoords(j, i)));
        }

        static void ShowUnitInformation()
        {
            List<string> unitInfo = new List<string>();

            unitInfo.Add("# - Sample block");
            unitInfo.Add(IndestructibleBlock.Symbol + " - Indestructible block");
            unitInfo.Add(UnpassableBlock.Symbol + " - Unpassable block");
            unitInfo.Add(GiftBlock.Symbol + " - Gift -> Produce: " + Gift.Symbol);
            unitInfo.Add(ExplodingBlock.Symbol + " - Exploding block -> Produce: " + Explode.Symbol);
            unitInfo.Add("");
            unitInfo.Add(TrailObject.Symbol + " - Trail object");
            unitInfo.Add("o - Ball");
            unitInfo.Add(MeteoriteBall.Symbol + " - Meteorite ball -> Produce: " + TrailObject.Symbol);
            unitInfo.Add(UnstoppableBall.Symbol + " - Unstoppable ball");
            unitInfo.Add("");
            unitInfo.Add("====== - Shooting racket -> Produce: " + Bullet.Symbol);

            for (int i = 0; i < unitInfo.Count; i++)
            {
                Console.SetCursorPosition(42, 1 + i);
                Console.WriteLine(unitInfo[i]);
            }
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            var gameEngine = new EngineForShootingRacket(renderer, keyboard, 200);

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

            ShowUnitInformation();

            gameEngine.Run();
        }
    }
}