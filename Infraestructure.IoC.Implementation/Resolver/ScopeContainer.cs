namespace Infraestructure.IoC.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;
    using Autofac;

    public class ScopeContainer : IDependencyScope
    {
        protected ILifetimeScope container;
        public bool IsDisposed { get; protected set; }


        public ScopeContainer(ILifetimeScope container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            this.container = container;
        }

        ~ScopeContainer()
        {
            this.Dispose(false);
        }


        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (this.IsDisposed)
            {
                return;
            }

            this.container?.Dispose();
            this.container = null;
            this.IsDisposed = true;
        }

        public object GetService(Type serviceType)
        {
            return this.container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.ResolveAll(serviceType);
        }

        private IEnumerable<T> ResolveAll<T>(T serviceType) where T : class
        {
            return this.container.Resolve<IEnumerable<T>>();
        }
    }
}
