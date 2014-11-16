namespace TicketingSystem.Web.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Web.Infrastructure.Mapping;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public PostCommentViewModel()
        {
        }

        public PostCommentViewModel(int ticketId)
        {
            this.TicketId = ticketId;
        }

        public int TicketId { get; set; }

        [Required]
        [MinLength(100), MaxLength(1000)]
        [UIHint("MultiLineText")]
        public string Content { get; set; }
    }
}