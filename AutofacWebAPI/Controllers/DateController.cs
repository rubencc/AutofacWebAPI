namespace AutofacWebAPI.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Infraestructure.IoC.Interfaces;

    [RoutePrefix("api/date")]
    public class DateController : ApiController
    {
        private readonly ITest test;
        private readonly IFactory factory;

        public DateController(ITest test, IFactory factory)
        {
            this.test = test;
            this.factory = factory;
        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetDate()
        {
            

            ITest test2 = this.factory.Resolve<ITest>();

            await Task.CompletedTask.ConfigureAwait(false);
            return Ok(DateTime.Now);
        }
    }
}
