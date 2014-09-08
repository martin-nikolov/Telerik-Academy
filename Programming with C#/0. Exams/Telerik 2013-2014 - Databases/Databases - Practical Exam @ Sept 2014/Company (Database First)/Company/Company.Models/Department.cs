namespace Company.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(10), MaxLength(50)]
        public string Name { get; set; }
    }
}