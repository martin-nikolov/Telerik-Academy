namespace StudentSystem.Services.Controllers
{
    using System.Web.Http;
    using StudentSystem.Data;
    using StudentSystem.Data.Contracts;

    public class BaseController : ApiController
    {
        private readonly IStudentSystemData studentSystemData;
  
        public BaseController()
            : this(new StudentSystemData())
        {
        }

        public BaseController(IStudentSystemData studentSystemData)
        {
            this.studentSystemData = studentSystemData;
        }

        protected IStudentSystemData StudentSystemData
        {
            get
            {
                return this.studentSystemData;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.StudentSystemData.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}