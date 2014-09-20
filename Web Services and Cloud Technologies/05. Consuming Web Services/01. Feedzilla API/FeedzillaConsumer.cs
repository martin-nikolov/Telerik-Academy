namespace FeedZillaApi
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using FeedZillaApi.Models;
    using Newtonsoft.Json;

    public class FeedzillaConsumer
    {
        private const string QueryString = "http://api.feedzilla.com/v1/categories/26/articles/search.json?q={0}&count={1}";

        public void GetArticles(string searchPattern, int count, Action<Article> articleAction)
        {
            var queryString = BuildQueryString(searchPattern, count);
            var request = HttpWebRequest.Create(queryString);

            using (var responseStream = request.GetResponse().GetResponseStream())
            {
                using (var reader = new StreamReader(responseStream))
                {
                    var fzResult = JsonConvert.DeserializeObject<FZResult>(reader.ReadToEnd());
                    fzResult.Articles.ForEach(articleAction);
                }
            }
        }

        private static string BuildQueryString(string q, int count)
        {
            var fullQueryString = string.Format(QueryString, q, count);
            return fullQueryString;
        }
    }
}