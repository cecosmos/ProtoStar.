using System.Collections.ObjectModel;
// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using ProtoStar.Core.Collections;

namespace ProtoStar.Core.Linq
{
    public static class EnumerableExtensions
    {
        #region Public Methods

        public static bool TryFind<T>(this IEnumerable<T> source, System.Predicate<T> predicate, out T match)
        {
            foreach (T item in source) { if (predicate(item)) { match = item; return true; } }
            match = default(T); return false;
        }

        public static IEnumerable<T> Interleave<T>(this IEnumerable<T> source, IEnumerable<T> second) =>
            source.Zip(second, (l, r) => new[] { l, r }).SelectMany(x => x);

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, System.Predicate<T> predicate, bool inclusive)
        {
            foreach(var item in source)
            {
                if (predicate(item)) yield return item;
                else
                {
                    if (inclusive) yield return item;
                    yield break;
                }
            }
        }

        public static IReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source as IReadOnlyCollection<T> ?? new CollectionAdapter<T>(()=>source);
        }

        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, System.Predicate<T> predicate, bool inclusive) =>
            source.TakeWhile(item => !predicate(item), inclusive);

        #endregion Public Methods
    }
}