namespace Infraestructure.Repository.Mongo
{
    using Autofac;
    using Infraestructure.IoC.Interfaces;

    public class Initializer : IConfigIoC
    {
        public void Configure(ContainerBuilder container)
        {
            container.RegisterType<MongoContext>().As<IMongoContext>();
        }
    }
}
