namespace Domain.Repository.Implementation
{
    using System;
    using Infraestructure.Repository.Mongo;

    public class DefaultRepository: MongoRepository<DefaultEntity, Guid>
    {
        public DefaultRepository(IMongoContext context) : base(context)
        {
        }
    }
}
