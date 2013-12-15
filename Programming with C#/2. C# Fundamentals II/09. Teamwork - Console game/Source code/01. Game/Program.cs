using System;
using System.Threading;
using _01.Game;

class Program
{
    public static WMPLib.WindowsMediaPlayer IntroSound, BossSound, Movement, SaucerSound, ShootSound;
    public static bool IsPlayerShootNow = false, FromOtherMenu = false, ShowMessage = false, StopGame = false;

    private static Invaders invaders = new Invaders();
    private static FlyingSaucer aliens = new FlyingSaucer();

    public static void Main()
    {
        Field.GetFieldOptions();

        #region [Sounds effects]
        if (!FromOtherMenu && System.IO.File.Exists("Sounds/outer_space.mp3"))
        {
            IntroSound = new WMPLib.WindowsMediaPlayer();
            IntroSound.URL = "Sounds/outer_space.mp3";
            IntroSound.controls.play();
            IntroSound.settings.playCount = 10;
        }

        if (System.IO.File.Exists("Sounds/saucer.mp3"))
        {
            SaucerSound = new WMPLib.WindowsMediaPlayer();
            SaucerSound.settings.autoStart = false;
            SaucerSound.URL = "Sounds/saucer.mp3";
            SaucerSound.settings.volume = 5;
        }

        if (System.IO.File.Exists("Sounds/boss.mp3"))
        {
            BossSound = new WMPLib.WindowsMediaPlayer();
            BossSound.settings.autoStart = false;
            BossSound.URL = "Sounds/boss.mp3";
            BossSound.settings.playCount = 2;
        }

        if (System.IO.File.Exists("Sounds/movement.mp3"))
        {
            Movement = new WMPLib.WindowsMediaPlayer();
            Movement.settings.autoStart = false;
            Movement.URL = "Sounds/movement.mp3";
            Movement.settings.volume = 50;
        }

        if (System.IO.File.Exists("Sounds/shoot.mp3"))
        {
            ShootSound = new WMPLib.WindowsMediaPlayer();
            ShootSound.settings.autoStart = false;
            ShootSound.URL = "Sounds/shoot.mp3";
            ShootSound.settings.volume = 10;
        }
        #endregion

        FromOtherMenu = false;

        MenuUserChoice();

        Console.Clear();

        if (Movement != null) Movement.controls.play();

        do
        {
            if (!StopGame)
            {
                Towers.PrintTowers();
                Field.ShowStatus();

                Field.CheckForAvailableKey();

                if (!Boss.BossTime)
                {
                    Invaders.MoveInvaders();
                    Invaders.PrintInvaders();
                }
                else if (Boss.BossTime && Boss.Hitted > 0)
                {
                    if (Movement != null) Movement = null;

                    Field.Speed = 200;
                    PlayerShip.PlayerShootSpeed = 20;
                    Boss.MoveBoss();
                    ObjectProperties.PrintObject(Boss.BossMatrix, Boss.BossCoords, 0, "boss");

                    if (new Random().Next(1, 5) == 2)
                    {
                        Thread shoot = new Thread(Boss.Shoot);
                        shoot.IsBackground = true;
                        shoot.Start();
                    }
                }
            }

            if (Boss.Hitted <= 0)
            {
                if (BossSound != null) BossSound.controls.stop();

                StopGame = true;
                Invaders.IsShooted = true;
                Field.Score += 1000;
                Thread.Sleep(300);
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 8);
                Field.EndGame();
                Environment.Exit(Environment.ExitCode);
            }

            if (!StopGame)
            {
                // Generates new shoot
                if (new Random().Next(1, 8) == 2)
                {
                    Thread shoot = new Thread(Invaders.Shoot);
                    shoot.IsBackground = true;
                    shoot.Start();
                }

                // Prints player's object
                PlayerShip.PrintObject(PlayerShip.Player, PlayerShip.PlayerCoords, type: "player");

                // Move flying saucer if exits, if not exit -> creates a new one
                MoveOrGenerateFlyingSaucer();

                if (!ShowMessage && Invaders.InvaderCoords1.Count == 0 && Invaders.InvaderCoords2.Count == 0 && Invaders.InvaderCoords3.Count == 0)
                {
                    if (Movement != null) Movement.controls.stop();

                    Boss.BossTime = true;

                    if (BossSound != null) BossSound.controls.play();

                    Invaders.ShootNow = true;
                    ShowMessage = true;
                }
            }

            // Check if the player is alive
            IsPlayerAlive();

            Thread.Sleep(Field.Speed);
            Console.Clear();
        }
        while (true);
    }

    private static void MenuUserChoice()
    {
        int choice = Field.Introduction();

        if (choice == 1)
        {
            Field.ThreeSeconds();
            if (IntroSound != null) IntroSound.controls.stop();
        }
        else if (choice == 2) Field.MenuInstructions();
        else if (choice == 3) Field.MenuRankList();
        else if (choice == 4) Field.MenuAbout();
        else
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.Write(new string(' ', Console.WindowWidth - 1));
            Console.SetCursorPosition(Console.WindowWidth / 2 - 13, Console.WindowHeight - 2);
            Environment.Exit(1);
        }
    }

    private static void MoveOrGenerateFlyingSaucer()
    {
        if (FlyingSaucer.IsExits)
        {
            FlyingSaucer.MoveAlien();
            ObjectProperties.PrintObject(FlyingSaucer.AlienMatrix, FlyingSaucer.AlienCoords, 0, "alien");
        }
        else if (!FlyingSaucer.IsExits && new Random().Next(1, 20) == 2)
        {
            if (!Boss.BossTime && SaucerSound != null) SaucerSound.controls.play();

            Program.aliens = new FlyingSaucer();
            FlyingSaucer.IsExits = true;
        }
    }

    private static void IsPlayerAlive()
    {
        if (Invaders.IsShooted)
        {
            if (Movement != null) Movement.controls.stop();

            StopGame = true;
            Thread.Sleep(300);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 8);
            Field.EndGame();
            Environment.Exit(0);
        }
    }
}