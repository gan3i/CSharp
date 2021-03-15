using System;

using System.Threading;

namespace Threads
{
    public class LockDemo
    {
        private  object _object = new object();
        public  void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadStart start =new ThreadStart(TestLock);
                var thread = new Thread(start);
                thread.Start();
            }
        }

        private  void TestLock()
        {
            lock (_object)
            {
                Thread.Sleep(1000);
                Console.WriteLine(Environment.TickCount);
            }
        }
    }
}
