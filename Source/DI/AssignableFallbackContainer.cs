// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

using System;
using System.Collections.Generic;
using ProtoStar.Core;
using System.Linq;
using System.ComponentModel.Design;

namespace ProtoStar.Core
{
    public class AssignableFallbackContainer :
        IServiceContainer
    {
        private readonly Dictionary<Type, Func<object>> resolvers = new Dictionary<Type, Func<object>>();

        public void AddService(Type serviceType, ServiceCreatorCallback callback)=>
            resolvers[serviceType] = ()=>callback(this,serviceType);
        

        public void AddService(Type serviceType, ServiceCreatorCallback callback, bool promote)=>
            AddService(serviceType,callback);

        public void AddService(Type serviceType, object serviceInstance)
        {
            serviceType.EnsureInheritance(serviceInstance.GetType());
            resolvers[serviceType] = ()=>serviceInstance;
        }

        public void AddService(Type serviceType, object serviceInstance, bool promote)=>
            AddService(serviceType,serviceInstance);

        public void RemoveService(Type serviceType)=>
            resolvers.Remove(serviceType);
        

        public void RemoveService(Type serviceType, bool promote)=>
            RemoveService(serviceType);

        public object GetService(Type serviceType)
        {
            if (!resolvers.TryGetValue(serviceType, out var result))
            {
                result = resolvers.TryFind(
                    keyValue=> serviceType.IsAssignableFrom(keyValue.Key),
                    out var service)?
                    service.Value:
                    ()=>null;
            }
            return result();
        }
    }
}
