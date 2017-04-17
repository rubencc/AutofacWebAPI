namespace AutofacWebAPI.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;


    [RoutePrefix("api/date")]
    public class DateController : ApiController
    {
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetDate()
        {
            await Task.CompletedTask.ConfigureAwait(false);
            return Ok(DateTime.Now);
        }
    }
}
