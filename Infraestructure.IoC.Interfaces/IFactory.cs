namespace Infraestructure.IoC.Interfaces
{
    using System;

    public interface IFactory : IDisposable
    {
        T Resolve<T>();
    }
}
