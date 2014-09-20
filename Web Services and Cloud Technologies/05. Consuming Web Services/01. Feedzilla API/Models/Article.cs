namespace FeedZillaApi.Models
{
    using System.Runtime.Serialization;

    public class Article
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}