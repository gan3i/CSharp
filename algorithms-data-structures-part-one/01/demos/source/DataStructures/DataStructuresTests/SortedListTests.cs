using System;
using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests
{
    [TestClass]
    public class SortedListTests
    {
        [TestMethod]
        public void InitalizeEmptyTest()
        {
            SortedList<int> ints = new SortedList<int>();
            Assert.AreEqual(0, ints.Count);
        }

        [TestMethod]
        public void AddTest()
        {
            SortedList<int> ints = new SortedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                ints.Add(i);
                Assert.AreEqual(i, ints.Count);
            }

            int expected = 1;
            foreach (int x in ints)
            {
                Assert.AreEqual(expected++, x);
            }
        }

        [TestMethod]
        public void RemoveTest()
        {
            SortedList<int> delete1to10 = create(1, 10);
            Assert.AreEqual(10, delete1to10.Count);

            for (int i = 1; i <= 10; i++)
            {
                Assert.IsTrue(delete1to10.Remove(i));
                Assert.IsFalse(delete1to10.Remove(i));
            }

            Assert.AreEqual(0, delete1to10.Count);

            SortedList<int> delete10to1 = create(1, 10);
            Assert.AreEqual(10, delete10to1.Count);

            for (int i = 10; i >= 1; i--)
            {
                Assert.IsTrue(delete10to1.Remove(i));
                Assert.IsFalse(delete10to1.Remove(i));
            }

            Assert.AreEqual(0, delete10to1.Count);
        }

        [TestMethod]
        public void ContainsTest()
        {
            SortedList<int> ints = create(1, 10);
            for (int i = 1; i <= 10; i++)
            {
                Assert.IsTrue(ints.Contains(i));
            }

            Assert.IsFalse(ints.Contains(0));
            Assert.IsFalse(ints.Contains(11));
        }

        [TestMethod]
        public void ReverseIteratorTest()
        {
            SortedList<int> ints = create(1, 10);
            int expected = 10;
            foreach(int actual in ints.GetReverseEnumerator())
            {
                Assert.AreEqual(expected--, actual);
            }
        }

        [TestMethod]
        public void RandomIsSorted()
        {
            SortedList<int> randoms = new SortedList<int>();
            Random rng = new Random();
            for(int i =0; i < 100; i++)
            {
                randoms.Add(rng.Next());
            }

            Assert.AreEqual(100, randoms.Count, "There should be 100");

            int prev = int.MinValue;
            foreach(int c in randoms)
            {
                Assert.IsTrue(prev <= c, "Sort order is wrong");
            }
        }

        private SortedList<int> create(int start, int end)
        {
            SortedList<int> ints = new SortedList<int>();
            for (int i = start; i <= end; i++)
            {
                ints.Add(i);
            }

            return ints;
        }
    }
}
