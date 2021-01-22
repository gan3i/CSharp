using System;
using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests
{
    [TestClass]
    public class StackTests_List
    {
        [TestMethod]
        public void Stack_Success_Cases()
        {
            foreach (int[] testData in GetTestData())
            {
                Stack<int> stack = new Stack<int>();

                for (int i = 0; i < testData.Length; i++)
                {
                    Assert.AreEqual(stack.Count, i, "The stack count is off");

                    stack.Push(testData[i]);

                    Assert.AreEqual(stack.Count, i + 1, "The stack count is off");

                    Assert.AreEqual(testData[i], stack.Peek(), "The recently pushed value is not peeking");
                }

                Assert.AreEqual(testData.Length, stack.Count, "The end count was not as expected");

                for (int i = testData.Length - 1; i >= 0; i--)
                {
                    int expected = testData[i];
                    Assert.AreEqual(expected, stack.Peek(), "The peeked value was not expected");
                    Assert.AreEqual(expected, stack.Pop(), "The popped value was not expected");
                    Assert.AreEqual(i, stack.Count, "The popped value was not expected");
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_From_Empty_Throws()
        {
            Stack<int> s = new Stack<int>();
            s.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_From_Empty_Throws_After_Push()
        {
            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Pop();
            s.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_From_Empty_Throws()
        {
            Stack<int> s = new Stack<int>();
            s.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_From_Empty_Throws_After_Push()
        {
            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Pop();
            s.Peek();
        }


        private object[] GetTestData()
        {
            object[] Push_TestData = new[]
                                     {
                                     new int[0],
                                     new [] { 0 },
                                     new [] { 0, 1 },
                                     new [] { 0, 1, 2 },
                                     new [] { 0, 1, 2, 3 },
                                     new [] { 0, 1, 2, 3, 4 },
                                 };

            return Push_TestData;
        }
    }
}
