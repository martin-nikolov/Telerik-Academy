namespace ForumSystem.WCF
{
    using System;
    using System.Linq;
    using ForumSystem.Data.Contracts;
    using ForumSystem.Data.UnitOfWork;
    using ForumSystem.WCF.Contracts;
    using ForumSystem.WCF.Projections;

    public class AlertsService : IAlertsService
    {
        private readonly IAlertsData alertsData = new AlertsData();

        public IQueryable<AlertProjection> GetAlerts()
        {
            return this.alertsData.Alerts
                       .All()
                       .Where(a => a.ExpirationDate > DateTime.Now)
                       .OrderBy(a => a.ExpirationDate)
                       .Select(AlertProjection.FromAlert);
        }
    }
}