namespace ForumSystem.Web.Projections
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using ForumSystem.Models;

    public class CategoryProjection
    {
        public static Expression<Func<Category, CategoryProjection>> FromCategory
        {
            get
            {
                return category => new CategoryProjection
                {
                    ID = category.ID,
                    Name = category.Name
                };
            }
        }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}