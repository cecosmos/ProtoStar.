// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels


using System;
using System.Collections.Generic;
using ProtoStar.Core;
using System.Linq;

namespace ProtoStar.Core.IoC
{
    public class Container<T> :
        IContainer<T>
    {
        private readonly Dictionary<Type, Func<T>> resolvers = new Dictionary<Type, Func<T>>();

        private T ResolveType(Type abstractType)
        {
            if (!resolvers.TryGetValue(abstractType, out var result))
            {
                try
                {
                    var assignableAbstract = resolvers.Keys.First(t => abstractType.IsAssignableFrom(t));
                    result = resolvers[assignableAbstract];
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException($"There is not a registered nor assignable concrete type to {abstractType.FullName}.", ex);
                }
            }
            return result();
        }

        private void EnsureInheritance(Type baseType, Type derivedType, string derivedParameterName)
        {
            if (!baseType.IsAssignableFrom(derivedType))
                throw new ArgumentException($"The {derivedType.FullName} is not an inheritor of {baseType.FullName}.",derivedParameterName);
        }

        public void Register<TAbstract>(Func<TAbstract> concreteObject) where TAbstract : T =>
            resolvers[typeof(TAbstract)] = ()=> concreteObject();

        public TAbstract Resolve<TAbstract>() where TAbstract : T =>(TAbstract)ResolveType(typeof(TAbstract));

        void IContainer.Register(Type abstractType, Func<object> concreteType)
        {
            EnsureInheritance(typeof(T),abstractType,nameof(abstractType));
            EnsureInheritance(abstractType, concreteType().GetType(), nameof(concreteType));
            resolvers[abstractType] = ()=> (T)concreteType();
        }

        object IContainer.Resolve(Type abstractType) => ResolveType(abstractType);
    }
}
