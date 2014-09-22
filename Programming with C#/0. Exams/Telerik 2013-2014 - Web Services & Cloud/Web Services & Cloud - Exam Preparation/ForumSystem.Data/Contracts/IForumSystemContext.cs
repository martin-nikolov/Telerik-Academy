namespace ForumSystem.Data.Contracts
{
    using System.Data.Entity;
    using ForumSystem.Models;

    public interface IForumSystemContext
    {
        IDbSet<Article> Articles { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Like> Likes { get; set; }

        IDbSet<Tag> Tags { get; set; }

        IDbSet<Alert> Alerts { get; set; }
    }
}