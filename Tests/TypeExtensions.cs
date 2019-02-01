using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace ProtoStar.Core
{
    public class TypeExtensions
    {
        [Fact]
        public void CanAssignToGenericType()
        {
            var listIntType = typeof(List<int>);
            Assert.True(listIntType.IsAssignableToGenericType(typeof(IEnumerable<>)));
        }

        [Fact]
        public void MatchingGenericArgsInterface()
        {
            var listIntType = typeof(List<int>);
            Assert.Equal(typeof(int), listIntType.GetGenericArgumentsForBaseType(typeof(IEnumerable<>)).First().First());
        }

        [Fact]
        public void MatchingGenericArgsAbstractClass()
        {
            var listIntType = typeof(ListTInheritor<int>);
            Assert.Equal(typeof(int), listIntType.GetGenericArgumentsForBaseType(typeof(List<>)).First().First());
        }

        private class ListTInheritor<T> : List<T> { }

    }
}
