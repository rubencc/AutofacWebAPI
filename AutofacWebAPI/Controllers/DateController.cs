using Domain.Repository.Implementation;
using Infraestructure.Commons;
using Infraestructure.Repository.Interfaces;

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
        private readonly IRepository<DefaultEntity, Guid> repository;

        public DateController(ITest test, IFactory factory, IRepository<DefaultEntity, Guid> repository)
        {
            this.test = test;
            this.factory = factory;
            this.repository = repository;
        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetDate()
        {
            

            ITest test2 = this.factory.Resolve<ITest>();
            await this.repository.GetAllAsync().ConfigureAwaitFalse();
            await Task.CompletedTask.ConfigureAwait(false);
            return Ok(DateTime.Now);
        }
    }
}
