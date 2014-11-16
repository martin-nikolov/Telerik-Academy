namespace TicketingSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Category
    {
        private ICollection<Ticket> tickets;

        public Category()
        {
            this.tickets = new HashSet<Ticket>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets
        {
            get
            {
                return this.tickets;
            }
            set
            {
                this.tickets = value;
            }
        }
    }
}