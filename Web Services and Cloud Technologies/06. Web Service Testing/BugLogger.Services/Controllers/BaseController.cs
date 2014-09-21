namespace BugLogger.Services.Controllers
{
    using System.Web.Http;
    using BugLogger.Data;
    using BugLogger.Data.Contracts;

    public class BaseController : ApiController
    {
        private IBugLoggerData bugLoggerData;
  
        public BaseController()
            : this(new BugLoggerData())
        {
        }

        public BaseController(IBugLoggerData bugLoggerData)
        {
            this.bugLoggerData = bugLoggerData;
        }

        protected IBugLoggerData BugLoggerData
        {
            get
            {
                return this.bugLoggerData;
            }
            set
            {
                this.bugLoggerData = value;
            }
        }
    }
}