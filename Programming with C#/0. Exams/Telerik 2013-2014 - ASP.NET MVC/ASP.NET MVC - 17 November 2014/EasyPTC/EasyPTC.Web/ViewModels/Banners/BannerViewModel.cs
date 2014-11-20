namespace EasyPTC.Web.ViewModels.Banners
{
    using System;
    using System.Linq;
    using EasyPTC.Models;
    using EasyPTC.Web.Infrastructure.Mapping;

    public class BannerViewModel : IMapFrom<Banner>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}