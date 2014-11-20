namespace EasyPTC.Models
{
    using System.ComponentModel.DataAnnotations;
    using EasyPTC.Data.Contracts;

    public class Advertisement : DeletableEntity, IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int AvailableClicks { get; set; }
    }
}