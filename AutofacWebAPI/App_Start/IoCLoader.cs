namespace AutofacWebAPI
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Autofac;
    using Infraestructure.IoC.Interfaces;

    public static class IoCLoader
    {
        public static void LoadAssemblies(ContainerBuilder container)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {


                foreach (Type item in assembly.GetTypes())
                {
                    if (!item.IsClass)
                        continue;

                    if (item.IsAbstract)
                        continue;

                    if (item.GetInterfaces().Contains(typeof(IConfigIoC)))
                    {
                        Type[] argTypes = new Type[] { };
                        ConstructorInfo cInfo = item.GetConstructor(argTypes);
                        if (cInfo == null)
                            continue;

                        var config = (IConfigIoC)cInfo.Invoke(new object[] { });
                        config.Configure(container);
                    }
                }
            }
        }
    }
}