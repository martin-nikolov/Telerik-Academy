namespace AbstractDataStructures.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AbstractDataStructures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void TestAddMethod()
        {
            var hashTable = new HashTable<int, int>();

            hashTable.Add(1, 2);
            hashTable[2] = 3;

            Assert.AreEqual(2, hashTable.Count);
        }

        [TestMethod]
        public void TestAddMethodShouldReplaceValues()
        {
            var hashTable = new HashTable<int, int>();

            hashTable.Add(1, 2);
            hashTable[2] = 3;

            Assert.AreEqual(2, hashTable.Count);

            hashTable.Add(1, 3);
            Assert.AreEqual(2, hashTable.Count);
            Assert.AreEqual(3, hashTable[1]);

            hashTable.Add(1, 4);
            Assert.AreEqual(2, hashTable.Count);
            Assert.AreEqual(4, hashTable[1]);
        }

        [TestMethod]
        public void TestGetValueMethod()
        {
            var hashTable = new HashTable<int, int>();

            hashTable.Add(1, 2);
            hashTable[2] = 3;

            Assert.AreEqual(2, hashTable.Count);
            
            Assert.AreEqual(2, hashTable[1]);
            Assert.AreEqual(2, hashTable.GetValue(1));

            Assert.AreEqual(3, hashTable[2]);
            Assert.AreEqual(3, hashTable.GetValue(2));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestGetValueMethodShouldThrowException()
        {
            var hashTable = new HashTable<int, int>();

            hashTable.Add(1, 2);
            hashTable[2] = 3;

            hashTable.GetValue(3);
        }

        [TestMethod]
        public void TestRemoveMethod()
        {
            var hashTable = new HashTable<int, int>();

            hashTable.Add(1, 2);
            hashTable[2] = 3;

            Assert.IsTrue(hashTable.Remove(2));
            Assert.IsFalse(hashTable.Remove(-1));
        }

        [TestMethod]
        public void TestExpandMethod()
        {
            var hashTable = new HashTable<int, int>();
            Assert.AreEqual(0, hashTable.Count);

            for (int i = 1; i <= 12; i++)
            {
                hashTable.Add(i, 12 - i + 1);
            }

            Assert.AreEqual(12, hashTable.Count);
        }

        [TestMethod]
        public void TestGetEnumerator()
        {
            var hashTable = new HashTable<int, int>();
            for (int i = 1; i <= 12; i++)
            {
                hashTable.Add(i, 12 - i + 1);
            }

            var collection = new List<KeyValuePair<int, int>>();

            foreach (var keyValuePair in hashTable)
            {
                var kv = new KeyValuePair<int, int>(keyValuePair.Key, keyValuePair.Value);
                collection.Add(kv);
            }

            Assert.AreEqual(collection.Count, hashTable.Count);

            foreach (var keyValuePair in hashTable)
            {
                Assert.IsTrue(collection.Contains(keyValuePair));
            }
        }
    }
}