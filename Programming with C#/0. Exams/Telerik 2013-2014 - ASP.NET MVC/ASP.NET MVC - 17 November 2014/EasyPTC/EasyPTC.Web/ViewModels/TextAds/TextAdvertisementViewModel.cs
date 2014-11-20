namespace EasyPTC.Web.ViewModels.TextAds
{
    using System;
    using System.Linq;
    using EasyPTC.Models;
    using EasyPTC.Web.Infrastructure.Mapping;

    public class TextAdvertisementViewModel : IMapFrom<TextAdvertisement>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }
    }
}