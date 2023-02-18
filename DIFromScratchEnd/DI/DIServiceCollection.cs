using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFromScratchEnd.DI
{
    public class DIServiceCollection
    {
        private List<ServiceDescriptor> serviceDescriptors = new List<ServiceDescriptor>();
        private List<ServiceDescriptor> scopeDescriptors = new List<ServiceDescriptor>();

        public void AddSingleton<T>()
        {
            serviceDescriptors.Add(new ServiceDescriptor(typeof(T), ServiceLifeTime.Singleton));
        }

        public void AddTransient<T>()
        {
            serviceDescriptors.Add(new ServiceDescriptor(typeof(T), ServiceLifeTime.Transient));
        }

        public void AddScope<T>()
        {
            scopeDescriptors.Add(new ServiceDescriptor(typeof(T), ServiceLifeTime.Scope));
        }

        public DIContainer GenerateContainer()
        {
            return new DIContainer(serviceDescriptors, scopeDescriptors);
        }
    }
}
