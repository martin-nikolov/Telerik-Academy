namespace Company.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}