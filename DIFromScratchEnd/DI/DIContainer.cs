using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFromScratchEnd.DI
{
    public class DIContainer
    {
        private Dictionary<Type, ServiceDescriptor> _serviceDescriptorDictionary = new Dictionary<Type, ServiceDescriptor>();
        private Dictionary<Type, ServiceDescriptor> _scopeDescriptorDictionary = new Dictionary<Type, ServiceDescriptor>();

        public DIContainer(List<ServiceDescriptor> serviceDescriptors, List<ServiceDescriptor> scopeDescriptors)
        {
            foreach(ServiceDescriptor serviceDescriptor in serviceDescriptors)
            {
                _serviceDescriptorDictionary[serviceDescriptor.ServiceType] = serviceDescriptor;
            }

            foreach (ServiceDescriptor serviceDescriptor in scopeDescriptors)
            {
                _scopeDescriptorDictionary[serviceDescriptor.ServiceType] = serviceDescriptor;
            }
        }

        public ScopeProvider CreateScope()
        {
            return new ScopeProvider(_serviceDescriptorDictionary, _scopeDescriptorDictionary);
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        private object GetService(Type serviceType)
        {
            // Get service descriptor
            ServiceDescriptor serviceDescriptor;

            if (_serviceDescriptorDictionary.ContainsKey(serviceType))
            {
                serviceDescriptor = _serviceDescriptorDictionary[serviceType];
            } else
            {
                throw new Exception("Service is not registered");
            }


            // Return implementation
            switch (serviceDescriptor.LifeTime)
            {
                case ServiceLifeTime.Singleton:
                    if (serviceDescriptor.Implementation == null)
                    {
                        InstatiateImplementation(serviceDescriptor);

                        serviceDescriptor.Implementation = InstatiateImplementation(serviceDescriptor);
                    }

                    return serviceDescriptor.Implementation;

                case ServiceLifeTime.Scope:
                    if (serviceDescriptor.Implementation == null)
                    {
                        InstatiateImplementation(serviceDescriptor);

                        serviceDescriptor.Implementation = InstatiateImplementation(serviceDescriptor);
                    }

                    return serviceDescriptor.Implementation;

                case ServiceLifeTime.Transient:
                    var implementation = InstatiateImplementation(serviceDescriptor);

                    return implementation;
            }

            throw new Exception("Cannot get scoped object outside scope provider");
        }

        private object InstatiateImplementation(ServiceDescriptor serviceDescriptor)
        {
            var constructorInfo = serviceDescriptor.ServiceType.GetConstructors().First();

            var parameters = constructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray();

            return constructorInfo.Invoke(parameters);
        }
    }
}
