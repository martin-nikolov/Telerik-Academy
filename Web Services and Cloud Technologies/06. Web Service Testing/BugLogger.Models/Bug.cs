namespace BugLogger.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Bug
    {
        [Key]
        public int BugId { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime LogDate { get; set; }

        public BugStatus Status { get; set; }
    }
}