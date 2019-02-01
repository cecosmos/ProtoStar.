using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProtoStar.Core.Collections
{
    
    public class ForwarderCollection
    {
        [Fact]
        public void AddRemoveElement()
        {
            IList<int> baseCollection = new List<int>(new[] { 2, 3, 4 });
            bool hitAdd = false;
            bool hitRemove = false;
            var forwardedCollection = new ForwarderCollection<int>(
                () => baseCollection,
                x => { hitAdd = true; baseCollection.Add(x); },                
                x => { hitRemove = true; return baseCollection.Remove(x); });

            Assert.Equal(baseCollection, forwardedCollection);
            Assert.False(hitAdd);
            Assert.False(hitRemove);
            
            forwardedCollection.Add(5);
            Assert.Equal(baseCollection, forwardedCollection);
            Assert.True(hitAdd);
            Assert.False(hitRemove);
            
            hitRemove = false;
            hitAdd = false;
            forwardedCollection.Remove(2);
            
            Assert.Equal(baseCollection, forwardedCollection);
            Assert.False(hitAdd);
            Assert.True(hitRemove);
        }

        [Fact]
        public void AddElement()
        {
            IList<int> baseCollection = new List<int>(new[] { 2, 3, 4 });
            bool hitAdd = false;
            bool hitRemove = false;
            var forwardedCollection = new ForwarderCollection<int>(
                () => baseCollection,
                x => { hitAdd = true; baseCollection.Add(x); },                
                x => { hitRemove = true; return baseCollection.Remove(x); });

            Assert.Equal(baseCollection, forwardedCollection);
            Assert.False(hitAdd);
            Assert.False(hitRemove);

            forwardedCollection.Add(5);
            Assert.Equal(baseCollection, forwardedCollection);
            Assert.True(hitAdd);
            Assert.False(hitRemove);
        }

        [Fact]
        public void RemoveElement()
        {
            IList<int> baseCollection = new List<int>(new[] { 2, 3, 4 });
            bool hitAdd = false;
            bool hitRemove = false;
            var forwardedCollection = new ForwarderCollection<int>(
                () => baseCollection,
                x => { hitAdd = true; baseCollection.Add(x); },                
                x => { hitRemove = true; return baseCollection.Remove(x); });

            forwardedCollection.Remove(2);

            Assert.Equal(baseCollection, forwardedCollection);
            Assert.False(hitAdd);
            Assert.True(hitRemove);
        }

    }
}
