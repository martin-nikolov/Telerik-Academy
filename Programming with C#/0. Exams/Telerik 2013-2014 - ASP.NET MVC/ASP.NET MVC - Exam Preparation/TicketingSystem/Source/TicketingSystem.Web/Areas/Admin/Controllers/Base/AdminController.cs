namespace TicketingSystem.Web.Areas.Admin.Controllers.Base
{
    using System.Web.Mvc;
    using TicketingSystem.Common;
    using TicketingSystem.Data.UnitOfWork;
    using TicketingSystem.Web.Controllers.Base;

    [Authorize(Roles = GlobalConstants.AdminRoleName)]
    public abstract class AdminController : BaseController
    {
        public AdminController(ITicketingSystemData data)
            : base(data)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Data.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}