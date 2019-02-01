// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

using Xunit;

namespace ProtoStar.Core.Ranges
{
    public class Test
    {
        #region Public Methods

        [Theory]
        [InlineData(1, 3, 2, false)]
        [InlineData(2, 4, 1, false)]
        [InlineData(1, 5, 1, false)]
        [InlineData(1, 5, 5, false)]
        [InlineData(1, 3, 3.2, true)]
        [InlineData(-10, -3, -1, true)]
        public void IsAbove(double lower, double upper, double value, bool isInside) =>
            Assert.Equal(isInside, (new Range<double>() { Minimum = lower, Maximum = upper }).IsAbove(value));

        [Theory]
        [InlineData(1, 3, 0, true)]
        [InlineData(2, 4, 2, false)]
        [InlineData(1, 2, 0, true)]
        [InlineData(1, 5, 0, true)]
        [InlineData(1, 3, -1, true)]
        public void IsBellow(double lower, double upper, double value, bool isBellow) =>
            Assert.Equal(isBellow, (new Range<double>() { Minimum = lower, Maximum = upper }).IsBellow(value));

        [Theory]
        [InlineData(1, 3, 2, true)]
        [InlineData(2, 4, 1, false)]
        [InlineData(1, 5, 1, true)]
        [InlineData(1, 5, 5, true)]
        [InlineData(1, 3, 3.2, false)]
        public void IsInside(double lower, double upper, double value, bool isAbove) =>
            Assert.Equal(isAbove, (new Range<double>() { Minimum = lower, Maximum = upper }).IsInside(value));

        #endregion Public Methods
    }
}