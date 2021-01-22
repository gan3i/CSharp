using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void Queue_EnqueueDequeue1to10()
        {
            Queue<int> queue = new Queue<int>();

            for(int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            Assert.AreEqual(10, queue.Count);

            for(int expected = 0; expected < 10; expected++)
            {
                Assert.AreEqual(expected, queue.Peek());
                Assert.AreEqual(expected, queue.Dequeue());
            }

            Assert.AreEqual(0, queue.Count);
        }
    }
}
