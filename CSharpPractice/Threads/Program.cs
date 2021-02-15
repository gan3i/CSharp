using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            MonitorDemo.Run();
            //var obj = new LockDemo();
            //obj.Run();
            LockDemo.Run();
        }

    }
}
