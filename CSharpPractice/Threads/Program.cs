using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            MonitorDemo monObj = new MonitorDemo();
            monObj.Run();
            var obj = new LockDemo();
            obj.Run();
        }

    }
}
