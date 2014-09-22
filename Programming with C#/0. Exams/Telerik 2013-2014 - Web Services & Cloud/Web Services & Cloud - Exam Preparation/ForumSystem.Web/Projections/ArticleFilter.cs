namespace ForumSystem.Web.Projections
{
    using System;
    using System.Linq;

    public class ArticleFilter
    {
        public string Category { get; set; }

        public int? Page { get; set; }
    }
}