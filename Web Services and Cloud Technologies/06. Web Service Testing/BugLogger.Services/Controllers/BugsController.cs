namespace BugLogger.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using BugLogger.Data.Contracts;
    using BugLogger.Models;
    using BugLogger.Services.Models;

    public class BugsController : BaseController
    {
        public BugsController()
            : base()
        {
        }

        public BugsController(IBugLoggerData bugLoggerData)
            : base(bugLoggerData)
        {
        }

        [HttpGet]
        public IQueryable<Bug> All()
        {
            return this.BugLoggerData.Bugs.All();
        }

        [HttpGet]
        public IQueryable<Bug> GetFromDate([FromUri]
                                           DateTime date)
        {
            return this.BugLoggerData.Bugs.GetAllFromDate(date);
        }

        [HttpGet]
        public IQueryable<Bug> GetToDate([FromUri]
                                         DateTime date)
        {
            return this.BugLoggerData.Bugs.GetAllToDate(date);
        }

        [HttpGet]
        public IQueryable<Bug> GetInDateRange([FromUri]
                                              DateTime fromDate, DateTime toDate)
        {
            return this.BugLoggerData.Bugs.GetAllInDateRange(fromDate, toDate);
        }

        [HttpGet]
        public IQueryable<Bug> GetByStatus([FromUri]
                                           BugStatus type)
        {
            return this.BugLoggerData.Bugs.GetAllByStatus(type);
        }

        [HttpPost]
        public HttpResponseMessage Create(CreateBugModel bugModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (string.IsNullOrEmpty(bugModel.Description))
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Description cannot be null or empty");
            }

            if (bugModel.LogDate == DateTime.MinValue || bugModel.LogDate == DateTime.MaxValue)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid LogDate: " + bugModel.LogDate);
            }

            var bug = new Bug()
            {
                Description = bugModel.Description,
                LogDate = bugModel.LogDate,
                Status = BugStatus.Pending
            };

            this.BugLoggerData.Bugs.Add(bug);
            this.BugLoggerData.SaveChanges();

            var response = this.Request.CreateResponse(HttpStatusCode.Created, bug);
            return response;
        }

        [HttpPost]
        public IHttpActionResult ChangeStatus(int id, BugStatus newStatus)
        {
            var bugFromDb = this.BugLoggerData.Bugs.Find(id);
            if (bugFromDb == null)
            {
                return this.BadRequest(string.Format("Bug with id={0} does not exists.", id));
            }

            bugFromDb.Status = newStatus;
            this.BugLoggerData.SaveChanges();

            return this.Ok(bugFromDb);
        }

        [HttpGet]
        public int Count()
        {
            return this.BugLoggerData.Bugs.All().Count();
        }
    }
}