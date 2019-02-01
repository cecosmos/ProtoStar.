using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace ProtoStar.Core.Linq
{
    public class DictionaryExtensions
    {
        [Fact]
        public void TryAddCanAdd()
        {
            var dictionary = new Dictionary<int, string>() { { 1, "one" }, { 2, "two" }, { 3, "three" } };
            dictionary.TryAdd(4, "four");
            Assert.Contains(4, dictionary.Keys);
            Assert.Equal("four", dictionary[4]);
        }

        [Fact]
        public void TryAddWontUpdate()
        {
            var dictionary = new Dictionary<int, string>() { { 1, "one" }, { 2, "two" }, { 3, "three" } };
            dictionary.TryAdd(3, "four");
            Assert.Equal("three", dictionary[3]);
        }

        [Fact]
        public void TryAddTrueOnAdd()
        {
            var dictionary = new Dictionary<int, string>() { { 1, "one" }, { 2, "two" }, { 3, "three" } };
            Assert.True(dictionary.TryAdd(4, "four"));
        }

        [Fact]
        public void TryAddFalseOnAvoidUpdate()
        {
            var dictionary = new Dictionary<int, string>() { { 1, "one" }, { 2, "two" }, { 3, "three" } };
            Assert.False(dictionary.TryAdd(3, "three"));
        }
    }
}
