namespace TicketingSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using TicketingSystem.Data.Models.Enums;

    public class Ticket
    {
        private ICollection<Comment> comments;

        public Ticket()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int TicketId { get; set; }

        [Required]
        [MaxLength(512)]
        public string Title { get; set; }

        [DefaultValue(PriorityType.Medium)]
        public PriorityType Priority { get; set; }

        [MaxLength(4096)]
        public string Description { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
    }
}