namespace Infraestructure.IoC.Interfaces
{
    using Autofac;

    public interface IConfigIoC
    {
        void Configure(ContainerBuilder container);
    }
}
