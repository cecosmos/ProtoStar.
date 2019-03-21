using Xunit;
using System;
using ProtoStar.Core;

namespace ProtoStar.Core.Tests
{
    public class ExceptionCheckingExtensions
    {
        [Fact]
        public void ThrowsWhenNull()
        {
            object arg = null;
            Assert.Throws<ArgumentNullException>(()=> arg.ThrowOnNull(nameof(arg)));
        }

        [Fact]
        public void ReturnSelf()
        {
            var arg = new object();
            Assert.Equal(arg,arg.ThrowOnNull());
        }
    }
}