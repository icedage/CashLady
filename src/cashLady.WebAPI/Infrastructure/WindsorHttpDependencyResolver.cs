using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;

namespace CashLady.WebAPI.Infrastructure
{
    
        internal sealed class WindsorHttpDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
        {
            private readonly IKernel kernel;

            public WindsorHttpDependencyResolver(IKernel kernel)
            {
                this.kernel = kernel;

            }

            public IDependencyScope BeginScope()
            {
                return new WindsorHttpDependencyResolver(kernel);
            }

            public object GetService(Type type)
            {
                return kernel.HasComponent(type) ? kernel.Resolve(type) : null;
            }

            public IEnumerable<object> GetServices(Type type)
            {
                return kernel.ResolveAll(type).Cast<object>();
            }

            public void Dispose()
            {
            }
        }
    
}