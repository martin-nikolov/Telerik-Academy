namespace Company.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Employee
    {
        private ICollection<EmployeeProject> employeesProjects;
        private ICollection<Report> reports;

        public Employee()
        {
            this.employeesProjects = new HashSet<EmployeeProject>();
            this.reports = new HashSet<Report>();
        }

        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MinLength(5), MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(5), MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public decimal YearSalary { get; set; }

        [InverseProperty("EmployeeId")]
        public int? ManagerId { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Report> Reports
        {
            get
            {
                return this.reports;
            }
            set
            {
                this.reports = value;
            }
        }

        public ICollection<EmployeeProject> EmployeesProjects
        {
            get
            {
                return this.employeesProjects;
            }
            set
            {
                this.employeesProjects = value;
            }
        }
    }
}