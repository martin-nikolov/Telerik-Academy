namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Filters;
    using ForumSystem.Web.ViewModels;
    using Microsoft.AspNet.Identity;

    public class PostsController : Controller
    {
        private IRepository<Post> posts;
        private IRepository<Vote> votes;

        public PostsController(IRepository<Post> posts, IRepository<Vote> votes)
        {
            this.posts = posts;
            this.votes = votes;
        }

        [AjaxPost]
        [Authorize]
        public ActionResult Vote(VoteViewModel model)
        {
            switch (model.VoteValue)
            {
                case "+":
                    {
                        this.UpdateOrCreateVote(model, 1);
                        break;
                    }
                case "-":
                    {
                        this.UpdateOrCreateVote(model, -1);
                        break;
                    }
                default:
                    { 
                        break;
                    }
            }

            return this.PartialView("_NumberOfVotes", model);
        }
 
        private void UpdateOrCreateVote(VoteViewModel model, int voteValue)
        {
            var userId = this.User.Identity.GetUserId();
            var vote = this.GetVoteFromDatabase(userId, model);

            if (vote != null)
            {
                this.ChangeVoteValue(vote, model, voteValue);
            }
            else
            {
                vote = this.CreateVote(model, userId, vote, voteValue);
            }
        }
 
        private void ChangeVoteValue(Vote vote, VoteViewModel model, int newVoteValue)
        {
            if (vote.Value == -newVoteValue)
            {
                vote.Value = 0;
            }
            else if (vote.Value == 0)
            {
                vote.Value = newVoteValue;
            }

            this.votes.Update(vote);
            this.votes.SaveChanges();
            model.PostVotes = this.GetPostVotes(model.PostId);
        }
 
        private Vote GetVoteFromDatabase(string userId, VoteViewModel model)
        {
            var vote = this.votes.All()
                           .Where(v => v.AuthorId == userId && v.PostId == model.PostId)
                           .FirstOrDefault();
            return vote;
        }
 
        private Vote CreateVote(VoteViewModel model, string userId, Vote vote, int voteValue)
        {
            vote = new Vote()
            {
                PostId = model.PostId,
                Value = voteValue,
                AuthorId = userId
            };

            model.PostVotes = model.PostVotes.HasValue ? model.PostVotes + voteValue : voteValue;
            this.votes.Add(vote);
            this.votes.SaveChanges();
            return vote;
        }

        private int GetPostVotes(int id)
        {
            return this.posts.GetById(id).Votes.Sum(v => v.Value);
        }
    }
}