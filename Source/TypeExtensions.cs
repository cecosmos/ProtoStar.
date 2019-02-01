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
                null :
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
            var interfaceTypes = givenType.GetInterfaces();
            foreach (var it in interfaceTypes) { if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType) return true; }
            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType) return true;
            Type baseType = givenType.BaseType;
            if (baseType == typeof(object)) return false;
            return IsAssignableToGenericType(baseType, genericType);
        }

        public static IEnumerable<Type> GetCurrentDomainTypes()=>
            AppDomain.CurrentDomain.GetAssemblies().
            Where(assembly=> !assembly.IsDynamic).
            SelectMany(assembly=> assembly.GetTypes());
        
        #endregion Public Methods
    }
}