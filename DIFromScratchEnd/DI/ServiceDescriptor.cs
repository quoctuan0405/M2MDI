using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFromScratchEnd.DI
{
    public class ServiceDescriptor
    {
        public Type ServiceType { get; set; }

        public object Implementation { get; set; }

        public ServiceLifeTime LifeTime { get; }

        public ServiceDescriptor(object implementation, ServiceLifeTime lifetime)
        {
            ServiceType = implementation.GetType();
            Implementation = implementation;   
            LifeTime = lifetime;
        }

        public ServiceDescriptor(Type type, ServiceLifeTime lifeTime)
        {
            ServiceType = type;
            LifeTime = lifeTime;    
        }
    }
}
