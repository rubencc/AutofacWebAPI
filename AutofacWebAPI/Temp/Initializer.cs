namespace AutofacWebAPI.Temp
{
    using Autofac;
    using Infraestructure.IoC.Interfaces;

    public class Initializer : IConfigIoC
    {
        public void Configure(ContainerBuilder container)
        {
            container.RegisterType<Test>().As<ITest>();
        }
    }
}