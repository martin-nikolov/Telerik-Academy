namespace FeedZillaApi.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class FZResult
    {
        [DataMember(Name = "articles")]
        public List<Article> Articles { get; set; }
    }
}