using System.Diagnostics.CodeAnalysis;
// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

using System.Linq;
using System.Collections.Generic;
using System;

namespace ProtoStar.Core
{
    public static class TypeExtensions
    {
        #region Private Methods

        private static Type[] GetGenericArgumentsForBaseTypeClass(this Type givenType, Type genericType)=>
            givenType == typeof(object) ?
                Enumerable.Empty<Type>().ToArray() :
                ((givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType) ?
                    givenType.GetGenericArguments() :
                    givenType.BaseType.GetGenericArgumentsForBaseTypeClass(genericType));

        private static IEnumerable<Type[]> GetGenericArgumentsForBaseTypeInterface(this Type givenType, Type genericType) =>
            givenType.GetInterfaces().Where((t) => t.IsGenericType && t.GetGenericTypeDefinition() == genericType).Select(t=> t.GetGenericArguments());

        #endregion Private Methods

        #region Public Methods

        public static IEnumerable<Type[]> GetGenericArgumentsForBaseType(this Type givenType, Type genericType) =>
            genericType.IsInterface ?
            givenType.GetGenericArgumentsForBaseTypeInterface(genericType) :
            new[] { givenType.GetGenericArgumentsForBaseTypeClass(genericType) };

        public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
        {
            if(givenType == typeof(object)) return false;

            var ownTypeResult =
                genericType.IsInterface?
                givenType.IsAssignableToGenericInterface(genericType):
                (givenType.IsGenericType && givenType.GetGenericTypeDefinition()==genericType);

            return ownTypeResult || IsAssignableToGenericType(givenType.BaseType,genericType);
        }

        private static bool IsAssignableToGenericInterface(this Type givenType, Type genericType) =>
            givenType.GetInterfaces().
            Any(intType=> intType.IsGenericType && 
                          intType.GetGenericTypeDefinition()==genericType);

        [ExcludeFromCodeCoverage]
        public static IEnumerable<Type> GetCurrentDomainTypes()=>
            AppDomain.CurrentDomain.GetAssemblies().
            Where(assembly=> !assembly.IsDynamic).
            SelectMany(assembly=> assembly.GetTypes());
        
        #endregion Public Methods
    }
}