namespace EasyPTC.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;
    using EasyPTC.Common.Extensions;
    using EasyPTC.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<EasyPtcDbContext>
    {
        private IList<string> imgUrls = new List<string>()
        {
            "http://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg",
            "http://img2.stockfresh.com/files/i/italianestro/m/48/292077_71413901.jpg",
            "http://1.bp.blogspot.com/-N2fSe2JF0rg/T-vAeJcx4tI/AAAAAAAAErU/bOy8ya936xA/s400/Tiger+3D+Wallpapers.jpg",
            "http://www.economie.gouv.fr/files/files/directions_services/apie/onglet-donnees-et-images/iconographie/visuel_donnees_et_images_small.jpg",
            "https://d13yacurqjgara.cloudfront.net/users/1641/screenshots/1508301/ximage_1x.jpg",
            "http://4.bp.blogspot.com/-degFS1qFHiM/Ut3Z9OSs3qI/AAAAAAAABWw/oGIV8qH-qOc/s1600/happy+valentines+day+2014.gif"
        };

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EasyPtcDbContext context)
        {
            this.SeedRoles(context);
            this.SeedUsers(context);
            this.SeedAds(context);
            this.SeedBanners(context);
            this.SeedTextAds(context);
        }

        private void SeedUsers(EasyPtcDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));
            var admin = new User()
            {
                UserName = "admin@gmail.com",
            };

            userManager.Create(admin, "admin@gmail.com");
            userManager.AddToRole(admin.Id, "Admin");

            for (int i = 0; i < 10; i++)
            {
                var user = new User
                {
                    Email = string.Format("{0}@{1}.com",
                        RandomDataGenerator.Instance.GetRandomString(6, 16),
                        RandomDataGenerator.Instance.GetRandomString(6, 16)),
                    UserName = RandomDataGenerator.Instance.GetRandomString(6, 16)
                };

                userManager.Create(user, "123456");
            }

            context.SaveChanges();
        }

        private void SeedRoles(EasyPtcDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var adminRole = new IdentityRole { Name = "Admin" };
            roleManager.Create(adminRole);

            context.SaveChanges();
        }
 
        private void SeedBanners(EasyPtcDbContext context)
        {
            if (context.Banners.Any())
            {
                return; 
            }

            for (int i = 0; i < 50; i++)
            {
                context.Banners.Add(new Banner()
                {
                    Name = RandomDataGenerator.Instance.GetRandomString(5, 50),
                    AvailableClicks = RandomDataGenerator.Instance.GetRandomInt(5, 20),
                    Url = "http://telerikacademy.com",
                    ImageUrl = this.imgUrls[RandomDataGenerator.Instance.GetRandomInt(0, this.imgUrls.Count - 1)]
                });
            }

            context.SaveChanges();
        }

        private void SeedTextAds(EasyPtcDbContext context)
        {
            if (context.TextAdvertisements.Any())
            {
                return;
            }

            for (int i = 0; i < 50; i++)
            {
                var content = new StringBuilder();

                for (int j = 0; j < 10; j++)
                {
                    content.AppendFormat(" {0}", RandomDataGenerator.Instance.GetRandomString(5, 20));
                }

                context.TextAdvertisements.Add(new TextAdvertisement()
                {
                    Name = RandomDataGenerator.Instance.GetRandomString(5, 50),
                    AvailableClicks = RandomDataGenerator.Instance.GetRandomInt(5, 20),
                    Url = "http://telerikacademy.com",
                    Content = content.ToString()
                });
            }

            context.SaveChanges();
        }

        private void SeedAds(EasyPtcDbContext context)
        {
            if (context.Advertisements.Any())
            {
                return;
            }

            context.Advertisements.AddOrUpdate(a => a.Id,
                new Advertisement
                {
                    Name = "We are cool",
                    AvailableClicks = 500,
                    Url = "http://telerikacademy.com",
                },
                new Advertisement
                {
                    Name = "We are cool 1",
                    AvailableClicks = 500,
                    Url = "http://telerikacademy.com",
                }, new Advertisement
                   {
                       Name = "We are cool 2",
                       AvailableClicks = 500,
                       Url = "http://telerikacademy.com",
                   },
                new Advertisement
                {
                    Name = "We are cool",
                    AvailableClicks = 500,
                    Url = "http://telerikacademy.com",
                },
                new Advertisement
                {
                    Name = "We are cool 1",
                    AvailableClicks = 500,
                    Url = "http://telerikacademy.com",
                }, new Advertisement
                   {
                       Name = "We are cool 2",
                       AvailableClicks = 500,
                       Url = "http://telerikacademy.com",
                   }, new Advertisement
                      {
                          Name = "We are cool",
                          AvailableClicks = 500,
                          Url = "http://telerikacademy.com",
                      },
                new Advertisement
                {
                    Name = "We are cool 1",
                    AvailableClicks = 500,
                    Url = "http://telerikacademy.com",
                }, new Advertisement
                   {
                       Name = "We are cool 2",
                       AvailableClicks = 500,
                       Url = "http://telerikacademy.com",
                   }, new Advertisement
                      {
                          Name = "We are cool",
                          AvailableClicks = 500,
                          Url = "http://telerikacademy.com",
                      },
                new Advertisement
                {
                    Name = "We are cool 1",
                    AvailableClicks = 500,
                    Url = "http://telerikacademy.com",
                }, new Advertisement
                   {
                       Name = "We are cool 2",
                       AvailableClicks = 500,
                       Url = "http://telerikacademy.com",
                   }, new Advertisement
                      {
                          Name = "We are cool",
                          AvailableClicks = 500,
                          Url = "http://telerikacademy.com",
                      },
                new Advertisement
                {
                    Name = "We are cool 1",
                    AvailableClicks = 500,
                    Url = "http://telerikacademy.com",
                }, new Advertisement
                   {
                       Name = "We are cool 2",
                       AvailableClicks = 500,
                       Url = "http://telerikacademy.com",
                   }, new Advertisement
                      {
                          Name = "We are cool",
                          AvailableClicks = 500,
                          Url = "http://telerikacademy.com",
                      },
                new Advertisement
                {
                    Name = "We are cool 1",
                    AvailableClicks = 500,
                    Url = "http://telerikacademy.com",
                }, new Advertisement
                   {
                       Name = "We are cool 2",
                       AvailableClicks = 500,
                       Url = "http://telerikacademy.com",
                   }, new Advertisement
                      {
                          Name = "We are cool",
                          AvailableClicks = 500,
                          Url = "http://telerikacademy.com",
                      },
                new Advertisement
                {
                    Name = "We are cool 1",
                    AvailableClicks = 500,
                    Url = "http://telerikacademy.com",
                }, new Advertisement
                   {
                       Name = "We are cool 2",
                       AvailableClicks = 500,
                       Url = "http://telerikacademy.com",
                   }, new Advertisement
                      {
                          Name = "We are cool",
                          AvailableClicks = 500,
                          Url = "http://telerikacademy.com",
                      },
                new Advertisement
                {
                    Name = "We are cool 1",
                    AvailableClicks = 500,
                    Url = "http://telerikacademy.com",
                }, new Advertisement
                   {
                       Name = "We are cool 2",
                       AvailableClicks = 500,
                       Url = "http://telerikacademy.com",
                   });
        }
    }
}