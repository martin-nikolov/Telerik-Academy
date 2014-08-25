namespace AbstractDataStructures.Tests
{
    using System;
    using System.Linq;
    using AbstractDataStructures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HashSetTest
    {
        [TestMethod]
        public void TestAddMethod()
        {
            var hashSet = new HashSet<int>();
            Assert.IsTrue(hashSet.Add(1));
            Assert.IsTrue(hashSet.Add(2));
            Assert.IsFalse(hashSet.Add(2));
            Assert.AreEqual(2, hashSet.Count);
        }

        [TestMethod]
        public void TestUnionMethod()
        {
            var hashSet = new HashSet<int>();

            Assert.IsTrue(hashSet.Add(1));
            Assert.IsTrue(hashSet.Add(2));
            Assert.AreEqual(2, hashSet.Count);

            int[] unionArray = { 2, 3, 4, 5 };
            hashSet.UnionWith(unionArray);

            Assert.AreEqual(5, hashSet.Count);
            CollectionAssert.AreEqual(hashSet.Keys.ToList(), new System.Collections.Generic.List<int>() { 1, 2, 3, 4, 5 });
        }

        [TestMethod]
        public void TestIntersectMethod()
        {
            var hashSet = new HashSet<int>();

            Assert.IsTrue(hashSet.Add(1));
            Assert.IsTrue(hashSet.Add(2));
            Assert.IsTrue(hashSet.Add(3));
            Assert.IsTrue(hashSet.Add(4));
            Assert.AreEqual(4, hashSet.Count);

            int[] intersectArray = { 2, 3 };
            hashSet.IntersectWith(intersectArray);

            Assert.AreEqual(2, hashSet.Count);
            CollectionAssert.AreEqual(hashSet.Keys.ToList(), new System.Collections.Generic.List<int>() { 2, 3 });
        }

        [TestMethod]
        public void TestCountMethod()
        {
            var hashSet = new HashSet<int>();

            Assert.IsTrue(hashSet.Add(1));
            Assert.IsTrue(hashSet.Add(2));
            Assert.IsFalse(hashSet.Add(2));
            Assert.IsTrue(hashSet.Add(4));

            Assert.AreEqual(3, hashSet.Count);
        }

        [TestMethod]
        public void TestContainsMethod()
        {
            var hashSet = new HashSet<int>();
            Assert.IsTrue(hashSet.Add(1));
            Assert.IsTrue(hashSet.Add(2));
            Assert.IsTrue(hashSet.Add(3));
            Assert.IsTrue(hashSet.Add(4));
            Assert.AreEqual(4, hashSet.Count);

            Assert.IsTrue(hashSet.Contains(3));
            Assert.IsTrue(hashSet.Contains(4));

            Assert.IsFalse(hashSet.Contains(-5));
            Assert.IsFalse(hashSet.Contains(14));  
        }

        [TestMethod]
        public void TestRemoveMethod()
        {
            var hashSet = new HashSet<int>();
            Assert.IsTrue(hashSet.Add(1));
            Assert.IsTrue(hashSet.Add(2));
            Assert.IsTrue(hashSet.Add(3));
            Assert.IsTrue(hashSet.Add(4));
            Assert.AreEqual(4, hashSet.Count);

            Assert.IsTrue(hashSet.Remove(3));
            Assert.IsTrue(hashSet.Remove(4));
                            
            Assert.IsFalse(hashSet.Remove(-5));
            Assert.IsFalse(hashSet.Remove(14));
        }

        [TestMethod]
        public void TestClearMethod()
        {
            var hashSet = new HashSet<int>();
            Assert.IsTrue(hashSet.Add(1));
            Assert.IsTrue(hashSet.Add(2));
            Assert.IsTrue(hashSet.Add(3));
            Assert.IsTrue(hashSet.Add(4));

            Assert.AreEqual(4, hashSet.Count);
            hashSet.Clear();
            Assert.AreEqual(0, hashSet.Count);

            Assert.IsFalse(hashSet.Contains(1));
            Assert.IsFalse(hashSet.Contains(2));
            Assert.IsTrue(hashSet.Add(3));
            Assert.IsTrue(hashSet.Add(4));
        }

        [TestMethod]
        public void TestGetEnumerator()
        {
            var hashSet = new HashSet<int>();
            Assert.IsTrue(hashSet.Add(1));
            Assert.IsTrue(hashSet.Add(2));
            Assert.IsTrue(hashSet.Add(3));
            Assert.IsTrue(hashSet.Add(4));

            var collection = new System.Collections.Generic.List<int>();

            foreach (var item in hashSet.Keys)
            {
                collection.Add(item);
            }

            Assert.AreEqual(collection.Count, hashSet.Keys.Count());
            CollectionAssert.AreEqual(collection.OrderBy(a => a).ToList(), hashSet.Keys.OrderBy(a => a).ToList());
        }
    }
}