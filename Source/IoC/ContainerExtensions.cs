// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

using System.Linq;
using System;

namespace ProtoStar.Core.IoC
{
    public static class ContainerExtensions
    {
        public static void SolveDependencies(this IContainer container, object dependent)
        {
            var genericIDependent = typeof(IDependent<>);
            var dependencies = dependent.GetType().
                GetGenericArgumentsForBaseType(genericIDependent).
                Select(t => t.First());
            foreach(var t in dependencies)
            {
                var dependencyTypeResolver = genericIDependent.MakeGenericType(t);
                var targetInjectionProperty = dependencyTypeResolver.GetProperties().First();
                var containerResolved = container.Resolve(t);
                targetInjectionProperty.SetValue(dependent, containerResolved);
            }
        }
    }
}
