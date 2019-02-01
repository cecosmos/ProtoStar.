using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace ProtoStar.Core.Linq
{
    public class EnumerableExtensions
    {

        private static readonly IEnumerable<int> BaseOddNumbersSource = new int[] { 1, 3, 5, 7, 9 };
        private static readonly IEnumerable<int> BaseEvenNumbersSource = new int[] { 2, 4, 6, 8, 10 };
        private static readonly Predicate<int> BasePredicate = (x) => x > 2;

        public static IEnumerable<object[]> Data =>
            new List<object[]>()
            {
                new object[] {BaseOddNumbersSource,BasePredicate, true, 3 },
                new object[] {BaseEvenNumbersSource, BasePredicate, true,4},
                new object[] {BaseOddNumbersSource, new Predicate<int>(x => x>10), false,0}                
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void TryFindMatches(IEnumerable<int> source, Predicate<int> predicate, bool shouldFind, int expectedMatchValue)
        {
            var found = source.TryFind(predicate, out var match);
            if (shouldFind) Assert.Equal(expectedMatchValue, match);
            Assert.Equal(shouldFind,found);
        }
    }
}
