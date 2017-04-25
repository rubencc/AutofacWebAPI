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
        private readonly IRepository<IDefaultEntity, Guid> repository;

        public DateController(ITest test, IFactory factory, IRepository<IDefaultEntity, Guid> repository)
        {
            this.test = test;
            this.factory = factory;
            this.repository = repository;
        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetDate()
        {


            IDefaultEntity entity = this.factory.Resolve<IDefaultEntity>();
            entity.Name = "name";
            entity.Id = Guid.NewGuid();
            await this.repository.AddAsync(entity).ConfigureAwaitFalse();
            await Task.CompletedTask.ConfigureAwait(false);
            return Ok(DateTime.Now);
        }
    }
}
