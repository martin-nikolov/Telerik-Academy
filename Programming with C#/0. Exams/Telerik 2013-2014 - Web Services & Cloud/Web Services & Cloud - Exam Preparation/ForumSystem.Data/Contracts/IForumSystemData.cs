namespace ForumSystem.Data.Contracts
{
    using System;
    using System.Linq;
    using ForumSystem.Models;

    public interface IForumSystemData : IDisposable
    {
        IGenericRepository<Article> Articles { get; }

        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Comment> Comments { get; }

        IGenericRepository<Like> Likes { get; }

        IGenericRepository<Tag> Tags { get; }

        IGenericRepository<Alert> Alerts { get; }

        int SaveChanges();
    }
}