namespace Infraestructure.IoC.Implementation
{
    using System.Web.Http.Dependencies;
    using Autofac;

    public class DependencyResolver : ScopeContainer, IDependencyResolver
    {
        public DependencyResolver(ILifetimeScope container) : base(container)
        {
        }

        public IDependencyScope BeginScope()
        {
            var child =  this.container.BeginLifetimeScope("ChildContainer");
            return new ScopeContainer(child);
        }
    }
}
