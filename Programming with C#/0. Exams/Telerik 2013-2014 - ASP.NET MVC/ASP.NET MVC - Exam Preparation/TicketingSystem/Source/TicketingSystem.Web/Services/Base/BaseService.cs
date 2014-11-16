namespace TicketingSystem.Web.Services.Base
{
    using System;
    using System.Linq;
    using TicketingSystem.Data.UnitOfWork;

    public abstract class BaseService
    {
        private ITicketingSystemData data;

        public BaseService(ITicketingSystemData data)
        {
            this.data = data;
        }

        public ITicketingSystemData Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }
    }
}