using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFromScratchEnd.DI
{
    public class ScopeProvider : IDisposable
    {
        private Dictionary<Type, ServiceDescriptor> _serviceDescriptorDictionary = new Dictionary<Type, ServiceDescriptor>();
        private Dictionary<Type, ServiceDescriptor> _scopeDescriptorDictionary = new Dictionary<Type, ServiceDescriptor>();

        public ScopeProvider(Dictionary<Type, ServiceDescriptor> serviceDescriptorDictionary, Dictionary<Type, ServiceDescriptor> scopeDescriptors)
        {
            _serviceDescriptorDictionary = serviceDescriptorDictionary; 
            _scopeDescriptorDictionary = scopeDescriptors;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        private object GetService(Type serviceType)
        {
            // Get service descriptor
            ServiceDescriptor serviceDescriptor;
            if (_scopeDescriptorDictionary.ContainsKey(serviceType))
            {
                serviceDescriptor = _scopeDescriptorDictionary[serviceType];

            } else if (_serviceDescriptorDictionary.ContainsKey(serviceType))
            {
                serviceDescriptor = _serviceDescriptorDictionary[serviceType];
            }
            else
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

            throw new Exception("Undefined lifetime");
        }

        private object InstatiateImplementation(ServiceDescriptor serviceDescriptor)
        {
            var constructorInfo = serviceDescriptor.ServiceType.GetConstructors().First();

            var parameters = constructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray();

            return Activator.CreateInstance(serviceDescriptor.ServiceType, parameters);
        }

        public void Dispose()
        {
            foreach (ServiceDescriptor serviceDescriptor in _scopeDescriptorDictionary.Values)
            {
                if (serviceDescriptor.Implementation is IDisposable)
                {
                    ((IDisposable)serviceDescriptor.Implementation).Dispose();
                }

                serviceDescriptor.Implementation = null;
            }
        }
    }
}
