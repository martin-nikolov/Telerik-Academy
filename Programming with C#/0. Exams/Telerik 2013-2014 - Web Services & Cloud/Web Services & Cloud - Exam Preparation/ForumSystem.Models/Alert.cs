namespace ForumSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
   
    public class Alert
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}