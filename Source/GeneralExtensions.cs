using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoStar.Core
{
    public static class GeneralExtensions
    {
        public static T ThrowOnNull<T>(this T obj, string paramName = "")
            where T:class
        {
            if (obj == null) throw new ArgumentNullException(paramName);
            return obj;
        }
    }
}
