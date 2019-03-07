// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

using System.Collections.Generic;
using System;

namespace ProtoStar.Core.Linq
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Adds an element with the provided key and value to the 
        /// <see cref="IDictionary{TKey, TValue}"/> with a first value win premise.
        /// </summary>
        /// <typeparam name="TKey">The type of the dictionary keys.</typeparam>
        /// <typeparam name="TValue">The type of the dictionary values.</typeparam>
        /// <param name="source">A dictionary <see.</param>
        /// <param name="key">The object to use as the key of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        /// <returns>
        /// <c>true</c> when the value was added, <c>false</c> otherwise.
        /// </returns>
        public static bool TryAdd<TKey,TValue>(this IDictionary<TKey,TValue> source, TKey key, TValue value)
        {
            if (source.ContainsKey(key)) { return false; }
            source.Add(key, value);
            return true;
        }

        public static void AddRange<TKey,TValue>(this IDictionary<TKey,TValue> source, IEnumerable<KeyValuePair<TKey,TValue>> pairs)
        {
            foreach(var kv in pairs) source.Add(kv.Key, kv.Value);
        }

        public static void RemoveRange<TKey,TValue>(this IDictionary<TKey,TValue> source, IEnumerable<TKey> keys)
        {
            foreach(var k in keys) source.Remove(k);
        }

    }
}
