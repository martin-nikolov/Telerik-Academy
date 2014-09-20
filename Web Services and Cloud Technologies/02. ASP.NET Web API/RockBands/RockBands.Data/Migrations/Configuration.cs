namespace RockBands.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RockBands.Data.Contracts;
    using RockBands.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RockBandsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "RockBands.Data.RockBandsDbContext";
        }

        protected override void Seed(RockBandsDbContext context)
        {
            this.SeedBands(context);
            this.SeedAlbums(context);
            this.SeedSongs(context);
        }

        private void SeedBands(IRockBandsDbContext context)
        {
            if (context.Bands.Any())
            {
                return;
            }

            var acdc = new Band()
            {
                ImageUrl = "http://nikolov.cloudvps.bg/rockbands/images/ac-dc.jpg",
                Name = "AC/DC",
                Nationality = "Australia",
                OfficialSite = "www.acdc.com",
                ReleasedAt = new DateTime(1973, 1, 1),
                Src = "ac-dc",
                Rating = 4
            };

            acdc.Artists = new List<Artist>()
            {
                new Artist()
                {
                    Name = "Brian Johnson"
                },
                new Artist()
                {
                    Name = "Angus Young"
                },
                new Artist()
                {
                    Name = "Cliff Williams"
                },
                new Artist()
                {
                    Name = "Phil Rudd"
                },
            };

            var beatles = new Band()
            {
                ImageUrl = "http://nikolov.cloudvps.bg/rockbands/images/the-beatles.jpg",
                Name = "The Beatles",
                Nationality = "England",
                OfficialSite = "www.thebeatles.com",
                ReleasedAt = new DateTime(1960, 1, 1),
                Src = "beatles",
                Rating = 10
            };

            beatles.Artists = new List<Artist>()
            {
                new Artist()
                {
                    Name = "John Lennon"
                },
                new Artist()
                {
                    Name = "Paul McCartney"
                },
                new Artist()
                {
                    Name = "George Harrison"
                },
                new Artist()
                {
                    Name = "Ringo Starr"
                },
            };

            var nazareth = new Band()
            {
                ImageUrl = "http://nikolov.cloudvps.bg/rockbands/images/nazareth.jpg",
                Name = "Nazareth",
                Nationality = "Scotland",
                OfficialSite = "www.nazarethdirect.co.uk",
                ReleasedAt = new DateTime(1968, 1, 1),
                Src = "nazareth",
                Rating = 15
            };

            nazareth.Artists = new List<Artist>()
            {
                new Artist()
                {
                    Name = "Dan McCafferty"
                },
                new Artist()
                {
                    Name = "Darrell Sweet"
                },
                new Artist()
                {
                    Name = "Manny Charlton"
                },
                new Artist()
                {
                    Name = "Zal Cleminson"
                },
                new Artist()
                {
                    Name = "Billy Rankin"
                },
                new Artist()
                {
                    Name = "John Locke"
                },
                new Artist()
                {
                    Name = "Ronnie Leahey"
                },
            };

            context.Bands.Add(acdc);
            context.Bands.Add(beatles);
            context.Bands.Add(nazareth);
            context.SaveChanges();
        }

        private void SeedAlbums(IRockBandsDbContext context)
        {
            if (context.Albums.Any())
            {
                return;
            }

            var razamanaz = new Album()
            {
                Name = "Razamanaz",
                ImageUrl = "http://nikolov.cloudvps.bg/rockbands/images/razamanaz.jpg",
                Rating = 10,
                ReleasedAt = new DateTime(1973, 1, 1),
                Src = "razamanaz",
                BandId = 3
            };

            var pastMasters = new Album()
            {
                Name = "Past Masters",
                ImageUrl = "http://nikolov.cloudvps.bg/rockbands/images/past-masters.jpg",
                Rating = 8,
                ReleasedAt = new DateTime(2009, 1, 1),
                Src = "past-masters",
                BandId = 2
            };

            var redAlbum = new Album()
            {
                Name = "Red Album",
                ImageUrl = "http://nikolov.cloudvps.bg/rockbands/images/red-album.jpg",
                Rating = 6,
                ReleasedAt = new DateTime(1973, 1, 1),
                Src = "red-album",
                BandId = 2
            };

            context.Albums.Add(razamanaz);
            context.Albums.Add(pastMasters);
            context.Albums.Add(redAlbum);
            context.SaveChanges();
        }

        private void SeedSongs(IRockBandsDbContext context)
        {
            if (context.Songs.Any())
            {
                return;
            }

            var razamanaz = new Song()
            {
                Name = "Razamanaz",
                ImageUrl = "http://nikolov.cloudvps.bg/rockbands/images/razamanaz.jpg",
                Rating = 5,
                Src = "razamanaz-song",
                Link = "https://youtube.com/watch?v=INR6AB6bXeQ",
                AlbumId = 1
            };

            var nightWoman = new Song()
            {
                Name = "Night Woman",
                ImageUrl = "http://nikolov.cloudvps.bg/rockbands/images/night-woman.jpg",
                Rating = 3,
                Src = "night-woman",
                Link = "https://youtube.com/watch?v=QVv3m1phqkQ",
                AlbumId = 1
            };

            var soldMySoul = new Song()
            {
                Name = "Sold My Soul",
                ImageUrl = "http://nikolov.cloudvps.bg/rockbands/images/woke-up-this-morning.jpg",
                Rating = 2,
                Src = "sold-my-soul",
                Link = "http://youtube.com/watch?v=fAkN72B9WkY",
                AlbumId = 1
            };

            context.Songs.Add(razamanaz);
            context.Songs.Add(nightWoman);
            context.Songs.Add(soldMySoul);
            context.SaveChanges();
        }
    }
}