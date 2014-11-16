namespace TicketingSystem.Web.Infrastructure.Filters
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}