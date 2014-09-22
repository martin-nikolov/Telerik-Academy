namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using ForumSystem.Data.Contracts;
    using Microsoft.AspNet.Identity;

    public class BaseApiController : ApiController
    {
        private IForumSystemData forumSystemData;

        public BaseApiController(IForumSystemData forumSystemData)
        {
            this.forumSystemData = forumSystemData;
        }

        protected IForumSystemData ForumSystemData
        {
            get
            {
                return this.forumSystemData;
            }
            set
            {
                this.forumSystemData = value;
            }
        }
        
        protected string GetUserId()
        {
            string userID = this.User.Identity.GetUserId();
            return userID;
        }

        protected string GetUsername()
        {
            string username = this.User.Identity.GetUserName();
            return username;
        }
    }
}