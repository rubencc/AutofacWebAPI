namespace Infraestructure.IoC.Implementation
{
    using Autofac;
    using Infraestructure.IoC.Interfaces;

    public class Initializer : IConfigIoC
    {
        public void Configure(ContainerBuilder container)
        {
            container.RegisterType<DependencyResolver>();
            container.RegisterType<Factory>().As<IFactory>();
        }
    }
}
