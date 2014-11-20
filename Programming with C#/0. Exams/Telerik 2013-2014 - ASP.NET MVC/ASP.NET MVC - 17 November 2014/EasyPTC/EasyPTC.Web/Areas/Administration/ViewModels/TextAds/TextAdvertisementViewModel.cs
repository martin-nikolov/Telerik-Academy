namespace EasyPTC.Web.Areas.Administration.ViewModels.TextAds
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using EasyPTC.Models;
    using EasyPTC.Web.Infrastructure.Mapping;

    public class TextAdvertisementViewModel : IMapFrom<TextAdvertisement>
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
        [MaxLength(256)]
        [UIHint("MultiLineText")]
        public string Content { get; set; }

        [Required]
        [Range(0, 1000)]
        public int AvailableClicks { get; set; }
    }
}