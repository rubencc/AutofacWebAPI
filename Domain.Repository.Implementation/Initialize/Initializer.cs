namespace Infraestructure.IoC.Implementation
{
    using Autofac;
    using Infraestructure.IoC.Interfaces;
    using System;
    using Domain.Repository.Implementation;
    using Infraestructure.Repository.Interfaces;

    public class Initializer : IConfigIoC
    {
        public void Configure(ContainerBuilder container)
        {
            container.RegisterType<DefaultRepository>().As<IRepository<DefaultEntity, Guid>>();
        }
    }
}
