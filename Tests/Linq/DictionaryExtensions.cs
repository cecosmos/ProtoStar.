using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace ProtoStar.Core.Linq
{
    public class DictionaryExtensionsUT
    {
        [Fact]
        public void CanAdd()
        {
            IDictionary<int,string> dictionary = new Dictionary<int, string>() { { 1, "one" }, { 2, "two" }, { 3, "three" } };
            dictionary.TryAdd(4, "four");
            Assert.Equal("four", dictionary[4]);
        }

        [Fact]
        public void WontUpdateOnExisting()
        {
            IDictionary<int,string>  dictionary = new Dictionary<int, string>() { { 1, "one" }, { 2, "two" }, { 3, "three" } };
            dictionary.TryAdd(3, "four");
            Assert.Equal("three", dictionary[3]);
        }

        [Fact]
        public void TrueOnAdd()
        {
            IDictionary<int,string>  dictionary = new Dictionary<int, string>() { { 1, "one" }, { 2, "two" }, { 3, "three" } };
            Assert.True(dictionary.TryAdd(4, "four"));
        }

        [Fact]
        public void FalseOnAvoidUpdate()
        {
            IDictionary<int,string>  dictionary = new Dictionary<int, string>() { { 1, "one" }, { 2, "two" }, { 3, "three" } };
            Assert.False(dictionary.TryAdd(3, "three"));
        }
    }
}
