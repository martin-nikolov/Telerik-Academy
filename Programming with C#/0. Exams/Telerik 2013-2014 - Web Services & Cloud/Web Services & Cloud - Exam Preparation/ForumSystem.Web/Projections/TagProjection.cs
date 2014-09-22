namespace ForumSystem.Web.Projections
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using ForumSystem.Models;

    public class TagProjection
    {
        public static Expression<Func<Tag, TagProjection>> FromTag
        {
            get
            {
                return tag => new TagProjection
                {
                    ID = tag.ID,
                    Name = tag.Name
                };
            }
        }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}