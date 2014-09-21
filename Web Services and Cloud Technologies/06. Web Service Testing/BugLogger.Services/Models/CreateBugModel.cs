namespace BugLogger.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class CreateBugModel
    {
        [Required]
        public string Description { get; set; }

        public DateTime LogDate { get; set; }
    }
}