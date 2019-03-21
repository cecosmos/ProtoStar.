using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoStar.Core
{
    public static class ExceptionCheckingExtensions
    {
        public static T ThrowOnNull<T>(this T obj, string paramName = "")
            where T:class
        {
            if (obj == null) throw new ArgumentNullException(paramName);
            return obj;
        }

        public static void EnsureInheritance(this Type baseType, Type derivedType, string derivedParameterName = "")
        {
            if (!baseType.IsAssignableFrom(derivedType))
                throw new ArgumentException($"The {derivedType.FullName} is not an inheritor of {baseType.FullName}.",derivedParameterName);
        }

    }
}
