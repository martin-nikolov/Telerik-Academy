namespace Company.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [MinLength(5), MaxLength(50)]
        public string Name { get; set; }
    }
}