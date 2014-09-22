namespace ForumSystem.WCF.Projections
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using ForumSystem.Models;
    using Microsoft.Build.Framework;

    public class AlertProjection
    {
        public static Expression<Func<Alert, AlertProjection>> FromAlert
        {
            get
            {
                return alert => new AlertProjection
                {
                    ID = alert.ID,
                    Content = alert.Content,
                    ExpirationDate = alert.ExpirationDate
                };
            }
        }

        public int ID { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}