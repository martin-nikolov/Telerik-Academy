namespace TicTacToe.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using TicTacToe.Data.Contracts;

    public abstract class BaseApiController : ApiController
    {
        private ITicTacToeData data;

        public BaseApiController(ITicTacToeData data)
        {
            this.Data = data;
        }

        protected ITicTacToeData Data
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