using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads
{
    public static class MonitorDemo
    {
        static readonly object _object = new object();

        private static void PrintNumbers()
        {
            Monitor.Enter(_object);
                for (int i = 0; i <5; i++)
            {
                Thread.Sleep(1000);
                Console.Write(i);
            }
            Console.WriteLine();
            Monitor.Exit(_object);
        }
        public static void Run()
        {
            Thread[] threads = new Thread[3];
            for (int i =0; i < 3; i++)
            {
                threads[i] = new Thread(new ThreadStart(PrintNumbers));
                threads[i].Name = "Thread" + i;
            }
            foreach(Thread t in threads)
            {
                t.Start();
            }
            Console.ReadLine();
             
        }

    }
}
