using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void InitalizeEmptyTest()
        {
            LinkedList<int> ints = new LinkedList<int>();
            Assert.AreEqual(0, ints.Count);
        }

        [TestMethod]
        public void AddHeadTest()
        {
            LinkedList<int> ints = new LinkedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                ints.AddHead(i);
                Assert.AreEqual(i, ints.Count);
            }

            int expected = 5;
            foreach (int x in ints)
            {
                Assert.AreEqual(expected--, x);
            }
        }

        [TestMethod]
        public void AddTailTest()
        {
            LinkedList<int> ints = new LinkedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                ints.AddTail(i);
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
            LinkedList<int> delete1to10 = create(1, 10);
            Assert.AreEqual(10, delete1to10.Count);

            for (int i = 1; i <= 10; i++)
            {
                Assert.IsTrue(delete1to10.Remove(i));
                Assert.IsFalse(delete1to10.Remove(i));
            }

            Assert.AreEqual(0, delete1to10.Count);

            LinkedList<int> delete10to1 = create(1, 10);
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
            LinkedList<int> ints = create(1, 10);
            for (int i = 1; i <= 10; i++)
            {
                Assert.IsTrue(ints.Contains(i));
            }

            Assert.IsFalse(ints.Contains(0));
            Assert.IsFalse(ints.Contains(11));
        }

        private LinkedList<int> create(int start, int end)
        {
            LinkedList<int> ints = new LinkedList<int>();
            for (int i = start; i <= end; i++)
            {
                ints.AddTail(i);
            }

            return ints;
        }
    }
}
