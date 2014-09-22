namespace ForumSystem.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ForumSystem.Models;

    public class DataGenerator
    {
        private static readonly Random rnd = new Random();

        public IList<Article> GenerateArticles(int count)
        {
            var category = this.GenerateCategory();
            var tags = this.GenerateTagsCollection();

            var articles = new List<Article>();
            for (int i = 0; i < count; i++)
            {
                var article = new Article
                {
                    ID = i,
                    Title = "Title #" + i,
                    Content = "Content #" + i,
                    Category = category,
                    DateCreated = DateTime.Now.AddHours(rnd.Next(-5 * 365, 5 * 365)),
                    Tags = tags,
                    Author = new ApplicationUser()
                };

                articles.Add(article);
            }

            return articles;
        }

        public Category GenerateCategory()
        {
            var category = new Category()
            {
                Name = "test-category"
            };

            return category;
        }

        public IList<Tag> GenerateTagsCollection()
        {
            var tags = new List<Tag>()
            {
                new Tag()
                {
                    ID = 1,
                    Name = "test-tag"
                }
            };

            return tags;
        }
    }
}