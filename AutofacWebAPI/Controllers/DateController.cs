namespace AutofacWebAPI.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;


    [RoutePrefix("api/date")]
    public class DateController : ApiController
    {
        private readonly ITest test;

        public DateController(ITest test)
        {
            this.test = test;
        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetDate()
        {
            test.Nada();
            
            await Task.CompletedTask.ConfigureAwait(false);
            return Ok(DateTime.Now);
        }
    }
}
