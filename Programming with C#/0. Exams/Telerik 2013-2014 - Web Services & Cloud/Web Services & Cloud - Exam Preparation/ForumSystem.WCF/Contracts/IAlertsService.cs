namespace ForumSystem.WCF.Contracts
{
    using System;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using ForumSystem.WCF.Projections;

    [ServiceContract]
    public interface IAlertsService
    {
        [OperationContract]
        [WebGet(UriTemplate = "api/Alerts")]
        IQueryable<AlertProjection> GetAlerts();
    }
}