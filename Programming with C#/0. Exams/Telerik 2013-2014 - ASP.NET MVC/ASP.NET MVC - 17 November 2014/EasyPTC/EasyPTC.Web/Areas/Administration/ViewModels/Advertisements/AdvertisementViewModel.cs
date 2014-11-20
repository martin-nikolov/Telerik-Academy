namespace EasyPTC.Web.Areas.Administration.ViewModels.Advertisements
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using EasyPTC.Models;
    using EasyPTC.Web.Areas.Administration.ViewModels.Base;
    using EasyPTC.Web.Infrastructure.Mapping;

    public class AdvertisementViewModel : AdministrationViewModel, IMapFrom<Advertisement>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Display(Name = "Име")]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "URL")]
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Url { get; set; }

        [Required]
        [Display(Name = "Останали кликове")]
        [Range(0, 1000)]
        public int AvailableClicks { get; set; }
    }
}