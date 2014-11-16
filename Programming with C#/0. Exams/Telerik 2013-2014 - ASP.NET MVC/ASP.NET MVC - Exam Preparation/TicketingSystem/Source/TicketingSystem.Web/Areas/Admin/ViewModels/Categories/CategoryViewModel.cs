namespace TicketingSystem.Web.Areas.Admin.ViewModels.Categories
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Web.Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        [HiddenInput(DisplayValue = false)]
        public int? CategoryId { get; set; }

        [Required]
        [UIHint("String")]
        public string Name { get; set; }
    }
}