namespace RockBands.Services.Controllers
{
    using System.Web.Http;
    using RockBands.Data;
    using RockBands.Data.Contracts;

    public class BaseController : ApiController
    {
        private IRockBandsData rockBandsData;

        public BaseController()
            : this(new RockBandsData())
        {
        }

        public BaseController(IRockBandsData rockBandsData)
        {
            this.rockBandsData = rockBandsData;
        }

        protected IRockBandsData RockBandsData
        {
            get
            {
                return this.rockBandsData;
            }
            set
            {
                this.rockBandsData = value;
            }
        }
    }
}