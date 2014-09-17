namespace StudentSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using StudentSystem.Models;

    public class MaterialModel
    {
        public static Expression<Func<Material, MaterialModel>> FromMaterial
        {
            get
            {
                return material => new MaterialModel
                {
                    MaterialId = material.MaterialId,
                    DownloadUrl = material.DownloadUrl,
                    HomeworkId = material.HomeworkId,
                    Type = material.Type
                };
            }
        }

        [Key]
        public int MaterialId { get; set; }

        [Required]
        public string DownloadUrl { get; set; }

        public MaterialType Type { get; set; }

        public int HomeworkId { get; set; }
    }
}