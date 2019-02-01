// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

using System;
using System.Collections.Generic;
using ProtoStar.Core.Collections;

namespace System.Linq
{
    public static class NormalizedDictionaryExtensions
    {
        public static NormalizedDictionary<TOut> ToNormalizedDictionary<TIn,TOut>(
            this IEnumerable<TIn> source,
            Func<TIn,TOut> keySelector,
            Func<TIn,double> valueSelector)
        {
            var result = new NormalizedDictionary<TOut>();
            foreach(var item in source)
            {
                result.Add(keySelector(item), valueSelector(item));
            }
            return result;
        }
    }
}
