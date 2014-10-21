namespace UploadSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    public class ZipFileContent
    {
        public ZipFileContent()
        {
            this.Id = Guid.NewGuid();
            this.DateAdded = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime DateAdded { get; set; }
    }
}