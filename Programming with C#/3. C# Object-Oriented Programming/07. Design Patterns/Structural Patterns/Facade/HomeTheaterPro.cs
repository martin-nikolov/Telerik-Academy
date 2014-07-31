using System;

namespace FacadePattern
{
    // FACADE
    public class HomeTheaterPro
    {
        private readonly Database db = new Database();
        private readonly Player player = new Player();
        private readonly InteriorController roomControll = new InteriorController();

        private static HomeTheaterPro instance;

        public static HomeTheaterPro GetInstance()
        {
            if (instance == null)
            {
                instance = new HomeTheaterPro();
            }

            return instance;
        }

        private void SeedDatabase()
        {
            db.Add(new MediaEntity
                {
                    Title = "Stardust",
                    FileExtention = "avi",
                    Duration = 160,
                    Content = new byte[200]
                });

            db.Add(new MediaEntity
            {
                Title = "Lord of the Rings - The Two Towers",
                FileExtention = "avi",
                Duration = 160,
                Content = new byte[200]
            });

            db.Add(new MediaEntity
            {
                Title = "Lord of the Rings - The Return of the King",
                FileExtention = "avi",
                Duration = 160,
                Content = new byte[200]
            });

            db.Add(new MediaEntity
            {
                Title = "Lord of the Rings - The Fellowship of the Ring",
                FileExtention = "mkv",
                Duration = 160,
                Content = new byte[200]
            });

            db.Add(new MediaEntity
            {
                Title = "The next three days",
                FileExtention = "mpeg",
                Duration = 160,
                Content = new byte[200]
            });

            db.Add(new MediaEntity
            {
                Title = "Red",
                FileExtention = "mp4",
                Duration = 160,
                Content = new byte[200]
            });
        }

        private HomeTheaterPro()
        {
            SeedDatabase(); // For testing
        }

        public void DisplayAvailableMedia()
        {
            var allMedia = db.GetAvailableMedia();

            foreach (var entity in allMedia)
            {
                Console.WriteLine("{0} - {1} minutes", entity.Title, entity.FileExtention);
            }
        }

        public void InitHomeSystem()
        {
            Console.WriteLine();
            Console.WriteLine("".PadLeft(30, '='));
            Console.WriteLine();
            roomControll.DimLights(15);
            roomControll.MoveCurtains(0);
            roomControll.HideTable();
            Console.WriteLine();
            Console.WriteLine("".PadLeft(30, '='));
            Console.WriteLine();
            LoadMedia();
            Console.WriteLine();
            Console.WriteLine("".PadLeft(30, '='));
            Console.WriteLine();
            player.Play();
        }

        private void LoadMedia()
        {
            var allMedia = db.GetAvailableMedia();

            foreach (var entity in allMedia)
            {
                player.Load(entity);
            }
        }

        public void Next()
        {
            player.Next();
            player.Play();
        }

        public void Previous()
        {
            player.Previous();
            player.Play();
        }

        public void Stop()
        {
            player.Stop();
        }
    }
}