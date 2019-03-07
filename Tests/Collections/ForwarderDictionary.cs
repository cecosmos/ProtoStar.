using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProtoStar.Core.Collections
{
    public class ForwarderDictionary
    {
        [Fact]
        public  void AddElement()
        {
            var dictionary = new Dictionary<int, string>()
            {
                { 1,"one" },
                { 2, "two" },
                { 3, "three" }
            };

            bool hitAdd = false;
            bool hitRemove = false;

            var forwarderDictionary = new ForwarderDictionary<int, string>(
                (int key,out string value) =>  dictionary.TryGetValue(key, out value),
                () => dictionary.Keys,
                (key, value) => { hitAdd = true; dictionary[key] = value; },
                (key) => { hitRemove = true; return dictionary.Remove(key); }                );

            Assert.Equal(dictionary, forwarderDictionary);
            Assert.False(hitAdd);
            Assert.False(hitRemove);

            forwarderDictionary.Add(4, "four");

            Assert.Equal(dictionary, forwarderDictionary);
            Assert.True(hitAdd);
            Assert.False(hitRemove);

        }

        [Fact]
        public void RemoveElement()
        {
            var dictionary = new Dictionary<int, string>()
            {
                { 1,"one" },
                { 2, "two" },
                { 3, "three" }
            };

            bool hitAdd = false;
            bool hitRemove = false;

            var forwarderDictionary = new ForwarderDictionary<int, string>(
                (int key, out string value) => dictionary.TryGetValue(key, out value),
                () => dictionary.Keys,
                (key, value) => { hitAdd = true; dictionary[key] = value; },
                (key) => { hitRemove = true; return dictionary.Remove(key); });

            Assert.Equal(dictionary, forwarderDictionary);
            Assert.False(hitAdd);
            Assert.False(hitRemove);

            forwarderDictionary.Remove(3);

            Assert.Equal(dictionary, forwarderDictionary);
            Assert.False(hitAdd);
            Assert.True(hitRemove);

            hitRemove=false;
            forwarderDictionary.Remove(new KeyValuePair<int,string>(1,"one"));
            Assert.True(hitRemove);
        }

        [Fact]
        public void AddRemoveElement()
        {
            var dictionary = new Dictionary<int, string>()
            {
                { 1,"one" },
                { 2, "two" },
                { 3, "three" }
            };

            var (hitAdd, hitRemove) = (false, false);

            var forwarderDictionary = new ForwarderDictionary<int, string>(
                (int key, out string value) => dictionary.TryGetValue(key, out value),
                () => dictionary.Keys,
                (key, value) => { hitAdd = true; dictionary[key] = value; },
                (key) => { hitRemove = true; return dictionary.Remove(key); }                );

            Assert.False(hitAdd);
            Assert.False(hitRemove);

            forwarderDictionary.Add(4, "four");

            Assert.Equal(dictionary, forwarderDictionary);
            Assert.True(hitAdd);
            Assert.False(hitRemove);

            (hitAdd, hitRemove) = (false, false);

            forwarderDictionary.Remove(3);

            Assert.Equal(dictionary, forwarderDictionary);
            Assert.False(hitAdd);
            Assert.True(hitRemove);

        }


        [Fact]
        public void TestName()
        {
            var dictionary = new Dictionary<int, string>()
                {
                    { 1,"one" },
                    { 2, "two" },
                    { 3, "three" }
                };

            var forwarderDictionary = new ForwarderDictionary<int, string>(
                dictionary.TryGetValue,
                () => dictionary.Keys,
                (key, value) =>  dictionary[key] = value,
                (key) => dictionary.Remove(key));
                
            Assert.Throws<KeyNotFoundException>(()=> forwarderDictionary[4]);
        }

    }
}
