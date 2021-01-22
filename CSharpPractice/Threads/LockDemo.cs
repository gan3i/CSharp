using System;

using System.Threading;

namespace Threads
{
    public static class LockDemo
    {
        private static object _object = new object();
        public static void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadStart start = new ThreadStart(TestLock);
                new Thread(start).Start();
            }
        }

        private static void TestLock()
        {
            lock (_object)
            {
                Thread.Sleep(1000);
                Console.WriteLine(Environment.TickCount);
            }
        }
    }
}
