namespace Visitors.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Visitor
    {
        [Key]
        public int Id { get; set; }

        public int Count { get; set; }
    }
}