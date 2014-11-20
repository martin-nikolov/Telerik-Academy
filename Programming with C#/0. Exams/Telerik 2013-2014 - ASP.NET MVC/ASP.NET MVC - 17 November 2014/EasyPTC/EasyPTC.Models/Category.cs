namespace EasyPTC.Models
{
    using System.ComponentModel.DataAnnotations;
    using EasyPTC.Data.Contracts;

    public class Category : DeletableEntity, IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsPublic { get; set; }

        public int MaxAds { get; set; }
    }
}