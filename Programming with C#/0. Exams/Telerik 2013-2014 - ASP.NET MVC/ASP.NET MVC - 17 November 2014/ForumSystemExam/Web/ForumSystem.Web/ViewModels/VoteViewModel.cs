namespace ForumSystem.Web.ViewModels
{
    using System;
    using System.Linq;

    public class VoteViewModel
    {
        public int PostId { get; set; }

        public int? PostVotes { get; set; }

        public string VoteValue { get; set; }
    }
}