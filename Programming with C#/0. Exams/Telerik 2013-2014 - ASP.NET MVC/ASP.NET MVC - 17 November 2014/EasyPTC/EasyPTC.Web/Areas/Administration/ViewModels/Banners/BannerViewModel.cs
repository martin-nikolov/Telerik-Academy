namespace EasyPTC.Web.Areas.Administration.ViewModels.Banners
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using EasyPTC.Models;
    using EasyPTC.Web.Infrastructure.Mapping;

    public class BannerViewModel : IMapFrom<Banner>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Url { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(0, 1000)]
        public int AvailableClicks { get; set; }
    }
}