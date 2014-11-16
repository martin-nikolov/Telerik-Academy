namespace TicketingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Data.Models.Enums;
    using TicketingSystem.Web.Infrastructure.Filters;
    using TicketingSystem.Web.Infrastructure.Mapping;

    public class CreateTicketViewModel : IMapFrom<Ticket>
    {
        public CreateTicketViewModel()
        {
            this.Priority = PriorityType.Medium;
        }

        [Required]
        [MaxLength(512)]
        [UIHint("SingleLineText")]
        [DoesNotContain("bug")]
        public string Title { get; set; }

        [UIHint("Enum")]
        [DefaultValue(PriorityType.Medium)]
        public PriorityType Priority { get; set; }

        [MaxLength(4096)]
        [UIHint("MultiLineText")]
        public string Description { get; set; }

        [UIHint("DropDownList")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }
    }
}